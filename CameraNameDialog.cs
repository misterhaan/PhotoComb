using System.Collections.Generic;
using System.Windows.Forms;

namespace au.Applications.PhotoComb {
	/// <summary>
	/// Dialog to ask for a camera nickname.
	/// </summary>
	public partial class CameraNameDialog : Form {
		/// <summary>
		/// Create a new camera nickname dialog that will work on the specified
		/// grouping type.
		/// </summary>
		/// <param name="grp">Which files will be affected</param>
		public CameraNameDialog(FileGroupType grp) {
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
			if(_cbModel.Items.Count > 0)
				_cbModel.SelectedIndex = 0;
		}

		/// <summary>
		/// The nickname value set on the form.
		/// </summary>
		public string Nickname { get { return _txtCameraName.Text; } }

		/// <summary>
		/// Camera model selected in the dropdown.
		/// </summary>
		public string CameraModel { get { return _cbModel.Text; } }

		/// <summary>
		/// When the camera model dropdown changes, put the model name into the
		/// nickname field unless something custom has been entered already.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _cbModel_SelectedIndexChanged(object sender, System.EventArgs e) {
			if(string.IsNullOrEmpty(_txtCameraName.Text) || _cbModel.Items.Contains(_txtCameraName.Text))
				_txtCameraName.Text = _cbModel.Text;
		}
	}
}
