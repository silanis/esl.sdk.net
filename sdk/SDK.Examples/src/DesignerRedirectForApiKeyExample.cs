using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DesignerRedirectForApiKeyExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new DesignerRedirectForApiKeyExample().Run();
        }

        public string GeneratedLinkToDesignerForApiKey{ get; private set; }
        private readonly AuthenticationClient _authenticationClient;

        public DesignerRedirectForApiKeyExample()
        {
            _authenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {            
            var package = PackageBuilder.NewPackageNamed (PackageName)
                    .DescribedAs ("This is a new package")
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromStream(fileStream1, DocumentType.PDF))
                    .Build();

            var id = eslClient.CreatePackage (package);

            var userAuthenticationToken = eslClient.AuthenticationTokenService.CreateUserAuthenticationToken();


            GeneratedLinkToDesignerForApiKey = _authenticationClient.BuildRedirectToDesignerForUserAuthenticationToken(userAuthenticationToken, id);

            //This is an example url that can be used in an iFrame or to open a browser window with a session (created from the user authentication token) and a redirect to the designer page.
            Console.WriteLine("Designer redirect url: " + GeneratedLinkToDesignerForApiKey);
        }
    }
}

