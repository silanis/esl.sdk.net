using System;
using System.IO;
using System.Globalization;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class PackageLanguageConfigurationExample : SDKSample
	{
        public static void Main (string[] args)
        {
            new PackageLanguageConfigurationExample().Run();
        }

        override public void Execute()
        {
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs( "This is a package created using the e-SignLive SDK" )
				.WithLanguage(new CultureInfo("fr"))
                    .ExpiresOn( DateTime.Now.AddMonths(1) )
                    .WithEmailMessage( "This message should be delivered to all signers" )
                    .WithSigner( SignerBuilder.NewSignerWithEmail( email1 )
                                .WithFirstName( "John" )
                                .WithLastName( "Smith" ) )
                    .WithDocument( DocumentBuilder.NewDocumentNamed( "First Document" )
                                  .FromStream( fileStream1, DocumentType.PDF )
                                  .WithSignature( SignatureBuilder.SignatureFor( email1 )
                                   .OnPage( 0 )
                                   .AtPosition( 100, 100 )
                                   .WithField( FieldBuilder.TextField()
                               .OnPage( 0 )
                               .AtPosition( 400, 100 )
                               .WithSize( 200, 50 ) ) ) )
                    .Build();

            packageId = eslClient.CreatePackage( superDuperPackage );
            eslClient.SendPackage( packageId );
            retrievedPackage = eslClient.GetPackage(packageId);
        }
	}
}