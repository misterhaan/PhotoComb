namespace au.Applications.PhotoComb.UI {
	partial class SettingsWindow {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
			this._picNaming = new System.Windows.Forms.PictureBox();
			this._lblNaming = new System.Windows.Forms.Label();
			this._lblDateSeparator = new System.Windows.Forms.Label();
			this._pnlDateSeparator = new System.Windows.Forms.Panel();
			this._radDateSeparatorDash = new System.Windows.Forms.RadioButton();
			this._radDateSeparatorPeriod = new System.Windows.Forms.RadioButton();
			this._radDateSeparatorNone = new System.Windows.Forms.RadioButton();
			this._pnlTimeSeparator = new System.Windows.Forms.Panel();
			this._radTimeSeparatorDash = new System.Windows.Forms.RadioButton();
			this._radTimeSeparatorPeriod = new System.Windows.Forms.RadioButton();
			this._radTimeSeparatorNone = new System.Windows.Forms.RadioButton();
			this._lblTimeSeparator = new System.Windows.Forms.Label();
			this._chkExpandJpeg = new System.Windows.Forms.CheckBox();
			this._pnlOverallSeparator = new System.Windows.Forms.Panel();
			this._radOverallSeparatorUnderscore = new System.Windows.Forms.RadioButton();
			this._radOverallSeparatorDash = new System.Windows.Forms.RadioButton();
			this._radOverallSeparatorPeriod = new System.Windows.Forms.RadioButton();
			this._lblOverallSeparator = new System.Windows.Forms.Label();
			this._picPhotoExtensions = new System.Windows.Forms.PictureBox();
			this._lblPhotoExtensions = new System.Windows.Forms.Label();
			this._txtPhotoExtensions = new System.Windows.Forms.TextBox();
			this._txtVideoExtensions = new System.Windows.Forms.TextBox();
			this._lblVideoExtensions = new System.Windows.Forms.Label();
			this._picVideoExtensions = new System.Windows.Forms.PictureBox();
			this._btnOk = new System.Windows.Forms.Button();
			this._btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this._picNaming)).BeginInit();
			this._pnlDateSeparator.SuspendLayout();
			this._pnlTimeSeparator.SuspendLayout();
			this._pnlOverallSeparator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._picPhotoExtensions)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._picVideoExtensions)).BeginInit();
			this.SuspendLayout();
			// 
			// _picNaming
			// 
			this._picNaming.BackColor = System.Drawing.SystemColors.Window;
			this._picNaming.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Rename18;
			this._picNaming.Location = new System.Drawing.Point(0, 0);
			this._picNaming.Name = "_picNaming";
			this._picNaming.Size = new System.Drawing.Size(40, 32);
			this._picNaming.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this._picNaming.TabIndex = 0;
			this._picNaming.TabStop = false;
			// 
			// _lblNaming
			// 
			this._lblNaming.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._lblNaming.BackColor = System.Drawing.SystemColors.Window;
			this._lblNaming.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._lblNaming.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._lblNaming.Location = new System.Drawing.Point(32, 0);
			this._lblNaming.Name = "_lblNaming";
			this._lblNaming.Size = new System.Drawing.Size(278, 32);
			this._lblNaming.TabIndex = 0;
			this._lblNaming.Text = "Naming";
			this._lblNaming.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _lblDateSeparator
			// 
			this._lblDateSeparator.AutoSize = true;
			this._lblDateSeparator.Location = new System.Drawing.Point(3, 6);
			this._lblDateSeparator.Name = "_lblDateSeparator";
			this._lblDateSeparator.Size = new System.Drawing.Size(65, 13);
			this._lblDateSeparator.TabIndex = 0;
			this._lblDateSeparator.Text = "Date format:";
			// 
			// _pnlDateSeparator
			// 
			this._pnlDateSeparator.Controls.Add(this._radDateSeparatorDash);
			this._pnlDateSeparator.Controls.Add(this._radDateSeparatorPeriod);
			this._pnlDateSeparator.Controls.Add(this._radDateSeparatorNone);
			this._pnlDateSeparator.Controls.Add(this._lblDateSeparator);
			this._pnlDateSeparator.Location = new System.Drawing.Point(36, 35);
			this._pnlDateSeparator.Name = "_pnlDateSeparator";
			this._pnlDateSeparator.Size = new System.Drawing.Size(118, 90);
			this._pnlDateSeparator.TabIndex = 1;
			// 
			// _radDateSeparatorDash
			// 
			this._radDateSeparatorDash.AutoSize = true;
			this._radDateSeparatorDash.Location = new System.Drawing.Point(15, 68);
			this._radDateSeparatorDash.Name = "_radDateSeparatorDash";
			this._radDateSeparatorDash.Size = new System.Drawing.Size(79, 17);
			this._radDateSeparatorDash.TabIndex = 3;
			this._radDateSeparatorDash.Tag = "";
			this._radDateSeparatorDash.Text = "2016-08-04";
			this._radDateSeparatorDash.UseVisualStyleBackColor = true;
			this._radDateSeparatorDash.CheckedChanged += new System.EventHandler(this.RadDateSeparator_CheckedChanged);
			// 
			// _radDateSeparatorPeriod
			// 
			this._radDateSeparatorPeriod.AutoSize = true;
			this._radDateSeparatorPeriod.Location = new System.Drawing.Point(15, 45);
			this._radDateSeparatorPeriod.Name = "_radDateSeparatorPeriod";
			this._radDateSeparatorPeriod.Size = new System.Drawing.Size(79, 17);
			this._radDateSeparatorPeriod.TabIndex = 2;
			this._radDateSeparatorPeriod.Tag = "";
			this._radDateSeparatorPeriod.Text = "2016.08.04";
			this._radDateSeparatorPeriod.UseVisualStyleBackColor = true;
			this._radDateSeparatorPeriod.CheckedChanged += new System.EventHandler(this.RadDateSeparator_CheckedChanged);
			// 
			// _radDateSeparatorNone
			// 
			this._radDateSeparatorNone.AutoSize = true;
			this._radDateSeparatorNone.Checked = true;
			this._radDateSeparatorNone.Location = new System.Drawing.Point(15, 22);
			this._radDateSeparatorNone.Name = "_radDateSeparatorNone";
			this._radDateSeparatorNone.Size = new System.Drawing.Size(73, 17);
			this._radDateSeparatorNone.TabIndex = 1;
			this._radDateSeparatorNone.TabStop = true;
			this._radDateSeparatorNone.Tag = "";
			this._radDateSeparatorNone.Text = "20160804";
			this._radDateSeparatorNone.UseVisualStyleBackColor = true;
			this._radDateSeparatorNone.CheckedChanged += new System.EventHandler(this.RadDateSeparator_CheckedChanged);
			// 
			// _pnlTimeSeparator
			// 
			this._pnlTimeSeparator.Controls.Add(this._radTimeSeparatorDash);
			this._pnlTimeSeparator.Controls.Add(this._radTimeSeparatorPeriod);
			this._pnlTimeSeparator.Controls.Add(this._radTimeSeparatorNone);
			this._pnlTimeSeparator.Controls.Add(this._lblTimeSeparator);
			this._pnlTimeSeparator.Location = new System.Drawing.Point(160, 35);
			this._pnlTimeSeparator.Name = "_pnlTimeSeparator";
			this._pnlTimeSeparator.Size = new System.Drawing.Size(115, 90);
			this._pnlTimeSeparator.TabIndex = 2;
			// 
			// _radTimeSeparatorDash
			// 
			this._radTimeSeparatorDash.AutoSize = true;
			this._radTimeSeparatorDash.Location = new System.Drawing.Point(15, 68);
			this._radTimeSeparatorDash.Name = "_radTimeSeparatorDash";
			this._radTimeSeparatorDash.Size = new System.Drawing.Size(67, 17);
			this._radTimeSeparatorDash.TabIndex = 3;
			this._radTimeSeparatorDash.Text = "22-33-44";
			this._radTimeSeparatorDash.UseVisualStyleBackColor = true;
			this._radTimeSeparatorDash.CheckedChanged += new System.EventHandler(this.RadTimeSeparator_CheckedChanged);
			// 
			// _radTimeSeparatorPeriod
			// 
			this._radTimeSeparatorPeriod.AutoSize = true;
			this._radTimeSeparatorPeriod.Location = new System.Drawing.Point(15, 45);
			this._radTimeSeparatorPeriod.Name = "_radTimeSeparatorPeriod";
			this._radTimeSeparatorPeriod.Size = new System.Drawing.Size(67, 17);
			this._radTimeSeparatorPeriod.TabIndex = 2;
			this._radTimeSeparatorPeriod.Text = "22.33.44";
			this._radTimeSeparatorPeriod.UseVisualStyleBackColor = true;
			this._radTimeSeparatorPeriod.CheckedChanged += new System.EventHandler(this.RadTimeSeparator_CheckedChanged);
			// 
			// _radTimeSeparatorNone
			// 
			this._radTimeSeparatorNone.AutoSize = true;
			this._radTimeSeparatorNone.Checked = true;
			this._radTimeSeparatorNone.Location = new System.Drawing.Point(15, 22);
			this._radTimeSeparatorNone.Name = "_radTimeSeparatorNone";
			this._radTimeSeparatorNone.Size = new System.Drawing.Size(61, 17);
			this._radTimeSeparatorNone.TabIndex = 1;
			this._radTimeSeparatorNone.TabStop = true;
			this._radTimeSeparatorNone.Text = "223344";
			this._radTimeSeparatorNone.UseVisualStyleBackColor = true;
			this._radTimeSeparatorNone.CheckedChanged += new System.EventHandler(this.RadTimeSeparator_CheckedChanged);
			// 
			// _lblTimeSeparator
			// 
			this._lblTimeSeparator.AutoSize = true;
			this._lblTimeSeparator.Location = new System.Drawing.Point(3, 6);
			this._lblTimeSeparator.Name = "_lblTimeSeparator";
			this._lblTimeSeparator.Size = new System.Drawing.Size(65, 13);
			this._lblTimeSeparator.TabIndex = 0;
			this._lblTimeSeparator.Text = "Time format:";
			// 
			// _chkExpandJpeg
			// 
			this._chkExpandJpeg.AutoSize = true;
			this._chkExpandJpeg.Location = new System.Drawing.Point(42, 131);
			this._chkExpandJpeg.Name = "_chkExpandJpeg";
			this._chkExpandJpeg.Size = new System.Drawing.Size(145, 17);
			this._chkExpandJpeg.TabIndex = 3;
			this._chkExpandJpeg.Text = "Expand JPEG extensions";
			this._chkExpandJpeg.UseVisualStyleBackColor = true;
			this._chkExpandJpeg.CheckedChanged += new System.EventHandler(this.ChkExpandJpeg_CheckedChanged);
			// 
			// _pnlOverallSeparator
			// 
			this._pnlOverallSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._pnlOverallSeparator.Controls.Add(this._radOverallSeparatorUnderscore);
			this._pnlOverallSeparator.Controls.Add(this._radOverallSeparatorDash);
			this._pnlOverallSeparator.Controls.Add(this._radOverallSeparatorPeriod);
			this._pnlOverallSeparator.Controls.Add(this._lblOverallSeparator);
			this._pnlOverallSeparator.Location = new System.Drawing.Point(36, 154);
			this._pnlOverallSeparator.Name = "_pnlOverallSeparator";
			this._pnlOverallSeparator.Size = new System.Drawing.Size(239, 90);
			this._pnlOverallSeparator.TabIndex = 4;
			// 
			// _radOverallSeparatorUnderscore
			// 
			this._radOverallSeparatorUnderscore.AutoSize = true;
			this._radOverallSeparatorUnderscore.Location = new System.Drawing.Point(15, 65);
			this._radOverallSeparatorUnderscore.Name = "_radOverallSeparatorUnderscore";
			this._radOverallSeparatorUnderscore.Size = new System.Drawing.Size(200, 17);
			this._radOverallSeparatorUnderscore.TabIndex = 3;
			this._radOverallSeparatorUnderscore.Text = "20160804_223344_iphone_1234.jpg";
			this._radOverallSeparatorUnderscore.UseVisualStyleBackColor = true;
			// 
			// _radOverallSeparatorDash
			// 
			this._radOverallSeparatorDash.AutoSize = true;
			this._radOverallSeparatorDash.Checked = true;
			this._radOverallSeparatorDash.Location = new System.Drawing.Point(15, 41);
			this._radOverallSeparatorDash.Name = "_radOverallSeparatorDash";
			this._radOverallSeparatorDash.Size = new System.Drawing.Size(191, 17);
			this._radOverallSeparatorDash.TabIndex = 2;
			this._radOverallSeparatorDash.TabStop = true;
			this._radOverallSeparatorDash.Text = "20160804-223344-iphone-1234.jpg";
			this._radOverallSeparatorDash.UseVisualStyleBackColor = true;
			// 
			// _radOverallSeparatorPeriod
			// 
			this._radOverallSeparatorPeriod.AutoSize = true;
			this._radOverallSeparatorPeriod.Location = new System.Drawing.Point(15, 17);
			this._radOverallSeparatorPeriod.Name = "_radOverallSeparatorPeriod";
			this._radOverallSeparatorPeriod.Size = new System.Drawing.Size(191, 17);
			this._radOverallSeparatorPeriod.TabIndex = 1;
			this._radOverallSeparatorPeriod.Tag = "";
			this._radOverallSeparatorPeriod.Text = "20160804.223344.iphone.1234.jpg";
			this._radOverallSeparatorPeriod.UseVisualStyleBackColor = true;
			// 
			// _lblOverallSeparator
			// 
			this._lblOverallSeparator.AutoSize = true;
			this._lblOverallSeparator.Location = new System.Drawing.Point(3, 0);
			this._lblOverallSeparator.Name = "_lblOverallSeparator";
			this._lblOverallSeparator.Size = new System.Drawing.Size(75, 13);
			this._lblOverallSeparator.TabIndex = 0;
			this._lblOverallSeparator.Text = "Overall format:";
			// 
			// _picPhotoExtensions
			// 
			this._picPhotoExtensions.BackColor = System.Drawing.SystemColors.Window;
			this._picPhotoExtensions.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Photo16;
			this._picPhotoExtensions.Location = new System.Drawing.Point(0, 259);
			this._picPhotoExtensions.Name = "_picPhotoExtensions";
			this._picPhotoExtensions.Size = new System.Drawing.Size(40, 32);
			this._picPhotoExtensions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this._picPhotoExtensions.TabIndex = 5;
			this._picPhotoExtensions.TabStop = false;
			// 
			// _lblPhotoExtensions
			// 
			this._lblPhotoExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._lblPhotoExtensions.BackColor = System.Drawing.SystemColors.Window;
			this._lblPhotoExtensions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._lblPhotoExtensions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._lblPhotoExtensions.Location = new System.Drawing.Point(32, 259);
			this._lblPhotoExtensions.Name = "_lblPhotoExtensions";
			this._lblPhotoExtensions.Size = new System.Drawing.Size(278, 32);
			this._lblPhotoExtensions.TabIndex = 5;
			this._lblPhotoExtensions.Text = "Photo Extensions";
			this._lblPhotoExtensions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _txtPhotoExtensions
			// 
			this._txtPhotoExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtPhotoExtensions.Location = new System.Drawing.Point(12, 297);
			this._txtPhotoExtensions.Name = "_txtPhotoExtensions";
			this._txtPhotoExtensions.Size = new System.Drawing.Size(286, 20);
			this._txtPhotoExtensions.TabIndex = 6;
			// 
			// _txtVideoExtensions
			// 
			this._txtVideoExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtVideoExtensions.Location = new System.Drawing.Point(12, 371);
			this._txtVideoExtensions.Name = "_txtVideoExtensions";
			this._txtVideoExtensions.Size = new System.Drawing.Size(286, 20);
			this._txtVideoExtensions.TabIndex = 8;
			// 
			// _lblVideoExtensions
			// 
			this._lblVideoExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._lblVideoExtensions.BackColor = System.Drawing.SystemColors.Window;
			this._lblVideoExtensions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._lblVideoExtensions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this._lblVideoExtensions.Location = new System.Drawing.Point(32, 333);
			this._lblVideoExtensions.Name = "_lblVideoExtensions";
			this._lblVideoExtensions.Size = new System.Drawing.Size(278, 32);
			this._lblVideoExtensions.TabIndex = 7;
			this._lblVideoExtensions.Text = "Video Extensions";
			this._lblVideoExtensions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _picVideoExtensions
			// 
			this._picVideoExtensions.BackColor = System.Drawing.SystemColors.Window;
			this._picVideoExtensions.Image = global::au.Applications.PhotoComb.UI.MaterialIcons.Video16;
			this._picVideoExtensions.Location = new System.Drawing.Point(0, 333);
			this._picVideoExtensions.Name = "_picVideoExtensions";
			this._picVideoExtensions.Size = new System.Drawing.Size(40, 32);
			this._picVideoExtensions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this._picVideoExtensions.TabIndex = 8;
			this._picVideoExtensions.TabStop = false;
			// 
			// _btnOk
			// 
			this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnOk.Location = new System.Drawing.Point(133, 408);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(75, 23);
			this._btnOk.TabIndex = 9;
			this._btnOk.Text = "OK";
			this._btnOk.UseVisualStyleBackColor = true;
			this._btnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// _btnCancel
			// 
			this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(223, 408);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 10;
			this._btnCancel.Text = "Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// SettingsWindow
			// 
			this.AcceptButton = this._btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(310, 443);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Controls.Add(this._txtVideoExtensions);
			this.Controls.Add(this._lblVideoExtensions);
			this.Controls.Add(this._picVideoExtensions);
			this.Controls.Add(this._txtPhotoExtensions);
			this.Controls.Add(this._lblPhotoExtensions);
			this.Controls.Add(this._picPhotoExtensions);
			this.Controls.Add(this._pnlOverallSeparator);
			this.Controls.Add(this._chkExpandJpeg);
			this.Controls.Add(this._lblNaming);
			this.Controls.Add(this._pnlTimeSeparator);
			this.Controls.Add(this._picNaming);
			this.Controls.Add(this._pnlDateSeparator);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "SettingsWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Photo Combine Settings";
			((System.ComponentModel.ISupportInitialize)(this._picNaming)).EndInit();
			this._pnlDateSeparator.ResumeLayout(false);
			this._pnlDateSeparator.PerformLayout();
			this._pnlTimeSeparator.ResumeLayout(false);
			this._pnlTimeSeparator.PerformLayout();
			this._pnlOverallSeparator.ResumeLayout(false);
			this._pnlOverallSeparator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._picPhotoExtensions)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._picVideoExtensions)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox _picNaming;
		private System.Windows.Forms.Label _lblNaming;
		private System.Windows.Forms.Label _lblDateSeparator;
		private System.Windows.Forms.Panel _pnlDateSeparator;
		private System.Windows.Forms.RadioButton _radDateSeparatorNone;
		private System.Windows.Forms.RadioButton _radDateSeparatorDash;
		private System.Windows.Forms.RadioButton _radDateSeparatorPeriod;
		private System.Windows.Forms.Panel _pnlTimeSeparator;
		private System.Windows.Forms.Label _lblTimeSeparator;
		private System.Windows.Forms.RadioButton _radTimeSeparatorDash;
		private System.Windows.Forms.RadioButton _radTimeSeparatorPeriod;
		private System.Windows.Forms.RadioButton _radTimeSeparatorNone;
		private System.Windows.Forms.CheckBox _chkExpandJpeg;
		private System.Windows.Forms.Panel _pnlOverallSeparator;
		private System.Windows.Forms.Label _lblOverallSeparator;
		private System.Windows.Forms.RadioButton _radOverallSeparatorUnderscore;
		private System.Windows.Forms.RadioButton _radOverallSeparatorDash;
		private System.Windows.Forms.RadioButton _radOverallSeparatorPeriod;
		private System.Windows.Forms.PictureBox _picPhotoExtensions;
		private System.Windows.Forms.Label _lblPhotoExtensions;
		private System.Windows.Forms.TextBox _txtPhotoExtensions;
		private System.Windows.Forms.TextBox _txtVideoExtensions;
		private System.Windows.Forms.Label _lblVideoExtensions;
		private System.Windows.Forms.PictureBox _picVideoExtensions;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Button _btnCancel;
	}
}