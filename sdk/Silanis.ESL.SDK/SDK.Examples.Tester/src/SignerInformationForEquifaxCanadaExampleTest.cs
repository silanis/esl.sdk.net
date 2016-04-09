using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SignerInformationForEquifaxCanadaExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignerInformationForEquifaxCanadaExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            var signerInformationForEquifaxCanada = documentPackage.GetSigner(example.email1).KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada;

            Assert.AreEqual(signerInformationForEquifaxCanada.FirstName, example.FirstName);
            Assert.AreEqual(signerInformationForEquifaxCanada.LastName, example.LastName);
            Assert.AreEqual(signerInformationForEquifaxCanada.StreetAddress, example.StreetAddress);
            Assert.AreEqual(signerInformationForEquifaxCanada.City, example.City);
            Assert.AreEqual(signerInformationForEquifaxCanada.Province, example.Province);
            Assert.AreEqual(signerInformationForEquifaxCanada.PostalCode, example.PostalCode);
            Assert.AreEqual(signerInformationForEquifaxCanada.TimeAtAddress, example.TimeAtAddress);
            Assert.AreEqual(signerInformationForEquifaxCanada.DriversLicenseNumber, example.DriversLicenseNumber);
            Assert.AreEqual(signerInformationForEquifaxCanada.SocialInsuranceNumber, example.SocialInsuranceNumber);
            Assert.AreEqual(signerInformationForEquifaxCanada.HomePhoneNumber, example.HomePhoneNumber);
            Assert.AreEqual(signerInformationForEquifaxCanada.DateOfBirth, example.DateOfBirth);
        }
    }
}

