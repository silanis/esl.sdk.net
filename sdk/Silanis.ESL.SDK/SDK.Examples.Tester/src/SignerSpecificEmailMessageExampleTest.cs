using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SignerSpecificEmailMessageExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignerSpecificEmailMessageExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            Assert.AreEqual(documentPackage.GetSigner(example.email1).Message, example.EmailMessage);
        }
    }
}

