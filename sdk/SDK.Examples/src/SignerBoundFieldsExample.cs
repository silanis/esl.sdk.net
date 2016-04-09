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

        public const string DocumentName = "My Document";
        public const int SignatureDatePage = 0;
        public const int SignatureDatePositionX = 500;
        public const int SignatureDatePositionY = 200;
        public const int SignerNamePage = 0;
        public const int SignerNamePositionX = 500;
        public const int SignerNamePositionY = 300;
        public const int SignerTitlePage = 0;
        public const int SignerTitlePositionX = 500;
        public const int SignerTitlePositionY = 400;
        public const int SignerCompanyPage = 0;
        public const int SignerCompanyPositionX = 500;
        public const int SignerCompanyPositionY = 500;

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