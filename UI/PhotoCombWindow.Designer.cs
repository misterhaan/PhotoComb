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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoCombWindow));
			this._pnlStatus = new System.Windows.Forms.Panel();
			this._lblFolder = new System.Windows.Forms.Label();
			this._cmnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
			this._ts = new System.Windows.Forms.ToolStrip();
			this._lv = new System.Windows.Forms.ListView();
			this._colOldName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colNewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._colMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this._il = new System.Windows.Forms.ImageList(this.components);
			this._fbdOpen = new System.Windows.Forms.FolderBrowserDialog();
			this._fbdExport = new System.Windows.Forms.FolderBrowserDialog();
			this._tsRescan = new System.Windows.Forms.ToolStripButton();
			this._tsTimestamp = new System.Windows.Forms.ToolStripSplitButton();
			this._tsTimestampAll = new System.Windows.Forms.ToolStripMenuItem();
			this._tsTimestampSelected = new System.Windows.Forms.ToolStripMenuItem();
			this._tsTimestampCamera = new System.Windows.Forms.ToolStripMenuItem();
			this._tsModel = new System.Windows.Forms.ToolStripSplitButton();
			this._tsModelAll = new System.Windows.Forms.ToolStripMenuItem();
			this._tsModelSelected = new System.Windows.Forms.ToolStripMenuItem();
			this._tsModelCamera = new System.Windows.Forms.ToolStripMenuItem();
			this._tsRename = new System.Windows.Forms.ToolStripSplitButton();
			this._tsRenameAll = new System.Windows.Forms.ToolStripMenuItem();
			this._tsRenameSelected = new System.Windows.Forms.ToolStripMenuItem();
			this._tsExport = new System.Windows.Forms.ToolStripSplitButton();
			this._tsExportAll = new System.Windows.Forms.ToolStripMenuItem();
			this._tsExportSelected = new System.Windows.Forms.ToolStripMenuItem();
			this._pbFolder = new System.Windows.Forms.PictureBox();
			this._pbMenu = new System.Windows.Forms.PictureBox();
			this._cmnuMainFolder = new System.Windows.Forms.ToolStripMenuItem();
			this._cmnuMainSettings = new System.Windows.Forms.ToolStripMenuItem();
			this._cmnuMainCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
			this._cmnuMainAbout = new System.Windows.Forms.ToolStripMenuItem();
			this._pnlStatus.SuspendLayout();
			this._cmnuMain.SuspendLayout();
			this._ts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._pbFolder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._pbMenu)).BeginInit();
			this.SuspendLayout();
			// 
			// _pnlStatus
			// 
			this._pnlStatus.BackColor = System.Drawing.SystemColors.Window;
			this._pnlStatus.Controls.Add(this._lblFolder);
			this._pnlStatus.Controls.Add(this._pbFolder);
			this._pnlStatus.Controls.Add(this._pbMenu);
			this._pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
			this._pnlStatus.ForeColor = System.Drawing.SystemColors.WindowText;
			this._pnlStatus.Location = new System.Drawing.Point(0, 0);
			this._pnlStatus.Name = "_pnlStatus";
			this._pnlStatus.Size = new System.Drawing.Size(752, 40);
			this._pnlStatus.TabIndex = 0;
			// 
			// _lblFolder
			// 
			this._lblFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this._lblFolder.AutoEllipsis = true;
			this._lblFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._lblFolder.Location = new System.Drawing.Point(36, 8);
			this._lblFolder.Margin = new System.Windows.Forms.Padding(0, 8, 3, 8);
			this._lblFolder.Name = "_lblFolder";
			this._lblFolder.Size = new System.Drawing.Size(677, 24);
			this._lblFolder.TabIndex = 1;
			this._lblFolder.Text = "Loading...";
			this._lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._lblFolder.DoubleClick += new System.EventHandler(this.folder_Click);
			// 
			// _cmnuMain
			// 
			this._cmnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._cmnuMainFolder,
            this._cmnuMainSettings,
            this._cmnuMainCheckUpdate,
            this._cmnuMainAbout});
			this._cmnuMain.Name = "_cmnuMain";
			this._cmnuMain.Size = new System.Drawing.Size(183, 122);
			// 
			// _ts
			// 
			this._ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this._ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsRescan,
            this._tsTimestamp,
            this._tsModel,
            this._tsRename,
            this._tsExport});
			this._ts.Location = new System.Drawing.Point(0, 40);
			this._ts.Name = "_ts";
			this._ts.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
			this._ts.Size = new System.Drawing.Size(752, 25);
			this._ts.TabIndex = 12;
			// 
			// _lv
			// 
			this._lv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lv.CheckBoxes = true;
			this._lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colOldName,
            this._colNewName,
            this._colMessage});
			this._lv.Dock = System.Windows.Forms.DockStyle.Fill;
			this._lv.FullRowSelect = true;
			this._lv.HideSelection = false;
			this._lv.Location = new System.Drawing.Point(0, 65);
			this._lv.Name = "_lv";
			this._lv.Size = new System.Drawing.Size(752, 376);
			this._lv.SmallImageList = this._il;
			this._lv.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this._lv.TabIndex = 13;
			this._lv.UseCompatibleStateImageBehavior = false;
			this._lv.View = System.Windows.Forms.View.Details;
			this._lv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this._lv_ItemChecked);
			// 
			// _colOldName
			// 
			this._colOldName.Text = "Original";
			this._colOldName.Width = 150;
			// 
			// _colNewName
			// 
			this._colNewName.Text = "New";
			this._colNewName.Width = 240;
			// 
			// _colMessage
			// 
			this._colMessage.Text = "Message";
			this._colMessage.Width = 300;
			// 
			// _il
			// 
			this._il.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this._il.ImageSize = new System.Drawing.Size(16, 16);
			this._il.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// _fbdOpen
			// 
			this._fbdOpen.Description = "Choose a folder with photos that need to be renamed.";
			this._fbdOpen.ShowNewFolderButton = false;
			// 
			// _fbdExport
			// 
			this._fbdExport.Description = "Choose a folder to copy files into using the new names.";
			// 
			// _tsRescan
			// 
			this._tsRescan.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Refresh18;
			this._tsRescan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsRescan.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tsRescan.Name = "_tsRescan";
			this._tsRescan.Size = new System.Drawing.Size(66, 22);
			this._tsRescan.Text = "&Rescan";
			this._tsRescan.ToolTipText = "Rescan files in the current folder";
			this._tsRescan.Click += new System.EventHandler(this._tsRescan_Click);
			// 
			// _tsTimestamp
			// 
			this._tsTimestamp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsTimestampAll,
            this._tsTimestampSelected,
            this._tsTimestampCamera});
			this._tsTimestamp.Enabled = false;
			this._tsTimestamp.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Time18;
			this._tsTimestamp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsTimestamp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tsTimestamp.Name = "_tsTimestamp";
			this._tsTimestamp.Size = new System.Drawing.Size(113, 22);
			this._tsTimestamp.Text = "Adjust &Time...";
			this._tsTimestamp.ToolTipText = "Adjust time taken for all files in the folder";
			this._tsTimestamp.ButtonClick += new System.EventHandler(this._tsTimestampAll_Click);
			// 
			// _tsTimestampAll
			// 
			this._tsTimestampAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this._tsTimestampAll.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.All18;
			this._tsTimestampAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsTimestampAll.Name = "_tsTimestampAll";
			this._tsTimestampAll.Size = new System.Drawing.Size(157, 24);
			this._tsTimestampAll.Text = "&All Files...";
			this._tsTimestampAll.ToolTipText = "Adjust time taken for all files in the folder";
			this._tsTimestampAll.Click += new System.EventHandler(this._tsTimestampAll_Click);
			// 
			// _tsTimestampSelected
			// 
			this._tsTimestampSelected.Enabled = false;
			this._tsTimestampSelected.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Checked18;
			this._tsTimestampSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsTimestampSelected.Name = "_tsTimestampSelected";
			this._tsTimestampSelected.Size = new System.Drawing.Size(157, 24);
			this._tsTimestampSelected.Text = "Chec&ked Files...";
			this._tsTimestampSelected.ToolTipText = "Adjust time taken for files marked with a checkmark";
			this._tsTimestampSelected.Click += new System.EventHandler(this._tsTimestampSelected_Click);
			// 
			// _tsTimestampCamera
			// 
			this._tsTimestampCamera.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Camera18;
			this._tsTimestampCamera.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsTimestampCamera.Name = "_tsTimestampCamera";
			this._tsTimestampCamera.Size = new System.Drawing.Size(157, 24);
			this._tsTimestampCamera.Text = "By &Camera...";
			this._tsTimestampCamera.ToolTipText = "Adjust time taken for files with a specified camera name";
			this._tsTimestampCamera.Click += new System.EventHandler(this._tsTimestampCamera_Click);
			// 
			// _tsModel
			// 
			this._tsModel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsModelAll,
            this._tsModelSelected,
            this._tsModelCamera});
			this._tsModel.Enabled = false;
			this._tsModel.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Camera18;
			this._tsModel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsModel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tsModel.Name = "_tsModel";
			this._tsModel.Size = new System.Drawing.Size(148, 22);
			this._tsModel.Text = "Nickname &Camera...";
			this._tsModel.ToolTipText = "Change camera name for all files in the folder";
			this._tsModel.ButtonClick += new System.EventHandler(this._tsModelAll_Click);
			// 
			// _tsModelAll
			// 
			this._tsModelAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this._tsModelAll.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.All18;
			this._tsModelAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsModelAll.Name = "_tsModelAll";
			this._tsModelAll.Size = new System.Drawing.Size(157, 24);
			this._tsModelAll.Text = "&All Files...";
			this._tsModelAll.ToolTipText = "Change camera name for all files in the folder";
			this._tsModelAll.Click += new System.EventHandler(this._tsModelAll_Click);
			// 
			// _tsModelSelected
			// 
			this._tsModelSelected.Enabled = false;
			this._tsModelSelected.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Checked18;
			this._tsModelSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsModelSelected.Name = "_tsModelSelected";
			this._tsModelSelected.Size = new System.Drawing.Size(157, 24);
			this._tsModelSelected.Text = "Chec&ked Files...";
			this._tsModelSelected.ToolTipText = "Change camera name for files marked with a checkmark";
			this._tsModelSelected.Click += new System.EventHandler(this._tsModelSelected_Click);
			// 
			// _tsModelCamera
			// 
			this._tsModelCamera.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Camera18;
			this._tsModelCamera.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsModelCamera.Name = "_tsModelCamera";
			this._tsModelCamera.Size = new System.Drawing.Size(157, 24);
			this._tsModelCamera.Text = "By &Camera...";
			this._tsModelCamera.ToolTipText = "Change camera name for files with a specified camera name";
			this._tsModelCamera.Click += new System.EventHandler(this._tsModelCamera_Click);
			// 
			// _tsRename
			// 
			this._tsRename.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsRenameAll,
            this._tsRenameSelected});
			this._tsRename.Enabled = false;
			this._tsRename.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Rename18;
			this._tsRename.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsRename.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tsRename.Name = "_tsRename";
			this._tsRename.Size = new System.Drawing.Size(84, 22);
			this._tsRename.Text = "Re&name";
			this._tsRename.ButtonClick += new System.EventHandler(this._tsRenameAll_Click);
			// 
			// _tsRenameAll
			// 
			this._tsRenameAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this._tsRenameAll.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.All18;
			this._tsRenameAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsRenameAll.Name = "_tsRenameAll";
			this._tsRenameAll.Size = new System.Drawing.Size(122, 24);
			this._tsRenameAll.Text = "&All";
			this._tsRenameAll.Click += new System.EventHandler(this._tsRenameAll_Click);
			// 
			// _tsRenameSelected
			// 
			this._tsRenameSelected.Enabled = false;
			this._tsRenameSelected.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Checked18;
			this._tsRenameSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsRenameSelected.Name = "_tsRenameSelected";
			this._tsRenameSelected.Size = new System.Drawing.Size(122, 24);
			this._tsRenameSelected.Text = "Chec&ked";
			this._tsRenameSelected.Click += new System.EventHandler(this._tsRenameSelected_Click);
			// 
			// _tsExport
			// 
			this._tsExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsExportAll,
            this._tsExportSelected});
			this._tsExport.Enabled = false;
			this._tsExport.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Export18;
			this._tsExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._tsExport.Name = "_tsExport";
			this._tsExport.Size = new System.Drawing.Size(84, 22);
			this._tsExport.Text = "E&xport...";
			this._tsExport.ButtonClick += new System.EventHandler(this._tsExportAll_Click);
			// 
			// _tsExportAll
			// 
			this._tsExportAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this._tsExportAll.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.All18;
			this._tsExportAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsExportAll.Name = "_tsExportAll";
			this._tsExportAll.Size = new System.Drawing.Size(131, 24);
			this._tsExportAll.Text = "&All...";
			this._tsExportAll.Click += new System.EventHandler(this._tsExportAll_Click);
			// 
			// _tsExportSelected
			// 
			this._tsExportSelected.Enabled = false;
			this._tsExportSelected.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Checked18;
			this._tsExportSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._tsExportSelected.Name = "_tsExportSelected";
			this._tsExportSelected.Size = new System.Drawing.Size(131, 24);
			this._tsExportSelected.Text = "Chec&ked...";
			this._tsExportSelected.Click += new System.EventHandler(this._tsExportSelected_Click);
			// 
			// _pbFolder
			// 
			this._pbFolder.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._pbFolder.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Folder24;
			this._pbFolder.Location = new System.Drawing.Point(4, 4);
			this._pbFolder.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
			this._pbFolder.Name = "_pbFolder";
			this._pbFolder.Size = new System.Drawing.Size(32, 32);
			this._pbFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this._pbFolder.TabIndex = 8;
			this._pbFolder.TabStop = false;
			this._pbFolder.Click += new System.EventHandler(this.folder_Click);
			// 
			// _pbMenu
			// 
			this._pbMenu.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this._pbMenu.ContextMenuStrip = this._cmnuMain;
			this._pbMenu.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Menu24;
			this._pbMenu.Location = new System.Drawing.Point(716, 4);
			this._pbMenu.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
			this._pbMenu.Name = "_pbMenu";
			this._pbMenu.Size = new System.Drawing.Size(32, 32);
			this._pbMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this._pbMenu.TabIndex = 7;
			this._pbMenu.TabStop = false;
			this._pbMenu.Click += new System.EventHandler(this._pbMenu_Click);
			// 
			// _cmnuMainFolder
			// 
			this._cmnuMainFolder.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Folder18;
			this._cmnuMainFolder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._cmnuMainFolder.Name = "_cmnuMainFolder";
			this._cmnuMainFolder.Size = new System.Drawing.Size(182, 24);
			this._cmnuMainFolder.Text = "Choose &Folder...";
			this._cmnuMainFolder.Click += new System.EventHandler(this.folder_Click);
			// 
			// _cmnuMainSettings
			// 
			this._cmnuMainSettings.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Settings18;
			this._cmnuMainSettings.Name = "_cmnuMainSettings";
			this._cmnuMainSettings.Size = new System.Drawing.Size(182, 24);
			this._cmnuMainSettings.Text = "&Settings...";
			this._cmnuMainSettings.Click += new System.EventHandler(this._cmnuMainSettings_Click);
			// 
			// _cmnuMainCheckUpdate
			// 
			this._cmnuMainCheckUpdate.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Update18;
			this._cmnuMainCheckUpdate.Name = "_cmnuMainCheckUpdate";
			this._cmnuMainCheckUpdate.Size = new System.Drawing.Size(182, 24);
			this._cmnuMainCheckUpdate.Text = "Check for &Update...";
			this._cmnuMainCheckUpdate.Click += new System.EventHandler(this._cmnuMainCheckUpdate_Click);
			// 
			// _cmnuMainAbout
			// 
			this._cmnuMainAbout.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.About18;
			this._cmnuMainAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this._cmnuMainAbout.Name = "_cmnuMainAbout";
			this._cmnuMainAbout.Size = new System.Drawing.Size(182, 24);
			this._cmnuMainAbout.Text = "&About";
			this._cmnuMainAbout.Click += new System.EventHandler(this._cmnuMainAbout_Click);
			// 
			// PhotoCombWindow
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(752, 441);
			this.Controls.Add(this._lv);
			this.Controls.Add(this._ts);
			this.Controls.Add(this._pnlStatus);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PhotoCombWindow";
			this.Text = "Photo Combine";
			this.Load += new System.EventHandler(this.PhotoComb_Load);
			this.Shown += new System.EventHandler(this.PhotoComb_Shown);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.PhotoComb_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PhotoComb_DragEnter);
			this._pnlStatus.ResumeLayout(false);
			this._cmnuMain.ResumeLayout(false);
			this._ts.ResumeLayout(false);
			this._ts.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._pbFolder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._pbMenu)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel _pnlStatus;
		private System.Windows.Forms.PictureBox _pbMenu;
		private System.Windows.Forms.ContextMenuStrip _cmnuMain;
		private System.Windows.Forms.ToolStripMenuItem _cmnuMainAbout;
		private System.Windows.Forms.Label _lblFolder;
		private System.Windows.Forms.PictureBox _pbFolder;
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
		private System.Windows.Forms.FolderBrowserDialog _fbdOpen;
		private System.Windows.Forms.FolderBrowserDialog _fbdExport;
		private System.Windows.Forms.ToolStripMenuItem _cmnuMainFolder;
		private System.Windows.Forms.ToolStripMenuItem _cmnuMainSettings;
		private System.Windows.Forms.ToolStripMenuItem _cmnuMainCheckUpdate;
	}
}