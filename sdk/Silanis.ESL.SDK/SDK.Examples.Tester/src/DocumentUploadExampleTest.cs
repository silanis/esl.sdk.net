using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class DocumentUploadExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new DocumentUploadExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            // Verify if the document was uploaded correctly.

            var document = documentPackage.GetDocument(example.UPLOADED_DOCUMENT_NAME);
            var documentFile = example.EslClient.DownloadDocument(example.PackageId, document.Id);
            Assert.IsTrue(documentFile.Length > 0);
        }
    }
}

