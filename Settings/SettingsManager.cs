using System;
using System.IO;
using au.Settings;

namespace au.Applications.PhotoComb.Settings {
	/// <summary>
	/// Manages persistent settings for Photo Combine
	/// </summary>
	public class SettingsManager : SettingsFileManager<PhotoCombSettings> {
		/// <summary>
		/// Name of the settings file in local app data.
		/// </summary>
		private const string _filename = "PhotoComb.settings";

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SettingsManager() : base(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _filename)) { }
	}
}
