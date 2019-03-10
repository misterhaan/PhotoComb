using System;

namespace au.Applications.PhotoComb.UI {
	/// <summary>
	/// Which group of files an action should apply to.
	/// </summary>
	internal enum FileGroupType {
		All,
		Checked,
		CameraModel
	}

	/// <summary>
	/// Extension methods for <cref>FileGroupType</cref>.
	/// </summary>
	internal static class FileGroupTypeExt {
		internal static string ToLabel(this FileGroupType fileGroupType) {
			switch(fileGroupType) {
				case FileGroupType.All: return Labels.WhichAll;
				case FileGroupType.CameraModel: return Labels.WhichCamera;
				case FileGroupType.Checked: return Labels.WhichChecked;
				default: throw new NotImplementedException($"No label defined for {nameof(FileGroupType)}.{fileGroupType}");
			}
		}
	}
}
