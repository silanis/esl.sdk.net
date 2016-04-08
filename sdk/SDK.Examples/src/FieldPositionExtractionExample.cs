using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class FieldPositionExtractionExample : SDKSample
	{
        public static void Main (string[] args)
        {
            new FieldPositionExtractionExample().Run();
        }

        override public void Execute()
        {
            var package = PackageBuilder.NewPackageNamed (PackageName)
				.DescribedAs ("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith"))
					.WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                    .FromStream(fileStream1, DocumentType.PDF)
					              	.EnableExtraction()
					              	.WithSignature(SignatureBuilder.SignatureFor(email1)
					            		.WithName("AGENT_SIG_1")
					               		.EnableExtraction()                                    
					               		.WithField(FieldBuilder.SignatureDate()
					           				.WithName("AGENT_SIG_2")
					           				.WithPositionExtracted())))
					.Build ();

			var id = eslClient.CreatePackage (package);
			eslClient.SendPackage(id);
		}
	}
}