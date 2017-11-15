using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace au.Applications.PhotoComb {
	/// <summary>
	/// Dialog to ask how many hours the time taken should be adjusted by.
	/// </summary>
	public partial class TimespanDialog : Form {
		/// <summary>
		/// Create a new camera nickname dialog that will work on the specified
		/// grouping type.
		/// </summary>
		/// <param name="grp">Which files will be affected</param>
		public TimespanDialog(FileGroupType grp) {
			InitializeComponent();
			switch(grp) {
				case FileGroupType.CameraModel:
					_lblWhich.Text = Strings.WhichCamera;
					_cbModel.Visible = true;
					break;
				case FileGroupType.Checked:
					_lblWhich.Text = Strings.WhichChecked;
					break;
				case FileGroupType.All:
				default:
					_lblWhich.Text = Strings.WhichAll;
					break;
			}
		}

		/// <summary>
		/// Sets the list of camera models.  Doesn't do anything unless the dialog
		/// was created with FileGroupType.CameraModel.
		/// </summary>
		/// <param name="keys">List of camera models, which is the keys from the _byModel Dictionary</param>
		public void SetModelList(Dictionary<string, List<ListViewItem>>.KeyCollection keys) {
			_cbModel.Items.Clear();
			foreach(string model in keys)
				_cbModel.Items.Add(model);
		}

		/// <summary>
		/// Time offset to adjust time taken by (will be added to time taken).
		/// </summary>
		public TimeSpan Offset { get {
				return TimeSpan.FromMinutes((double)_numOffsetMinutes.Value)
					+ TimeSpan.FromHours((double)_numOffsetHours.Value)
					+ TimeSpan.FromDays((double)_numOffsetDays.Value);
		} }

		/// <summary>
		/// Camera model selected in the dropdown.  Only meaningful when the dialog
		/// was created with FileGroupType.CameraModel.
		/// </summary>
		public string CameraModel { get { return _cbModel.Text; } }
	}
}
