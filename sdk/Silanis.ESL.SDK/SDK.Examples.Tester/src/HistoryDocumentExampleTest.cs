using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class HistoryDocumentExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new HistoryDocumentExample(  );
            example.Run();

            var documentPackage = example.RetrievedPackage;

            // Verify if the package is created correctly
            var historyDocument = documentPackage.GetDocument(example.ExternalDocumentName);
            Assert.IsNotNull(historyDocument);
            Assert.AreEqual(example.ExternalDocumentName, historyDocument.Name);

        }
    }
}

