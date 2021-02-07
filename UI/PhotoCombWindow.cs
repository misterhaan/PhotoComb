using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using au.Applications.PhotoComb.Logic.Types;
using au.Applications.PhotoComb.Settings.Types;
using au.IO.Files.Camera.Types;
using au.IO.Files.FileOperation;
using au.UI.LatestVersion;

namespace au.Applications.PhotoComb.UI {
	/// <summary>
	/// Main Photo Combine form.  Lists files in the directory with current name
	/// and what it will be changed to and allows tweaking and then renaming or
	/// copying with new filenames.
	/// </summary>
	public partial class PhotoCombWindow : Form {
		/// <summary>
		/// Settings are mostly values that persist when the application is closed
		/// and reopened.
		/// </summary>
		private readonly IPhotoCombSettings _settings;

		/// <summary>
		/// Update checker.
		/// </summary>
		private readonly VersionManager _versionManager;

		/// <summary>
		/// Collection of camera files the application is currently working with.
		/// </summary>
		private readonly ICameraFileCollection _files;

		#region initialization
		/// <summary>
		/// Create a new Photo Combine main form.
		/// </summary>
		public PhotoCombWindow(IPhotoCombSettings settings, VersionManager versionManager, ICameraFileCollection fileCollection) {
			_settings = settings;
			_versionManager = versionManager;
			_files = fileCollection;
			InitializeComponent();
			// these icons must match up with CameraFileType (same number and order)
			_il.Images.Add(MaterialIcons.File16);
			_il.Images.Add(MaterialIcons.Photo16);
			_il.Images.Add(MaterialIcons.Video16);
		}

		/// <summary>
		/// Actions when the form loads (before it's displayed)
		/// </summary>
		/// <param name="sender">not used</param>
		/// <param name="e">not used</param>
		private void PhotoComb_Load(object sender, EventArgs e) {
			if(_settings.MainForm.Size.HasValue)
				Size = _settings.MainForm.Size.Value;
			else
				_settings.MainForm.Size = Size;
			if(_settings.MainForm.Location.HasValue)
				Location = _settings.MainForm.Location.Value;
			else {
				CenterToScreen();
				_settings.MainForm.Location = Location;
			}
			WindowState = _settings.MainForm.WindowState;
			ResizeEnd += new EventHandler(PhotoComb_ResizeEnd);
			LocationChanged += new EventHandler(PhotoComb_LocationChanged);
			_fbdOpen.SelectedPath = _settings.LastSourceDir;
			_fbdExport.SelectedPath = _settings.LastDestDir;
		}

		/// <summary>
		/// Actions when the form is first displayed (scan the last folder used).
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private async void PhotoComb_Shown(object sender, EventArgs e)
			=> await Task.WhenAll(
					ChooseFolder(),
					_versionManager.PromptForUpdate(this)
				).ConfigureAwait(false);

		/// <summary>
		/// Update the display size setting when it changes.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void PhotoComb_ResizeEnd(object sender, EventArgs e) {
			if(WindowState == FormWindowState.Normal)
				_settings.MainForm.Size = Size;
		}

