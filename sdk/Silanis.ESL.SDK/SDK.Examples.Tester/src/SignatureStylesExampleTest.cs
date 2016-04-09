using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class SignatureStylesExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignatureStylesExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            foreach (var signature in documentPackage.GetDocument(example.DocumentName).Signatures)
            {
                if ((int)(signature.X + 0.1) == example.FullNameSignaturePositionX && (int)(signature.Y + 0.1) == example.FullNameSignaturePositionY)
                {
                    Assert.AreEqual(signature.Style, SignatureStyle.FULL_NAME);
                    Assert.AreEqual(signature.Page, example.FullNameSignaturePage);
                }
                if ((int)(signature.X + 0.1) == example.InitialSignaturePositionX && (int)(signature.Y + 0.1) == example.InitialSignaturePositionY)
                {
                    Assert.AreEqual(signature.Style, SignatureStyle.INITIALS);
                    Assert.AreEqual(signature.Page, example.InitialSignaturePage);
                }
                if ((int)(signature.X + 0.1) == example.HandDrawnSignaturePositionX && (int)(signature.Y + 0.1) == example.HandDrawnSignaturePositionY)
                {
                    Assert.AreEqual(signature.Style, SignatureStyle.HAND_DRAWN);
                    Assert.AreEqual(signature.Page, example.HandDrawnSignaturePage);
                }
            }
        }
    }
}

