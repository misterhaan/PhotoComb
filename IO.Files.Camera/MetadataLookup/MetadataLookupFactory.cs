using System.Collections.Generic;

namespace au.IO.Files.Camera.MetadataLookup {
	internal class MetadataLookupFactory {
		private readonly ISet<string> _photoExtensions;
		private readonly ISet<string> _videoExtensions;

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="photoExtensions">Extensions (without dots) that should be treated as photos.</param>
		/// <param name="videoExtensions">Extensions (without dots) that should be treated as videos.</param>
		internal MetadataLookupFactory(ISet<string> photoExtensions, ISet<string> videoExtensions) {
			_photoExtensions = photoExtensions;
			_videoExtensions = videoExtensions;
		}

		/// <summary>
		/// Create the appropriate metadata lookup for the specified file.
		/// </summary>
		/// <param name="file">File whose metadata needs to be looked up.</param>
		/// <returns>Metadata lookup object.</returns>
		internal virtual MetadataLookupBase Build(CameraFileInfo file) {
			return _videoExtensions.Contains(file.Extension)
				? new MediaInfoMetadataLookup(file)
				: _photoExtensions.Contains(file.Extension)
					? new ExifMetadataLookup(file)
					: (MetadataLookupBase)new UnknownMetadataLookup(file);
		}
	}
}
