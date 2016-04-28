using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SDK.Examples
{
    [TestClass]
    public class MixedSignerAuthenticationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new MixedSignerAuthenticationExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            var canadianSigner = documentPackage.GetSigner(example.SignerWithAuthenticationEquifaxCanada.Email);
            var canadianSignerInformationForEquifaxCanada = canadianSigner.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada;

            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.FirstName, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.FirstName);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.LastName, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.LastName);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.StreetAddress, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.StreetAddress);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.City, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.City);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.Province, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.Province);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.PostalCode, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.PostalCode);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.TimeAtAddress, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.TimeAtAddress);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.DriversLicenseNumber, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.DriversLicenseNumber);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.SocialInsuranceNumber, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.SocialInsuranceNumber);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.HomePhoneNumber, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.HomePhoneNumber);
            Assert.AreEqual(canadianSignerInformationForEquifaxCanada.DateOfBirth, example.SignerWithAuthenticationEquifaxCanada.KnowledgeBasedAuthentication.SignerInformationForEquifaxCanada.DateOfBirth);

            // Note that for security reasons, the backend doesn't return challenge answers, so we don't verify the answers here.
            foreach (var challenge in canadianSigner.ChallengeQuestion)
            {
                Assert.IsTrue(String.Equals(challenge.Question, example.SignerWithAuthenticationEquifaxCanada.ChallengeQuestion[0].Question) || String.Equals(challenge.Question, example.SignerWithAuthenticationEquifaxCanada.ChallengeQuestion[1].Question));
            }

            var usaSigner = documentPackage.GetSigner(example.SignerWithAuthenticationEquifaxUsa.Email);
            var usaSignerInformationForEquifaxUSA = usaSigner.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA;

            Assert.AreEqual(usaSignerInformationForEquifaxUSA.FirstName, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.FirstName);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.LastName, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.LastName);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.StreetAddress, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.StreetAddress);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.City, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.City);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.State, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.State);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.Zip, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.Zip);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.SocialSecurityNumber, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.SocialSecurityNumber);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.HomePhoneNumber, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.HomePhoneNumber);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.DateOfBirth, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.DateOfBirth);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.TimeAtAddress, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.TimeAtAddress);
            Assert.AreEqual(usaSignerInformationForEquifaxUSA.DriversLicenseNumber, example.SignerWithAuthenticationEquifaxUsa.KnowledgeBasedAuthentication.SignerInformationForEquifaxUSA.DriversLicenseNumber);

            foreach (var challenge in usaSigner.ChallengeQuestion)
            {
                Assert.IsTrue(String.Equals(challenge.Question, example.SignerWithAuthenticationEquifaxUsa.ChallengeQuestion[0].Question) || String.Equals(challenge.Question, example.SignerWithAuthenticationEquifaxUsa.ChallengeQuestion[1].Question));
            }

        }
    }
}

