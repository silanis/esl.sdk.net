using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class SignerBoundFieldsExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignerBoundFieldsExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            foreach (var signature in documentPackage.GetDocument(example.DocumentName).Signatures)
            {
                foreach (var field in signature.Fields)
                {
                    if ((int)(field.X + 0.1) == example.SignatureDatePositionX && (int)(field.Y + 0.1) == example.SignatureDatePositionY)
                    {
                        Assert.AreEqual(field.Page, example.SignatureDatePage);
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_DATE);
                    }
                    if ((int)(field.X + 0.1) == example.SignerCompanyPositionX && (int)(field.Y + 0.1) == example.SignerCompanyPositionY)
                    {
                        Assert.AreEqual(field.Page, example.SignerCompanyPage);
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_COMPANY);
                    }
                    if ((int)(field.X + 0.1) == example.SignerNamePositionX && (int)(field.Y + 0.1) == example.SignerNamePositionY)
                    {
                        Assert.AreEqual(field.Page, example.SignerNamePage);
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_NAME);
                    }
                    if ((int)(field.X + 0.1) == example.SignerTitlePositionX && (int)(field.Y + 0.1) == example.SignerTitlePositionY)
                    {
                        Assert.AreEqual(field.Page, example.SignerTitlePage);
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_TITLE);
                    }
                }
            }
        }
    }
}

