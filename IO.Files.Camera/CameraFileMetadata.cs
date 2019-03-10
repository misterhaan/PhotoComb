using System;
using au.IO.Files.Camera.Types;

namespace au.IO.Files.Camera {
	/// <inheritdoc />
	internal class CameraFileMetadata : ICameraFileMetadata {
		/// <inheritdoc />
		public bool Failed { get; }

		/// <summary>
		/// Error message when metadata lookup fails.
		/// </summary>
		internal string Message { get; }

		/// <summary>
		/// Exception when metadata lookup fails.
		/// </summary>
		internal Exception Exception { get; }

		/// <inheritdoc />
		public CameraFileType Type { get; }

		/// <inheritdoc />
		public string Model { get; }

		/// <inheritdoc />
		public DateTime? Taken { get; }

		/// <summary>
		/// Failure constructor.
		/// </summary>
		/// <param name="message">Failure message.</param>
		protected CameraFileMetadata(string message) {
			Type = CameraFileType.Unknown;
			Failed = true;
			Message = message;
		}

		/// <summary>
		/// Failure constructor.
		/// </summary>
		/// <param name="message">Failure message.</param>
		/// <param name="ex">Failure exception.</param>
		internal CameraFileMetadata(string message, Exception ex) : this(message) {
			Exception = ex;
		}

		/// <summary>
		/// Create camera file metadata.
		/// </summary>
		/// <param name="type">Type of camera file.</param>
		/// <param name="model">Camera model that took the picture or video.</param>
		/// <param name="taken">Date and time the picture or video was taken.</param>
		/// <returns>Camera file metadata.</returns>
		internal static CameraFileMetadata Create(CameraFileType type, string model, string taken) {
			return DateTime.TryParse(taken, out DateTime dateTimeTaken)
				? new CameraFileMetadata(type, model, dateTimeTaken)
				: new CameraFileMetadata(type, model);
		}

		/// <summary>
		/// Success constructor.
		/// </summary>
		/// <param name="model">Camera model that took the picture or video.</param>
		/// <param name="taken">Date and time the picture or video was taken.</param>
		internal CameraFileMetadata(CameraFileType type, string model, DateTime? taken) : this(type, model) {
			Taken = taken;
		}

		/// <summary>
		/// Success constructor without date/time taken.
		/// </summary>
		/// <param name="model">Camera model that took the picture or video.</param>
		private CameraFileMetadata(CameraFileType type, string model) {
			Type = type;
			Model = model;
		}

		/// <summary>
		/// Success constructor with date/time taken.
		/// </summary>
		/// <param name="model">Camera model that took the picture or video.</param>
		/// <param name="taken">Date and time the picture or video was taken.</param>
		private CameraFileMetadata(CameraFileType type, string model, DateTime taken) : this(type, model) {
			Taken = taken;
		}

		/// <summary>
		/// Initial state for CameraFileMetadata objects is not looked up.
		/// </summary>
		public static ICameraFileMetadata NotLookedUp => _notLookedUp.Value;

		/// <summary>
		/// Create the instance for NotLookedUp the first time it's requested.
		/// </summary>
		private static readonly Lazy<ICameraFileMetadata> _notLookedUp = new Lazy<ICameraFileMetadata>(() => new _notLookedUpCameraFileMetadata());

		/// <summary>
		/// Special-case class for metadata that hasn't been looked up yet.
		/// </summary>
		private class _notLookedUpCameraFileMetadata : CameraFileMetadata {
			internal _notLookedUpCameraFileMetadata() : base(Messages.MetadataNotLookedUp) { }
		}

		/// <summary>
		/// Files with unrecognized extensions don't get looked up.
		/// </summary>
		public static CameraFileMetadata Unknown => _unknown.Value;

		/// <summary>
		/// Create the instance for Unknown the first time it's requested.
		/// </summary>
		private static readonly Lazy<CameraFileMetadata> _unknown = new Lazy<CameraFileMetadata>(() => new _unknownCameraFileMetadata());

		/// <summary>
		/// Special-case class for metadata that could not be looked up.
		/// </summary>
		private class _unknownCameraFileMetadata : CameraFileMetadata {
			internal _unknownCameraFileMetadata() : base(Messages.UnknownExtension) { }
		}
	}
}
