using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SessionCreationExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new SessionCreationExample().Run();
        }

        private const string SignerId = "myCustomSignerId";

        public SessionToken SignerSessionToken;

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                            .WithFirstName( "John" )
                            .WithLastName( "Smith" )
                            .WithCustomId( SignerId ) )
                    .WithDocument( DocumentBuilder.NewDocumentNamed( "First Document" )
                                  .FromStream( fileStream1, DocumentType.PDF )
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage( 0 )
                                   .AtPosition( 100, 100 ) ) )
                    .Build();

            var package = eslClient.CreatePackage( superDuperPackage );
            eslClient.SendPackage( package );
			SignerSessionToken = eslClient.CreateSignerSessionToken( package, email1 );
            Console.WriteLine("{0}/access?sessionToken={1}", webpageUrl, SignerSessionToken.Token);
        }
    }
}

