using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignatureStylesExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignatureStylesExample example = new SignatureStylesExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            foreach (Signature signature in documentPackage.GetDocument(example.DOCUMENT_NAME).Signatures)
            {
                if ((int)(signature.X + 0.1) == example.FULL_NAME_SIGNATURE_POSITION_X && (int)(signature.Y + 0.1) == example.FULL_NAME_SIGNATURE_POSITION_Y)
                {
                    Assert.AreEqual(signature.Style, SignatureStyle.FULL_NAME);
                    Assert.AreEqual(signature.Page, example.FULL_NAME_SIGNATURE_PAGE);
                }
                if ((int)(signature.X + 0.1) == example.INITIAL_SIGNATURE_POSITION_X && (int)(signature.Y + 0.1) == example.INITIAL_SIGNATURE_POSITION_Y)
                {
                    Assert.AreEqual(signature.Style, SignatureStyle.INITIALS);
                    Assert.AreEqual(signature.Page, example.INITIAL_SIGNATURE_PAGE);
                }
                if ((int)(signature.X + 0.1) == example.HAND_DRAWN_SIGNATURE_POSITION_X && (int)(signature.Y + 0.1) == example.HAND_DRAWN_SIGNATURE_POSITION_Y)
                {
                    Assert.AreEqual(signature.Style, SignatureStyle.HAND_DRAWN);
                    Assert.AreEqual(signature.Page, example.HAND_DRAWN_SIGNATURE_PAGE);
                }
            }
        }
    }
}

