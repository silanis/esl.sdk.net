using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SendSmsToSignerExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new SendSmsToSignerExample().Run();
        }

        public readonly string SIGNER1_FIRST = "John";
        public readonly string SIGNER1_LAST = "Smith";
        public readonly string SIGNER2_FIRST = "Patty";
        public readonly string SIGNER2_LAST = "Galant";
        public readonly string DOCUMENT_NAME = "First Document";

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(SIGNER1_FIRST)
                                .WithLastName(SIGNER1_LAST)
                                .WithSMSSentTo(sms1))
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithFirstName(SIGNER2_FIRST)
                                .WithLastName(SIGNER2_LAST)
                                .WithSMSSentTo(sms2))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100))
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(400, 100)))
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);

            eslClient.PackageService.SendSmsToSigner(packageId, retrievedPackage.GetSigner(email1));
            eslClient.PackageService.SendSmsToSigner(packageId, retrievedPackage.GetSigner(email2));

            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

