using System;
using au.IO.Files.Camera.Types;

namespace au.IO.Files.Camera.MetadataLookup {
	/// <summary>
	/// Look up metadata using MediaInfo, which isn't particularly standardized but usually has values for videos.
	/// </summary>
	internal class MediaInfoMetadataLookup : MetadataLookupBase {
		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="file">Camera file to look up metadata for.</param>
		internal MediaInfoMetadataLookup(CameraFileInfo file) : base(file) { }

		/// <inheritdoc />
		protected override CameraFileMetadata Get() {
			using MediaInfo mediaInfo = new MediaInfo();
			try {
				mediaInfo.Open(_file.FullName);
				try {
					return new CameraFileMetadata(CameraFileType.Video, mediaInfo.GetCameraModel(), mediaInfo.GetDateTaken());
				} catch(Exception infoException) {
					return new CameraFileMetadata(Messages.MediaInfoReadError, infoException);
				} finally {
					mediaInfo.Close();
				}
			} catch(Exception videoException) {
				return new CameraFileMetadata(Messages.VideoReadError, videoException);
			}
		}
	}
}
