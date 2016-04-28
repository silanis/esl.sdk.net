using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DocumentPackageAttributesExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new DocumentPackageAttributesExample().Run();
        }

        public readonly string Dynamics2015 = "dynamics2015";
        public readonly string AttributeKey1 = "First Name";
        public readonly string AttributeKey2 = "Last Name";
        public readonly string AttributeKey3 = "Signing Order";
        public readonly string Attribute1 = "Bill";
        public readonly string Attribute2 = "Johnson";
        public readonly string Attribute3 = "1";

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
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
                    .WithOrigin(Dynamics2015)
                    .WithAttributes(new DocumentPackageAttributesBuilder()
                                .WithAttribute( AttributeKey1, Attribute1 )
                                .WithAttribute( AttributeKey2, Attribute2 )
                                .WithAttribute( AttributeKey3, Attribute3 )
                                .Build())
                    .Build();

            packageId = eslClient.CreatePackage( superDuperPackage );
            eslClient.SendPackage( packageId );
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}
