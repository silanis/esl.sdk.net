using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SignerBoundFieldsExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new SignerBoundFieldsExample().Run();
        }

        public readonly string DOCUMENT_NAME = "My Document";
        public readonly int SIGNATURE_DATE_PAGE = 0;
        public readonly int SIGNATURE_DATE_POSITION_X = 500;
        public readonly int SIGNATURE_DATE_POSITION_Y = 200;
        public readonly int SIGNER_NAME_PAGE = 0;
        public readonly int SIGNER_NAME_POSITION_X = 500;
        public readonly int SIGNER_NAME_POSITION_Y = 300;
        public readonly int SIGNER_TITLE_PAGE = 0;
        public readonly int SIGNER_TITLE_POSITION_X = 500;
        public readonly int SIGNER_TITLE_POSITION_Y = 400;
        public readonly int SIGNER_COMPANY_PAGE = 0;
        public readonly int SIGNER_COMPANY_POSITION_X = 500;
        public readonly int SIGNER_COMPANY_POSITION_Y = 500;

        override public void Execute()
        {
            DocumentPackage package = PackageBuilder.NewPackageNamed(PackageName)
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
                                            .OnPage(SIGNATURE_DATE_PAGE)
                                            .AtPosition(SIGNATURE_DATE_POSITION_X, SIGNATURE_DATE_POSITION_Y))
					               		.WithField(FieldBuilder.SignerName()
                                            .OnPage(SIGNER_NAME_PAGE)
                                            .AtPosition(SIGNER_NAME_POSITION_X, SIGNER_NAME_POSITION_Y))
							         	.WithField(FieldBuilder.SignerTitle()
                                            .OnPage(SIGNER_TITLE_PAGE)
                                            .AtPosition(SIGNER_TITLE_POSITION_X, SIGNER_TITLE_POSITION_Y))
					               		.WithField(FieldBuilder.SignerCompany()
                                            .OnPage(SIGNER_COMPANY_PAGE)
                                            .AtPosition(SIGNER_COMPANY_POSITION_X, SIGNER_COMPANY_POSITION_Y))))
					.Build();

            packageId = eslClient.CreatePackage(package);
            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}