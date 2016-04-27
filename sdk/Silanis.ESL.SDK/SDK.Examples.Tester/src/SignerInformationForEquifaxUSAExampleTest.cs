using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SignerInformationForEquifaxUSAExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignerInformationForEquifaxUsaExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            var signerInformationForEquifaxUSA = documentPackage.GetSigner(example.email1).KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA;

            Assert.AreEqual(signerInformationForEquifaxUSA.FirstName, example.FirstName);
            Assert.AreEqual(signerInformationForEquifaxUSA.LastName, example.LastName);
            Assert.AreEqual(signerInformationForEquifaxUSA.StreetAddress, example.StreetAddress);
            Assert.AreEqual(signerInformationForEquifaxUSA.City, example.City);
            Assert.AreEqual(signerInformationForEquifaxUSA.State, example.State);
            Assert.AreEqual(signerInformationForEquifaxUSA.Zip, example.Zip);
            Assert.AreEqual(signerInformationForEquifaxUSA.TimeAtAddress, example.TimeAtAddress);
            Assert.AreEqual(signerInformationForEquifaxUSA.SocialSecurityNumber, example.SocialSecurityNumber);
            Assert.AreEqual(signerInformationForEquifaxUSA.HomePhoneNumber, example.HomePhoneNumber);
            Assert.AreEqual(signerInformationForEquifaxUSA.DateOfBirth, example.DateOfBirth);
            Assert.AreEqual(signerInformationForEquifaxUSA.DriversLicenseNumber, example.DriversLicenseNumber);
        }
    }
}


