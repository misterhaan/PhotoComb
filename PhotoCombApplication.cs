using System;
using System.Windows.Forms;
using au.Applications.PhotoComb.Logic;
using au.Applications.PhotoComb.Settings;
using au.Applications.PhotoComb.UI;

namespace au.Applications.PhotoComb {
	internal static class PhotoCombApplication {
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			SettingsManager settingsManager = new SettingsManager();
			PhotoCombSettings settings = settingsManager.Settings;
			CameraFileCollection cameraFileCollection = new CameraFileCollection(settings);

			Application.Run(new PhotoCombWindow(settings, cameraFileCollection));

			settingsManager.Save();
		}
	}
}
