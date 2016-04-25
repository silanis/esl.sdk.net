using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DocumentPackageAttributesExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new DocumentPackageAttributesExample().Run();
        }

        public readonly string DYNAMICS_2015 = "dynamics2015";
        public readonly string ATTRIBUTE_KEY_1 = "First Name";
        public readonly string ATTRIBUTE_KEY_2 = "Last Name";
        public readonly string ATTRIBUTE_KEY_3 = "Signing Order";
        public readonly string ATTRIBUTE_1 = "Bill";
        public readonly string ATTRIBUTE_2 = "Johnson";
        public readonly string ATTRIBUTE_3 = "1";

        override public void Execute()
        {
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
                    .WithDocument( DocumentBuilder.NewDocumentNamed( "First Document" )
                                  .FromStream( fileStream1, DocumentType.PDF )
                                  .WithSignature( SignatureBuilder.SignatureFor( email1 )
                                   .OnPage( 0 )
                                   .WithField( FieldBuilder.CheckBox()
                               .OnPage( 0 )
                               .AtPosition( 400, 200 )
                               .WithValue( FieldBuilder.CHECKBOX_CHECKED ) )
                                   .AtPosition( 100, 100 ) ) )
                    .WithOrigin(DYNAMICS_2015)
                    .WithAttributes(new DocumentPackageAttributesBuilder()
                                .WithAttribute( ATTRIBUTE_KEY_1, ATTRIBUTE_1 )
                                .WithAttribute( ATTRIBUTE_KEY_2, ATTRIBUTE_2 )
                                .WithAttribute( ATTRIBUTE_KEY_3, ATTRIBUTE_3 )
                                .Build())
                    .Build();

            packageId = eslClient.CreatePackage( superDuperPackage );
            eslClient.SendPackage( packageId );
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}
