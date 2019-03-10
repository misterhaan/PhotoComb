using au.Settings.Types;

namespace au.Applications.PhotoComb.Settings.Types {
	/// <summary>
	/// All Settings for Photo Combine.
	/// </summary>
	public interface IPhotoCombSettings {
		/// <summary>
		/// The last directory files were read from.
		/// </summary>
		string LastSourceDir { get; set; }

		/// <summary>
		/// The last directory files were copied to.
		/// </summary>
		string LastDestDir { get; set; }

		/// <summary>
		/// Settings for formatting sortable filenames.
		/// </summary>
		IFilenameFormatSettings FilenameFormat { get; }

		/// <summary>
		/// Settings for opening the main form.
		/// </summary>
		IFormGeometrySettings MainForm { get; }
	}
}
