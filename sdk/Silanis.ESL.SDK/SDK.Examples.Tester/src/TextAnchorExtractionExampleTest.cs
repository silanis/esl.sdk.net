using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class TextAnchorExtractionExampleTest 
    {
        private double maxErrorAfterScaling = 0.75;

        [Test()]
        public void VerifyResult()
        {
            TextAnchorExtractionExample example = new TextAnchorExtractionExample();
            example.Run();

            Document document = example.RetrievedPackage.GetDocument(example.DOCUMENT_NAME);

            foreach (Signature signature in document.Signatures) {
                foreach ( Field field in signature.Fields ) {
                    Assert.GreaterOrEqual(field.Width, -maxErrorAfterScaling + (double)(example.FIELD_WIDTH), "Field's width was incorrectly returned.");
                    Assert.LessOrEqual(field.Width, maxErrorAfterScaling + (double)(example.FIELD_WIDTH), "Field's width was incorrectly returned.");
                    Assert.GreaterOrEqual(field.Height, -maxErrorAfterScaling + (double)(example.FIELD_HEIGHT), "Field's height was incorrectly returned.");
                    Assert.LessOrEqual(field.Height, maxErrorAfterScaling + (double)(example.FIELD_HEIGHT), "Field's height was incorrectly returned.");
                }
            }
        }
    }
}

