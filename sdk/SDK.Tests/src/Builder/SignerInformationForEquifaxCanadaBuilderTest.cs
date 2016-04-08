
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class SignerInformationForEquifaxCanadaBuilderTest
    {
        private string firstName = "First name";
        private string lastName = "Last name";
        private string streetAddress = "1234 Decarie";
        private string city = "Montreal";
        private string province = "Quebec";
        private string postalCode = "A2A 3B3";
        private Int32 timeAtAddress = 1;
        private string driversLicenseNumber = "driver license";
        private string socialInsuranceNumber = "111-222-333-444";
        private string homePhoneNumber = "1-800-976-0934";
        private readonly Nullable<DateTime> dateOfBirth = new DateTime();

        [TestMethod]
        public void BuildWithSpecificValues() {
            var signerInformationForEquifaxCanada = SignerInformationForEquifaxCanadaBuilder.NewSignerInformationForEquifaxCanada()
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithStreetAddress(streetAddress)
                .WithCity(city)
                .WithProvince(province)
                .WithPostalCode(postalCode)
                .WithTimeAtAddress(timeAtAddress)
                .WithDriversLicenseNumber(driversLicenseNumber)
                .WithSocialInsuranceNumber(socialInsuranceNumber)
                .WithHomePhoneNumber(homePhoneNumber)
                .WithDateOfBirth(dateOfBirth)
                .Build();

            Assert.AreEqual(firstName, signerInformationForEquifaxCanada.FirstName);
            Assert.AreEqual(lastName, signerInformationForEquifaxCanada.LastName);
            Assert.AreEqual(streetAddress, signerInformationForEquifaxCanada.StreetAddress);
            Assert.AreEqual(city, signerInformationForEquifaxCanada.City);
            Assert.AreEqual(province, signerInformationForEquifaxCanada.Province);
            Assert.AreEqual(postalCode, signerInformationForEquifaxCanada.PostalCode);
            Assert.AreEqual(socialInsuranceNumber, signerInformationForEquifaxCanada.SocialInsuranceNumber);
            Assert.AreEqual(homePhoneNumber, signerInformationForEquifaxCanada.HomePhoneNumber);
            Assert.AreEqual(dateOfBirth, signerInformationForEquifaxCanada.DateOfBirth);
        }
    }
}