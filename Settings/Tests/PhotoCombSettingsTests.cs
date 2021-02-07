using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using au.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.Applications.PhotoComb.Settings.Tests {
	[TestClass]
	public class PhotoCombSettingsTests {
		private const string _pathOnFakeDrive = @"W:\drive\does\not\exist";

		#region LastSourceDir
		[TestMethod]
		public void LastSourceDir_Exists_SetEqual() {
			PhotoCombSettings settings = GetSettings();
			string tmpPath = Path.GetTempPath();

			settings.LastSourceDir = tmpPath;

			Assert.IsTrue(Directory.Exists(tmpPath), "Test requires that the temporary path exists.");
			PathAssert.AreSame(tmpPath, settings.LastSourceDir, $"{nameof(settings.LastSourceDir)} should be the same path as it was set to when it exists.");
		}

		[DataTestMethod]
		[DataRow("doesNotExist")]
		[DataRow(@"does\not\exist")]
		public void LastSourceDir_ParentExists_SetParent(string subdirs) {
			PhotoCombSettings settings = GetSettings();
			string tmpPath = Path.GetTempPath();
			string childPath = Path.Combine(tmpPath, subdirs);

			settings.LastSourceDir = childPath;

			Assert.IsTrue(Directory.Exists(tmpPath), "Test requires that the temporary path exists.");
			Assert.IsFalse(Directory.Exists(Path.Combine(tmpPath, subdirs.Split('\\')[0])), "Test requires that none of the child path subdirectories exist.");
			PathAssert.AreSame(tmpPath, settings.LastSourceDir, $"{nameof(settings.LastSourceDir)} should be the first existing parent of the value it was set to.");
		}

		[TestMethod]
		public void LastSourceDir_NoParentExists_Unchanged() {
			PhotoCombSettings settings = GetSettings();
			string defaultPath = settings.LastSourceDir;

			settings.LastSourceDir = _pathOnFakeDrive;

			Assert.IsFalse(Directory.Exists(Path.GetPathRoot(_pathOnFakeDrive)), $"Test requires that there is no {_pathOnFakeDrive[0]} drive.");
			PathAssert.AreSame(defaultPath, settings.LastSourceDir, $"{nameof(settings.LastSourceDir)} should not change when set to a path on a drive that doesn't exist.");
		}
		#endregion LastSourceDir

		#region LastDestDir
		[TestMethod]
		public void LastDestDir_Exists_SetEqual() {
			PhotoCombSettings settings = GetSettings();
			string tmpPath = Path.GetTempPath();

			settings.LastDestDir = tmpPath;

			Assert.IsTrue(Directory.Exists(tmpPath), "Test requires that the temporary path exists.");
			PathAssert.AreSame(tmpPath, settings.LastDestDir, $"{nameof(settings.LastDestDir)} should be the same path as it was set to when it exists.");
		}

		[DataTestMethod]
		[DataRow("doesNotExist")]
		[DataRow(@"does\not\exist")]
		public void LastDestDir_ParentExists_SetParent(string subdirs) {
			PhotoCombSettings settings = GetSettings();
			string tmpPath = Path.GetTempPath();
			string childPath = Path.Combine(tmpPath, subdirs);

			settings.LastDestDir = childPath;

			Assert.IsTrue(Directory.Exists(tmpPath), "Test requires that the temporary path exists.");
			Assert.IsFalse(Directory.Exists(Path.Combine(tmpPath, subdirs.Split('\\')[0])), "Test requires that none of the child path subdirectories exist.");
			PathAssert.AreSame(tmpPath, settings.LastDestDir, $"{nameof(settings.LastDestDir)} should be the first existing parent of the value it was set to.");
		}

		[TestMethod]
		public void LastDestDir_NoParentExists_Unchanged() {
			PhotoCombSettings settings = GetSettings();
			string defaultPath = settings.LastDestDir;

			settings.LastDestDir = _pathOnFakeDrive;

			Assert.IsFalse(Directory.Exists(Path.GetPathRoot(_pathOnFakeDrive)), $"Test requires that there is no {_pathOnFakeDrive[0]} drive.");
			PathAssert.AreSame(defaultPath, settings.LastDestDir, $"{nameof(settings.LastDestDir)} should not change when set to a path on a drive that doesn't exist.");
		}
		#endregion LastDestDir

		[TestMethod]
		public void SaveLoad_PropertiesMatch() {
			FileInfo file = new FileInfo(Path.Combine(Path.GetTempPath(), $"{nameof(PhotoCombSettingsTests)}.{nameof(SaveLoad_PropertiesMatch)}.test"));
			try {
				SettingsFileManager<PhotoCombSettings> saveManager = new SettingsFileManager<PhotoCombSettings>(file);
				saveManager.Settings.LastDestDir = Environment.CurrentDirectory;
				saveManager.Settings.FilenameFormat = new FilenameFormatSettings {
					DateSeparator = "-",
					TimeSeparator = ".",
					OverallSeparator = "_",
					ExpandJpegExtension = true
				};
				saveManager.Settings.MainForm = new FormGeometrySettings {
					Location = new Point(1, 2),
					Size = new Size(1280, 720),
					WindowState = FormWindowState.Maximized
				};

				saveManager.Save();
				PhotoCombSettings loadedSettings = new SettingsFileManager<PhotoCombSettings>(file).Settings;

				Assert.AreEqual(saveManager.Settings.LastSourceDir, loadedSettings.LastSourceDir, $"{nameof(loadedSettings.LastSourceDir)} should be the same after saving and loading.");
				Assert.AreEqual(saveManager.Settings.LastDestDir, loadedSettings.LastDestDir, $"{nameof(loadedSettings.LastDestDir)} should be the same after saving and loading.");
				Assert.AreEqual(saveManager.Settings.FilenameFormat.DateSeparator, loadedSettings.FilenameFormat.DateSeparator, $"{nameof(loadedSettings.FilenameFormat)}.{nameof(loadedSettings.FilenameFormat.DateSeparator)} should be the same after saving and loading.");
				Assert.AreEqual(saveManager.Settings.FilenameFormat.TimeSeparator, loadedSettings.FilenameFormat.TimeSeparator, $"{nameof(loadedSettings.FilenameFormat)}.{nameof(loadedSettings.FilenameFormat.TimeSeparator)} should be the same after saving and loading.");
				Assert.AreEqual(saveManager.Settings.FilenameFormat.OverallSeparator, loadedSettings.FilenameFormat.OverallSeparator, $"{nameof(loadedSettings.FilenameFormat)}.{nameof(loadedSettings.FilenameFormat.OverallSeparator)} should be the same after saving and loading.");
				Assert.AreEqual(saveManager.Settings.FilenameFormat.ExpandJpegExtension, loadedSettings.FilenameFormat.ExpandJpegExtension, $"{nameof(loadedSettings.FilenameFormat)}.{nameof(loadedSettings.FilenameFormat.ExpandJpegExtension)} should be the same after saving and loading.");
				Assert.AreEqual(saveManager.Settings.MainForm.Location, loadedSettings.MainForm.Location, $"{nameof(loadedSettings.MainForm)}.{nameof(loadedSettings.MainForm.Location)} should be the same after saving and loading.");
				Assert.AreEqual(saveManager.Settings.MainForm.Size, loadedSettings.MainForm.Size, $"{nameof(loadedSettings.MainForm)}.{nameof(loadedSettings.MainForm.Size)} should be the same after saving and loading.");
				Assert.AreEqual(saveManager.Settings.MainForm.WindowState, loadedSettings.MainForm.WindowState, $"{nameof(loadedSettings.MainForm)}.{nameof(loadedSettings.MainForm.WindowState)} should be the same after saving and loading.");
			} finally {
				try { file.Delete(); } catch { }
			}
		}

		private static PhotoCombSettings GetSettings()
			=> new PhotoCombSettings();

		private static class PathAssert {
			public static void AreSame(string expectedPath, string actualPath, string message)
				=> Assert.AreEqual(Path.GetFullPath(expectedPath).TrimEnd(Path.DirectorySeparatorChar), Path.GetFullPath(actualPath).TrimEnd(Path.DirectorySeparatorChar), true, CultureInfo.InvariantCulture, message);  // should be ordinal not invariant, but that's not an option
		}
	}
}
