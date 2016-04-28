using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class ConsentExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new ConsentExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            // Verify if the required information is correctly extracted.
            var document = documentPackage.GetDocument("Custom Consent Document");

            Assert.AreEqual(document.Signatures[0].Style, SignatureStyle.ACCEPTANCE);
        }
    }
}

