using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignerInformationForEquifaxCanadaExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SignerInformationForEquifaxCanadaExample().Run();
        }

        public readonly string FirstName = "John";
        public readonly string LastName = "Smith";
        public readonly string StreetAddress = "1234 Decarie";
        public readonly string City = "Montreal";
        public readonly string Province = "QC";
        public readonly string PostalCode = "A2A5D4";
        public readonly string DriversLicenseNumber = "C54625641298452";
        public readonly string SocialInsuranceNumber = "247018476";
        public readonly string HomePhoneNumber = "5145786234";
        public readonly int? TimeAtAddress = 1;
        public readonly DateTime? DateOfBirth = new DateTime(1971, 1, 1);

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
                                        SignerInformationForEquifaxCanadaBuilder.NewSignerInformationForEquifaxCanada()
                                        .WithFirstName(FirstName)
                                        .WithLastName(LastName)
                                        .WithStreetAddress(StreetAddress)
                                        .WithCity(City)
                                        .WithProvince(Province)
                                        .WithPostalCode(PostalCode)
                                        .WithTimeAtAddress(TimeAtAddress)
                                        .WithDriversLicenseNumber(DriversLicenseNumber)
                                        .WithSocialInsuranceNumber(SocialInsuranceNumber)
                                        .WithHomePhoneNumber(HomePhoneNumber)
                                        .WithDateOfBirth(DateOfBirth)
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
