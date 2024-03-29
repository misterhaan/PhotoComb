﻿namespace au.Applications.PhotoComb.UI {
	partial class AboutPhotoCombWindow {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutPhotoCombWindow));
			this.panel1 = new System.Windows.Forms.Panel();
			this._lblVersion = new System.Windows.Forms.Label();
			this._lblTitle = new System.Windows.Forms.Label();
			this._picIcon = new System.Windows.Forms.PictureBox();
			this._txtDescription = new System.Windows.Forms.TextBox();
			this._txtCopyright = new System.Windows.Forms.TextBox();
			this._lnkURL = new System.Windows.Forms.LinkLabel();
			this._btnOK = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._picIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.Controls.Add(this._lblVersion);
			this.panel1.Controls.Add(this._lblTitle);
			this.panel1.Controls.Add(this._picIcon);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(486, 55);
			this.panel1.TabIndex = 1;
			// 
			// _lblVersion
			// 
			this._lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._lblVersion.Location = new System.Drawing.Point(64, 32);
			this._lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this._lblVersion.Name = "_lblVersion";
			this._lblVersion.Size = new System.Drawing.Size(408, 15);
			this._lblVersion.TabIndex = 2;
			this._lblVersion.Text = "Version ";
			// 
			// _lblTitle
			// 
			this._lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._lblTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this._lblTitle.Location = new System.Drawing.Point(63, 7);
			this._lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this._lblTitle.Name = "_lblTitle";
			this._lblTitle.Size = new System.Drawing.Size(410, 25);
			this._lblTitle.TabIndex = 3;
			this._lblTitle.Text = "Photo Combine";
			this._lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// _picIcon
			// 
			this._picIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this._picIcon.Image = ((System.Drawing.Image)(resources.GetObject("_picIcon.Image")));
			this._picIcon.Location = new System.Drawing.Point(0, 0);
			this._picIcon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this._picIcon.Name = "_picIcon";
			this._picIcon.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
			this._picIcon.Size = new System.Drawing.Size(56, 55);
			this._picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this._picIcon.TabIndex = 1;
			this._picIcon.TabStop = false;
			// 
			// _txtDescription
			// 
			this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._txtDescription.Location = new System.Drawing.Point(18, 73);
			this._txtDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this._txtDescription.Multiline = true;
			this._txtDescription.Name = "_txtDescription";
			this._txtDescription.ReadOnly = true;
			this._txtDescription.Size = new System.Drawing.Size(455, 93);
			this._txtDescription.TabIndex = 5;
			this._txtDescription.TabStop = false;
			this._txtDescription.Text = resources.GetString("_txtDescription.Text");
			// 
			// _txtCopyright
			// 
			this._txtCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._txtCopyright.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._txtCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._txtCopyright.Location = new System.Drawing.Point(18, 186);
			this._txtCopyright.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this._txtCopyright.Multiline = true;
			this._txtCopyright.Name = "_txtCopyright";
			this._txtCopyright.ReadOnly = true;
			this._txtCopyright.Size = new System.Drawing.Size(350, 59);
			this._txtCopyright.TabIndex = 6;
			this._txtCopyright.TabStop = false;
			this._txtCopyright.Text = ".\r\nThis program may be distributed freely to anyone.\r\nSource code and updates are" +
    " available at:";
			// 
			// _lnkURL
			// 
			this._lnkURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._lnkURL.AutoSize = true;
			this._lnkURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._lnkURL.Location = new System.Drawing.Point(14, 241);
			this._lnkURL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this._lnkURL.Name = "_lnkURL";
			this._lnkURL.Size = new System.Drawing.Size(253, 16);
			this._lnkURL.TabIndex = 7;
			this._lnkURL.TabStop = true;
			this._lnkURL.Text = "http://www.track7.org/code/vs/photocomb";
			this._lnkURL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _btnOK
			// 
			this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnOK.Location = new System.Drawing.Point(385, 233);
			this._btnOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this._btnOK.Name = "_btnOK";
			this._btnOK.Size = new System.Drawing.Size(88, 27);
			this._btnOK.TabIndex = 8;
			this._btnOK.Text = "OK";
			this._btnOK.UseVisualStyleBackColor = true;
			// 
			// AboutPhotoCombWindow
			// 
			this.AcceptButton = this._btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnOK;
			this.ClientSize = new System.Drawing.Size(486, 273);
			this.ControlBox = false;
			this.Controls.Add(this._btnOK);
			this.Controls.Add(this._lnkURL);
			this.Controls.Add(this._txtCopyright);
			this.Controls.Add(this._txtDescription);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutPhotoCombWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this._picIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label _lblVersion;
		private System.Windows.Forms.Label _lblTitle;
		private System.Windows.Forms.PictureBox _picIcon;
		private System.Windows.Forms.TextBox _txtDescription;
		private System.Windows.Forms.TextBox _txtCopyright;
		private System.Windows.Forms.LinkLabel _lnkURL;
		private System.Windows.Forms.Button _btnOK;
	}
}