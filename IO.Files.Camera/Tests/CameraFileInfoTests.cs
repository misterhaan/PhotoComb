using System;
using System.IO;
using System.Threading.Tasks;
using au.Applications.PhotoComb.Settings.Types;
using au.IO.Files.Camera.MetadataLookup;
using au.IO.Files.Camera.Types;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.IO.Files.Camera.Tests {
	[TestClass]
	public class CameraFileInfoTests {
		private const string JpgFilename = @"C:\IMG_1337.JPG";
		private const string JpegFilename = @"C:\IMG_8008.JPEG";
		private const string TxtFilename = @"C:\info.txt";

		private const string JpgExt = "jpg";
		private const string JpegExt = "jpeg";
		private const string TxtExt = "txt";

		[DataTestMethod]
		[DataRow(JpgFilename, JpgExt)]
		[DataRow(JpegFilename, JpegExt)]
		[DataRow(TxtFilename, TxtExt)]
		public void Extension_ReturnsLowerCaseWithoutDot(string filePath, string expectedExtension) {
			CameraFileInfo cfi = BuildCameraFileInfo(filePath, false);

			string ext = cfi.Extension;

			Assert.AreEqual(expectedExtension, ext, false, "Extension property should be lowercase of the original without the dot.");
		}

		[DataTestMethod]
		[DataRow(JpgFilename)]
		[DataRow(JpegFilename)]
		public void SortableName_ExpandJpegTrue_JpegExtension(string filePath) {
			CameraFileInfo cfi = BuildCameraFileInfo(filePath, true);

			string sortableName = cfi.SortableName;

			ExtensionAssert.HasExtension(JpegExt, sortableName, "JPG and JPEG extensions should both be expanded to jpeg when expandJpegExtension parameter is true.");
		}

		[TestMethod]
		public void SortableName_ExpandJpegFalse_JpgExtension() {
			CameraFileInfo cfi = BuildCameraFileInfo(JpgFilename, false);

			string sortableName = cfi.SortableName;

			ExtensionAssert.HasExtension(JpgExt, sortableName, "JPG extension should not be expanded to jpeg when expandJpegExtension parameter is false.");
		}

		[TestMethod]
		public void Equality_CreatedFromSamePath_Equal() {
			CameraFileInfo cfi1 = BuildCameraFileInfo(JpgFilename, false);
			CameraFileInfo cfi2 = BuildCameraFileInfo(JpgFilename, false);

			Assert.AreEqual(cfi1, cfi2, "Two CameraFileInfo objects created separately from the same path should be equal.");
			Assert.IsTrue(cfi1.Equals(cfi2), "A CameraFileInfo object's Equals() method should return true for another CameraFileInfo object created separately from the same path.");
			Assert.IsTrue(cfi1 == cfi2, "Two CameraFileInfo objects created separately from the same path should return true when used with the == operator.");
		}

		[TestMethod]
		public void Equality_InterfaceLevelCreatedFromSamePath_Equal() {
			ICameraFileInfo cfi1 = BuildCameraFileInfo(JpgFilename, false);
			ICameraFileInfo cfi2 = BuildCameraFileInfo(JpgFilename, false);

			Assert.AreEqual(cfi1, cfi2, "Two ICameraFileInfo objects created separately from the same path should be equal.");
			Assert.IsTrue(cfi1.Equals(cfi2), "A CameraFileInfo object's Equals() method should return true for another ICameraFileInfo object created separately from the same path.");
			// Assert.IsTrue(cfi1 == cfi2, "Two ICameraFileInfo objects created separately from the same path should return true when used with the == operator.");  // this doesn't work and i don't know how to make it work
		}

		[TestMethod]
		public void Equality_Null_NotEqual() {
			CameraFileInfo cfi = BuildCameraFileInfo(JpgFilename, false);
			CameraFileInfo nullCfi = null;

			Assert.AreNotEqual(cfi, nullCfi, "A non-null CameraFileInfo object should not be equal to null.");
			Assert.IsFalse(cfi.Equals(nullCfi), "A non-null CameraFileInfo object's Equals() method should return false for a null ICameraFileInfo.");
			Assert.IsTrue(cfi != nullCfi, "A non-null CameraFileInfo object and null should return true when used with the != operator.");
		}

		private static CameraFileInfo BuildCameraFileInfo(string filePath, bool expandJpeg) {
			IFilenameFormatSettings settings = A.Fake<IFilenameFormatSettings>();
			A.CallTo(() => settings.ExpandJpegExtension).Returns(expandJpeg);
			A.CallTo(() => settings.FormatString).Returns("fakeFilename.{3}");
			MetadataLookupFactory metadataFactory = A.Fake<MetadataLookupFactory>();
			MetadataLookupBase metadataLookup = A.Fake<MetadataLookupBase>(options => options.WithArgumentsForConstructor(() => new UnknownMetadataLookup(new CameraFileInfo(new FileInfo(filePath), settings, metadataFactory))));
			A.CallTo(() => metadataLookup.GetAsync()).Returns(Task.FromResult(new CameraFileMetadata(CameraFileType.Unknown, "camera", DateTime.Now)));
			A.CallTo(() => metadataFactory.Build(A<CameraFileInfo>.Ignored)).Returns(metadataLookup);
			return new CameraFileInfo(new FileInfo(filePath), settings, metadataFactory);
		}

		private static class ExtensionAssert {
			public static void HasExtension(string expectedExtension, string actualFilename, string message) {
				HasExtension(expectedExtension, new FileInfo(actualFilename), message);
			}

			private static void HasExtension(string expectedExtension, FileInfo actualFile, string message) {
				string actualExtension = actualFile.Extension.TrimStart('.');
				Assert.AreEqual(expectedExtension, actualExtension, false, message);
			}
		}
	}
}
