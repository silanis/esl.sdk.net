using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture]
    public class SignerInformationForEquifaxUSAConverterTest
    {
        private Silanis.ESL.SDK.SignerInformationForEquifaxUSA sdkSignerInformationForEquifaxUSA1 = null;
        private Silanis.ESL.SDK.SignerInformationForEquifaxUSA sdkSignerInformationForEquifaxUSA2 = null;
        private Silanis.ESL.API.SignerInformationForEquifaxUSA apiSignerInformationForEquifaxUSA1 = null;
        private Silanis.ESL.API.SignerInformationForEquifaxUSA apiSignerInformationForEquifaxUSA2 = null;
        private SignerInformationForEquifaxUSAConverter converter;

        [Test]
        public void ConvertNullSDKToAPI()
        {
            sdkSignerInformationForEquifaxUSA1 = null;
            converter = new SignerInformationForEquifaxUSAConverter(sdkSignerInformationForEquifaxUSA1);
            Assert.IsNull(converter.ToAPISignerInformationForEquifaxUSA());
        }

        [Test]
        public void ConvertNullAPIToSDK()
        {
            apiSignerInformationForEquifaxUSA1 = null;
            converter = new SignerInformationForEquifaxUSAConverter(apiSignerInformationForEquifaxUSA1);
            Assert.IsNull(converter.ToSDKSignerInformationForEquifaxUSA());
        }

        [Test]
        public void ConvertNullSDKToSDK()
        {
            sdkSignerInformationForEquifaxUSA1 = null;
            converter = new SignerInformationForEquifaxUSAConverter(sdkSignerInformationForEquifaxUSA1);
            Assert.IsNull(converter.ToSDKSignerInformationForEquifaxUSA());
        }

        [Test]
        public void ConvertNullAPIToAPI()
        {
            apiSignerInformationForEquifaxUSA1 = null;
            converter = new SignerInformationForEquifaxUSAConverter(apiSignerInformationForEquifaxUSA1);
            Assert.IsNull(converter.ToAPISignerInformationForEquifaxUSA());
        }

        [Test]
        public void ConvertSDKToSDK()
        {
            sdkSignerInformationForEquifaxUSA1 = CreateTypicalSDKSignerInformationForEquifaxUSA();
            sdkSignerInformationForEquifaxUSA2 = new SignerInformationForEquifaxUSAConverter(sdkSignerInformationForEquifaxUSA1).ToSDKSignerInformationForEquifaxUSA();

            Assert.IsNotNull(sdkSignerInformationForEquifaxUSA2);
            Assert.AreEqual(sdkSignerInformationForEquifaxUSA2, sdkSignerInformationForEquifaxUSA1);
        }

        [Test]
        public void ConvertAPIToAPI()
        {
            apiSignerInformationForEquifaxUSA1 = CreateTypicalAPISignerInformationForEquifaxUSA();
            apiSignerInformationForEquifaxUSA2 = new SignerInformationForEquifaxUSAConverter(apiSignerInformationForEquifaxUSA1).ToAPISignerInformationForEquifaxUSA();

            Assert.IsNotNull(apiSignerInformationForEquifaxUSA2);
            Assert.AreEqual(apiSignerInformationForEquifaxUSA2, apiSignerInformationForEquifaxUSA1);
        }

        [Test]
        public void ConvertAPIToSDK()
        {
            apiSignerInformationForEquifaxUSA1 = CreateTypicalAPISignerInformationForEquifaxUSA();
            sdkSignerInformationForEquifaxUSA1 = new SignerInformationForEquifaxUSAConverter(apiSignerInformationForEquifaxUSA1).ToSDKSignerInformationForEquifaxUSA();

            Assert.AreEqual(sdkSignerInformationForEquifaxUSA1.FirstName, apiSignerInformationForEquifaxUSA1.FirstName);
            Assert.AreEqual(sdkSignerInformationForEquifaxUSA1.LastName, apiSignerInformationForEquifaxUSA1.LastName);
            Assert.AreEqual(sdkSignerInformationForEquifaxUSA1.StreetAddress, apiSignerInformationForEquifaxUSA1.StreetAddress);
            Assert.AreEqual(sdkSignerInformationForEquifaxUSA1.City, apiSignerInformationForEquifaxUSA1.City);
            Assert.AreEqual(sdkSignerInformationForEquifaxUSA1.State, apiSignerInformationForEquifaxUSA1.State);
            Assert.AreEqual(sdkSignerInformationForEquifaxUSA1.Zip, apiSignerInformationForEquifaxUSA1.Zip);
            Assert.AreEqual(sdkSignerInformationForEquifaxUSA1.SocialSecurityNumber, apiSignerInformationForEquifaxUSA1.SocialSecurityNumber);
            Assert.AreEqual(sdkSignerInformationForEquifaxUSA1.HomePhoneNumber, apiSignerInformationForEquifaxUSA1.HomePhoneNumber);
            Assert.AreEqual(sdkSignerInformationForEquifaxUSA1.DateOfBirth, apiSignerInformationForEquifaxUSA1.DateOfBirth);
        }

        [Test]
        public void ConvertSDKToAPI()
        {
            sdkSignerInformationForEquifaxUSA1 = CreateTypicalSDKSignerInformationForEquifaxUSA();
            apiSignerInformationForEquifaxUSA1 = new SignerInformationForEquifaxUSAConverter(sdkSignerInformationForEquifaxUSA1).ToAPISignerInformationForEquifaxUSA();

            Assert.AreEqual(apiSignerInformationForEquifaxUSA1.FirstName, sdkSignerInformationForEquifaxUSA1.FirstName);
            Assert.AreEqual(apiSignerInformationForEquifaxUSA1.LastName, sdkSignerInformationForEquifaxUSA1.LastName);
            Assert.AreEqual(apiSignerInformationForEquifaxUSA1.StreetAddress, sdkSignerInformationForEquifaxUSA1.StreetAddress);
            Assert.AreEqual(apiSignerInformationForEquifaxUSA1.City, sdkSignerInformationForEquifaxUSA1.City);
            Assert.AreEqual(apiSignerInformationForEquifaxUSA1.State, sdkSignerInformationForEquifaxUSA1.State);
            Assert.AreEqual(apiSignerInformationForEquifaxUSA1.Zip, sdkSignerInformationForEquifaxUSA1.Zip);
            Assert.AreEqual(apiSignerInformationForEquifaxUSA1.SocialSecurityNumber, sdkSignerInformationForEquifaxUSA1.SocialSecurityNumber);
            Assert.AreEqual(apiSignerInformationForEquifaxUSA1.HomePhoneNumber, sdkSignerInformationForEquifaxUSA1.HomePhoneNumber);
            Assert.AreEqual(apiSignerInformationForEquifaxUSA1.DateOfBirth, sdkSignerInformationForEquifaxUSA1.DateOfBirth);
        }

        private Silanis.ESL.SDK.SignerInformationForEquifaxUSA CreateTypicalSDKSignerInformationForEquifaxUSA()
        {

            Silanis.ESL.SDK.SignerInformationForEquifaxUSA SignerInformationForEquifaxUSA = SignerInformationForEquifaxUSABuilder.NewSignerInformationForEquifaxUSA()
                .WithFirstName("Signer First Name")
                .WithLastName("Last Name")
                .WithStreetAddress("main street")
                .WithCity("Montreal")
                .WithState("Quebec")
                .WithZip("H4L3K1")
                .WithSocialSecurityNumber("111-222-333-444")
                .WithHomePhoneNumber("1-800-123-8763")
                .WithDateOfBirth(new DateTime())
                .WithDriversLicenseNumber("98826278262728262")
                .WithTimeAtAddress(2)
                .Build();

            return SignerInformationForEquifaxUSA;
        }

        private Silanis.ESL.API.SignerInformationForEquifaxUSA CreateTypicalAPISignerInformationForEquifaxUSA()
        {
            Silanis.ESL.API.SignerInformationForEquifaxUSA SignerInformationForEquifaxUSA = new Silanis.ESL.API.SignerInformationForEquifaxUSA();
            SignerInformationForEquifaxUSA.FirstName = "first name";
            SignerInformationForEquifaxUSA.LastName = "last name";
            SignerInformationForEquifaxUSA.StreetAddress = "1234 main street";
            SignerInformationForEquifaxUSA.City = "Montreal";
            SignerInformationForEquifaxUSA.State = "Quebec";
            SignerInformationForEquifaxUSA.Zip = "1h27r4";
            SignerInformationForEquifaxUSA.SocialSecurityNumber = "222-099-888-333";
            SignerInformationForEquifaxUSA.HomePhoneNumber = "877-098-0974";
            SignerInformationForEquifaxUSA.TimeAtAddress = 3;
            SignerInformationForEquifaxUSA.DriversLicenseNumber = "97262872628463282";
            SignerInformationForEquifaxUSA.DateOfBirth = new DateTime();

            return SignerInformationForEquifaxUSA;
        }
    }
}
