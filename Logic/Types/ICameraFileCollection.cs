using System;
using System.Collections.Generic;
using au.IO.Files.Camera.Types;

namespace au.Applications.PhotoComb.Logic.Types {
	public interface ICameraFileCollection {
		/// <summary>
		/// All camera names.
		/// </summary>
		ICollection<string> CameraNames { get; }

		/// <summary>
		/// All camera files.
		/// </summary>
		IEnumerable<ICameraFileInfo> Files { get; }

		/// <summary>
		/// Get files that match the specified list of names.
		/// </summary>
		/// <param name="filenames">List of filenames to get.</param>
		/// <returns>Files that match the list of names.</returns>
		IEnumerable<ICameraFileInfo> GetFilesFromNames(IEnumerable<string> filenames);

		/// <summary>
		/// Scans a directory for camera files.
		/// </summary>
		/// <param name="path">Path to directory to scan.</param>
		/// <returns>Camera files found in the directory.</returns>
		IEnumerable<ICameraFileInfo> ScanDirectory(string path);

		/// <summary>
		/// Correct the time taken by the specified amount for all files.
		/// </summary>
		/// <param name="correction">Amount of time to add to the time taken.</param>
		void ApplyTimeCorrection(TimeSpan correction);

		/// <summary>
		/// Correct the time taken by the specified amount for all files from the specified camera model.
		/// </summary>
		/// <param name="correction">Amount of time to add to the time taken.</param>
		/// <param name="model">Camera model or nickname.</param>
		void ApplyTimeCorrection(TimeSpan correction, string model);

		/// <summary>
		/// Correct the time taken by the specified amount for the specified files.
		/// </summary>
		/// <param name="correction">Amount of time to add to the time taken.</param>
		/// <param name="filenames">Filenames that need time correction.</param>
		void ApplyTimeCorrection(TimeSpan correction, IEnumerable<string> filenames);

		/// <summary>
		/// Set the camera nickname for all files.
		/// </summary>
		/// <param name="nickname">New camera nickname.</param>
		void SetCameraNickname(string nickname);

		/// <summary>
		/// Set the camera nickname for files with the specified camera name.
		/// </summary>
		/// <param name="nickname">New camera nickname.</param>
		/// <param name="oldCameraName">Current camera name of files to change.</param>
		void SetCameraNickname(string nickname, string oldCameraName);

		/// <summary>
		/// Set the camera nickname for the specified files.
		/// </summary>
		/// <param name="nickname">New camera nickname.</param>
		/// <param name="filenames">Which files should get the new nickname.</param>
		void SetCameraNickname(string nickname, IEnumerable<string> filenames);

		/// <summary>
		/// Renames all files to their sortable names.
		/// </summary>
		void RenameFilesToSortable();

		/// <summary>
		/// Renames the specified files to their sortable names.
		/// </summary>
		/// <param name="filenames">Names of files to rename.</param>
		void RenameFilesToSortable(IEnumerable<string> filenames);
	}
}
