using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class DocumentRetrievalExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            DocumentRetrievalExample example = new DocumentRetrievalExample();
            example.Run();

            Assert.IsNotNull(example.pdfDownloadedBytes);
            Assert.IsNotNull(example.originalPdfDownloadedBytes);
            Assert.IsNotNull(example.zippedDownloadedBytes);
        }
    }
}

