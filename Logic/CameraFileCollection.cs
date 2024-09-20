using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using au.Applications.PhotoComb.Logic.Types;
using au.Applications.PhotoComb.Settings.Types;
using au.IO.Files.Camera;
using au.IO.Files.Camera.Types;

namespace au.Applications.PhotoComb.Logic {
	/// <summary>
	/// Manages a collection of camera files.
	/// </summary>
	/// <param name="settings">Application settings.</param>
	public class CameraFileCollection(IPhotoCombSettings settings) : ICameraFileCollection {

		/// <summary>
		/// Camera files indexed by filename.
		/// </summary>
		private readonly Dictionary<string, ICameraFileInfo> _filenameIndex = new(StringComparer.OrdinalIgnoreCase);

		/// <summary>
		/// Camera files grouped by camera model.
		/// </summary>
		private readonly Dictionary<string, List<ICameraFileInfo>> _modelIndex = [];

		/// <inheritdoc />
		public ICollection<string> CameraNames => _modelIndex.Keys;

		/// <inheritdoc />
		public IEnumerable<ICameraFileInfo> Files => _filenameIndex.Values;

		/// <inheritdoc />
		public IEnumerable<ICameraFileInfo> GetFilesFromNames(IEnumerable<string> filenames)
			=> filenames.Select(filename => _filenameIndex[filename]);

		#region Initialization
		/// <inheritdoc />
		public IEnumerable<ICameraFileInfo> ScanDirectory(string path) {
			_filenameIndex.Clear();
			_modelIndex.Clear();
			CameraDirectoryInfo cdi = new(path, settings.FilenameFormat);
			foreach(ICameraFileInfo cfi in cdi.EnumerateFiles()) {
				_filenameIndex.Add(cfi.Name, cfi);
				Task.Run(() => UpdateModelIndexAsync(cfi));
				yield return cfi;
			}
		}

		/// <summary>
		/// Once metadata has been looked up, update the model index.
		/// </summary>
		/// <param name="cfi">Camera file to await and update.</param>
		/// <returns></returns>
		private async Task UpdateModelIndexAsync(ICameraFileInfo cfi) {
			await cfi.LookupMetadata.ConfigureAwait(false);
			if(_filenameIndex.ContainsKey(cfi.Name))  // it's possible for metadata lookup to finish after the application switched to a different folder
				lock(_modelIndex) {
					string model = cfi.CameraNameOverride ?? cfi.Metadata.Model ?? "";
					if(!_modelIndex.ContainsKey(model))
						_modelIndex[model] = [];
					if(!_modelIndex[model].Contains(cfi))
						_modelIndex[model].Add(cfi);
				}
		}
		#endregion Initialization

		#region Time Correction
		/// <inheritdoc />
		public void ApplyTimeCorrection(TimeSpan correction)
			=> ApplyTimeCorrection(correction, _filenameIndex.Values);

		/// <inheritdoc />
		public void ApplyTimeCorrection(TimeSpan correction, string model)
			=> ApplyTimeCorrection(correction, _modelIndex[model]);

		/// <inheritdoc />
		public void ApplyTimeCorrection(TimeSpan correction, IEnumerable<string> filenames)
			=> ApplyTimeCorrection(correction, GetFilesFromNames(filenames));

		/// <summary>
		/// Correct the time taken by the specified amount for the specified files.
		/// </summary>
		/// <param name="correction">Amount of time to add to the time taken.</param>
		private static void ApplyTimeCorrection(TimeSpan correction, IEnumerable<ICameraFileInfo> files) {
			foreach(ICameraFileInfo file in files)
				file.TimeCorrection += correction;
		}
		#endregion Time Correction

		#region Camera Nickname
		/// <inheritdoc />
		public void SetCameraNickname(string nickname) {
			lock(_modelIndex) {
				_modelIndex.Clear();
				foreach(ICameraFileInfo file in _filenameIndex.Values)
					file.CameraNameOverride = nickname;
				_modelIndex[nickname] = new List<ICameraFileInfo>(_filenameIndex.Values);
			}
		}

		/// <inheritdoc />
		public void SetCameraNickname(string nickname, string oldCameraName) {
			foreach(ICameraFileInfo file in _modelIndex[oldCameraName])
				file.CameraNameOverride = nickname;
			lock(_modelIndex) {
				if(_modelIndex.TryGetValue(nickname, out List<ICameraFileInfo> nicknamedFiles))
					nicknamedFiles.AddRange(_modelIndex[oldCameraName]);
				else
					_modelIndex[nickname] = _modelIndex[oldCameraName];
				_modelIndex.Remove(oldCameraName);
			}
		}

		/// <inheritdoc />
		public void SetCameraNickname(string nickname, IEnumerable<string> filenames) {
			lock(_modelIndex) {
				// make sure the nickname is in the index
				if(!_modelIndex.ContainsKey(nickname))
					_modelIndex.Add(nickname, []);

				foreach(ICameraFileInfo file in GetFilesFromNames(filenames)) {
					// remove from index of old camera name
					string oldCameraName = file.CameraNameOverride ?? file.Metadata.Model ?? "";
					RemoveFromModelIndex(oldCameraName, file);
					if(!string.IsNullOrEmpty(oldCameraName))
						RemoveFromModelIndex("", file);  // also make sure it wasn't indexed before it had a camera name

					// set camera nickname
					file.CameraNameOverride = nickname;
					// add to index of new nickname
					_modelIndex[nickname].Add(file);
				}
			}
		}

		/// <summary>
		/// Remove a file from the index for the specified camera name.
		/// </summary>
		/// <param name="model">Camera name the file might be indexed under.</param>
		/// <param name="file">File to remove from index.</param>
		private void RemoveFromModelIndex(string model, ICameraFileInfo file) {
			if(_modelIndex.TryGetValue(model, out List<ICameraFileInfo> modelFiles)) {
				modelFiles.Remove(file);
				if(modelFiles.Count == 0)
					_modelIndex.Remove(model);
			}
		}
		#endregion Camera Nickname

		#region Rename Files
		/// <inheritdoc />
		public void RenameFilesToSortable()
			=> RenameFilesToSortable(_filenameIndex.Values.ToArray());  // needs to make a copy first so we can change _filenameIndex

		/// <inheritdoc />
		public void RenameFilesToSortable(IEnumerable<string> filenames)
			=> RenameFilesToSortable(GetFilesFromNames(filenames));

		/// <summary>
		/// Renames the specified files to their sortable names.
		/// </summary>
		/// <param name="files">Files to rename.</param>
		private void RenameFilesToSortable(IEnumerable<ICameraFileInfo> files) {
			foreach(ICameraFileInfo file in files) {
				if(file.Metadata.Taken.HasValue) {
					string oldFilename = file.Name;
					string newFilename = file.SortableName;
					if(oldFilename != newFilename) {
						try {
							file.RenameToSortable();
							_filenameIndex[file.SortableName] = _filenameIndex[oldFilename];
							_filenameIndex.Remove(oldFilename);
						} catch(Exception e) {
							file.ErrorMessage = Messages.RenameError;
							file.Exception = e;
						}
					}
				} else {
					file.ErrorMessage = Messages.RenameUnavailable;
					file.Exception = null;
				}
			}
		}
		#endregion Rename Files
	}
}
