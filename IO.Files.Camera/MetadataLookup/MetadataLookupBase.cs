using System.Threading.Tasks;

namespace au.IO.Files.Camera.MetadataLookup {
	/// <summary>
	/// Base class for looking up metadata.
	/// </summary>
	internal abstract class MetadataLookupBase {
		/// <summary>
		/// File metadata is being looked up for.
		/// </summary>
		internal readonly CameraFileInfo _file;

		/// <summary>
		/// Default constructor.  Child classes need to call this so ID property works.
		/// </summary>
		/// <param name="file">Camera file to look up metadata for.</param>
		internal MetadataLookupBase(CameraFileInfo file) {
			_file = file;
		}

		/// <summary>
		/// Get metadata for the file.
		/// </summary>
		/// <returns>Metadata</returns>
		internal async Task<CameraFileMetadata> GetAsync()
			=> await Task.Run(Get).ConfigureAwait(false);

		/// <summary>
		/// Get metadata for the file.
		/// </summary>
		/// <returns>Metadata</returns>
		protected abstract CameraFileMetadata Get();
	}
}
