using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class DocumentUploadExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            DocumentUploadExample example = new DocumentUploadExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            // Verify if the document was uploaded correctly.

            Document document = documentPackage.GetDocument(example.UPLOADED_DOCUMENT_NAME);
            byte[] documentFile = example.EslClient.DownloadDocument(example.PackageId, document.Id);
            Assert.Greater(documentFile.Length, 0);
        }
    }
}

