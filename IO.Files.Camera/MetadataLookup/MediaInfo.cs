using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace au.IO.Files.Camera.MetadataLookup {
	/// <summary>
	/// Interactions with the unmanaged MediaInfo DLL from https://mediaarea.net/.
	/// </summary>
	internal class MediaInfo : IDisposable {
		/// <summary>
		/// Tested MediaInfo.DLL version
		/// </summary>
		private const string _dllVersion = "0.7.95.0";

		/// <summary>
		/// When nonzero, handle to the unmanaged MediaInfo object.
		/// </summary>
		private IntPtr _handle = IntPtr.Zero;

		/// <summary>
		/// Whether a file is open.
		/// </summary>
		private bool _opened = false;

		/// <summary>
		/// Create a new MediaInfo object.  One object can be used to read info from multiple media files.
		/// </summary>
		public MediaInfo() {
			_handle = MediaInfo_New();
			try {
				AssemblyName application = Assembly.GetEntryAssembly().GetName();
				MediaInfo_Option(_handle, "Info_Version", $"{_dllVersion};{application.Name};{application.Version}");
			} catch { } // if we couldn't get the application name and version, then just skip setting Info_Version
		}

		/// <summary>
		/// Open a media file.
		/// </summary>
		/// <param name="filename">Full path to the media file to open.</param>
		public void Open(string filename) {
			if(_opened)
				Close();
			MediaInfo_Open(_handle, filename);
			_opened = true;
		}

		/// <summary>
		/// Get information from the general section of the metadata.
		/// </summary>
		/// <param name="parameters">Name of the piece of information to retrieve.  First parameter with non-empty information will be used.</param>
		/// <returns>Information specified under the first parameter name that has a non-empty value.</returns>
		public string GetGeneral(params string[] parameters) {
			if(_handle != IntPtr.Zero && _opened) {
				foreach(string p in parameters) {
					string info = Marshal.PtrToStringUni(MediaInfo_Get(_handle, (IntPtr)StreamKind.General, (IntPtr)0, p, (IntPtr)1, (IntPtr)0));
					if(!string.IsNullOrEmpty(info))
						return info;
				}
			}
			return null;
		}

		/// <summary>
		/// Look up the camera model from the QuickTime field (MOV) or the encoding
		/// application (AVI).  If that's not there, then try @inf which Fuji seems
		/// to use.  Android M4V videos don't seem to include camera model at all.
		/// </summary>
		/// <returns>Camera model name, or null if not present.</returns>
		public string GetCameraModel()
			=> GetGeneral("com.apple.quicktime.model", "Encoded_Application", "@inf");

		/// <summary>
		/// Look up the date and time this video was taken.
		/// </summary>
		/// <returns>Date and time taken, or null if not present.</returns>
		public DateTime? GetDateTaken() {
			string taken = GetGeneral("Encoded_Date", "Mastered_Date");
			if(DateTime.TryParse(taken, out DateTime dt))
				return dt;
			// from Encoded_Date in iPhone and Canon QuickTime videos
			if(DateTime.TryParseExact(taken, "UTC yyyy-MM-dd H:mm:ss", null, DateTimeStyles.AssumeUniversal, out dt))
				return dt;
			// from Mastered_Date in Canon AVI videos
			return DateTime.TryParseExact(taken, "ddd MMM d H:mm:ss yyyy", null, DateTimeStyles.AssumeLocal, out dt)
				? (DateTime?)dt
				: null;
		}

		/// <summary>
		/// Close the file if one is currently opened.
		/// </summary>
		public void Close() {
			if(_opened) {
				MediaInfo_Close(_handle);
				_opened = false;
			}
		}

		/// <summary>
		/// Dispose of the unmanaged object.
		/// </summary>
		public void Dispose() {
			if(_handle != IntPtr.Zero) {
				Close();
				MediaInfo_Delete(_handle);
				_handle = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Make sure the unmanaged resources are disposed if they haven't been yet
		/// when this object is cleaned up.
		/// </summary>
		~MediaInfo() {
			Dispose();
		}

		#region MediaInfo.dll imports
		private enum StreamKind {
			General,
			Video,
			Audio,
			Text,
			Other,
			Image,
			Menu,
		}

		[DllImport("MediaInfo.dll")]
		private static extern IntPtr MediaInfo_New();
		[DllImport("MediaInfo.dll")]
		private static extern IntPtr MediaInfo_Option(IntPtr Handle, [MarshalAs(UnmanagedType.LPWStr)] string Option, [MarshalAs(UnmanagedType.LPWStr)] string Value);
		[DllImport("MediaInfo.dll")]
		private static extern IntPtr MediaInfo_Open(IntPtr Handle, [MarshalAs(UnmanagedType.LPWStr)] string FileName);
		[DllImport("MediaInfo.dll")]
		private static extern IntPtr MediaInfo_Get(IntPtr Handle, IntPtr StreamKind, IntPtr StreamNumber, [MarshalAs(UnmanagedType.LPWStr)] string Parameter, IntPtr KindOfInfo, IntPtr KindOfSearch);
		[DllImport("MediaInfo.dll")]
		private static extern void MediaInfo_Close(IntPtr Handle);
		[DllImport("MediaInfo.dll")]
		private static extern void MediaInfo_Delete(IntPtr Handle);
		#endregion MediaInfo.dll imports
	}
}
