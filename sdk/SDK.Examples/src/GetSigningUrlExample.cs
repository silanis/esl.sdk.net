using System;
using System.IO;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class GetSigningUrlExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new GetSigningUrlExample().Run();
        }

        public string signingUrlForSigner1;
        public string signingUrlForSigner2;

        public readonly string DOCUMENT_NAME = "First Document";

        override public void Execute()
        {
            string signer1Id = Guid.NewGuid().ToString().Replace("-", "");
            string signer2Id = Guid.NewGuid().ToString().Replace("-", "");

            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings().WithInPerson())
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John1")
                                .WithLastName("Smith1")
                                .WithCustomId(signer1Id))
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithFirstName("John2")
                                .WithLastName("Smith2")
                                .WithCustomId(signer2Id))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .WithSignature(SignatureBuilder.SignatureFor(email2)
                                   .OnPage(0)
                                   .AtPosition(100, 200)))
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);

            signingUrlForSigner1 = eslClient.PackageService.GetSigningUrl(packageId, signer1Id);
            signingUrlForSigner2 = eslClient.PackageService.GetSigningUrl(packageId, signer2Id);
        }
    }
}

