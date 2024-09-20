using System;
using System.Collections.Generic;
using System.Windows.Forms;
using au.Applications.PhotoComb.Settings.Types;

namespace au.Applications.PhotoComb.UI {
	/// <summary>
	/// Settings edit window.
	/// </summary>
	internal partial class SettingsWindow : Form {
		/// <summary>
		/// No separator.
		/// </summary>
		private const string _sepNone = "";

		/// <summary>
		/// Period separator.
		/// </summary>
		private const string _sepPeriod = ".";

		/// <summary>
		/// Dash separator.
		/// </summary>
		private const string _sepDash = "-";

		/// <summary>
		/// Underscore separator.
		/// </summary>
		private const string _sepUnderscore = "_";

		/// <summary>
		/// Delimiter for extension lists.
		/// </summary>
		private const string _extensionDelimiter = ";";

		/// <summary>
		/// Settings to edit.
		/// </summary>
		private readonly IPhotoCombSettings _settings;

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="settings">Settings to edit.</param>
		internal SettingsWindow(IPhotoCombSettings settings) {
			const string dateLabelFormat = "yyyy{0}MM{0}dd";
			const string timeLabelFormat = "HH{0}mm{0}ss";

			InitializeComponent();
			DateTime now = DateTime.Now;
			_radDateSeparatorNone.Text = now.ToString(string.Format(dateLabelFormat, _sepNone));
			_radDateSeparatorPeriod.Text = now.ToString(string.Format(dateLabelFormat, _sepPeriod));
			_radDateSeparatorDash.Text = now.ToString(string.Format(dateLabelFormat, _sepDash));
			_radTimeSeparatorNone.Text = now.ToString(string.Format(timeLabelFormat, _sepNone));
			_radTimeSeparatorPeriod.Text = now.ToString(string.Format(timeLabelFormat, _sepPeriod));
			_radTimeSeparatorDash.Text = now.ToString(string.Format(timeLabelFormat, _sepDash));

			_settings = settings;
			LoadSettings();
		}

		/// <summary>
		/// Copy current settings into the form.
		/// </summary>
		private void LoadSettings() {
			DateSeparator = _settings.FilenameFormat.DateSeparator;
			TimeSeparator = _settings.FilenameFormat.TimeSeparator;
			_chkExpandJpeg.Checked = _settings.FilenameFormat.ExpandJpegExtension;
			OverallSeparator = _settings.FilenameFormat.OverallSeparator;
			UpdateOverallSeparatorLabels();

			PhotoExtensions = _settings.FilenameFormat.PhotoExtensions;
			VideoExtensions = _settings.FilenameFormat.VideoExtensions;
		}

		/// <summary>
		/// Convenience property for setting and reading date separator in the UI.
		/// </summary>
		private string DateSeparator {
			get
				=> _radDateSeparatorDash.Checked
					? _sepDash
					: _radDateSeparatorPeriod.Checked
						? _sepPeriod
						: _sepNone;
			set {
				switch(value) {
					case _sepDash:
						_radDateSeparatorDash.Checked = true;
						break;
					case _sepPeriod:
						_radDateSeparatorPeriod.Checked = true;
						break;
					default:
						_radDateSeparatorNone.Checked = true;
						break;
				}
			}
		}

		/// <summary>
		/// Convenience property for setting and reading time separator in the UI.
		/// </summary>
		private string TimeSeparator {
			get
				=> _radTimeSeparatorDash.Checked
					? _sepDash
					: _radTimeSeparatorPeriod.Checked
						? _sepPeriod
						: _sepNone;
			set {
				switch(value) {
					case _sepDash:
						_radTimeSeparatorDash.Checked = true;
						break;
					case _sepPeriod:
						_radTimeSeparatorPeriod.Checked = true;
						break;
					default:
						_radTimeSeparatorNone.Checked = true;
						break;
				}
			}
		}

		/// <summary>
		/// Convenience property for setting and reading overall separator in the UI.
		/// </summary>
		private string OverallSeparator {
			get
				=> _radOverallSeparatorUnderscore.Checked
					? _sepUnderscore
					: _radOverallSeparatorPeriod.Checked
						? _sepPeriod
						: _sepDash;
			set {
				switch(value) {
					case _sepUnderscore:
						_radOverallSeparatorUnderscore.Checked = true;
						break;
					case _sepPeriod:
						_radOverallSeparatorPeriod.Checked = true;
						break;
					default:
						_radOverallSeparatorDash.Checked = true;
						break;
				}
			}
		}

		/// <summary>
		/// Convenience property for setting and reading photo extensions in the UI.
		/// </summary>
		private IEnumerable<string> PhotoExtensions {
			get { return _txtPhotoExtensions.Text.Split(_extensionDelimiter[0]); }
			set { _txtPhotoExtensions.Text = string.Join(_extensionDelimiter, value); }
		}

		/// <summary>
		/// Convenience property for setting and reading video extensions in the UI.
		/// </summary>
		private IEnumerable<string> VideoExtensions {
			get { return _txtVideoExtensions.Text.Split(_extensionDelimiter[0]); }
			set { _txtVideoExtensions.Text = string.Join(_extensionDelimiter, value); }
		}

		/// <summary>
		/// When the date or time separator or the expand JPEG setting change,
		/// update the overall separator labels to reflect the other settings.
		/// </summary>
		private void UpdateOverallSeparatorLabels() {
			const string overallLabelFormat = "{{0:yyyy'{0}'MM'{0}'dd'{3}'HH'{1}'mm'{1}'ss}}{3}iphone{3}1234.{2}";
			string dateSep = DateSeparator;
			string timeSep = TimeSeparator;
			string extension = _chkExpandJpeg.Checked ? "jpeg" : "jpg";
			DateTime now = DateTime.Now;
			_radOverallSeparatorPeriod.Text = string.Format(string.Format(overallLabelFormat, dateSep, timeSep, extension, _sepPeriod), now);
			_radOverallSeparatorDash.Text = string.Format(string.Format(overallLabelFormat, dateSep, timeSep, extension, _sepDash), now);
			_radOverallSeparatorUnderscore.Text = string.Format(string.Format(overallLabelFormat, dateSep, timeSep, extension, _sepUnderscore), now);
		}

		/// <summary>
		/// Saves the settings from the form back to the settings object.
		/// </summary>
		private void SaveSettings() {
			_settings.FilenameFormat.DateSeparator = DateSeparator;
			_settings.FilenameFormat.TimeSeparator = TimeSeparator;
			_settings.FilenameFormat.ExpandJpegExtension = _chkExpandJpeg.Checked;
			_settings.FilenameFormat.OverallSeparator = OverallSeparator;
			_settings.FilenameFormat.PhotoExtensions.Clear();
			_settings.FilenameFormat.PhotoExtensions.UnionWith(PhotoExtensions);
			_settings.FilenameFormat.VideoExtensions.Clear();
			_settings.FilenameFormat.VideoExtensions.UnionWith(VideoExtensions);
		}

		#region Event Handlers
		private void BtnOk_Click(object sender, EventArgs e)
			=> SaveSettings();

		private void RadDateSeparator_CheckedChanged(object sender, EventArgs e)
			=> UpdateOverallSeparatorLabels();

		private void RadTimeSeparator_CheckedChanged(object sender, EventArgs e)
			=> UpdateOverallSeparatorLabels();

		private void ChkExpandJpeg_CheckedChanged(object sender, EventArgs e)
			=> UpdateOverallSeparatorLabels();
		#endregion Event Handlers
	}
}
