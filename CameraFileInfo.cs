using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Media.Imaging;

namespace au.Applications.PhotoComb {
	/// <summary>
	/// Wrapper around System.IO.FileInfo adding metadata lookup for photo and
	/// video files from digital cameras.
	/// </summary>
	public class CameraFileInfo {
		private FileInfo _file;  // have to wrap this instead of extending it because it's sealed
		private CameraFileType _type = CameraFileType.Unknown;
		private string _model = null;
		private DateTime? _taken = null;
		private string _errorPhoto = null;
		private string _errorVideo = null;

		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		public string Name { get { return _file.Name; } }
		/// <summary>
		/// Type of file, determined by being able to read its metadata.
		/// </summary>
		public CameraFileType Type { get { return _type; } }
		/// <summary>
		/// Camera model name from metadata, or the camera nickname.
		/// </summary>
		public string Model { get { return _model; } set { _model = value; } }
		/// <summary>
		/// Date photo or video was taken (from metadata, if available).
		/// </summary>
		public DateTime? Taken { get { return _taken; } set { _taken = value; } }
		/// <summary>
		/// Error encountered while looking up metadata, or null for success.
		/// </summary>
		public string Error { get { return _errorPhoto ?? _errorVideo; } }

		/// <summary>
		/// Initializes a new instance of the CameraFileInfo class, which acts as a wrapper for a file path.
		/// </summary>
		/// <param name="file">The new file.</param>
		public CameraFileInfo(FileInfo file) {
			_file = file;
			switch(_file.Extension.ToLowerInvariant()) {
				case ".avi":
				case ".mov":
					GetVideoMetadata();
					break;
				case ".jpeg":
				case ".jpg":
					GetPhotoMetadata();
					break;
				default:
					if(!GetPhotoMetadata())
						GetVideoMetadata();
					break;
			}
		}
		/// <summary>
		/// Initializes a new instance of the CameraFileInfo class, which acts as a wrapper for a file path.
		/// </summary>
		/// <param name="fileName">The fully qualified name of the new file, or the relative file name.  Do not end the path with the directory separator character.</param>
		public CameraFileInfo(string fileName) : this(new FileInfo(fileName)) { }

		/// <summary>
		/// The unique portion of a camera file name.  Usually this is a 4-digit
		/// sequential number.  If the file doesn't have a typical name pattern
		/// then ID is the filename without extension.
		/// </summary>
		public string ID {
			get {
				string id = _file.Name.Substring(0, _file.Name.Length - _file.Extension.Length);
				// default camera filenames 
				if(id.StartsWith("IMG_") || id.StartsWith("MVI_") || id.StartsWith("DSC"))
					return id.Substring(4);
				// photo combine filename pattern (also contains date/time taken and camera nickname)
				if(Regex.IsMatch(id, @"^[0-9]{8}-[0-9]{6}-.+-[^-]+$")) {
					string[] parts = id.Split('-');
					return parts[parts.Length - 1];
				}
				return id;
			}
		}

		/// <summary>
		/// Gets the string representing the extension part of the file the way it
		/// will be written for the renamed file.  Does not include the dot.
		/// </summary>
		public string Extension {
			get {
				string ext = _file.Extension.Substring(1).ToLowerInvariant();  // remove the dot and go lowercase
				return ext == "jpg" ? "jpeg" : ext;
			}
		}

		/// <summary>
		/// Moves the file to a new location, providing the option to
		/// specify a new file name.
		/// </summary>
		/// <param name="destFileName">The path to move the file to, which can specify a different file name.</param>
		public void MoveTo(string destFileName) {
			_file.MoveTo(destFileName);
		}

		/// <summary>
		/// Copies the file to a new file.
		/// </summary>
		/// <param name="destFileName">The name of the new file to copy to.</param>
		public void CopyTo(string destFileName) {
			_file.CopyTo(destFileName);
		}

		/// <summary>
		/// Read date taken and camera model from JPEG EXIF data.
		/// </summary>
		/// <returns>True if successful.</returns>
		private bool GetPhotoMetadata() {
			try {
				using(FileStream stream = _file.Open(FileMode.Open, FileAccess.Read, FileShare.Read)) {
					try {
						BitmapSource bmp = BitmapFrame.Create(stream);
						try {
							BitmapMetadata meta = (BitmapMetadata)bmp.Metadata;
							if(DateTime.TryParse(meta.DateTaken, out DateTime taken))
								_taken = taken;
							_model = meta.CameraModel;
							_type = CameraFileType.Photo;
							return true;
						} catch {
							_errorPhoto = Strings.ErrorExif;
						}
					} catch {
						_errorPhoto = Strings.ErrorImage;
					}
				}
			} catch {
				_errorPhoto = Strings.ErrorFile;
			}
			return false;
		}

		/// <summary>
		/// Shared object for reading metadata from video files.
		/// </summary>
		private static MediaInfo _mediaInfo = new MediaInfo();

		/// <summary>
		/// Read date taken and camera model from video metadata.
		/// Supports Quicktime, AVI, and probably others.
		/// </summary>
		/// <returns>True if successful.</returns>
		private bool GetVideoMetadata() {
			try {
				_mediaInfo.Open(_file.FullName);
				try {
					_taken = _mediaInfo.GetDateTaken();
					_model = _mediaInfo.GetCameraModel();
					_type = CameraFileType.Video;
					return true;
				} catch {
					_errorVideo = Strings.ErrorMetadata;
				}
				_mediaInfo.Close();
			} catch {
				_errorVideo = Strings.ErrorVideo;
			}
			return false;
		}
	}
}
