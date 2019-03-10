using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace au.Applications.PhotoComb.UI {
	/// <summary>
	/// Dialog to ask how many hours the time taken should be adjusted by.
	/// </summary>
	internal partial class TimespanDialog : Form {
		/// <summary>
		/// Create a new camera nickname dialog that will work on the specified
		/// grouping type.
		/// </summary>
		/// <param name="grp">Which files will be affected</param>
		internal TimespanDialog(FileGroupType grp) {
			InitializeComponent();
			_lblWhich.Text = grp.ToLabel();
			_cbModel.Visible = grp == FileGroupType.CameraModel;
		}

		/// <summary>
		/// Sets the list of camera models.  Doesn't do anything unless the dialog
		/// was created with FileGroupType.CameraModel.
		/// </summary>
		/// <param name="keys">List of camera models, which is the keys from the _byModel Dictionary</param>
		internal void SetModelList(IEnumerable<string> keys) {
			_cbModel.Items.Clear();
			foreach(string model in keys)
				_cbModel.Items.Add(model);
		}

		/// <summary>
		/// Time offset to adjust time taken by (will be added to time taken).
		/// </summary>
		internal TimeSpan Offset {
			get {
				return TimeSpan.FromMinutes((double)_numOffsetMinutes.Value)
					+ TimeSpan.FromHours((double)_numOffsetHours.Value)
					+ TimeSpan.FromDays((double)_numOffsetDays.Value);
			}
		}

		/// <summary>
		/// Camera model selected in the dropdown.  Only meaningful when the dialog
		/// was created with FileGroupType.CameraModel.
		/// </summary>
		internal string CameraModel { get { return _cbModel.Text; } }
	}
}
