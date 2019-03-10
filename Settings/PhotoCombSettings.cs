using System;
using System.IO;
using au.Applications.PhotoComb.Settings.Types;
using au.Settings;
using au.Settings.Types;

namespace au.Applications.PhotoComb.Settings {
	/// <summary>
	/// All Settings for Photo Combine.
	/// </summary>
	public class PhotoCombSettings : IPhotoCombSettings {
		/// <inheritdoc />
		public string LastSourceDir {
			get {
				return _lastSourceDir;
			}
			set {
				DirectoryInfo dir = new DirectoryInfo(value);
				while(!dir.Exists && dir.Parent != null)  // find nearest existing ancestor if possible
					dir = dir.Parent;
				if(dir.Exists)
					_lastSourceDir = dir.FullName;
			}
		}
		private string _lastSourceDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

		/// <inheritdoc />
		public string LastDestDir {
			get {
				return _lastDestDir;
			}
			set {
				DirectoryInfo dir = new DirectoryInfo(value);
				while(!dir.Exists && dir.Parent != null)  // find nearest existing ancestor if possible
					dir = dir.Parent;
				if(dir.Exists)
					_lastDestDir = dir.FullName;
			}
		}
		private string _lastDestDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

		/// <inheritdoc />
		IFilenameFormatSettings IPhotoCombSettings.FilenameFormat => FilenameFormat;

		/// <summary>
		/// Serializable FilenameFormat implementation.
		/// </summary>
		public FilenameFormatSettings FilenameFormat { get; set; } = new FilenameFormatSettings();

		/// <inheritdoc />
		IFormGeometrySettings IPhotoCombSettings.MainForm => MainForm;

		/// <summary>
		/// Serializable MainForm implementation.
		/// </summary>
		public FormGeometrySettings MainForm { get; set; } = new FormGeometrySettings();
	}
}
