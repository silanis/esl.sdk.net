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

            Assert.AreEqual(signerInformationForEquifaxCanada.FirstName, example.FIRST_NAME);
            Assert.AreEqual(signerInformationForEquifaxCanada.LastName, example.LAST_NAME);
            Assert.AreEqual(signerInformationForEquifaxCanada.StreetAddress, example.STREET_ADDRESS);
            Assert.AreEqual(signerInformationForEquifaxCanada.City, example.CITY);
            Assert.AreEqual(signerInformationForEquifaxCanada.Province, example.PROVINCE);
            Assert.AreEqual(signerInformationForEquifaxCanada.PostalCode, example.POSTAL_CODE);
            Assert.AreEqual(signerInformationForEquifaxCanada.TimeAtAddress, example.TIME_AT_ADDRESS);
            Assert.AreEqual(signerInformationForEquifaxCanada.DriversLicenseNumber, example.DRIVERS_LICENSE_NUMBER);
            Assert.AreEqual(signerInformationForEquifaxCanada.SocialInsuranceNumber, example.SOCIAL_INSURANCE_NUMBER);
            Assert.AreEqual(signerInformationForEquifaxCanada.HomePhoneNumber, example.HOME_PHONE_NUMBER);
            Assert.AreEqual(signerInformationForEquifaxCanada.DateOfBirth, example.DATE_OF_BIRTH);
        }
    }
}

