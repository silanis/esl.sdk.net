using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Tests
{
	public class DocumentBuilderTest
	{
		[TestMethod]
		public void BuildsDocumentWithSpecifiedValues()
		{
			var file = new FileInfo (Directory.GetCurrentDirectory() + "/src/document.pdf");

			var doc = DocumentBuilder.NewDocumentNamed ("testing")
				.FromFile (file.FullName)
				.Build ();

			Assert.AreEqual ("testing", doc.Name);
			Assert.AreEqual (file.FullName, doc.FileName);
		}

		[TestMethod]
		[ExpectedException(typeof(EslException))]
		public void CannotCreateDocumentWithoutFileName()
		{
			DocumentBuilder.NewDocumentNamed ("testing").Build ();
		}
	}
}