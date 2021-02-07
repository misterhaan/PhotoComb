using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using au.Applications.PhotoComb.Settings.Types;

namespace au.Applications.PhotoComb.Settings {
	public class FilenameFormatSettings : IFilenameFormatSettings {
		private static readonly ISet<string> _allowedSeparators = new HashSet<string>(new string[] { "", ".", "-", "_" });

		/// <inheritdoc />
		public string DateSeparator {
			get { return _sepDate; }
			set {
				if(_allowedSeparators.Contains(value)) {
					_sepDate = value;
					UpdateFormatString();
					UpdateOutputFormat();
				}
			}
		}
		private string _sepDate = "";

		/// <inheritdoc />
		public string TimeSeparator {
			get { return _sepTime; }
			set {
				if(_allowedSeparators.Contains(value)) {
					_sepTime = value;
					UpdateFormatString();
					UpdateOutputFormat();
				}
			}
		}
		private string _sepTime = "";

		/// <inheritdoc />
		public string OverallSeparator {
			get { return _sepOverall; }
			set {
				if(_allowedSeparators.Contains(value)) {
					_sepOverall = value;
					UpdateFormatString();
					UpdateOutputFormat();
				}
			}
		}
		private string _sepOverall = "-";

		/// <inheritdoc />
		public bool ExpandJpegExtension { get; set; } = false;

		/// <inheritdoc />
		ISet<string> IFilenameFormatSettings.PhotoExtensions => PhotoExtensions;

		/// <summary>
		/// Non-interface member for serialization.
		/// </summary>
		public HashSet<string> PhotoExtensions { get; set; } = new HashSet<string>(new string[] { "jpeg", "jpg" }, StringComparer.OrdinalIgnoreCase);

		/// <inheritdoc />
		ISet<string> IFilenameFormatSettings.VideoExtensions => VideoExtensions;

		/// <summary>
		/// Non-interface member for serialization.
		/// </summary>
		public HashSet<string> VideoExtensions { get; set; } = new HashSet<string>(new string[] { "mp4", "mov", "avi" }, StringComparer.OrdinalIgnoreCase);

		/// <inheritdoc />
		[XmlIgnore]
		public string FormatString { get; private set; } = "{0:yyyyMMdd-HHmmss}-{1}{2}.{3}";

		/// <inheritdoc />
		[XmlIgnore]
		public Regex OutputFormat { get; private set; } = new Regex(@"^\d{8}-\d{6}-.+-[^-]+$");

		/// <summary>
		/// Rebuilds <cref>FormatString</cref> because a separator has changed.
		/// </summary>
		private void UpdateFormatString()
			=> FormatString = string.Format("{{0:yyyy'{0}'MM'{0}'dd'{2}'HH'{1}'mm'{1}'ss}}{2}{{1}}{{2}}.{{3}}", DateSeparator, TimeSeparator, OverallSeparator);

		/// <summary>
		/// Rebuilds <cref>OutputFormat</cref> because a separator has changed.
		/// </summary>
		private void UpdateOutputFormat()
			=> OutputFormat = new Regex(string.Format(@"^\d{{4}}{0}\d{{2}}{0}\d{{2}}{2}\d{{2}}{1}\d{{2}}{1}\d{{2}}{2}.+{2}[^{2}]+$", DateSeparator, TimeSeparator, OverallSeparator));
	}
}
