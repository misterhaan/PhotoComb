using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace au.Applications.PhotoComb {
	/// <summary>
	/// Main Photo Combine form.  Lists files in the directory with current name
	/// and what it will be changed to and allows tweaking and then renaming or
	/// copying with new filenames.
	/// </summary>
	public partial class PhotoComb : Form {
		/// <summary>
		/// Settings are mostly values that persist when the application is closed
		/// and reopened.
		/// </summary>
		private PCSettings _settings;
		/// <summary>
		/// Index of list view items by camera model.  Used for performing
		/// operations on all files from a specific camera model.
		/// </summary>
		private Dictionary<string, List<ListViewItem>> _byModel = new Dictionary<string, List<ListViewItem>>();

		#region initialization and closing
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new PhotoComb());
		}

		/// <summary>
		/// Create a new Photo Combine main form.
		/// </summary>
		public PhotoComb() {
			InitializeComponent();
			// these icons must match up with CameraFileType (same number and order)
			_il.Images.Add(MaterialIcons.Photo16);
			_il.Images.Add(MaterialIcons.Video16);
			_il.Images.Add(MaterialIcons.File16);
		}

		/// <summary>
		/// Actions when the form loads (before it's displayed)
		/// </summary>
		/// <param name="sender">not used</param>
		/// <param name="e">not used</param>
		private void PhotoComb_Load(object sender, EventArgs e) {
			_settings = new PCSettings();
			_settings.Load();
			if(_settings.Display.Size.Width != -42 && _settings.Display.Size.Height != -42)
				Size = _settings.Display.Size;
			if(_settings.Display.Location.X != -42 && _settings.Display.Location.Y != -42)
				Location = _settings.Display.Location;
			else
				CenterToScreen();
			WindowState = _settings.Display.WindowState;
			ResizeEnd += new System.EventHandler(PhotoComb_ResizeEnd);
			LocationChanged += new System.EventHandler(PhotoComb_LocationChanged);
			_fbdOpen.SelectedPath = _settings.LastSourceDir;
			_fbdExport.SelectedPath = _settings.LastDestDir;
		}

		/// <summary>
		/// Actions when the form is first displayed (scan the last folder used).
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void PhotoComb_Shown(object sender, EventArgs e) {
			ChooseFolder();
			//ScanFolder(_settings.LastSourceDir);
		}

		/// <summary>
		/// Update the display size setting when it changes.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void PhotoComb_ResizeEnd(object sender, EventArgs e) {
			if(WindowState == FormWindowState.Normal) {
				_settings.Display.Size.Height = Height;
				_settings.Display.Size.Width = Width;
			}
		}

		/// <summary>
		/// Update the display location setting when it changes.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void PhotoComb_LocationChanged(object sender, EventArgs e) {
			if(WindowState == FormWindowState.Normal) {
				_settings.Display.Location.X = Left;
				_settings.Display.Location.Y = Top;
			}
		}

		/// <summary>
		/// Save settings when the program closes.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void PhotoComb_FormClosed(object sender, FormClosedEventArgs e) {
			_settings.Save();
		}
		#endregion initialization and closing

		/// <summary>
		/// Prompt for selection of a folder to scan.
		/// </summary>
		private void ChooseFolder() {
			if(_fbdOpen.ShowDialog(this) == DialogResult.OK)
				ScanFolder(_fbdOpen.SelectedPath);
		}

		/// <summary>
		/// Scans the specified folder path.
		/// </summary>
		/// <param name="path">Full folder path to scan</param>
		private void ScanFolder(string path) {
			_lv.Items.Clear();
			_byModel.Clear();
			_lblFolder.Text = Strings.Loading;
			_lv.BeginUpdate();
			CameraDirectoryInfo cdi = new CameraDirectoryInfo(path);
			foreach(CameraFileInfo cfi in cdi.GetFiles()) {
				ListViewItem lvi = new ListViewItem(new string[] { cfi.Name, NewName(cfi), cfi.Error }, (int)cfi.Type) {
					Tag = cfi
				};
				_lv.Items.Add(lvi);
				if(!_byModel.ContainsKey(cfi.Model ?? ""))
					_byModel.Add(cfi.Model ?? "", new List<ListViewItem>());
				_byModel[cfi.Model ?? ""].Add(lvi);
			}
			_lv.EndUpdate();
			_settings.LastSourceDir = _lblFolder.Text = path;
			_tsTimestamp.Enabled = _tsModel.Enabled = _tsRename.Enabled = _tsExport.Enabled = _lv.Items.Count > 0;
			_tsTimestampCamera.Visible = _tsModelCamera.Visible = _byModel.Keys.Count > 1;
		}

		/// <summary>
		/// Generate the new filename based on the old filename and metadata.
		/// </summary>
		/// <param name="cfi">File to generate new name for</param>
		/// <returns>New name for the specified file</returns>
		private string NewName(CameraFileInfo cfi) {
			// TODO:  support custom format
			string id = cfi.ID;
			if(!string.IsNullOrEmpty(id))
				id = "-" + id;
			return string.Format("{0:yyyyMMdd-HHmmss}-{1}{2}.{3}", cfi.Taken, cfi.Model, id, cfi.Extension);
		}

		/// <summary>
		/// Prompt for a time taken adjustment and then adjust the time taken and
		/// update the new filename column.
		/// </summary>
		/// <param name="grp">Which type of file group is being updated</param>
		/// <param name="items">Collection of ListViewItems to update</param>
		private void AdjustTimeTaken(FileGroupType grp, IEnumerable items) {
			using(TimespanDialog tsd = new TimespanDialog(grp)) {
				if(grp == FileGroupType.CameraModel)
					tsd.SetModelList(_byModel.Keys);
				if(tsd.ShowDialog(this) != DialogResult.Cancel) {
					if(grp == FileGroupType.CameraModel)
						items = _byModel[tsd.CameraModel];
					foreach(ListViewItem lvi in items)
						if(lvi.Tag is CameraFileInfo cfi && cfi.Taken.HasValue) {
							cfi.Taken = cfi.Taken.Value.Add(tsd.Offset);
							lvi.SubItems[_colNewName.Index].Text = NewName(cfi);
						}
				}
			}
		}

		/// <summary>
		/// Prompt for a camera nickname and then adjust the camera model and
		/// update the new filename column.
		/// </summary>
		/// <param name="grp">Which type of file group is being updated</param>
		/// <param name="items">Collection of ListViewItems to update</param>
		private void ChangeCameraName(FileGroupType grp, IEnumerable items) {
			using(CameraNameDialog cnd = new CameraNameDialog(grp)) {
				if(grp == FileGroupType.CameraModel)
					cnd.SetModelList(_byModel.Keys);
				if(cnd.ShowDialog(this) != DialogResult.Cancel) {
					if(grp == FileGroupType.CameraModel)
						items = _byModel[cnd.CameraModel].ToArray();
					foreach(ListViewItem lvi in items)
						if(lvi.Tag is CameraFileInfo cfi) {
							if(_byModel.ContainsKey(cfi.Model ?? "")) {
								_byModel[cfi.Model ?? ""].Remove(lvi);
								if(_byModel[cfi.Model ?? ""].Count < 1)
									_byModel.Remove(cfi.Model ?? "");
							}
							cfi.Model = cnd.Nickname;
							lvi.SubItems[_colNewName.Index].Text = NewName(cfi);
							if(!_byModel.ContainsKey(cnd.Nickname))
								_byModel.Add(cnd.Nickname, new List<ListViewItem>());
							_byModel[cnd.Nickname].Add(lvi);
						}
				}
			}
		}

		/// <summary>
		/// Rename the specified files.
		/// </summary>
		/// <param name="items">Collection of ListViewItems to update</param>
		private void RenameFiles(IEnumerable items) {
			foreach(ListViewItem lvi in items)
				if(lvi.Tag is CameraFileInfo cfi)
					if(string.IsNullOrEmpty(cfi.Model) || !cfi.Taken.HasValue)
						lvi.SubItems[_colMessage.Index].Text = "Files must have both date taken and camera model";
					else
						try {
							cfi.MoveTo(Path.Combine(_settings.LastSourceDir, lvi.SubItems[_colNewName.Index].Text));
							lvi.SubItems[_colOldName.Index].Text = lvi.SubItems[_colNewName.Index].Text;
						} catch(Exception e) {
							// TODO:  more readable messages; maybe catch different types of exceptions
							lvi.SubItems[_colMessage.Index].Text = e.ToString();
						}
		}

		/// <summary>
		/// Copy the specified files and change their names.
		/// </summary>
		/// <param name="items">Collection of ListViewItems to update</param>
		private void CopyFiles(IEnumerable items) {
			if(_fbdExport.ShowDialog(this) == DialogResult.OK) {
				_settings.LastDestDir = _fbdExport.SelectedPath;
				foreach(ListViewItem lvi in items)
					if(lvi.Tag is CameraFileInfo cfi)
						if(string.IsNullOrEmpty(cfi.Model) || !cfi.Taken.HasValue)
							lvi.SubItems[_colMessage.Index].Text = "Files must have both date taken and camera model";
						else
							try {
								cfi.CopyTo(Path.Combine(_settings.LastDestDir, lvi.SubItems[_colNewName.Index].Text));
							} catch(Exception e) {
								// TODO:  more readable messages; maybe catch different types of exceptions
								lvi.SubItems[_colMessage.Index].Text = e.ToString();
							}
			}
		}

		#region event handlers
		/// <summary>
		/// Give feedback that files / folders can be dropped on the form.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Checked for file / folder data being dragged</param>
		private void PhotoComb_DragEnter(object sender, DragEventArgs e) {
			e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
		}

		/// <summary>
		/// Switch to the folder that was dropped on the form, or the folder
		/// containing the file that was dropped on the form.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">The first foldername or the containing folder of the first filename will be used</param>
		private void PhotoComb_DragDrop(object sender, DragEventArgs e) {
			if(e.Data.GetDataPresent(DataFormats.FileDrop)) {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if(files.Length > 0)
					ScanFolder(Directory.Exists(files[0]) ? files[0] : Path.GetDirectoryName(files[0]));
			}	
		}

		/// <summary>
		/// Prompt for a folder to scan.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void folder_Click(object sender, EventArgs e) {
			ChooseFolder();
		}

		/// <summary>
		/// Enable or disable buttons that act on the selection based on whether
		/// anything is selected.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _lv_ItemChecked(object sender, ItemCheckedEventArgs e) {
			_tsTimestampSelected.Enabled = _tsModelSelected.Enabled = _tsRenameSelected.Enabled = _tsExportSelected.Enabled = _lv.CheckedItems.Count > 0;
		}

		/// <summary>
		/// Re-scan the current folder in case changes have been made.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsRescan_Click(object sender, EventArgs e) {
			ScanFolder(_lblFolder.Text);
		}

		/// <summary>
		/// Change the time taken for all files that have a time taken.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsTimestampAll_Click(object sender, EventArgs e) {
			AdjustTimeTaken(FileGroupType.All, _lv.Items);
		}

		/// <summary>
		/// Change the time taken for checked files that have a time taken.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsTimestampSelected_Click(object sender, EventArgs e) {
			AdjustTimeTaken(FileGroupType.Checked, _lv.CheckedItems);
		}

		/// <summary>
		/// Change the time taken for files that were taken by a chosen camera model.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsTimestampCamera_Click(object sender, EventArgs e) {
			AdjustTimeTaken(FileGroupType.CameraModel, null);
		}

		/// <summary>
		/// Change the camera model name for all files.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsModelAll_Click(object sender, EventArgs e) {
			ChangeCameraName(FileGroupType.All, _lv.Items);
		}

		/// <summary>
		/// Change the camera model name for checked files.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsModelSelected_Click(object sender, EventArgs e) {
			ChangeCameraName(FileGroupType.Checked, _lv.CheckedItems);
		}

		/// <summary>
		/// Change the camera model name for files that were taken by a chosen camera model.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsModelCamera_Click(object sender, EventArgs e) {
			ChangeCameraName(FileGroupType.CameraModel, null);
		}

		/// <summary>
		/// Rename all the files in place.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsRenameAll_Click(object sender, EventArgs e) {
			RenameFiles(_lv.Items);
		}

		/// <summary>
		/// Rename checked files in place.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsRenameSelected_Click(object sender, EventArgs e) {
			RenameFiles(_lv.CheckedItems);
		}

		/// <summary>
		/// Copy all files to a new location with updated names.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsExportAll_Click(object sender, EventArgs e) {
			CopyFiles(_lv.Items);
		}

		/// <summary>
		/// Copy checked files to a new location with updated names.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _tsExportSelected_Click(object sender, EventArgs e) {
			CopyFiles(_lv.CheckedItems);
		}

		/// <summary>
		/// Show the main menu when clicking on the menu image.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _pbMenu_Click(object sender, EventArgs e) {
			_cmnuMain.Show(_pbMenu, -_cmnuMain.Width +_pbMenu.Width, _pbMenu.Height);
		}

		/// <summary>
		/// Show about window.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _cmnuMainAbout_Click(object sender, EventArgs e) {
			new AboutPhotoComb().ShowDialog(this);
		}
		#endregion event handlers
	}
}
