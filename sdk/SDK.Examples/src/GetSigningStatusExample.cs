using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class GetSigningStatusExample : SdkSample
	{
        public static void Main (string[] args)
        {
            new GetSigningStatusExample().Run();
        }

        public SigningStatus DraftSigningStatus, SentSigningStatus, TrashedSigningStatus;

        override public void Execute()
        {
            var package = PackageBuilder.NewPackageNamed (PackageName)
					.DescribedAs ("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith"))
					.WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
					              .WithSignature(SignatureBuilder.SignatureFor(email1)
					              		.OnPage(0)
					               		.AtPosition(500, 100)))
					.Build ();

            var id = eslClient.CreatePackage (package);
            DraftSigningStatus = eslClient.GetSigningStatus(id, null, null);

            eslClient.SendPackage(id);
            SentSigningStatus = eslClient.GetSigningStatus(id, null, null);

            eslClient.PackageService.Trash(id);
            TrashedSigningStatus = eslClient.GetSigningStatus(id, null, null);
		}
	}
}