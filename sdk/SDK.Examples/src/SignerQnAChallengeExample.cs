using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    /// <summary>
    /// Example of how to configure the Question & Answer authentication method for a signer. The answer is given for testing 
    /// purposes. Never include the answer when creating packages for actual customers.
    /// </summary>
    public class SignerQnAChallengeExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SignerQnAChallengeExample().Run();
        }

        public readonly string FirstQuestion = "What's your favorite sport? (answer: golf)";
        public readonly string FirstAnswer = "golf";
        public readonly string SecondQuestion = "What music instrument do you play? (answer: drums)";
        public readonly string SecondAnswer = "drums";

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a Q&A authentication example")
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName("John")
                    .WithLastName("Smith")
                    .ChallengedWithQuestions(ChallengeBuilder.FirstQuestion(FirstQuestion)
                        .Answer(FirstAnswer)
                        .SecondQuestion(SecondQuestion)
                        .AnswerWithMaskInput(SecondAnswer)))
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

