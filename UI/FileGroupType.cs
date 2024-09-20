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
			return fileGroupType switch {
				FileGroupType.All => Labels.WhichAll,
				FileGroupType.CameraModel => Labels.WhichCamera,
				FileGroupType.Checked => Labels.WhichChecked,
				_ => throw new NotImplementedException($"No label defined for {nameof(FileGroupType)}.{fileGroupType}"),
			};
		}
	}
}
