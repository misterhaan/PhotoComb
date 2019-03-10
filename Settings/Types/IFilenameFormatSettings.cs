using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace au.Applications.PhotoComb.Settings.Types {
	public interface IFilenameFormatSettings {
		/// <summary>
		/// Separator character for date pieces.
		/// </summary>
		string DateSeparator { get; set; }

		/// <summary>
		/// Separator character for time pieces.
		/// </summary>
		string TimeSeparator { get; set; }

		/// <summary>
		/// Separator character for overall filename pieces.
		/// </summary>
		string OverallSeparator { get; set; }

		/// <summary>
		/// Whether files with jpg extension are renamed to jpeg.
		/// </summary>
		bool ExpandJpegExtension { get; set; }

		/// <summary>
		/// File extensions to treat as photos.
		/// </summary>
		ISet<string> PhotoExtensions { get; }

		/// <summary>
		/// File extensions to treat as videos.
		/// </summary>
		ISet<string> VideoExtensions { get; }

		/// <summary>
		/// Filename format string for use with string.Format(),
		/// with arguments date/time taken, camera name, ID, and extension.
		/// Does not take into account <cref>ExpandJpegExtension</cref>.
		/// </summary>
		string FormatString { get; }

		/// <summary>
		/// Regex for matching filenames that Photo Combine is set to use.
		/// </summary>
		Regex OutputFormat { get; }
	}
}
