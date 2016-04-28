using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class MobileCaptureSignatureStyleExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new MobileCaptureSignatureStyleExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            foreach (var signature in documentPackage.GetDocument(example.DocumentName).Signatures)
            {
				if ((int)(signature.X + 0.1) == example.MobileCaptureSignaturePositionX && (int)(signature.Y + 0.1) == example.MobileCaptureSignaturePositionY)
                {
					Assert.AreEqual(signature.Style, SignatureStyle.MOBILE_CAPTURE);
					Assert.AreEqual(signature.Page, example.MobileCaptureSignaturePage);
                }
            }
        }
    }
}

