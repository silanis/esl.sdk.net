using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignerInformationForEquifaxUsaExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SignerInformationForEquifaxUsaExample().Run();
        }

        public readonly string FirstName = "John";
        public readonly string LastName = "Smith";
        public readonly string StreetAddress = "PO BOX 451";
        public readonly string City = "CALERA";
        public readonly string State = "AL";
        public readonly string Zip = "35040";
        public readonly int? TimeAtAddress = 2;
        public readonly string SocialSecurityNumber = "666110007";
        public readonly string HomePhoneNumber = "2055551212";
        public readonly string DriversLicenseNumber = "251689216";
        public readonly DateTime? DateOfBirth = new DateTime(1973, 2, 2);

        private const string SignerId = "signerId";
        private const string DocumentName = "My Document";

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(FirstName)
                                .WithLastName(LastName)
                                .WithCustomId(SignerId)
                                .ChallengedWithKnowledgeBasedAuthentication(
                                        SignerInformationForEquifaxUSABuilder.NewSignerInformationForEquifaxUSA()
                                        .WithFirstName(FirstName)
                                        .WithLastName(LastName)
                                        .WithStreetAddress(StreetAddress)
                                        .WithCity(City)
                                        .WithState(State)
                                        .WithZip(Zip)
                                        .WithTimeAtAddress(TimeAtAddress)
                                        .WithSocialSecurityNumber(SocialSecurityNumber)
                                        .WithHomePhoneNumber(HomePhoneNumber)
                                        .WithDateOfBirth(DateOfBirth)
                                        .WithDriversLicenseNumber(DriversLicenseNumber)
                                        .Build()))
                                .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
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
