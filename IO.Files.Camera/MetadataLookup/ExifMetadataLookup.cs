using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using au.IO.Files.Camera.Types;

namespace au.IO.Files.Camera.MetadataLookup {
	/// <summary>
	/// Look up metadata from EXIF data, which digital cameras should set for JPEG photos.
	/// </summary>
	internal class ExifMetadataLookup : MetadataLookupBase {
		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="file"></param>
		internal ExifMetadataLookup(CameraFileInfo file) : base(file) { }

		/// <inheritdoc />
		internal override async Task<CameraFileMetadata> GetAsync() {
			await Task.Yield();
			try {
				using(FileStream stream = _file.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
					try {
						BitmapSource bmp = BitmapFrame.Create(stream);
						try {
							BitmapMetadata meta = (BitmapMetadata)bmp.Metadata;
							return CameraFileMetadata.Create(CameraFileType.Photo, meta.CameraModel, meta.DateTaken);
						} catch(Exception exifException) {
							return new CameraFileMetadata(Messages.ExifReadError, exifException);
						}
					} catch(Exception bmpException) {
						return new CameraFileMetadata(Messages.ImageReadError, bmpException);
					}
			} catch(Exception fileException) {
				return new CameraFileMetadata(Messages.FileReadError, fileException);
			}
		}
	}
}
