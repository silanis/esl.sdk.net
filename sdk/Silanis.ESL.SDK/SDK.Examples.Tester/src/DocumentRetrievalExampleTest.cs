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

            Assert.IsNotNull(example.PdfDownloadedBytes);
            Assert.IsNotNull(example.OriginalPdfDownloadedBytes);
            Assert.IsNotNull(example.ZippedDownloadedBytes);
        }
    }
}

