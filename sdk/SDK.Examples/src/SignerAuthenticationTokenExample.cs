using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class SignerAuthenticationTokenExample : SdkSample
    {
        /** 
        Will not be supported until later release.
        **/
        public static void Main (string[] args)
        {
            new SignerAuthenticationTokenExample().Run();
        }
        public string SignerSessionId { get; private set; }

        private readonly AuthenticationClient _authenticationClient;
        private const string SignerSessionFieldKey = "SDK SignerAuthenticationTokenExample Signer";

        public SignerAuthenticationTokenExample()
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

            IDictionary<string, string> signerSessionFields = new Dictionary<string, string>();
            signerSessionFields.Add(SignerSessionFieldKey, email1);
            var signerAuthenticationToken = eslClient.AuthenticationTokenService.CreateSignerAuthenticationToken(id, signerId, signerSessionFields);

            //This session id can be set in a cookie header
            SignerSessionId = _authenticationClient.GetSessionIdForSignerAuthenticationToken(signerAuthenticationToken);
        }
    }
}

