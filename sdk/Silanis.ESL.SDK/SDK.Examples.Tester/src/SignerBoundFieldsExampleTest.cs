using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignerBoundFieldsExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignerBoundFieldsExample example = new SignerBoundFieldsExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            foreach (Signature signature in documentPackage.GetDocument(example.DOCUMENT_NAME).Signatures)
            {
                foreach (Field field in signature.Fields)
                {
                    if ((int)(field.X + 0.1) == example.SIGNATURE_DATE_POSITION_X && (int)(field.Y + 0.1) == example.SIGNATURE_DATE_POSITION_Y)
                    {
                        Assert.AreEqual(field.Page, example.SIGNATURE_DATE_PAGE);
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_DATE);
                    }
                    if ((int)(field.X + 0.1) == example.SIGNER_COMPANY_POSITION_X && (int)(field.Y + 0.1) == example.SIGNER_COMPANY_POSITION_Y)
                    {
                        Assert.AreEqual(field.Page, example.SIGNER_COMPANY_PAGE);
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_COMPANY);
                    }
                    if ((int)(field.X + 0.1) == example.SIGNER_NAME_POSITION_X && (int)(field.Y + 0.1) == example.SIGNER_NAME_POSITION_Y)
                    {
                        Assert.AreEqual(field.Page, example.SIGNER_NAME_PAGE);
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_NAME);
                    }
                    if ((int)(field.X + 0.1) == example.SIGNER_TITLE_POSITION_X && (int)(field.Y + 0.1) == example.SIGNER_TITLE_POSITION_Y)
                    {
                        Assert.AreEqual(field.Page, example.SIGNER_TITLE_PAGE);
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_TITLE);
                    }
                }
            }
        }
    }
}

