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
	public class CameraDirectoryInfo : ICameraDirectoryInfo {
		/// <summary>
		/// Wrapped instance (sealed class can't be extended).
		/// </summary>
		private readonly DirectoryInfo _dir;  // have to wrap this instead of extending it because it's sealed

		/// <summary>
		/// How sortable filenames are formatted.
		/// </summary>
		private readonly IFilenameFormatSettings _fileFormat;

		/// <summary>
		/// Initializes a new instance of the CameraDirectoryInfo class on the specified
		/// path.
		/// </summary>
		/// <param name="path">Path to camera files.</param>
		/// <param name="fileFormat">How to format sortable filenames.</param>
		public CameraDirectoryInfo(string path, IFilenameFormatSettings fileFormat) {
			_dir = new DirectoryInfo(path);
			_fileFormat = fileFormat;
		}

		/// <summary>
		/// Returns an enumerable collection of file information in the current directory.
		/// </summary>
		/// <returns>Array of CameraFileInfo objects for the files in the current directory</returns>
		public IEnumerable<ICameraFileInfo> EnumerateFiles() {
			MetadataLookupFactory metadataLookup = new MetadataLookupFactory(_fileFormat.PhotoExtensions, _fileFormat.VideoExtensions);
			return _dir.EnumerateFiles().Select(fi => new CameraFileInfo(fi, _fileFormat, metadataLookup));
		}
	}
}
