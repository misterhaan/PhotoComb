using System.IO;

namespace au.Applications.PhotoComb {
	/// <summary>
	/// Wrapper around System.IO.DirectoryInfo returning CameraFileInfo objects
	/// instead of System.IO.FileInfo objects.
	/// </summary>
	public class CameraDirectoryInfo {
		private DirectoryInfo _dir;  // have to wrap this instead of extending it because it's sealed

		/// <summary>
		/// Initializes a new instance of the CameraFileInfo class on the specified
		/// path.
		/// </summary>
		public CameraDirectoryInfo(string path) {
			_dir = new DirectoryInfo(path);
		}

		/// <summary>
		/// Returns a file list from the current directory.
		/// </summary>
		/// <returns>Array of CameraFileInfo objects for the files in the current directory</returns>
		public CameraFileInfo[] GetFiles() {
			FileInfo[] fis = _dir.GetFiles();
			CameraFileInfo[] cfis = new CameraFileInfo[fis.Length];
			for(int i = 0; i < fis.Length; i++)
				cfis[i] = new CameraFileInfo(fis[i]);
			return cfis;
		}
	}
}
