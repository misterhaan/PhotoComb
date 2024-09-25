namespace au.Applications.PhotoComb.UI {
	partial class PhotoCombWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoCombWindow));
			_pnlStatus = new System.Windows.Forms.Panel();
			_lblFolder = new System.Windows.Forms.Label();
			_pbMenu = new System.Windows.Forms.PictureBox();
			_cmnuMain = new System.Windows.Forms.ContextMenuStrip(components);
			_cmnuMainSettings = new System.Windows.Forms.ToolStripMenuItem();
			_cmnuMainCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
			_cmnuMainAbout = new System.Windows.Forms.ToolStripMenuItem();
			_ts = new System.Windows.Forms.ToolStrip();
			_tsRescan = new System.Windows.Forms.ToolStripButton();
			_tsTimestamp = new System.Windows.Forms.ToolStripSplitButton();
			_tsTimestampAll = new System.Windows.Forms.ToolStripMenuItem();
			_tsTimestampSelected = new System.Windows.Forms.ToolStripMenuItem();
			_tsTimestampCamera = new System.Windows.Forms.ToolStripMenuItem();
			_tsModel = new System.Windows.Forms.ToolStripSplitButton();
			_tsModelAll = new System.Windows.Forms.ToolStripMenuItem();
			_tsModelSelected = new System.Windows.Forms.ToolStripMenuItem();
			_tsModelCamera = new System.Windows.Forms.ToolStripMenuItem();
			_tsRename = new System.Windows.Forms.ToolStripSplitButton();
			_tsRenameAll = new System.Windows.Forms.ToolStripMenuItem();
			_tsRenameSelected = new System.Windows.Forms.ToolStripMenuItem();
			_tsExport = new System.Windows.Forms.ToolStripSplitButton();
			_tsExportAll = new System.Windows.Forms.ToolStripMenuItem();
			_tsExportSelected = new System.Windows.Forms.ToolStripMenuItem();
			_lv = new System.Windows.Forms.ListView();
			_colOldName = new System.Windows.Forms.ColumnHeader();
			_colNewName = new System.Windows.Forms.ColumnHeader();
			_colMessage = new System.Windows.Forms.ColumnHeader();
			_il = new System.Windows.Forms.ImageList(components);
			_fbdExport = new System.Windows.Forms.FolderBrowserDialog();
			_split = new System.Windows.Forms.SplitContainer();
			_tvFolders = new System.Windows.Forms.TreeView();
			_pnlStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)_pbMenu).BeginInit();
			_cmnuMain.SuspendLayout();
			_ts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)_split).BeginInit();
			_split.Panel1.SuspendLayout();
			_split.Panel2.SuspendLayout();
			_split.SuspendLayout();
			SuspendLayout();
			// 
			// _pnlStatus
			// 
			_pnlStatus.BackColor = System.Drawing.SystemColors.Window;
			_pnlStatus.Controls.Add(_lblFolder);
			_pnlStatus.Controls.Add(_pbMenu);
			_pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
			_pnlStatus.ForeColor = System.Drawing.SystemColors.WindowText;
			_pnlStatus.Location = new System.Drawing.Point(0, 0);
			_pnlStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			_pnlStatus.Name = "_pnlStatus";
			_pnlStatus.Size = new System.Drawing.Size(877, 46);
			_pnlStatus.TabIndex = 0;
			// 
			// _lblFolder
			// 
			_lblFolder.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			_lblFolder.AutoEllipsis = true;
			_lblFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_lblFolder.Location = new System.Drawing.Point(9, 9);
			_lblFolder.Margin = new System.Windows.Forms.Padding(0, 9, 4, 9);
			_lblFolder.Name = "_lblFolder";
			_lblFolder.Size = new System.Drawing.Size(823, 28);
			_lblFolder.TabIndex = 1;
			_lblFolder.Text = "Loading...";
			_lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _pbMenu
			// 
			_pbMenu.Anchor = System.Windows.Forms.AnchorStyles.Right;
			_pbMenu.ContextMenuStrip = _cmnuMain;
			_pbMenu.Image = MaterialIcons.Menu24;
			_pbMenu.Location = new System.Drawing.Point(835, 5);
			_pbMenu.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
			_pbMenu.Name = "_pbMenu";
			_pbMenu.Size = new System.Drawing.Size(37, 37);
			_pbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			_pbMenu.TabIndex = 7;
			_pbMenu.TabStop = false;
			_pbMenu.Click += PbMenu_Click;
			// 
			// _cmnuMain
			// 
			_cmnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { _cmnuMainSettings, _cmnuMainCheckUpdate, _cmnuMainAbout });
			_cmnuMain.Name = "_cmnuMain";
			_cmnuMain.Size = new System.Drawing.Size(178, 76);
			// 
			// _cmnuMainSettings
			// 
			_cmnuMainSettings.Image = MaterialIcons.Settings18;
			_cmnuMainSettings.Name = "_cmnuMainSettings";
			_cmnuMainSettings.Size = new System.Drawing.Size(177, 24);
			_cmnuMainSettings.Text = "&Settings...";
			_cmnuMainSettings.Click += CmnuMainSettings_Click;
			// 
			// _cmnuMainCheckUpdate
			// 
			_cmnuMainCheckUpdate.Image = MaterialIcons.Update18;
			_cmnuMainCheckUpdate.Name = "_cmnuMainCheckUpdate";
			_cmnuMainCheckUpdate.Size = new System.Drawing.Size(177, 24);
			_cmnuMainCheckUpdate.Text = "Check for &Update...";
			_cmnuMainCheckUpdate.Click += CmnuMainCheckUpdate_Click;
			// 
			// _cmnuMainAbout
			// 
			_cmnuMainAbout.Image = MaterialIcons.About18;
			_cmnuMainAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_cmnuMainAbout.Name = "_cmnuMainAbout";
			_cmnuMainAbout.Size = new System.Drawing.Size(177, 24);
			_cmnuMainAbout.Text = "&About";
			_cmnuMainAbout.Click += CmnuMainAbout_Click;
			// 
			// _ts
			// 
			_ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			_ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { _tsRescan, _tsTimestamp, _tsModel, _tsRename, _tsExport });
			_ts.Location = new System.Drawing.Point(0, 46);
			_ts.Name = "_ts";
			_ts.Padding = new System.Windows.Forms.Padding(7, 0, 1, 0);
			_ts.Size = new System.Drawing.Size(877, 25);
			_ts.TabIndex = 12;
			// 
			// _tsRescan
			// 
			_tsRescan.Image = MaterialIcons.Refresh18;
			_tsRescan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsRescan.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tsRescan.Name = "_tsRescan";
			_tsRescan.Size = new System.Drawing.Size(66, 22);
			_tsRescan.Text = "&Rescan";
			_tsRescan.ToolTipText = "Rescan files in the current folder";
			_tsRescan.Click += TsRescan_Click;
			// 
			// _tsTimestamp
			// 
			_tsTimestamp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _tsTimestampAll, _tsTimestampSelected, _tsTimestampCamera });
			_tsTimestamp.Enabled = false;
			_tsTimestamp.Image = MaterialIcons.Time18;
			_tsTimestamp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsTimestamp.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tsTimestamp.Name = "_tsTimestamp";
			_tsTimestamp.Size = new System.Drawing.Size(113, 22);
			_tsTimestamp.Text = "Adjust &Time...";
			_tsTimestamp.ToolTipText = "Adjust time taken for all files in the folder";
			_tsTimestamp.ButtonClick += TsTimestampAll_Click;
			// 
			// _tsTimestampAll
			// 
			_tsTimestampAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			_tsTimestampAll.Image = MaterialIcons.All18;
			_tsTimestampAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsTimestampAll.Name = "_tsTimestampAll";
			_tsTimestampAll.Size = new System.Drawing.Size(157, 24);
			_tsTimestampAll.Text = "&All Files...";
			_tsTimestampAll.ToolTipText = "Adjust time taken for all files in the folder";
			_tsTimestampAll.Click += TsTimestampAll_Click;
			// 
			// _tsTimestampSelected
			// 
			_tsTimestampSelected.Enabled = false;
			_tsTimestampSelected.Image = MaterialIcons.Checked18;
			_tsTimestampSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsTimestampSelected.Name = "_tsTimestampSelected";
			_tsTimestampSelected.Size = new System.Drawing.Size(157, 24);
			_tsTimestampSelected.Text = "Chec&ked Files...";
			_tsTimestampSelected.ToolTipText = "Adjust time taken for files marked with a checkmark";
			_tsTimestampSelected.Click += TsTimestampSelected_Click;
			// 
			// _tsTimestampCamera
			// 
			_tsTimestampCamera.Image = MaterialIcons.Camera18;
			_tsTimestampCamera.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsTimestampCamera.Name = "_tsTimestampCamera";
			_tsTimestampCamera.Size = new System.Drawing.Size(157, 24);
			_tsTimestampCamera.Text = "By &Camera...";
			_tsTimestampCamera.ToolTipText = "Adjust time taken for files with a specified camera name";
			_tsTimestampCamera.Click += TsTimestampCamera_Click;
			// 
			// _tsModel
			// 
			_tsModel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _tsModelAll, _tsModelSelected, _tsModelCamera });
			_tsModel.Enabled = false;
			_tsModel.Image = MaterialIcons.Camera18;
			_tsModel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsModel.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tsModel.Name = "_tsModel";
			_tsModel.Size = new System.Drawing.Size(148, 22);
			_tsModel.Text = "Nickname &Camera...";
			_tsModel.ToolTipText = "Change camera name for all files in the folder";
			_tsModel.ButtonClick += TsModelAll_Click;
			// 
			// _tsModelAll
			// 
			_tsModelAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			_tsModelAll.Image = MaterialIcons.All18;
			_tsModelAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsModelAll.Name = "_tsModelAll";
			_tsModelAll.Size = new System.Drawing.Size(157, 24);
			_tsModelAll.Text = "&All Files...";
			_tsModelAll.ToolTipText = "Change camera name for all files in the folder";
			_tsModelAll.Click += TsModelAll_Click;
			// 
			// _tsModelSelected
			// 
			_tsModelSelected.Enabled = false;
			_tsModelSelected.Image = MaterialIcons.Checked18;
			_tsModelSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsModelSelected.Name = "_tsModelSelected";
			_tsModelSelected.Size = new System.Drawing.Size(157, 24);
			_tsModelSelected.Text = "Chec&ked Files...";
			_tsModelSelected.ToolTipText = "Change camera name for files marked with a checkmark";
			_tsModelSelected.Click += TsModelSelected_Click;
			// 
			// _tsModelCamera
			// 
			_tsModelCamera.Image = MaterialIcons.Camera18;
			_tsModelCamera.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsModelCamera.Name = "_tsModelCamera";
			_tsModelCamera.Size = new System.Drawing.Size(157, 24);
			_tsModelCamera.Text = "By &Camera...";
			_tsModelCamera.ToolTipText = "Change camera name for files with a specified camera name";
			_tsModelCamera.Click += TsModelCamera_Click;
			// 
			// _tsRename
			// 
			_tsRename.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _tsRenameAll, _tsRenameSelected });
			_tsRename.Enabled = false;
			_tsRename.Image = MaterialIcons.Rename18;
			_tsRename.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsRename.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tsRename.Name = "_tsRename";
			_tsRename.Size = new System.Drawing.Size(84, 22);
			_tsRename.Text = "Re&name";
			_tsRename.ButtonClick += TsRenameAll_Click;
			// 
			// _tsRenameAll
			// 
			_tsRenameAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			_tsRenameAll.Image = MaterialIcons.All18;
			_tsRenameAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsRenameAll.Name = "_tsRenameAll";
			_tsRenameAll.Size = new System.Drawing.Size(122, 24);
			_tsRenameAll.Text = "&All";
			_tsRenameAll.Click += TsRenameAll_Click;
			// 
			// _tsRenameSelected
			// 
			_tsRenameSelected.Enabled = false;
			_tsRenameSelected.Image = MaterialIcons.Checked18;
			_tsRenameSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsRenameSelected.Name = "_tsRenameSelected";
			_tsRenameSelected.Size = new System.Drawing.Size(122, 24);
			_tsRenameSelected.Text = "Chec&ked";
			_tsRenameSelected.Click += TsRenameSelected_Click;
			// 
			// _tsExport
			// 
			_tsExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { _tsExportAll, _tsExportSelected });
			_tsExport.Enabled = false;
			_tsExport.Image = MaterialIcons.Export18;
			_tsExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			_tsExport.Name = "_tsExport";
			_tsExport.Size = new System.Drawing.Size(84, 22);
			_tsExport.Text = "E&xport...";
			_tsExport.ButtonClick += TsExportAll_Click;
			// 
			// _tsExportAll
			// 
			_tsExportAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			_tsExportAll.Image = MaterialIcons.All18;
			_tsExportAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsExportAll.Name = "_tsExportAll";
			_tsExportAll.Size = new System.Drawing.Size(131, 24);
			_tsExportAll.Text = "&All...";
			_tsExportAll.Click += TsExportAll_Click;
			// 
			// _tsExportSelected
			// 
			_tsExportSelected.Enabled = false;
			_tsExportSelected.Image = MaterialIcons.Checked18;
			_tsExportSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			_tsExportSelected.Name = "_tsExportSelected";
			_tsExportSelected.Size = new System.Drawing.Size(131, 24);
			_tsExportSelected.Text = "Chec&ked...";
			_tsExportSelected.Click += TsExportSelected_Click;
			// 
			// _lv
			// 
			_lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_lv.CheckBoxes = true;
			_lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { _colOldName, _colNewName, _colMessage });
			_lv.Dock = System.Windows.Forms.DockStyle.Fill;
			_lv.FullRowSelect = true;
			_lv.Location = new System.Drawing.Point(0, 0);
			_lv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			_lv.Name = "_lv";
			_lv.Size = new System.Drawing.Size(673, 438);
			_lv.SmallImageList = _il;
			_lv.Sorting = System.Windows.Forms.SortOrder.Ascending;
			_lv.TabIndex = 13;
			_lv.UseCompatibleStateImageBehavior = false;
			_lv.View = System.Windows.Forms.View.Details;
			_lv.ItemChecked += Lv_ItemChecked;
			// 
			// _colOldName
			// 
			_colOldName.Text = "Original";
			_colOldName.Width = 150;
			// 
			// _colNewName
			// 
			_colNewName.Text = "New";
			_colNewName.Width = 240;
			// 
			// _colMessage
			// 
			_colMessage.Text = "Message";
			_colMessage.Width = 300;
			// 
			// _il
			// 
			_il.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			_il.ImageSize = new System.Drawing.Size(16, 16);
			_il.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// _fbdExport
			// 
			_fbdExport.Description = "Choose a folder to copy files into using the new names.";
			// 
			// _split
			// 
			_split.Dock = System.Windows.Forms.DockStyle.Fill;
			_split.Location = new System.Drawing.Point(0, 71);
			_split.Name = "_split";
			// 
			// _split.Panel1
			// 
			_split.Panel1.Controls.Add(_tvFolders);
			// 
			// _split.Panel2
			// 
			_split.Panel2.Controls.Add(_lv);
			_split.Size = new System.Drawing.Size(877, 438);
			_split.SplitterDistance = 200;
			_split.TabIndex = 14;
			// 
			// _tvFolders
			// 
			_tvFolders.BorderStyle = System.Windows.Forms.BorderStyle.None;
			_tvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
			_tvFolders.FullRowSelect = true;
			_tvFolders.HideSelection = false;
			_tvFolders.Indent = 12;
			_tvFolders.Location = new System.Drawing.Point(0, 0);
			_tvFolders.Name = "_tvFolders";
			_tvFolders.ShowLines = false;
			_tvFolders.ShowNodeToolTips = true;
			_tvFolders.ShowRootLines = false;
			_tvFolders.Size = new System.Drawing.Size(200, 438);
			_tvFolders.TabIndex = 0;
			_tvFolders.AfterSelect += TvFolders_AfterSelect;
			// 
			// PhotoCombWindow
			// 
			AllowDrop = true;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(877, 509);
			Controls.Add(_split);
			Controls.Add(_ts);
			Controls.Add(_pnlStatus);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			Name = "PhotoCombWindow";
			Text = "Photo Combine";
			Load += PhotoComb_Load;
			Shown += PhotoComb_Shown;
			DragDrop += PhotoComb_DragDrop;
			DragEnter += PhotoComb_DragEnter;
			_pnlStatus.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)_pbMenu).EndInit();
			_cmnuMain.ResumeLayout(false);
			_ts.ResumeLayout(false);
			_ts.PerformLayout();
			_split.Panel1.ResumeLayout(false);
			_split.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)_split).EndInit();
			_split.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Panel _pnlStatus;
		private System.Windows.Forms.PictureBox _pbMenu;
		private System.Windows.Forms.ContextMenuStrip _cmnuMain;
		private System.Windows.Forms.ToolStripMenuItem _cmnuMainAbout;
		private System.Windows.Forms.Label _lblFolder;
		private System.Windows.Forms.ToolStrip _ts;
		private System.Windows.Forms.ToolStripButton _tsRescan;
		private System.Windows.Forms.ListView _lv;
		private System.Windows.Forms.ColumnHeader _colOldName;
		private System.Windows.Forms.ColumnHeader _colNewName;
		private System.Windows.Forms.ColumnHeader _colMessage;
		private System.Windows.Forms.ImageList _il;
		private System.Windows.Forms.ToolStripSplitButton _tsTimestamp;
		private System.Windows.Forms.ToolStripMenuItem _tsTimestampAll;
		private System.Windows.Forms.ToolStripMenuItem _tsTimestampSelected;
		private System.Windows.Forms.ToolStripMenuItem _tsTimestampCamera;
		private System.Windows.Forms.ToolStripSplitButton _tsModel;
		private System.Windows.Forms.ToolStripMenuItem _tsModelAll;
		private System.Windows.Forms.ToolStripMenuItem _tsModelSelected;
		private System.Windows.Forms.ToolStripMenuItem _tsModelCamera;
		private System.Windows.Forms.ToolStripSplitButton _tsRename;
		private System.Windows.Forms.ToolStripMenuItem _tsRenameAll;
		private System.Windows.Forms.ToolStripMenuItem _tsRenameSelected;
		private System.Windows.Forms.ToolStripSplitButton _tsExport;
		private System.Windows.Forms.ToolStripMenuItem _tsExportAll;
		private System.Windows.Forms.ToolStripMenuItem _tsExportSelected;
		private System.Windows.Forms.FolderBrowserDialog _fbdExport;
		private System.Windows.Forms.ToolStripMenuItem _cmnuMainSettings;
		private System.Windows.Forms.ToolStripMenuItem _cmnuMainCheckUpdate;
		private System.Windows.Forms.SplitContainer _split;
		private System.Windows.Forms.TreeView _tvFolders;
	}
}