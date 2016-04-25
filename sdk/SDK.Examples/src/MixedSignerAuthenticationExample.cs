using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.IO;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class MixedSignerAuthenticationExample: SDKSample
    {
        public static void Main(string[] args)
        {
            new MixedSignerAuthenticationExample().Run();
        }

        public Signer SIGNER_WITH_AUTHENTICATION_EQUIFAX_CANADA;
        public Signer SIGNER_WITH_AUTHENTICATION_EQUIFAX_USA;

        private string documentName = "My Document";

        override public void Execute()
        {
            SIGNER_WITH_AUTHENTICATION_EQUIFAX_CANADA = 
                SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName("Signer1")
                    .WithLastName("Canada")
                    .WithCustomId("SingerCanadaID")
                    .ChallengedWithKnowledgeBasedAuthentication(
                            SignerInformationForEquifaxCanadaBuilder.NewSignerInformationForEquifaxCanada()
                                .WithFirstName("Signer1")
                                .WithLastName("lastNameCanada")
                                .WithStreetAddress("1111")
                                .WithCity("Montreal")
                                .WithProvince("QC")
                                .WithPostalCode("A1A1A1")
                                .WithTimeAtAddress(1)
                                .WithDriversLicenseNumber("Driver licence number")
                                .WithSocialInsuranceNumber("111222333")
                                .WithHomePhoneNumber("514-111-2222")
                                .WithDateOfBirth(new DateTime(1965, 1, 1)))
                    .ChallengedWithQuestions(ChallengeBuilder.FirstQuestion("What's your favorite restaurant? (answer: Staffany)")
                        .Answer("Staffany")
                        .SecondQuestion("What sport do you play? (answer: hockey)")
                        .Answer("hockey"))
                    .Build();

            SIGNER_WITH_AUTHENTICATION_EQUIFAX_USA =
                SignerBuilder.NewSignerWithEmail(email2)
                    .WithFirstName("Signer2")
                    .WithLastName("USA")
                    .WithCustomId("SignerUSAID")
                    .ChallengedWithKnowledgeBasedAuthentication(
                            SignerInformationForEquifaxUSABuilder.NewSignerInformationForEquifaxUSA()
                                .WithFirstName("Singer2")
                                .WithLastName("lastNameUSA")
                                .WithStreetAddress("2222")
                                .WithCity("New York")
                                .WithState("NY")
                                .WithZip("65212")
                                .WithSocialSecurityNumber("222667098")
                                .WithHomePhoneNumber("870-111-6547")
                                .WithTimeAtAddress(3)
                                .WithDriversLicenseNumber("Driver License Number")
                                .WithDateOfBirth(new DateTime(1967, 2, 2)))
                    .ChallengedWithQuestions(ChallengeBuilder.FirstQuestion("What's your favorite sport? (answer: golf)")
                        .Answer("golf")
                        .SecondQuestion("What music instrument do you play? (answer: drums)")
                        .Answer("drums"))
                    .Build();

            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .WithSigner(SIGNER_WITH_AUTHENTICATION_EQUIFAX_CANADA)
                .WithSigner(SIGNER_WITH_AUTHENTICATION_EQUIFAX_USA)
                .WithDocument(DocumentBuilder.NewDocumentNamed(documentName)
                    .FromStream(fileStream1, DocumentType.PDF)
                    .WithSignature(SignatureBuilder.SignatureFor(email1)
                        .Build())
                    .WithSignature(SignatureBuilder.SignatureFor(email2)
                        .Build())
                    .Build())
                .Build();

            packageId = eslClient.CreateAndSendPackage(superDuperPackage);

            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}