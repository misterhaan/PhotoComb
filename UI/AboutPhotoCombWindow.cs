using System;
using System.Diagnostics;
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
		}

		/// <summary>
		/// Show the version on the form.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void AboutMythClient_Load(object sender, EventArgs e) {
			_lblVersion.Text += Application.ProductVersion;
		}

		/// <summary>
		/// Open the project page URL in the default browser.
		/// </summary>
		/// <param name="sender">Not used</param>
		/// <param name="e">Not used</param>
		private void _lnkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start(_lnkURL.Text);
		}
	}
}
