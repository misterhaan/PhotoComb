// Enumerations used by PhotoComb

namespace au.Applications.PhotoComb {
	/// <summary>
	/// Type of file based on how metadata was read.
	/// </summary>
	public enum CameraFileType {
		// these must match up with the icons set in PhotoComb constructor (same number and order)
		Photo,
		Video,
		Unknown
	}

	/// <summary>
	/// Which group of files the action should apply to.
	/// </summary>
	public enum FileGroupType {
		All,
		Checked,
		CameraModel
	}
}
