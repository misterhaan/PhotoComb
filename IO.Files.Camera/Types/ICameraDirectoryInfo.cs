using System.Collections.Generic;

namespace au.IO.Files.Camera.Types {
	/// <summary>
	/// Information about a directory of files from a digital camera.
	/// </summary>
	public interface ICameraDirectoryInfo {
		/// <summary>
		/// Returns an enumerable collection of file information in the current directory.
		/// </summary>
		/// <returns>Enumerable collection of CameraFileInfo objects for the files in the current directory</returns>
		IEnumerable<ICameraFileInfo> EnumerateFiles();
	}
}
