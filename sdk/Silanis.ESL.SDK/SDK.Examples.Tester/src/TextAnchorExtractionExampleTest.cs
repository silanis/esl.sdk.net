using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class TextAnchorExtractionExampleTest 
    {
        private double maxErrorAfterScaling = 0.75;

        [TestMethod]
        public void VerifyResult()
        {
            var example = new TextAnchorExtractionExample();
            example.Run();

            var document = example.RetrievedPackage.GetDocument(example.DocumentName);

            foreach (var signature in document.Signatures) {
                foreach ( var field in signature.Fields ) {
                    Assert.IsTrue(field.Width >= -maxErrorAfterScaling + (double)(example.FieldWidth), "Field's width was incorrectly returned.");
                    Assert.IsTrue(field.Width <= maxErrorAfterScaling + (double)(example.FieldWidth), "Field's width was incorrectly returned.");
                    Assert.IsTrue(field.Height >= -maxErrorAfterScaling + (double)(example.FieldHeight), "Field's height was incorrectly returned.");
                    Assert.IsTrue(field.Height <= maxErrorAfterScaling + (double)(example.FieldHeight), "Field's height was incorrectly returned.");
                }
            }
        }
    }
}

