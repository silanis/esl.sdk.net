using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture]
    public class SignerInformationForEquifaxUSABuilderTest
    {
        private string firstName = "First name";
        private string lastName = "Last name";
        private string streetAddress = "1234 Decarie";
        private string city = "Montreal";
        private string state = "Quebec";
        private string zip = "A2A 3B3";
        private string socialSecurityNumber = "111-222-333-444";
        private string homePhoneNumber = "1-800-976-0934";
        private Int32 timeAtAddress = 2;
        private string driversLicenseNumber = "driver license";

        private Nullable<DateTime> dateOfBirth = new DateTime();

        [Test]
        public void BuildWithSpecificValues() {
            SignerInformationForEquifaxUSA signerInformationForEquifaxUSA = SignerInformationForEquifaxUSABuilder.NewSignerInformationForEquifaxUSA()
                .WithFirstName(firstName)
                .WithLastName(lastName)
                .WithStreetAddress(streetAddress)
                .WithCity(city)
                .WithState(state)
                .WithZip(zip)
                .WithSocialSecurityNumber(socialSecurityNumber)
                .WithHomePhoneNumber(homePhoneNumber)
                .WithDateOfBirth(dateOfBirth)
                .WithTimeAtAddress(timeAtAddress)
                .WithDriversLicenseNumber(driversLicenseNumber)
                .Build();

            Assert.AreEqual(firstName, signerInformationForEquifaxUSA.FirstName);
            Assert.AreEqual(lastName, signerInformationForEquifaxUSA.LastName);
            Assert.AreEqual(streetAddress, signerInformationForEquifaxUSA.StreetAddress);
            Assert.AreEqual(city, signerInformationForEquifaxUSA.City);
            Assert.AreEqual(state, signerInformationForEquifaxUSA.State);
            Assert.AreEqual(zip, signerInformationForEquifaxUSA.Zip);
            Assert.AreEqual(socialSecurityNumber, signerInformationForEquifaxUSA.SocialSecurityNumber);
            Assert.AreEqual(homePhoneNumber, signerInformationForEquifaxUSA.HomePhoneNumber);
            Assert.AreEqual(dateOfBirth, signerInformationForEquifaxUSA.DateOfBirth);
            Assert.AreEqual(timeAtAddress, signerInformationForEquifaxUSA.TimeAtAddress);
            Assert.AreEqual(driversLicenseNumber, signerInformationForEquifaxUSA.DriversLicenseNumber);
        }
    }
}

