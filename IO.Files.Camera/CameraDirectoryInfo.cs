using System.Collections.Generic;
using System.IO;
using System.Linq;
using au.Applications.PhotoComb.Settings.Types;
using au.IO.Files.Camera.MetadataLookup;
using au.IO.Files.Camera.Types;

namespace au.IO.Files.Camera {
	/// <summary>
	/// Information about a directory of files from a digital camera.
	/// </summary>
	/// <param name="path">Path to camera files.</param>
	/// <param name="fileFormat">How to format sortable filenames.</param>
	public class CameraDirectoryInfo(string path, IFilenameFormatSettings fileFormat) : ICameraDirectoryInfo {
		/// <summary>
		/// Wrapped instance (sealed class can't be extended).
		/// </summary>
		private readonly DirectoryInfo _dir = new(path);  // have to wrap this instead of extending it because it's sealed

		/// <summary>
		/// Returns an enumerable collection of file information in the current directory.
		/// </summary>
		/// <returns>Array of CameraFileInfo objects for the files in the current directory</returns>
		public IEnumerable<ICameraFileInfo> EnumerateFiles() {
			MetadataLookupFactory metadataLookup = new(fileFormat.PhotoExtensions, fileFormat.VideoExtensions);
			return _dir.EnumerateFiles().Select(fi => new CameraFileInfo(fi, fileFormat, metadataLookup));
		}
	}
}
