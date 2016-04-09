using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignerBoundFieldsExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SignerBoundFieldsExample().Run();
        }

        public readonly string DocumentName = "My Document";
        public readonly int SignatureDatePage = 0;
        public readonly int SignatureDatePositionX = 500;
        public readonly int SignatureDatePositionY = 200;
        public readonly int SignerNamePage = 0;
        public readonly int SignerNamePositionX = 500;
        public readonly int SignerNamePositionY = 300;
        public readonly int SignerTitlePage = 0;
        public readonly int SignerTitlePositionX = 500;
        public readonly int SignerTitlePositionY = 400;
        public readonly int SignerCompanyPage = 0;
        public readonly int SignerCompanyPositionX = 500;
        public readonly int SignerCompanyPositionY = 500;

        override public void Execute()
        {
            var package = PackageBuilder.NewPackageNamed(PackageName)
					.DescribedAs("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith")
					            .WithCompany("Acme Inc")
					            .WithTitle("Managing Director"))
					.WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
					              .WithSignature(SignatureBuilder.SignatureFor(email1)
					              		.OnPage(0)
					               		.AtPosition(500, 100)
					               		.WithField(FieldBuilder.SignatureDate()
                                            .OnPage(SignatureDatePage)
                                            .AtPosition(SignatureDatePositionX, SignatureDatePositionY))
					               		.WithField(FieldBuilder.SignerName()
                                            .OnPage(SignerNamePage)
                                            .AtPosition(SignerNamePositionX, SignerNamePositionY))
							         	.WithField(FieldBuilder.SignerTitle()
                                            .OnPage(SignerTitlePage)
                                            .AtPosition(SignerTitlePositionX, SignerTitlePositionY))
					               		.WithField(FieldBuilder.SignerCompany()
                                            .OnPage(SignerCompanyPage)
                                            .AtPosition(SignerCompanyPositionX, SignerCompanyPositionY))))
					.Build();

            packageId = eslClient.CreatePackage(package);
            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}