		/// <summary>
		/// Update the display location setting when it changes.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void PhotoComb_LocationChanged(object sender, EventArgs e) {
			if(WindowState == FormWindowState.Normal)
				_settings.MainForm.Location = Location;
		}
		#endregion initialization

		/// <summary>
		/// Prompt for selection of a folder to scan.
		/// </summary>
		private async Task ChooseFolder() {
			if(_fbdOpen.ShowDialog(this) == DialogResult.OK)
				await ScanFolder(_fbdOpen.SelectedPath).ConfigureAwait(false);
		}

		/// <summary>
		/// Scans the specified folder path.
		/// </summary>
		/// <param name="path">Full folder path to scan</param>
		private async Task ScanFolder(string path) {
			_lv.Items.Clear();
			_lblFolder.Text = Labels.Loading;
			_lv.BeginUpdate();
			List<Task> metadataTasks = new List<Task>();
			foreach(ICameraFileInfo cfi in _files.ScanDirectory(path)) {
				ListViewItem lvi = new ListViewItem(new string[] { cfi.Name, cfi.SortableName, cfi.ErrorMessage }, (int)cfi.Metadata.Type);
				metadataTasks.Add(UpdateWithMetadataAsync(lvi, cfi));
				_lv.Items.Add(lvi);
			}
			_lv.EndUpdate();
			_settings.LastSourceDir = _lblFolder.Text = path;
			_tsTimestamp.Enabled = _tsModel.Enabled = _tsRename.Enabled = _tsExport.Enabled = _lv.Items.Count > 0;
			_tsTimestampCamera.Visible = _tsModelCamera.Visible = _files.CameraNames.Count > 0;
			await Task.WhenAll(metadataTasks).ConfigureAwait(false);
		}

		/// <summary>
		/// Refresh the list of files without loading them from disk again.
		/// </summary>
		private void RefreshData() {
			ISet<string> checkedFilenames = new HashSet<string>(GetCheckedFilenames(true));
			_lv.BeginUpdate();
			_lv.Items.Clear();
			foreach(ICameraFileInfo cfi in _files.Files) {
				ListViewItem lvi = new ListViewItem(new string[] { cfi.Name, cfi.SortableName, cfi.ErrorMessage }, (int)cfi.Metadata.Type) {
					Checked = checkedFilenames.Contains(cfi.Name)
				};
				_lv.Items.Add(lvi);
			}
			_lv.EndUpdate();
			_tsTimestamp.Enabled = _tsModel.Enabled = _tsRename.Enabled = _tsExport.Enabled = _lv.Items.Count > 0;
			_tsTimestampCamera.Visible = _tsModelCamera.Visible = _files.CameraNames.Count > 0;
		}

		/// <summary>
		/// Update an item once its metadata has been looked up.
		/// </summary>
		/// <param name="lvi">List item to update</param>
		/// <param name="cfi">Data for list item</param>
		/// <returns></returns>
		private async Task UpdateWithMetadataAsync(ListViewItem lvi, ICameraFileInfo cfi) {
			await cfi.LookupMetadata.ConfigureAwait(true);
			lvi.SubItems[_colNewName.Index].Text = cfi.SortableName;
			lvi.SubItems[_colMessage.Index].Text = cfi.ErrorMessage;
			lvi.ImageIndex = (int)cfi.Metadata.Type;
		}

		/// <summary>
		/// Prompt for a time taken adjustment and then adjust the time taken and
		/// update the new filename column.
		/// </summary>
		/// <param name="fileGroupType">Which type of file group is being updated</param>
		private void AdjustTimeTaken(FileGroupType fileGroupType) {
			using TimespanDialog tsd = new TimespanDialog(fileGroupType);
			if(fileGroupType == FileGroupType.CameraModel)
				tsd.SetModelList(_files.CameraNames);
			if(tsd.ShowDialog(this) != DialogResult.Cancel) {
				switch(fileGroupType) {
					case FileGroupType.All:
						_files.ApplyTimeCorrection(tsd.Offset);
						break;
					case FileGroupType.CameraModel:
						_files.ApplyTimeCorrection(tsd.Offset, tsd.CameraModel);
						break;
					case FileGroupType.Checked:
						_files.ApplyTimeCorrection(tsd.Offset, GetCheckedFilenames());
						break;
				}
				RefreshData();
			}
		}

		/// <summary>
		/// Prompt for a camera nickname and then adjust the camera model and
		/// update the new filename column.
		/// </summary>
		/// <param name="fileGroupType">Which type of file group is being updated.</param>
		private void ChangeCameraName(FileGroupType fileGroupType) {
			using CameraNameDialog cnd = new CameraNameDialog(fileGroupType);
			if(fileGroupType == FileGroupType.CameraModel)
				cnd.SetModelList(_files.CameraNames);
			if(cnd.ShowDialog(this) != DialogResult.Cancel) {
				switch(fileGroupType) {
					case FileGroupType.All:
						_files.SetCameraNickname(cnd.Nickname);
						break;
					case FileGroupType.CameraModel:
						_files.SetCameraNickname(cnd.Nickname, cnd.CameraModel);
						break;
					case FileGroupType.Checked:
						_files.SetCameraNickname(cnd.Nickname, GetCheckedFilenames());
						break;
				}
				RefreshData();
			}
		}

		/// <summary>
		/// Rename the specified files.
		/// </summary>
		/// <param name="fileGroupType">Group of files to rename.</param>
		private void RenameFiles(FileGroupType fileGroupType) {
			switch(fileGroupType) {
				case FileGroupType.All:
					_files.RenameFilesToSortable();
					break;
				case FileGroupType.CameraModel:
					throw new ArgumentOutOfRangeException(nameof(fileGroupType), "Rename by camera model is not supported.");
				case FileGroupType.Checked:
					_files.RenameFilesToSortable(GetCheckedFilenames());
					break;
			}
			RefreshData();
		}

		/// <summary>
		/// Copy files and change their names.
		/// </summary>
		/// <param name="fileGroupType">Group of files to copy.</param>
		private void CopyFiles(FileGroupType fileGroupType) {
			if(fileGroupType == FileGroupType.CameraModel)
				throw new ArgumentOutOfRangeException(nameof(fileGroupType), "Copy by camera model is not supported.");
			if(_fbdExport.ShowDialog(this) == DialogResult.OK) {
				_settings.LastDestDir = _fbdExport.SelectedPath;
				switch(fileGroupType) {
					case FileGroupType.All:
						CopyFiles(_fbdExport.SelectedPath);
						break;
					case FileGroupType.Checked:
						CopyFiles(_fbdExport.SelectedPath, GetCheckedFilenames());
						break;
				}
				RefreshData();
			}
		}

		#region Copy Files
		/// <summary>
		/// Copy all files and change their names.
		/// </summary>
		/// <param name="destPath">Full path to the directory the files should be copied to.</param>
		private void CopyFiles(string destPath)
			=> CopyFiles(destPath, _files.Files);

		/// <summary>
		/// Copy the specified files and change their names.
		/// </summary>
		/// <param name="destPath">Full path to the directory the files should be copied to.</param>
		/// <param name="filenames">List of filenames to copy.</param>
		private void CopyFiles(string destPath, IEnumerable<string> filenames)
			=> CopyFiles(destPath, _files.GetFilesFromNames(filenames));

		/// <summary>
		/// Copy the specified files and change their names.
		/// </summary>
		/// <param name="destPath">Full path to the directory the files should be copied to.</param>
		/// <param name="files">List of files to copy.</param>
		private void CopyFiles(string destPath, IEnumerable<ICameraFileInfo> files) {
			using(CopyFilesOperation copyFiles = new CopyFilesOperation())
				foreach(ICameraFileInfo file in files)
					if(file.Metadata.Taken.HasValue && !string.IsNullOrEmpty(file.CameraNameOverride ?? file.Metadata.Model))
						copyFiles.Queue(file.FullName, destPath, file.SortableName);
					else
						file.ErrorMessage = Messages.ExportUnavailable;
			RefreshData();
		}
		#endregion Copy Files

		/// <summary>
		/// Gets the filenames of all checked files.
		/// </summary>
		/// <returns>Filenames of checked files.</returns>
		private IEnumerable<string> GetCheckedFilenames()
			=> GetCheckedFilenames(false);

		/// <summary>
		/// Gets the filenames of all checked files.
		/// </summary>
		/// <param name="includeSortableNames">Whether sortable names should be included.</param>
		/// <returns>Filenames of checked files.</returns>
		private IEnumerable<string> GetCheckedFilenames(bool includeSortableNames) {
			foreach(ListViewItem lvi in _lv.CheckedItems) {
				yield return lvi.SubItems[_colOldName.Index].Text;
				if(includeSortableNames)
					yield return lvi.SubItems[_colNewName.Index].Text;
			}
		}

		#region event handlers
		/// <summary>
		/// Give feedback that files / folders can be dropped on the form.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Checked for file / folder data being dragged</param>
		private void PhotoComb_DragEnter(object sender, DragEventArgs e)
			=> e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

		/// <summary>
		/// Switch to the folder that was dropped on the form, or the folder
		/// containing the file that was dropped on the form.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">The first foldername or the containing folder of the first filename will be used</param>
		private async void PhotoComb_DragDrop(object sender, DragEventArgs e) {
			if(e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if(files.Length > 0)
					await ScanFolder(Directory.Exists(files[0]) ? files[0] : Path.GetDirectoryName(files[0])).ConfigureAwait(false);
			}
		}

		/// <summary>
		/// Prompt for a folder to scan.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private async void folder_Click(object sender, EventArgs e)
			=> await ChooseFolder().ConfigureAwait(false);

		/// <summary>
		/// Enable or disable buttons that act on the selection based on whether
		/// anything is selected.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _lv_ItemChecked(object sender, ItemCheckedEventArgs e)
			=> _tsTimestampSelected.Enabled = _tsModelSelected.Enabled = _tsRenameSelected.Enabled = _tsExportSelected.Enabled = _lv.CheckedItems.Count > 0;

		/// <summary>
		/// Re-scan the current folder in case changes have been made.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private async void _tsRescan_Click(object sender, EventArgs e)
			=> await ScanFolder(_lblFolder.Text).ConfigureAwait(false);

		/// <summary>
		/// Change the time taken for all files that have a time taken.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsTimestampAll_Click(object sender, EventArgs e)
			=> AdjustTimeTaken(FileGroupType.All);

		/// <summary>
		/// Change the time taken for checked files that have a time taken.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsTimestampSelected_Click(object sender, EventArgs e)
			=> AdjustTimeTaken(FileGroupType.Checked);

		/// <summary>
		/// Change the time taken for files that were taken by a chosen camera model.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsTimestampCamera_Click(object sender, EventArgs e)
			=> AdjustTimeTaken(FileGroupType.CameraModel);

		/// <summary>
		/// Change the camera model name for all files.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsModelAll_Click(object sender, EventArgs e)
			=> ChangeCameraName(FileGroupType.All);

		/// <summary>
		/// Change the camera model name for checked files.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsModelSelected_Click(object sender, EventArgs e)
			=> ChangeCameraName(FileGroupType.Checked);

		/// <summary>
		/// Change the camera model name for files that were taken by a chosen camera model.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsModelCamera_Click(object sender, EventArgs e)
			=> ChangeCameraName(FileGroupType.CameraModel);

		/// <summary>
		/// Rename all the files in place.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsRenameAll_Click(object sender, EventArgs e)
			=> RenameFiles(FileGroupType.All);

		/// <summary>
		/// Rename checked files in place.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsRenameSelected_Click(object sender, EventArgs e)
			=> RenameFiles(FileGroupType.Checked);

		/// <summary>
		/// Copy all files to a new location with updated names.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsExportAll_Click(object sender, EventArgs e)
			=> CopyFiles(FileGroupType.All);

		/// <summary>
		/// Copy checked files to a new location with updated names.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsExportSelected_Click(object sender, EventArgs e)
			=> CopyFiles(FileGroupType.Checked);

		/// <summary>
		/// Show the main menu when clicking on the menu image.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _pbMenu_Click(object sender, EventArgs e)
			=> _cmnuMain.Show(_pbMenu, -_cmnuMain.Width + _pbMenu.Width, _pbMenu.Height);

		/// <summary>
		/// Show settings window.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _cmnuMainSettings_Click(object sender, EventArgs e) {
			using SettingsWindow settingsWindow = new SettingsWindow(_settings);
			if(settingsWindow.ShowDialog(this) == DialogResult.OK)
				RefreshData();
		}

		/// <summary>
		/// Check for update and display the results.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private async void _cmnuMainCheckUpdate_Click(object sender, EventArgs e)
			=> await _versionManager.PromptForUpdate(this, true).ConfigureAwait(false);

		/// <summary>
		/// Show about window.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _cmnuMainAbout_Click(object sender, EventArgs e) {
			using AboutPhotoCombWindow about = new AboutPhotoCombWindow();
			about.ShowDialog(this);
		}
		#endregion event handlers
	}
}
