using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SigningRedirectForSignerExample: SdkSample
    {
        /** 
        Will not be supported until later release.
        **/

        public static void Main (string[] args)
        {
            new SigningRedirectForSignerExample().Run();
        }

        public string GeneratedLinkToSigningForSigner{ get; private set; }

        private readonly AuthenticationClient _authenticationClient;

        public SigningRedirectForSignerExample()
        {
            _authenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {
            var signerId = Guid.NewGuid().ToString();
            var package = PackageBuilder.NewPackageNamed (PackageName)
                    .DescribedAs ("This is a new package")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John")
                                .WithLastName("Smith")
                                .WithCompany ("Acme Inc")
                                .WithTitle ("Managing Director")
                                .WithCustomId(signerId))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                        .OnPage(0)
                                        .AtPosition(500, 100)))
                    .Build ();

            var id = eslClient.CreatePackage (package);
            eslClient.SendPackage(id);


            var signerAuthenticationToken = eslClient.AuthenticationTokenService.CreateSignerAuthenticationToken(id, signerId);


            GeneratedLinkToSigningForSigner = _authenticationClient.BuildRedirectToSigningForSigner(signerAuthenticationToken, id);

            //This is an example url that can be used in an iFrame or to open a browser window with a signing session (created from the signer authentication token) and a redirect to the signing page.
            Console.WriteLine("Signing redirect url: " + GeneratedLinkToSigningForSigner);
        }

    }
}