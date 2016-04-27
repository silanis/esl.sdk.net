using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class StampFieldValueExample : SdkSample
	{
        public static void Main (string[] args)
        {
            new StampFieldValueExample().Run();
        }

        override public void Execute()
        {
            fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-with-fields.pdf").FullName);

            var package = PackageBuilder.NewPackageNamed (PackageName)
				.DescribedAs ("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith"))
					.WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                    .FromStream(fileStream1, DocumentType.PDF)
					              	.WithSignature(SignatureBuilder.SignatureFor(email1)
					            		.WithName("AGENT_SIG_1"))
					              	.WithInjectedField(FieldBuilder.Label()
					           			.WithName ("AGENT_SIG_2")
                                       .WithValue("Céline Lelièvre")))
					.Build ();

			var id = eslClient.CreatePackage (package);
			eslClient.SendPackage(id);
		}
	}
}