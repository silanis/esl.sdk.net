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
            
        public const string FirstName = "John";
        public const string LastName = "Smith";
        public const string StreetAddress = "1234 Decarie";
        public const string City = "Montreal";
        public const string Province = "QC";
        public const string PostalCode = "A2A5D4";
        public const string DriversLicenseNumber = "C54625641298452";
        public const string SocialInsuranceNumber = "247018476";
        public const string HomePhoneNumber = "5145786234";
        public readonly int? TimeAtAddress = 1;
        public static readonly DateTime? DateOfBirth = new DateTime(1971, 1, 1);

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
