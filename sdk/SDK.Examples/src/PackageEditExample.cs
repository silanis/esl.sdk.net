using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class PackageEditExample : SdkSample
	{
        public static void Main (string[] args)
        {
			new PackageEditExample().Run();
        }

        override public void Execute()
        {
			var superDuperPackage =
                PackageBuilder.NewPackageNamed(PackageName)
					.DescribedAs("This is a package created using the e-SignLive SDK")
					.WithSigner(SignerBuilder.NewSignerWithEmail("john.smith@acme.com")
						.WithCustomId("Client1")
						.WithFirstName("John")
						.WithLastName("Smith")
					)
					.WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
						.FromStream(fileStream1, DocumentType.PDF)
						.WithSignature(SignatureBuilder.SignatureFor("john.smith@acme.com")
							.OnPage(0)
							.AtPosition(100, 100)
						)
					)
					.Build();

			var id = eslClient.CreateAndSendPackage(superDuperPackage);
			eslClient.PackageService.Edit(id);
        }
	}
}