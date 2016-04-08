using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class AuthenticationMethodsExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new AuthenticationMethodsExample().Run();
        }

        public static string QUESTION1 = "What's 1+1?";
        public static string ANSWER1 = "2";
        public static string QUESTION2 = "What color's the sky?";
        public static string ANSWER2 = "blue";

        override public void Execute()
        {
            var package = PackageBuilder.NewPackageNamed(PackageName)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName("John1")
                    .WithLastName("Smith1"))
                .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                    .WithCustomId("signer2")
                    .WithFirstName("John2")
                    .WithLastName("Smith2")
                    .ChallengedWithQuestions(ChallengeBuilder.FirstQuestion(QUESTION1)
                        .Answer(ANSWER1, Challenge.MaskOptions.None)
                        .SecondQuestion(QUESTION2)
                        .Answer(ANSWER2, Challenge.MaskOptions.MaskInput)))
                .WithSigner(SignerBuilder.NewSignerWithEmail(email3)
                    .WithFirstName("John3")
                    .WithLastName("Smith3")
                    .WithSMSSentTo(sms3))
                .WithDocument(DocumentBuilder.NewDocumentNamed("Custom Consent Document")
                    .FromStream(fileStream1, DocumentType.PDF)
                    .WithSignature(SignatureBuilder.SignatureFor(email2)
                        .OnPage(0)
                        .AtPosition(100, 100)))
                .Build();

            packageId = eslClient.CreatePackage(package); 
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

