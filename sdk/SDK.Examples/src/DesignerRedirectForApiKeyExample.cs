using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.IO;

namespace SDK.Examples
{
    public class DesignerRedirectForApiKeyExample : SDKSample
    {
        public static void Main (string[] args)
        {
            new DesignerRedirectForApiKeyExample().Run();
        }

        public string GeneratedLinkToDesignerForApiKey{ get; private set; }
        private AuthenticationClient authenticationClient;

        public DesignerRedirectForApiKeyExample()
        {
            this.authenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {            
            DocumentPackage package = PackageBuilder.NewPackageNamed (PackageName)
                    .DescribedAs ("This is a new package")
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromStream(fileStream1, DocumentType.PDF))
                    .Build();

            PackageId packageId = eslClient.CreatePackage (package);

            string userAuthenticationToken = eslClient.AuthenticationTokenService.CreateUserAuthenticationToken();


            GeneratedLinkToDesignerForApiKey = authenticationClient.BuildRedirectToDesignerForUserAuthenticationToken(userAuthenticationToken, packageId);

            //This is an example url that can be used in an iFrame or to open a browser window with a session (created from the user authentication token) and a redirect to the designer page.
            System.Console.WriteLine("Designer redirect url: " + GeneratedLinkToDesignerForApiKey);
        }
    }
}

