using System;
using System.Collections.Generic;
using System.IO;
using au.Applications.PhotoComb.Settings.Types;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace au.IO.Files.Camera.MetadataLookup.Tests {
#pragma warning restore IDE0130 // Namespace does not match folder structure
	[TestClass]
	public class MetadataLookupFactoryTest {
		[DataTestMethod]
		[DataRow("IMG_1234.JPG")]
		[DataRow("family portrait.jpeg")]
		public void Build_Photo_ReturnsExif(string filename) {
			MetadataLookupFactory factory = GetMetadataLookupFactory();

			MetadataLookupBase lookup = factory.Build(GetCameraFileInfo(filename, factory));

			Assert.IsInstanceOfType(lookup, typeof(ExifMetadataLookup), "Photo files should look up metadata from exif.");
		}

		[DataTestMethod]
		[DataRow("IMG_1234.AVI")]
		[DataRow("first dance.mov")]
		[DataRow("MVIMG_20190115_123456_exported_1337_2.MP4")]
		public void Build_Video_ReturnsMediaInfo(string filename) {
			// the MediaInfo.dll reference chooses 64- or 32-bit based on the OS, so the process needs to match
			EnsureProcessBitnessMatchesOperatingSystem();
			MetadataLookupFactory factory = GetMetadataLookupFactory();

			MetadataLookupBase lookup = factory.Build(GetCameraFileInfo(filename, factory));

			Assert.IsInstanceOfType(lookup, typeof(MediaInfoMetadataLookup), "Video files should look up metadata from MediaInfo.");
		}

		[DataTestMethod]
		[DataRow("IMG_1337.PNG")]
		[DataRow("IMG_1337.AAE")]
		public void Build_Other_ReturnsUnknown(string filename) {
			MetadataLookupFactory factory = GetMetadataLookupFactory();

			MetadataLookupBase lookup = factory.Build(GetCameraFileInfo(filename, factory));

			Assert.IsInstanceOfType(lookup, typeof(UnknownMetadataLookup), "Files with unrecognized extensions should not look up metadata.");
		}

		private static void EnsureProcessBitnessMatchesOperatingSystem()
			// If this fails when running tests in Visual Studio, go to Test > Test
			// Settings > Default Processor Architecture and choose X64.  The default
			// is to run all tests in X86 even on 64-bit OS.
			=> Assert.AreEqual(Environment.Is64BitOperatingSystem, Environment.Is64BitProcess, "This test requires the process bitness and OS bitness to agree.  Configure Visual Studio at Tests > Test Settings > Default Processor Architecture and choose your OS architecture.");

		private static MetadataLookupFactory GetMetadataLookupFactory()
			=> new(
				new HashSet<string>(["jpg", "jpeg"], StringComparer.OrdinalIgnoreCase),
				new HashSet<string>(["mp4", "mov", "avi"], StringComparer.OrdinalIgnoreCase));

		private static CameraFileInfo GetCameraFileInfo(string filePath, MetadataLookupFactory factory)
			=> new(new FileInfo(filePath), A.Fake<IFilenameFormatSettings>(), factory);
	}
}
