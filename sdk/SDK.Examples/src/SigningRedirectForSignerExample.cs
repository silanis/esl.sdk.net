using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.IO;

namespace SDK.Examples
{
    public class SigningRedirectForSignerExample: SDKSample
    {
        /** 
        Will not be supported until later release.
        **/

        public static void Main (string[] args)
        {
            new SigningRedirectForSignerExample().Run();
        }

        public string GeneratedLinkToSigningForSigner{ get; private set; }

        private AuthenticationClient authenticationClient;

        public SigningRedirectForSignerExample()
        {
            this.authenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {
            var signerId = System.Guid.NewGuid().ToString();
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

            var packageId = eslClient.CreatePackage (package);
            eslClient.SendPackage(packageId);


            var signerAuthenticationToken = eslClient.AuthenticationTokenService.CreateSignerAuthenticationToken(packageId, signerId);


            GeneratedLinkToSigningForSigner = authenticationClient.BuildRedirectToSigningForSigner(signerAuthenticationToken, packageId);

            //This is an example url that can be used in an iFrame or to open a browser window with a signing session (created from the signer authentication token) and a redirect to the signing page.
            System.Console.WriteLine("Signing redirect url: " + GeneratedLinkToSigningForSigner);
        }

    }
}