using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SendSmsToSignerExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SendSmsToSignerExample().Run();
        }

        public readonly string Signer1First = "John";
        public readonly string Signer1Last = "Smith";
        public readonly string Signer2First = "Patty";
        public readonly string Signer2Last = "Galant";
        public readonly string DocumentName = "First Document";

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName(Signer1First)
                                .WithLastName(Signer1Last)
                                .WithSMSSentTo(sms1))
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithFirstName(Signer2First)
                                .WithLastName(Signer2Last)
                                .WithSMSSentTo(sms2))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
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

