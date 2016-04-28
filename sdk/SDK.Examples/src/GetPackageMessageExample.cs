using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    /// <summary>
    /// Get a package's messages (ex: opt out or decline messages from signers).
    /// </summary>
    public class GetPackageMessageExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new GetPackageMessageExample().Run();
        }

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                    .DescribedAs("This is a package created using the e-SignLive SDK")
                    .ExpiresOn(DateTime.Now.AddMonths(100))
                    .WithEmailMessage("This message should be delivered to all signers")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                        .WithCustomId("Client1")
                        .WithFirstName("John")
                        .WithLastName("Smith")
                        .WithTitle("Managing Director")
                        .WithCompany("Acme Inc."))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                        .FromStream(fileStream1, DocumentType.PDF)
                        .WithSignature(SignatureBuilder.SignatureFor(email1)
                            .OnPage(0)
                            .AtPosition(100, 100)
                            .WithSize(200, 50)))
                    .Build();

            packageId = eslClient.CreateAndSendPackage(superDuperPackage);

            // Signer opt-out or decline signing.

            // Get the list of messages from signer (ex: opt out or decline reasons)
            var documentPackage = eslClient.GetPackage(packageId);
            var messages = eslClient.GetPackage(packageId).Messages;
            Console.WriteLine(documentPackage.Status + " reason : " + messages[0].Content);
        }
    }
}
