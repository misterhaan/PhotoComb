namespace au.Applications.PhotoComb.UI {
	partial class CameraNameDialog {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraNameDialog));
			this._lblCameraName = new System.Windows.Forms.Label();
			this._txtCameraName = new System.Windows.Forms.TextBox();
			this._cbModel = new System.Windows.Forms.ComboBox();
			this._lblWhich = new System.Windows.Forms.Label();
			this._btnCancel = new System.Windows.Forms.Button();
			this._btnAccept = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _lblCameraName
			// 
			this._lblCameraName.AutoSize = true;
			this._lblCameraName.Location = new System.Drawing.Point(12, 15);
			this._lblCameraName.Name = "_lblCameraName";
			this._lblCameraName.Size = new System.Drawing.Size(105, 13);
			this._lblCameraName.TabIndex = 0;
			this._lblCameraName.Text = "Set camera name to:";
			// 
			// _txtCameraName
			// 
			this._txtCameraName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._txtCameraName.Location = new System.Drawing.Point(123, 12);
			this._txtCameraName.Name = "_txtCameraName";
			this._txtCameraName.Size = new System.Drawing.Size(149, 20);
			this._txtCameraName.TabIndex = 1;
			// 
			// _cbModel
			// 
			this._cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cbModel.FormattingEnabled = true;
			this._cbModel.Location = new System.Drawing.Point(123, 38);
			this._cbModel.Name = "_cbModel";
			this._cbModel.Size = new System.Drawing.Size(149, 21);
			this._cbModel.TabIndex = 8;
			this._cbModel.Visible = false;
			this._cbModel.SelectedIndexChanged += new System.EventHandler(this.CbModel_SelectedIndexChanged);
			// 
			// _lblWhich
			// 
			this._lblWhich.AutoSize = true;
			this._lblWhich.Location = new System.Drawing.Point(12, 41);
			this._lblWhich.Name = "_lblWhich";
			this._lblWhich.Size = new System.Drawing.Size(104, 13);
			this._lblWhich.TabIndex = 7;
			this._lblWhich.Text = "for files from camera:";
			// 
			// _btnCancel
			// 
			this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(197, 76);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 10;
			this._btnCancel.Text = "&Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnAccept
			// 
			this._btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnAccept.Location = new System.Drawing.Point(116, 76);
			this._btnAccept.Name = "_btnAccept";
			this._btnAccept.Size = new System.Drawing.Size(75, 23);
			this._btnAccept.TabIndex = 9;
			this._btnAccept.Text = "&Accept";
			this._btnAccept.UseVisualStyleBackColor = true;
			// 
			// CameraNameDialog
			// 
			this.AcceptButton = this._btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 111);
			this.ControlBox = false;
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnAccept);
			this.Controls.Add(this._cbModel);
			this.Controls.Add(this._lblWhich);
			this.Controls.Add(this._txtCameraName);
			this.Controls.Add(this._lblCameraName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CameraNameDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Nickname Camera";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _lblCameraName;
		private System.Windows.Forms.TextBox _txtCameraName;
		private System.Windows.Forms.ComboBox _cbModel;
		private System.Windows.Forms.Label _lblWhich;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Button _btnAccept;
	}
}