using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class UpdateSignerExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new UpdateSignerExample();
            example.Run();

            Assert.IsNotNull(example.RetrievedPackage.GetSigner(example.email1));
            Assert.AreEqual(AuthenticationMethod.EMAIL, example.RetrievedPackage.GetSigner(example.email1).Authentication.Method);
            Assert.IsNotNull(example.RetrievedPackage.GetSigner(example.email2));
            Assert.AreEqual(AuthenticationMethod.EMAIL, example.RetrievedPackage.GetSigner(example.email2).Authentication.Method);

            Assert.IsNull(example.UpdatedPackage.GetSigner(example.email1));
            Assert.IsNotNull(example.UpdatedPackage.GetSigner(example.email3));
            Assert.AreEqual(AuthenticationMethod.CHALLENGE, example.UpdatedPackage.GetSigner(example.email3).Authentication.Method);
            Assert.AreEqual(UpdateSignerExample.Signer3FirstQuestion, example.UpdatedPackage.GetSigner(example.email3).Authentication.Challenges[0].Question);
            Assert.AreEqual(UpdateSignerExample.Signer3FirstAnswer, example.UpdatedPackage.GetSigner(example.email3).Authentication.Challenges[0].Answer);
            Assert.AreEqual(UpdateSignerExample.Signer3SecondQuestion, example.UpdatedPackage.GetSigner(example.email3).Authentication.Challenges[1].Question);
            Assert.AreEqual(UpdateSignerExample.Signer3SecondAnswer, example.UpdatedPackage.GetSigner(example.email3).Authentication.Challenges[1].Answer);

            Assert.IsNotNull(example.UpdatedPackage.GetSigner(example.email2));
            Assert.AreEqual(AuthenticationMethod.SMS, example.UpdatedPackage.GetSigner(example.email2).Authentication.Method);
            Assert.AreEqual(example.sms1, example.UpdatedPackage.GetSigner(example.email2).Authentication.PhoneNumber);
        }
    }
}

