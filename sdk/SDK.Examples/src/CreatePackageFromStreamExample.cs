using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CreatePackageFromStreamExample : SDKSample
    {
        public static void Main (string[] args)
        {
            new CreatePackageFromStreamExample().Run();
        }

        override public void Execute()
        {
            DocumentPackage package = PackageBuilder.NewPackageNamed(PackageName)
                    .DescribedAs("This is a new package")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John")
                                .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100)))
                    .Build();

            PackageId id = eslClient.CreatePackage(package);
            eslClient.SendPackage(id);
        }
    }
}