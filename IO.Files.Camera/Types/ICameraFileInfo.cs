using System;
using System.Threading.Tasks;

namespace au.IO.Files.Camera.Types {
	/// <summary>
	/// Information about a file from a digital camera.
	/// </summary>
	public interface ICameraFileInfo : IEquatable<ICameraFileInfo> {
		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the full path of the file.
		/// </summary>
		string FullName { get; }

		/// <summary>
		/// Gets the string representing the extension part of the file.  Does not
		/// include the dot.
		/// </summary>
		string Extension { get; }

		/// <summary>
		/// Gets or sets the error message from the last failed operation.
		/// </summary>
		string ErrorMessage { get; set; }

		/// <summary>
		/// Exception from the last failed operation.
		/// </summary>
		Exception Exception { get; set; }

		/// <summary>
		/// User-entered name for the camera this file came from.
		/// </summary>
		string CameraNameOverride { get; set; }

		/// <summary>
		/// User-entered time correction for cameras that didn't have the date / time set correctly.
		/// </summary>
		TimeSpan TimeCorrection { get; set; }

		/// <summary>
		/// Properties that require opening the file to figure out.
		/// </summary>
		/// <remarks>
		/// Before accessing this, make sure LookupMetadata is complete.
		/// </remarks>
		ICameraFileMetadata Metadata { get; }

		/// <summary>
		/// Proposed filename that will sort by time taken and not overlap with files from other cameras.
		/// </summary>
		/// <remarks>
		/// Before accessing this, make sure LookupMetadata is complete.
		/// </remarks>
		string SortableName { get; }

		/// <summary>
		/// Metadata is looked up asynchronously because it has to look at file contents.
		/// </summary>
		Task LookupMetadata { get; }

		/// <summary>
		/// Renames the file to its sortable name.
		/// </summary>
		void RenameToSortable();

		/// <summary>
		/// Copies the file to a new file.
		/// </summary>
		/// <param name="destFileName">The name of the new file to copy to.</param>
		void CopyTo(string destFileName);
	}
}
