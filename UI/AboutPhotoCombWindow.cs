using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace au.Applications.PhotoComb.UI {
	/// <summary>
	/// About form for PhotoComb
	/// </summary>
	public partial class AboutPhotoCombWindow : Form {
		/// <summary>
		/// Create a new about form for PhotoComb.
		/// </summary>
		public AboutPhotoCombWindow() {
			InitializeComponent();
			_txtCopyright.Text = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).LegalCopyright + _txtCopyright.Text;
			_lblVersion.Text += Application.ProductVersion;
		}

		/// <summary>
		/// Open the project page URL in the default browser.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _lnkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> Process.Start(_lnkURL.Text);
	}
}
