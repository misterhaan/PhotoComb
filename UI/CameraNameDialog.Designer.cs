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
			_lblCameraName = new System.Windows.Forms.Label();
			_txtCameraName = new System.Windows.Forms.TextBox();
			_cbModel = new System.Windows.Forms.ComboBox();
			_lblWhich = new System.Windows.Forms.Label();
			_btnCancel = new System.Windows.Forms.Button();
			_btnAccept = new System.Windows.Forms.Button();
			SuspendLayout();
			// 
			// _lblCameraName
			// 
			_lblCameraName.AutoSize = true;
			_lblCameraName.Location = new System.Drawing.Point(14, 17);
			_lblCameraName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_lblCameraName.Name = "_lblCameraName";
			_lblCameraName.Size = new System.Drawing.Size(115, 15);
			_lblCameraName.TabIndex = 0;
			_lblCameraName.Text = "Set camera name to:";
			// 
			// _txtCameraName
			// 
			_txtCameraName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			_txtCameraName.Location = new System.Drawing.Point(144, 14);
			_txtCameraName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			_txtCameraName.Name = "_txtCameraName";
			_txtCameraName.Size = new System.Drawing.Size(173, 23);
			_txtCameraName.TabIndex = 1;
			// 
			// _cbModel
			// 
			_cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cbModel.FormattingEnabled = true;
			_cbModel.Location = new System.Drawing.Point(144, 44);
			_cbModel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			_cbModel.Name = "_cbModel";
			_cbModel.Size = new System.Drawing.Size(173, 23);
			_cbModel.TabIndex = 8;
			_cbModel.Visible = false;
			_cbModel.SelectedIndexChanged += CbModel_SelectedIndexChanged;
			// 
			// _lblWhich
			// 
			_lblWhich.AutoSize = true;
			_lblWhich.Location = new System.Drawing.Point(14, 47);
			_lblWhich.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_lblWhich.Name = "_lblWhich";
			_lblWhich.Size = new System.Drawing.Size(120, 15);
			_lblWhich.TabIndex = 7;
			_lblWhich.Text = "for files from camera:";
			// 
			// _btnCancel
			// 
			_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_btnCancel.Location = new System.Drawing.Point(230, 88);
			_btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			_btnCancel.Name = "_btnCancel";
			_btnCancel.Size = new System.Drawing.Size(88, 27);
			_btnCancel.TabIndex = 10;
			_btnCancel.Text = "&Cancel";
			_btnCancel.UseVisualStyleBackColor = true;
			// 
			// _btnAccept
			// 
			_btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			_btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
			_btnAccept.Location = new System.Drawing.Point(135, 88);
			_btnAccept.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			_btnAccept.Name = "_btnAccept";
			_btnAccept.Size = new System.Drawing.Size(88, 27);
			_btnAccept.TabIndex = 9;
			_btnAccept.Text = "&Accept";
			_btnAccept.UseVisualStyleBackColor = true;
			// 
			// CameraNameDialog
			// 
			AcceptButton = _btnAccept;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			CancelButton = _btnCancel;
			ClientSize = new System.Drawing.Size(331, 128);
			ControlBox = false;
			Controls.Add(_btnCancel);
			Controls.Add(_btnAccept);
			Controls.Add(_cbModel);
			Controls.Add(_lblWhich);
			Controls.Add(_txtCameraName);
			Controls.Add(_lblCameraName);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "CameraNameDialog";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Nickname Camera";
			ResumeLayout(false);
			PerformLayout();
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