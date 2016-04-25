using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.IO;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class SignerInformationForEquifaxUSAExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new SignerInformationForEquifaxUSAExample().Run();
        }

        public readonly string FIRST_NAME = "John";
        public readonly string LAST_NAME = "Smith";
        public readonly string STREET_ADDRESS = "PO BOX 451";
        public readonly string CITY = "CALERA";
        public readonly string STATE = "AL";
        public readonly string ZIP = "35040";
        public readonly Nullable<Int32> TIME_AT_ADDRESS = 2;
        public readonly string SOCIAL_SECURITY_NUMBER = "666110007";
        public readonly string HOME_PHONE_NUMBER = "2055551212";
        public readonly string DRIVERS_LICENSE_NUMBER = "251689216";
        public readonly Nullable<DateTime> DATE_OF_BIRTH = new DateTime(1973, 2, 2);

        private string signerId = "signerId";
        private string documentName = "My Document";

        override public void Execute()
        {
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(FIRST_NAME)
                                .WithLastName(LAST_NAME)
                                .WithCustomId(signerId)
                                .ChallengedWithKnowledgeBasedAuthentication(
                                        SignerInformationForEquifaxUSABuilder.NewSignerInformationForEquifaxUSA()
                                        .WithFirstName(FIRST_NAME)
                                        .WithLastName(LAST_NAME)
                                        .WithStreetAddress(STREET_ADDRESS)
                                        .WithCity(CITY)
                                        .WithState(STATE)
                                        .WithZip(ZIP)
                                        .WithTimeAtAddress(TIME_AT_ADDRESS)
                                        .WithSocialSecurityNumber(SOCIAL_SECURITY_NUMBER)
                                        .WithHomePhoneNumber(HOME_PHONE_NUMBER)
                                        .WithDateOfBirth(DATE_OF_BIRTH)
                                        .WithDriversLicenseNumber(DRIVERS_LICENSE_NUMBER)
                                        .Build()))
                                .WithDocument(DocumentBuilder.NewDocumentNamed(documentName)
                                .FromStream(fileStream1, DocumentType.PDF)
                                .WithSignature(SignatureBuilder.SignatureFor(email1)
                                    .Build())
                                .Build())
                            .Build();

            packageId = eslClient.CreateAndSendPackage(superDuperPackage);

            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}
