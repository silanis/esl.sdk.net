using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class DocumentWorkflowExample : SdkSample
	{
        public static void Main (string[] args)
        {
            new DocumentWorkflowExample().Run();
        }

        override public void Execute() {
            var package = PackageBuilder.NewPackageNamed (PackageName)
					.DescribedAs ("This is a document workflow example")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith"))
					.WithDocument(DocumentBuilder.NewDocumentNamed("Second Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
					              .AtIndex(2)
					              .WithSignature(SignatureBuilder.SignatureFor(email1)
					              		.OnPage(0)
					               		.AtPosition(100, 100)))
					.WithDocument (DocumentBuilder.NewDocumentNamed("First Document")
                                   .FromStream(fileStream2, DocumentType.PDF)
					               .AtIndex (1)
					               .WithSignature(SignatureBuilder.SignatureFor(email1)
					               		.OnPage (0)
					               		.AtPosition (100, 100)))
					.Build ();

			packageId = eslClient.CreatePackage (package);

			Console.WriteLine("Package create, id = " + packageId);

			var savedPackage = eslClient.GetPackage(packageId);

			savedPackage.GetDocument("First Document").Index = 2;
            savedPackage.GetDocument("Second Document").Index = 1;

			eslClient.PackageService.OrderDocuments(savedPackage);

			Console.WriteLine("Document order saved");
		}
	}
}