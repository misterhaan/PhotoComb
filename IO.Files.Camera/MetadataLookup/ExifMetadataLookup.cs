using System;
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
		protected override CameraFileMetadata Get() {
			try {
				Exif exif = new(_file.FullName);
				try {
					return new CameraFileMetadata(CameraFileType.Photo, exif.GetCameraModel(), exif.GetDateTaken());
				} catch(Exception exifException) {
					return new CameraFileMetadata(Messages.ExifReadError, exifException);
				}
			} catch(Exception imageException) {
				return new CameraFileMetadata(Messages.ImageReadError, imageException);
			}
		}
	}
}
