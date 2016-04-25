using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DocumentUploadExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new DocumentUploadExample().Run();
        }

        public readonly string UPLOADED_DOCUMENT_NAME = "First Document";

        override public void Execute()
        {
            // 1. Create a package
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs( "This is a package created using the e-SignLive SDK" )
                    .ExpiresOn( DateTime.Now.AddMonths(1) )
                    .WithEmailMessage( "This message should be delivered to all signers" )
                    .WithSigner( SignerBuilder.NewSignerWithEmail( email1 )
                                .WithCustomId( "Client1" )
                                .WithFirstName( "John" )
                                .WithLastName( "Smith" )
                                .WithTitle( "Managing Director" )
                                .WithCompany( "Acme Inc." ) )
                    .Build();
            packageId = eslClient.CreatePackage( superDuperPackage );
            superDuperPackage.Id = packageId;

            // 2. Construct a document
            Document document = DocumentBuilder.NewDocumentNamed( "First Document" )
                                .FromStream( fileStream1, DocumentType.PDF )
                                .WithSignature( SignatureBuilder.SignatureFor( email1 )
                                .OnPage( 0 )
                                .WithField( FieldBuilder.CheckBox()
                                .OnPage( 0 )
                                .AtPosition( 400, 200 )
                                .WithValue( FieldBuilder.CHECKBOX_CHECKED ) )
                                .AtPosition( 100, 100 ) )
                    .Build();

            // 3. Attach the document to the created package by uploading the document.
            eslClient.UploadDocument(document, superDuperPackage);

            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

