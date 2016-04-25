using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class GetSigningStatusExample : SDKSample
	{
        public static void Main (string[] args)
        {
            new GetSigningStatusExample().Run();
        }

        public SigningStatus draftSigningStatus, sentSigningStatus, trashedSigningStatus;

        override public void Execute()
        {
            DocumentPackage package = PackageBuilder.NewPackageNamed (PackageName)
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

            PackageId packageId = eslClient.CreatePackage (package);
            draftSigningStatus = eslClient.GetSigningStatus(packageId, null, null);

            eslClient.SendPackage(packageId);
            sentSigningStatus = eslClient.GetSigningStatus(packageId, null, null);

            eslClient.PackageService.Trash(packageId);
            trashedSigningStatus = eslClient.GetSigningStatus(packageId, null, null);
		}
	}
}