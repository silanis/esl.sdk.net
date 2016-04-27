using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class DocumentRetrievalExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new DocumentRetrievalExample();
            example.Run();

            Assert.IsNotNull(example.pdfDownloadedBytes);
            Assert.IsNotNull(example.originalPdfDownloadedBytes);
            Assert.IsNotNull(example.zippedDownloadedBytes);
        }
    }
}

