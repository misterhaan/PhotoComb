using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace au.IO.Files.Camera.MetadataLookup {
	/// <summary>
	/// EXIF metadata.
	/// </summary>
	internal class Exif {
		/// <summary>
		/// Metadata for the currently opened file.
		/// </summary>
		private readonly IReadOnlyList<MetadataExtractor.Directory> _metadata;

		/// <summary>
		/// Open an image file.
		/// </summary>
		/// <param name="filename">Full path to the image file to open.</param>
		public Exif(string filename) {
			using FileStream stream = File.OpenRead(filename);
			_metadata = ImageMetadataReader.ReadMetadata(stream);
		}

		/// <summary>
		/// Look up the camera model.
		/// </summary>
		/// <returns>Camera model name, or null if not present.</returns>
		public string GetCameraModel()
			=> _metadata?.OfType<ExifIfd0Directory>().FirstOrDefault()?.GetDescription(ExifDirectoryBase.TagModel);

		/// <summary>
		/// Look up the date and time the image was taken.
		/// </summary>
		/// <returns>Date and time taken, or null if not present.</returns>
		public DateTime? GetDateTaken() {
			string taken = _metadata?.OfType<ExifSubIfdDirectory>().FirstOrDefault()?.GetDescription(ExifDirectoryBase.TagDateTimeOriginal);
			return DateTime.TryParseExact(taken, "yyyy:MM:dd HH:mm:ss", null, DateTimeStyles.AssumeLocal, out DateTime dateTimeTaken)
				 ? dateTimeTaken
				 : null;
		}
	}
}
