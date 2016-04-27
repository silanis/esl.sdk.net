using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DesignerRedirectForPackageSenderExample: SdkSample
    {
        public static void Main (string[] args)
        {
            new DesignerRedirectForPackageSenderExample().Run();
        }

        public string GeneratedLinkToDesignerForSender{ get; private set; }

        private readonly AuthenticationClient _authenticationClient;
        private readonly string _packageSenderEmail;

        public DesignerRedirectForPackageSenderExample()
        {
            _packageSenderEmail = GetRandomEmail();
            _authenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {
            //Create a user on behalf of which you are going to send the package
            eslClient.AccountService.InviteUser(
                AccountMemberBuilder.NewAccountMember(_packageSenderEmail)
                .WithFirstName("firstName")
                .WithLastName("lastName")
                .WithCompany("company")
                .WithTitle("title")
                .WithLanguage( "language" )
                .WithPhoneNumber( "phoneNumber" )
                .Build()
            );

            var customSenderPackageId = CreatePackageWithCustomSender(_packageSenderEmail);


            var senderAuthenticationToken = eslClient.AuthenticationTokenService.CreateSenderAuthenticationToken(customSenderPackageId);


            GeneratedLinkToDesignerForSender = _authenticationClient.BuildRedirectToDesignerForSender(senderAuthenticationToken, customSenderPackageId);

            //This is an example url that can be used in an iFrame or to open a browser window with a sender session (created from the package sender authentication token) and a redirect to the designer page.
            Console.WriteLine("Designer redirect url: " + GeneratedLinkToDesignerForSender);
        }

        private PackageId CreatePackageWithCustomSender(string packageSenderEmail)
        {
            var customSenderInfo = SenderInfoBuilder.NewSenderInfo(packageSenderEmail)
                                    .WithName("firstName", "lastName")
                                    .WithTitle("title")
                                    .WithCompany("company")
                                    .Build();

            var customSenderPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSenderInfo(customSenderInfo)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .ExpiresOn(DateTime.Now.AddMonths(1))
                .WithEmailMessage("This message should be delivered to all signers")
                .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                              .FromStream(fileStream1, DocumentType.PDF)
                              .WithId("doc1"))
                .Build();
            var customSenderPackageId = eslClient.CreatePackage (customSenderPackage);
            return customSenderPackageId;
        }
    }
}

