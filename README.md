# Photo Combine
Photo Combine renames photos from multiple cameras to avoid filename conflicts and sort by date and time taken across cameras.

## Revision History

### 2.1.0
* Update checking
* Better threading

### 2.0.0
* Add settings for filename format and which extensions are videos or photos
* Use file copy dialog for export
* Configuration file changed (previous configuration ignored)
* Major refactor into multiple assemblies
* Update to .NET 4.5
* Add unit tests

### 1.1.0
* Add minutes and days options for adjusting time taken, since sometimes people don’t set the date on their cameras

#### 1.1.1
* Support photos and videos from Google Pixel 3 phones
	* Recognize mp4 files as video
	* Handle filename patterns with date/time instead of sequential IDs

### 1.0.0
* Rearrange main form
* Read video file metadata via MediaInfo
* Allow adjusting time taken
* Update to Visual Studio 2017

#### 1.0.1
* Fix crash when video camera model isn’t found
* Find camera model for videos from Fuji cameras

### 0.1.0
* Initial release.

## External Libraries
Photo Combine has an original application icon, but the other icons come from [Material Design](https://material.io/icons/).  Video file metadata is accessed via the [MediaInfo](https://mediaarea.net/) library.