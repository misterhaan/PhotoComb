using System.Threading.Tasks;

namespace au.IO.Files.Camera.MetadataLookup {
	/// <summary>
	/// Files with extensions not mapped to an actual lookup use this instead of doing metadata lookup.
	/// </summary>
	internal class UnknownMetadataLookup : MetadataLookupBase {
		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="file">File we don't know how to look up metadata for.</param>
		internal UnknownMetadataLookup(CameraFileInfo file) : base(file) { }

		/// <inheritdoc />
		internal override Task<CameraFileMetadata> GetAsync() {
			return Task.FromResult(CameraFileMetadata.Unknown);
		}
	}
}
