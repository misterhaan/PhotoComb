using System;

namespace au.IO.Files.Camera.Types {
	/// <summary>
	/// Metadata for a file from a digital camera.
	/// </summary>
	public interface ICameraFileMetadata {
		/// <summary>
		/// Whether metadata lookup failed.
		/// </summary>
		bool Failed { get; }

		/// <summary>
		/// What type of camera file this is.
		/// </summary>
		CameraFileType Type { get; }

		/// <summary>
		/// Camera model that took the picture or video.
		/// </summary>
		string Model { get; }

		/// <summary>
		/// Date and time the picture or video was taken.
		/// </summary>
		DateTime? Taken { get; }
	}
}
