using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignerInformationForEquifaxCanadaExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignerInformationForEquifaxCanadaExample example = new SignerInformationForEquifaxCanadaExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            SignerInformationForEquifaxCanada signerInformationForEquifaxCanada = documentPackage.GetSigner(example.email1).KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada;

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

