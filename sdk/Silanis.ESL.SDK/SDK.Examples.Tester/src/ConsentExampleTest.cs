using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class ConsentExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            ConsentExample example = new ConsentExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            // Verify if the required information is correctly extracted.
            Document document = documentPackage.GetDocument("Custom Consent Document");

            Assert.AreEqual(document.Signatures[0].Style, SignatureStyle.ACCEPTANCE);
        }
    }
}

