namespace au.Applications.PhotoComb {
	partial class TimespanDialog {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimespanDialog));
			this._numOffset = new System.Windows.Forms.NumericUpDown();
			this._btnAccept = new System.Windows.Forms.Button();
			this._btnCancel = new System.Windows.Forms.Button();
			this._lblInstructions = new System.Windows.Forms.Label();
			this._lblHoursAhead = new System.Windows.Forms.Label();
			this._lblWhich = new System.Windows.Forms.Label();
			this._cbModel = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this._numOffset)).BeginInit();
			this.SuspendLayout();
			// 
			// _numOffset
			// 
			this._numOffset.Location = new System.Drawing.Point(100, 12);
			this._numOffset.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this._numOffset.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
			this._numOffset.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            -2147483648});
			this._numOffset.Name = "_numOffset";
			this._numOffset.Size = new System.Drawing.Size(48, 20);
			this._numOffset.TabIndex = 0;
			this._numOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._numOffset.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// _btnAccept
			// 
			this._btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._btnAccept.Location = new System.Drawing.Point(116, 73);
			this._btnAccept.Name = "_btnAccept";
			this._btnAccept.Size = new System.Drawing.Size(75, 23);
			this._btnAccept.TabIndex = 1;
			this._btnAccept.Text = "&Accept";
			this._btnAccept.UseVisualStyleBackColor = true;
			// 
			// _btnCancel
			// 
			this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnCancel.Location = new System.Drawing.Point(197, 73);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(75, 23);
			this._btnCancel.TabIndex = 2;
			this._btnCancel.Text = "&Cancel";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _lblInstructions
			// 
			this._lblInstructions.AutoSize = true;
			this._lblInstructions.Location = new System.Drawing.Point(12, 14);
			this._lblInstructions.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this._lblInstructions.Name = "_lblInstructions";
			this._lblInstructions.Size = new System.Drawing.Size(88, 13);
			this._lblInstructions.TabIndex = 3;
			this._lblInstructions.Text = "Adjust time taken";
			// 
			// _lblHoursAhead
			// 
			this._lblHoursAhead.AutoSize = true;
			this._lblHoursAhead.Location = new System.Drawing.Point(151, 14);
			this._lblHoursAhead.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this._lblHoursAhead.Name = "_lblHoursAhead";
			this._lblHoursAhead.Size = new System.Drawing.Size(62, 13);
			this._lblHoursAhead.TabIndex = 4;
			this._lblHoursAhead.Text = "hour(s) later";
			// 
			// _lblWhich
			// 
			this._lblWhich.AutoSize = true;
			this._lblWhich.Location = new System.Drawing.Point(12, 41);
			this._lblWhich.Name = "_lblWhich";
			this._lblWhich.Size = new System.Drawing.Size(104, 13);
			this._lblWhich.TabIndex = 5;
			this._lblWhich.Text = "for files from camera:";
			// 
			// _cbModel
			// 
			this._cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cbModel.FormattingEnabled = true;
			this._cbModel.Location = new System.Drawing.Point(122, 38);
			this._cbModel.Name = "_cbModel";
			this._cbModel.Size = new System.Drawing.Size(150, 21);
			this._cbModel.TabIndex = 6;
			this._cbModel.Visible = false;
			// 
			// TimespanDialog
			// 
			this.AcceptButton = this._btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 108);
			this.ControlBox = false;
			this.Controls.Add(this._cbModel);
			this.Controls.Add(this._lblWhich);
			this.Controls.Add(this._lblHoursAhead);
			this.Controls.Add(this._lblInstructions);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnAccept);
			this.Controls.Add(this._numOffset);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TimespanDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Adjust Time Taken";
			((System.ComponentModel.ISupportInitialize)(this._numOffset)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown _numOffset;
		private System.Windows.Forms.Button _btnAccept;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Label _lblInstructions;
		private System.Windows.Forms.Label _lblHoursAhead;
		private System.Windows.Forms.Label _lblWhich;
		private System.Windows.Forms.ComboBox _cbModel;
	}
}