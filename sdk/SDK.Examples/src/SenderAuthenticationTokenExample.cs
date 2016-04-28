using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class SenderAuthenticationTokenExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new SenderAuthenticationTokenExample().Run();
        }

        public string SenderSessionId { get; private set; }
        
        private readonly AuthenticationClient _authenticationClient;

        public SenderAuthenticationTokenExample()
        {
            _authenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {
            var superDuperPackage =
                PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .ExpiresOn(DateTime.Now.AddMonths(1))
                .WithEmailMessage("This message should be delivered to all signers")
                .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                              .FromStream(fileStream1, DocumentType.PDF)
                             )
                .Build();

            var package = eslClient.CreatePackage(superDuperPackage);

            var senderAuthenticationToken = eslClient.AuthenticationTokenService.CreateSenderAuthenticationToken(package);

            SenderSessionId = _authenticationClient.GetSessionIdForSenderAuthenticationToken(senderAuthenticationToken);
        }

    }
}

