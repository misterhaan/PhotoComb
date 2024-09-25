namespace au.Applications.PhotoComb.UI {
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
			_numOffsetHours = new System.Windows.Forms.NumericUpDown();
			_btnAccept = new System.Windows.Forms.Button();
			_btnCancel = new System.Windows.Forms.Button();
			_lblInstructions = new System.Windows.Forms.Label();
			_lblHoursAhead = new System.Windows.Forms.Label();
			_lblWhich = new System.Windows.Forms.Label();
			_cbModel = new System.Windows.Forms.ComboBox();
			_lblMinutesAhead = new System.Windows.Forms.Label();
			_numOffsetMinutes = new System.Windows.Forms.NumericUpDown();
			_numOffsetDays = new System.Windows.Forms.NumericUpDown();
			_lblDaysAhead = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)_numOffsetHours).BeginInit();
			((System.ComponentModel.ISupportInitialize)_numOffsetMinutes).BeginInit();
			((System.ComponentModel.ISupportInitialize)_numOffsetDays).BeginInit();
			SuspendLayout();
			// 
			// _numOffsetHours
			// 
			_numOffsetHours.Location = new System.Drawing.Point(117, 44);
			_numOffsetHours.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
			_numOffsetHours.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
			_numOffsetHours.Minimum = new decimal(new int[] { 24, 0, 0, int.MinValue });
			_numOffsetHours.Name = "_numOffsetHours";
			_numOffsetHours.Size = new System.Drawing.Size(56, 23);
			_numOffsetHours.TabIndex = 0;
			_numOffsetHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			_numOffsetHours.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// _btnAccept
			// 
			_btnAccept.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			_btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
			_btnAccept.Location = new System.Drawing.Point(135, 144);
			_btnAccept.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			_btnAccept.Name = "_btnAccept";
			_btnAccept.Size = new System.Drawing.Size(88, 27);
			_btnAccept.TabIndex = 6;
			_btnAccept.Text = "&Accept";
			_btnAccept.UseVisualStyleBackColor = true;
			// 
			// _btnCancel
			// 
			_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_btnCancel.Location = new System.Drawing.Point(230, 144);
			_btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			_btnCancel.Name = "_btnCancel";
			_btnCancel.Size = new System.Drawing.Size(88, 27);
			_btnCancel.TabIndex = 7;
			_btnCancel.Text = "&Cancel";
			_btnCancel.UseVisualStyleBackColor = true;
			// 
			// _lblInstructions
			// 
			_lblInstructions.AutoSize = true;
			_lblInstructions.Location = new System.Drawing.Point(14, 16);
			_lblInstructions.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
			_lblInstructions.Name = "_lblInstructions";
			_lblInstructions.Size = new System.Drawing.Size(100, 15);
			_lblInstructions.TabIndex = 8;
			_lblInstructions.Text = "Adjust time taken";
			// 
			// _lblHoursAhead
			// 
			_lblHoursAhead.AutoSize = true;
			_lblHoursAhead.Location = new System.Drawing.Point(176, 46);
			_lblHoursAhead.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
			_lblHoursAhead.Name = "_lblHoursAhead";
			_lblHoursAhead.Size = new System.Drawing.Size(71, 15);
			_lblHoursAhead.TabIndex = 1;
			_lblHoursAhead.Text = "hour(s) later";
			// 
			// _lblWhich
			// 
			_lblWhich.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			_lblWhich.AutoSize = true;
			_lblWhich.Location = new System.Drawing.Point(14, 107);
			_lblWhich.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_lblWhich.Name = "_lblWhich";
			_lblWhich.Size = new System.Drawing.Size(120, 15);
			_lblWhich.TabIndex = 4;
			_lblWhich.Text = "for files from camera:";
			// 
			// _cbModel
			// 
			_cbModel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			_cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			_cbModel.FormattingEnabled = true;
			_cbModel.Location = new System.Drawing.Point(142, 104);
			_cbModel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			_cbModel.Name = "_cbModel";
			_cbModel.Size = new System.Drawing.Size(174, 23);
			_cbModel.TabIndex = 5;
			_cbModel.Visible = false;
			// 
			// _lblMinutesAhead
			// 
			_lblMinutesAhead.AutoSize = true;
			_lblMinutesAhead.Location = new System.Drawing.Point(176, 16);
			_lblMinutesAhead.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
			_lblMinutesAhead.Name = "_lblMinutesAhead";
			_lblMinutesAhead.Size = new System.Drawing.Size(84, 15);
			_lblMinutesAhead.TabIndex = 10;
			_lblMinutesAhead.Text = "minute(s) later";
			// 
			// _numOffsetMinutes
			// 
			_numOffsetMinutes.Location = new System.Drawing.Point(117, 14);
			_numOffsetMinutes.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
			_numOffsetMinutes.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
			_numOffsetMinutes.Minimum = new decimal(new int[] { 60, 0, 0, int.MinValue });
			_numOffsetMinutes.Name = "_numOffsetMinutes";
			_numOffsetMinutes.Size = new System.Drawing.Size(56, 23);
			_numOffsetMinutes.TabIndex = 9;
			_numOffsetMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _numOffsetDays
			// 
			_numOffsetDays.Location = new System.Drawing.Point(117, 74);
			_numOffsetDays.Margin = new System.Windows.Forms.Padding(0, 3, 4, 3);
			_numOffsetDays.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
			_numOffsetDays.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
			_numOffsetDays.Name = "_numOffsetDays";
			_numOffsetDays.Size = new System.Drawing.Size(56, 23);
			_numOffsetDays.TabIndex = 2;
			_numOffsetDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _lblDaysAhead
			// 
			_lblDaysAhead.AutoSize = true;
			_lblDaysAhead.Location = new System.Drawing.Point(176, 76);
			_lblDaysAhead.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
			_lblDaysAhead.Name = "_lblDaysAhead";
			_lblDaysAhead.Size = new System.Drawing.Size(65, 15);
			_lblDaysAhead.TabIndex = 3;
			_lblDaysAhead.Text = "day(s) later";
			// 
			// TimespanDialog
			// 
			AcceptButton = _btnAccept;
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			CancelButton = _btnCancel;
			ClientSize = new System.Drawing.Size(331, 185);
			ControlBox = false;
			Controls.Add(_lblMinutesAhead);
			Controls.Add(_numOffsetMinutes);
			Controls.Add(_cbModel);
			Controls.Add(_lblWhich);
			Controls.Add(_lblDaysAhead);
			Controls.Add(_lblHoursAhead);
			Controls.Add(_lblInstructions);
			Controls.Add(_btnCancel);
			Controls.Add(_btnAccept);
			Controls.Add(_numOffsetDays);
			Controls.Add(_numOffsetHours);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TimespanDialog";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Adjust Time Taken";
			((System.ComponentModel.ISupportInitialize)_numOffsetHours).EndInit();
			((System.ComponentModel.ISupportInitialize)_numOffsetMinutes).EndInit();
			((System.ComponentModel.ISupportInitialize)_numOffsetDays).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.NumericUpDown _numOffsetHours;
		private System.Windows.Forms.Button _btnAccept;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.Label _lblInstructions;
		private System.Windows.Forms.Label _lblHoursAhead;
		private System.Windows.Forms.Label _lblWhich;
		private System.Windows.Forms.ComboBox _cbModel;
		private System.Windows.Forms.Label _lblMinutesAhead;
		private System.Windows.Forms.NumericUpDown _numOffsetMinutes;
		private System.Windows.Forms.NumericUpDown _numOffsetDays;
		private System.Windows.Forms.Label _lblDaysAhead;
	}
}