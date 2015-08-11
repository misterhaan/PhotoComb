namespace au.Applications.PhotoComb {
  partial class PhotoComb {
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
      System.Windows.Forms.Label _lblSource;
      System.Windows.Forms.Label _lblDest;
      System.Windows.Forms.Label _lblInputMask;
      System.Windows.Forms.Label _lblOutputMask;
      System.Windows.Forms.Label _lblCamera;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoComb));
      this._fnbSource = new au.util.comctl.FoldernameBox();
      this._fnbDest = new au.util.comctl.FoldernameBox();
      this._txtInputMask = new System.Windows.Forms.TextBox();
      this._txtOutputPattern = new System.Windows.Forms.TextBox();
      this._chkKeepSource = new System.Windows.Forms.CheckBox();
      this._chkWriteDest = new System.Windows.Forms.CheckBox();
      this._btnRun = new System.Windows.Forms.Button();
      this._txtCamera = new System.Windows.Forms.TextBox();
      this._colOrigName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this._colNewName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this._lvResults = new System.Windows.Forms.ListView();
      _lblSource = new System.Windows.Forms.Label();
      _lblDest = new System.Windows.Forms.Label();
      _lblInputMask = new System.Windows.Forms.Label();
      _lblOutputMask = new System.Windows.Forms.Label();
      _lblCamera = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // _lblSource
      // 
      _lblSource.AutoSize = true;
      _lblSource.Location = new System.Drawing.Point(12, 15);
      _lblSource.Name = "_lblSource";
      _lblSource.Size = new System.Drawing.Size(94, 13);
      _lblSource.TabIndex = 0;
      _lblSource.Text = "Read photos from:";
      // 
      // _fnbSource
      // 
      this._fnbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._fnbSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this._fnbSource.BasePath = "";
      this._fnbSource.Description = "Select a directory where photos from multiple cameras are stored in subdirectorie" +
    "s.";
      this._fnbSource.FlatButton = true;
      this._fnbSource.FolderFullName = "";
      this._fnbSource.FolderMustExist = true;
      this._fnbSource.FolderName = "";
      this._fnbSource.LimitBase = false;
      this._fnbSource.Location = new System.Drawing.Point(140, 12);
      this._fnbSource.MaximumSize = new System.Drawing.Size(32767, 20);
      this._fnbSource.MinimumSize = new System.Drawing.Size(50, 20);
      this._fnbSource.Name = "_fnbSource";
      this._fnbSource.Size = new System.Drawing.Size(670, 20);
      this._fnbSource.StripBase = false;
      this._fnbSource.TabIndex = 1;
      // 
      // _lblDest
      // 
      _lblDest.AutoSize = true;
      _lblDest.Location = new System.Drawing.Point(12, 41);
      _lblDest.Name = "_lblDest";
      _lblDest.Size = new System.Drawing.Size(82, 13);
      _lblDest.TabIndex = 2;
      _lblDest.Text = "Write photos to:";
      // 
      // _fnbDest
      // 
      this._fnbDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._fnbDest.BasePath = "";
      this._fnbDest.Description = "";
      this._fnbDest.FlatButton = true;
      this._fnbDest.FolderFullName = "";
      this._fnbDest.FolderMustExist = true;
      this._fnbDest.FolderName = "";
      this._fnbDest.LimitBase = false;
      this._fnbDest.Location = new System.Drawing.Point(140, 38);
      this._fnbDest.MaximumSize = new System.Drawing.Size(32767, 20);
      this._fnbDest.MinimumSize = new System.Drawing.Size(50, 20);
      this._fnbDest.Name = "_fnbDest";
      this._fnbDest.Size = new System.Drawing.Size(670, 20);
      this._fnbDest.StripBase = false;
      this._fnbDest.TabIndex = 3;
      // 
      // _lblInputMask
      // 
      _lblInputMask.AutoSize = true;
      _lblInputMask.Location = new System.Drawing.Point(12, 67);
      _lblInputMask.Name = "_lblInputMask";
      _lblInputMask.Size = new System.Drawing.Size(122, 13);
      _lblInputMask.TabIndex = 4;
      _lblInputMask.Text = "Source filename pattern:";
      // 
      // _txtInputMask
      // 
      this._txtInputMask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._txtInputMask.Location = new System.Drawing.Point(140, 64);
      this._txtInputMask.Name = "_txtInputMask";
      this._txtInputMask.Size = new System.Drawing.Size(670, 20);
      this._txtInputMask.TabIndex = 5;
      this._txtInputMask.Text = "IMG_([0-9]+)\\.JPG";
      // 
      // _lblOutputMask
      // 
      _lblOutputMask.AutoSize = true;
      _lblOutputMask.Location = new System.Drawing.Point(12, 93);
      _lblOutputMask.Name = "_lblOutputMask";
      _lblOutputMask.Size = new System.Drawing.Size(120, 13);
      _lblOutputMask.TabIndex = 6;
      _lblOutputMask.Text = "Output filename pattern:";
      // 
      // _txtOutputPattern
      // 
      this._txtOutputPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._txtOutputPattern.Location = new System.Drawing.Point(140, 90);
      this._txtOutputPattern.Name = "_txtOutputPattern";
      this._txtOutputPattern.Size = new System.Drawing.Size(670, 20);
      this._txtOutputPattern.TabIndex = 7;
      this._txtOutputPattern.Text = "%DATE%-%TIME%-%CAMERA%-%NUM%.jpeg";
      // 
      // _chkKeepSource
      // 
      this._chkKeepSource.AutoSize = true;
      this._chkKeepSource.Checked = true;
      this._chkKeepSource.CheckState = System.Windows.Forms.CheckState.Checked;
      this._chkKeepSource.Enabled = false;
      this._chkKeepSource.Location = new System.Drawing.Point(241, 142);
      this._chkKeepSource.Name = "_chkKeepSource";
      this._chkKeepSource.Size = new System.Drawing.Size(107, 17);
      this._chkKeepSource.TabIndex = 11;
      this._chkKeepSource.Text = "Keep source files";
      this._chkKeepSource.UseVisualStyleBackColor = true;
      // 
      // _chkWriteDest
      // 
      this._chkWriteDest.AutoSize = true;
      this._chkWriteDest.Location = new System.Drawing.Point(140, 142);
      this._chkWriteDest.Name = "_chkWriteDest";
      this._chkWriteDest.Size = new System.Drawing.Size(95, 17);
      this._chkWriteDest.TabIndex = 10;
      this._chkWriteDest.Text = "Write new files";
      this._chkWriteDest.UseVisualStyleBackColor = true;
      this._chkWriteDest.CheckedChanged += new System.EventHandler(this._chkWriteDest_CheckedChanged);
      // 
      // _btnRun
      // 
      this._btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this._btnRun.Location = new System.Drawing.Point(735, 138);
      this._btnRun.Name = "_btnRun";
      this._btnRun.Size = new System.Drawing.Size(75, 23);
      this._btnRun.TabIndex = 12;
      this._btnRun.Text = "Run";
      this._btnRun.UseVisualStyleBackColor = true;
      this._btnRun.Click += new System.EventHandler(this._btnRun_Click);
      // 
      // _txtCamera
      // 
      this._txtCamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._txtCamera.Location = new System.Drawing.Point(140, 116);
      this._txtCamera.Name = "_txtCamera";
      this._txtCamera.Size = new System.Drawing.Size(670, 20);
      this._txtCamera.TabIndex = 9;
      // 
      // _lblCamera
      // 
      _lblCamera.AutoSize = true;
      _lblCamera.Location = new System.Drawing.Point(12, 119);
      _lblCamera.Name = "_lblCamera";
      _lblCamera.Size = new System.Drawing.Size(117, 13);
      _lblCamera.TabIndex = 8;
      _lblCamera.Text = "Override camera name:";
      // 
      // _colOrigName
      // 
      this._colOrigName.Text = "Original";
      this._colOrigName.Width = 161;
      // 
      // _colNewName
      // 
      this._colNewName.Text = "New";
      this._colNewName.Width = 584;
      // 
      // _lvResults
      // 
      this._lvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colOrigName,
            this._colNewName});
      this._lvResults.Location = new System.Drawing.Point(15, 165);
      this._lvResults.Name = "_lvResults";
      this._lvResults.Size = new System.Drawing.Size(795, 215);
      this._lvResults.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this._lvResults.TabIndex = 13;
      this._lvResults.UseCompatibleStateImageBehavior = false;
      this._lvResults.View = System.Windows.Forms.View.Details;
      // 
      // PhotoComb
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(822, 392);
      this.Controls.Add(_lblCamera);
      this.Controls.Add(this._txtCamera);
      this.Controls.Add(this._btnRun);
      this.Controls.Add(this._lvResults);
      this.Controls.Add(this._chkWriteDest);
      this.Controls.Add(this._chkKeepSource);
      this.Controls.Add(this._txtOutputPattern);
      this.Controls.Add(_lblOutputMask);
      this.Controls.Add(this._txtInputMask);
      this.Controls.Add(_lblInputMask);
      this.Controls.Add(this._fnbDest);
      this.Controls.Add(_lblDest);
      this.Controls.Add(this._fnbSource);
      this.Controls.Add(_lblSource);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "PhotoComb";
      this.Text = "Photo Combine";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PhotoComb_FormClosed);
      this.Load += new System.EventHandler(this.PhotoComb_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private au.util.comctl.FoldernameBox _fnbSource;
    private util.comctl.FoldernameBox _fnbDest;
    private System.Windows.Forms.TextBox _txtInputMask;
    private System.Windows.Forms.TextBox _txtOutputPattern;
    private System.Windows.Forms.CheckBox _chkKeepSource;
    private System.Windows.Forms.CheckBox _chkWriteDest;
    private System.Windows.Forms.Button _btnRun;
    private System.Windows.Forms.TextBox _txtCamera;
    private System.Windows.Forms.ColumnHeader _colOrigName;
    private System.Windows.Forms.ColumnHeader _colNewName;
    private System.Windows.Forms.ListView _lvResults;
  }
}

