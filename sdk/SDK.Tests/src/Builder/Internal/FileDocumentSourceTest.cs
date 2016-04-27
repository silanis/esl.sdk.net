using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Builder.Internal;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
	public class FileDocumentSourceTest
	{
		[TestMethod]
		public void ReadsFileContent()
		{
			var file = new FileInfo (Directory.GetCurrentDirectory() + "/src/document.pdf");
			var source = new FileDocumentSource (file.FullName);

			var content = source.Content ();

			Assert.IsNotNull (content);
			Assert.IsTrue (content.Length > 0);
		}

		[TestMethod]
		[ExpectedException(typeof(EslException))]
		public void ValidatesFileExistence()
		{
			new FileDocumentSource ("coco.pdf");
		}
	}
}