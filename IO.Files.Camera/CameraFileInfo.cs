using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using au.Applications.PhotoComb.Settings.Types;
using au.IO.Files.Camera.MetadataLookup;
using au.IO.Files.Camera.Types;

namespace au.IO.Files.Camera {
	/// <summary>
	/// Information about a file from a digital camera.
	/// </summary>
	internal partial class CameraFileInfo : ICameraFileInfo {
		/// <summary>
		/// Wrapped object (can't extend sealed class).
		/// </summary>
		private readonly FileInfo _file;

		/// <summary>
		/// How sortable filenames are formatted.
		/// </summary>
		private readonly IFilenameFormatSettings _fileFormat;

		/// <inheritdoc />
		public string Name => _file.Name;

		/// <inheritdoc />
		public string FullName => _file.FullName;

		/// <inheritdoc />
		public string Extension => _file.Extension[1..].ToLowerInvariant();

		/// <inheritdoc />
		public string ErrorMessage { get; set; }

		/// <inheritdoc />
		public Exception Exception { get; set; }

		/// <inheritdoc />
		public string CameraNameOverride { get; set; } = null;

		/// <inheritdoc />
		public TimeSpan TimeCorrection { get; set; } = TimeSpan.Zero;

		/// <inheritdoc />
		public ICameraFileMetadata Metadata { get; private set; } = CameraFileMetadata.NotLookedUp;

		/// <inheritdoc />
		public string SortableName {
			get {
				if(Metadata.Taken.HasValue) {
					string id = GetId();
					if(!string.IsNullOrEmpty(id))
						id = _fileFormat.OverallSeparator + id;
					string ext = Extension;
					if(ext == "jpg" && _fileFormat.ExpandJpegExtension)
						ext = "jpeg";
					return string.Format(_fileFormat.FormatString, Metadata.Taken.Value.Add(TimeCorrection), CameraNameOverride ?? Metadata.Model, id, ext);
				}
				return "";
			}
		}

		/// <inheritdoc />
		public Task LookupMetadata { get; }

		/// <summary>
		/// Initializes a new instance of the CameraFileInfo class, which acts as a wrapper for a file path.
		/// </summary>
		/// <param name="file">The new file.</param>
		/// <param name="fileFormat">How sortable filenames are formatted.</param>
		/// <param name="metadataFactory">How metadata is looked up.</param>
		internal CameraFileInfo(FileInfo file, IFilenameFormatSettings fileFormat, MetadataLookupFactory metadataFactory) {
			_file = file;
			_fileFormat = fileFormat;
			LookupMetadata = LookupMetadataAsync(metadataFactory);
		}

		/// <inheritdoc />
		public void RenameToSortable()
			=> _file.MoveTo(Path.Combine(_file.DirectoryName, SortableName));

		/// <inheritdoc />
		public void CopyTo(string destFileName)
			=> _file.CopyTo(destFileName);

		/// <inheritdoc />
		internal FileStream Open(FileMode mode, FileAccess access, FileShare share)
			=> _file.Open(mode, access, share);

		/// <summary>
		/// Get the unique part of the filename.  Often a sequential number.
		/// </summary>
		/// <returns>Unique part of the filename.</returns>
		private string GetId() {
			string id = Name[..^_file.Extension.Length];

#pragma warning disable IDE0046
			// default camera filenames 
			if((id.StartsWith("IMG_") || id.StartsWith("MVI_") || id.StartsWith("DSC")) && id.Length <= 12)
				return id[4..];
			// photo combine filename pattern (also contains date/time taken and camera nickname)
			if(_fileFormat.OutputFormat.IsMatch(id)) {
				string[] parts = id.Split('-');
				return parts[^1];
			}
			if(AndroidMotionPhotoExportRegex().IsMatch(id)) {
				string[] parts = id.Split('_');
				return parts[^2];
			}
			// multiple photos in same second adds a counter after the time portion of the filename
			if(MultipleInSameSecondRegex().IsMatch(id)) {
				string[] parts = id.Split('_');
				return parts[3];
			}
			// couldn't find an ID, so use the entire filename if it's mostly letters
			if(id.Length <= 12 || id.Count(char.IsLetter) * 2 > id.Length)
				return id;
			return "";
#pragma warning restore IDE0046
		}

		/// <summary>
		/// Asynchronous metadata lookup.
		/// </summary>
		private async Task LookupMetadataAsync(MetadataLookupFactory metadataFactory) {
			CameraFileMetadata metadata = await metadataFactory.Build(this).GetAsync().ConfigureAwait(false);
			if(metadata.Failed) {
				ErrorMessage = metadata.Message;
				Exception = metadata.Exception;
			}
			Metadata = metadata;
		}

		/// <summary>
		/// Indicates whether the current object references the same file as another.
		/// </summary>
		/// <param name="obj">Another object to compare.</param>
		/// <returns>Whether the objects reference the same file.</returns>
		public override bool Equals(object obj)
			=> obj is ICameraFileInfo cfi && Equals(cfi);

		/// <summary>
		/// Returns the hash code for this CameraFileInfo.
		/// </summary>
		/// <returns>Hash code for this CameraFileInfo.</returns>
		public override int GetHashCode()
			=> FullName.GetHashCode();

		/// <summary>
		/// Indicates whether the current object references the same file as another.
		/// </summary>
		/// <param name="other">Another object to compare.</param>
		/// <returns>Whether the objects reference the same file.</returns>
		public bool Equals(ICameraFileInfo other)
			=> FullName == other?.FullName;

		/// <summary>
		/// Equality operator for CameraFileInfo.
		/// </summary>
		/// <param name="cfi1">Object to compare.</param>
		/// <param name="cfi2">Another object to compare.</param>
		/// <returns>Whether the objects reference the same file.</returns>
		public static bool operator ==(CameraFileInfo cfi1, ICameraFileInfo cfi2)
			=> cfi1.Equals(cfi2);


		/// <summary>
		/// Equality operator for CameraFileInfo.
		/// </summary>
		/// <param name="cfi1">Object to compare.</param>
		/// <param name="cfi2">Another object to compare.</param>
		/// <returns>Whether the objects reference the same file.</returns>
		public static bool operator !=(CameraFileInfo cfi1, ICameraFileInfo cfi2)
			=> !cfi1.Equals(cfi2);

		[GeneratedRegex(@"^(MV)?IMG_[0-9]{8}_[0-9]{6}(_[0-9]+)?_exported_[0-9]+_[0-9]+$")]
		private static partial Regex AndroidMotionPhotoExportRegex();

		[GeneratedRegex(@"^(MV)?IMG_[0-9]{8}_[0-9]{6}_[0-9]+")]
		private static partial Regex MultipleInSameSecondRegex();
	}
}
