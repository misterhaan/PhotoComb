using System.Collections.Generic;
using System.Windows.Forms;

namespace au.Applications.PhotoComb.UI {
	/// <summary>
	/// Dialog to ask for a camera nickname.
	/// </summary>
	internal partial class CameraNameDialog : Form {
		/// <summary>
		/// Create a new camera nickname dialog that will work on the specified
		/// grouping type.
		/// </summary>
		/// <param name="fileGroupType">Which files will be affected</param>
		internal CameraNameDialog(FileGroupType fileGroupType) {
			InitializeComponent();
			_lblWhich.Text = fileGroupType.ToLabel();
			_cbModel.Visible = fileGroupType == FileGroupType.CameraModel;
		}

		/// <summary>
		/// Sets the list of camera models.  Doesn't do anything unless the dialog
		/// was created with FileGroupType.CameraModel.
		/// </summary>
		/// <param name="models">List of camera models.</param>
		internal void SetModelList(IEnumerable<string> models) {
			_cbModel.Items.Clear();
			foreach(string model in models)
				_cbModel.Items.Add(model);
			if(_cbModel.Items.Count > 0)
				_cbModel.SelectedIndex = 0;
		}

		/// <summary>
		/// The nickname value set on the form.
		/// </summary>
		internal string Nickname { get { return _txtCameraName.Text; } }

		/// <summary>
		/// Camera model selected in the dropdown.  Only meaningful when the dialog
		/// was created with FileGroupType.CameraModel.
		/// </summary>
		internal string CameraModel { get { return _cbModel.Text; } }

		/// <summary>
		/// When the camera model dropdown changes, put the model name into the
		/// nickname field unless something custom has been entered already.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void CbModel_SelectedIndexChanged(object sender, System.EventArgs e) {
			if(string.IsNullOrEmpty(_txtCameraName.Text) || _cbModel.Items.Contains(_txtCameraName.Text))
				_txtCameraName.Text = _cbModel.Text;
		}
	}
}
