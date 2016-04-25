using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignerSpecificEmailMessageExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignerSpecificEmailMessageExample example = new SignerSpecificEmailMessageExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            Assert.AreEqual(documentPackage.GetSigner(example.email1).Message, example.EMAIL_MESSAGE);
        }
    }
}

