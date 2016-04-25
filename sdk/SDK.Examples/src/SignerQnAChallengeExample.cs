using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    /// <summary>
    /// Example of how to configure the Question&Answer authentication method for a signer. The answer is given for testing 
    /// purposes. Never include the answer when creating packages for actual customers.
    /// </summary>
    public class SignerQnAChallengeExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new SignerQnAChallengeExample().Run();
        }

        public readonly string FIRST_QUESTION = "What's your favorite sport? (answer: golf)";
        public readonly string FIRST_ANSWER = "golf";
        public readonly string SECOND_QUESTION = "What music instrument do you play? (answer: drums)";
        public readonly string SECOND_ANSWER = "drums";

        override public void Execute()
        {
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a Q&A authentication example")
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName("John")
                    .WithLastName("Smith")
                    .ChallengedWithQuestions(ChallengeBuilder.FirstQuestion(FIRST_QUESTION)
                        .Answer(FIRST_ANSWER)
                        .SecondQuestion(SECOND_QUESTION)
                        .AnswerWithMaskInput(SECOND_ANSWER)))
                .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                    .FromStream(fileStream1, DocumentType.PDF)
                    .WithSignature(SignatureBuilder.SignatureFor(email1)
                        .OnPage(0)
                        .AtPosition(199, 100)))
                .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);

            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

