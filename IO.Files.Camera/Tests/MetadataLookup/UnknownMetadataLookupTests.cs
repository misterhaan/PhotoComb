using System.IO;
using au.IO.Files.Camera.Types;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.IO.Files.Camera.MetadataLookup.Tests {
	[TestClass]
	public class UnknownMetadataLookupTests {
		[TestMethod]
		public void Get_ReturnsUnknown() {
			UnknownMetadataLookup lookup = new UnknownMetadataLookup(A.Fake<CameraFileInfo>(options => options.WithArgumentsForConstructor(() => new CameraFileInfo(new FileInfo("nothing.at.all")))));

			ICameraFileMetadata metadata = lookup.Get();

			Assert.AreEqual(CameraFileMetadata.Unknown, metadata);
		}
	}
}
