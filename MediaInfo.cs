using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace au.Applications.PhotoComb {
	/// <summary>
	/// Interactions with the unmanaged MediaInfo DLL from https://mediaarea.net/.
	/// </summary>
	public class MediaInfo : IDisposable {
		private const string VERSION = "0.7.95.0";

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

		/// <summary>
		/// If nonzero, handle to the MediaInfo object.
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
			MediaInfo_Option(_handle, "Info_Version", string.Format("{0};{1};{2}", VERSION, Application.ProductName, Application.ProductVersion));
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
		/// Look up the camera model from the QuickTime field (MOV) or
		/// the encoding application (AVI).
		/// </summary>
		/// <returns>Camera model name, or null if not present.</returns>
		public string GetCameraModel() {
			return GetGeneral("com.apple.quicktime.model", "Encoded_Application");
		}

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
			if(DateTime.TryParseExact(taken, "ddd MMM d H:mm:ss yyyy", null, DateTimeStyles.AssumeLocal, out dt))
				return dt;
			return null;
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
		}

		/// <summary>
		/// Make sure the unmanaged resources are disposed if they haven't been yet
		/// when this object is cleaned up.
		/// </summary>
		~MediaInfo() {
			Dispose();
		}
	}
}
