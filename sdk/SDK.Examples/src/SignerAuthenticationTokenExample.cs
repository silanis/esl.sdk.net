using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.IO;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class SignerAuthenticationTokenExample : SDKSample
    {
        /** 
        Will not be supported until later release.
        **/
        public static void Main (string[] args)
        {
            new SignerAuthenticationTokenExample().Run();
        }
        public string SignerSessionId { get; private set; }

        private AuthenticationClient AuthenticationClient;
        private string signerSessionFieldKey = "SDK SignerAuthenticationTokenExample Signer";

        public SignerAuthenticationTokenExample()
        {
            this.AuthenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {
            string signerId = System.Guid.NewGuid().ToString();
            DocumentPackage package = PackageBuilder.NewPackageNamed (PackageName)
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

            PackageId packageId = eslClient.CreatePackage (package);
            eslClient.SendPackage(packageId);

            IDictionary<string, string> signerSessionFields = new Dictionary<string, string>();
            signerSessionFields.Add(signerSessionFieldKey, email1);
            string signerAuthenticationToken = eslClient.AuthenticationTokenService.CreateSignerAuthenticationToken(packageId, signerId, signerSessionFields);

            //This session id can be set in a cookie header
            SignerSessionId = AuthenticationClient.GetSessionIdForSignerAuthenticationToken(signerAuthenticationToken);
        }
    }
}

