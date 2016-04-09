using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DeliverSignedDocumentsByEmailExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new DeliverSignedDocumentsByEmailExample().Run();
        }

        override public void Execute()
        {
            var package = PackageBuilder.NewPackageNamed(PackageName)
                    .DescribedAs("This is a new package")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John")
                                .WithLastName("Smith")
                                .DeliverSignedDocumentsByEmail())
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100)))
                    .Build();

            var id = eslClient.CreatePackage(package);
            eslClient.SendPackage(id);
        }
    }
}

