using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class PackageViewRedirectForPackageSenderExample: SdkSample
    {
        public static void Main (string[] args)
        {
            new PackageViewRedirectForPackageSenderExample().Run();
        }
        public string GeneratedLinkToPackageViewForSender;

        private readonly AuthenticationClient _authenticationClient;

        public PackageViewRedirectForPackageSenderExample()
        {
            _authenticationClient = new AuthenticationClient(webpageUrl);
        }

        override public void Execute()
        {
            eslClient.AccountService.InviteUser(
                AccountMemberBuilder.NewAccountMember(senderEmail)
                .WithFirstName("firstName")
                .WithLastName("lastName")
                .WithCompany("company")
                .WithTitle("title")
                .WithLanguage( "language" )
                .WithPhoneNumber( "phoneNumber" )
                .Build()
                );

            var customSenderInfo = SenderInfoBuilder.NewSenderInfo(senderEmail)
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
                                  .WithSignature(SignatureBuilder.SignatureFor(senderEmail)
                                   .OnPage(0)
                                   .AtPosition(100, 100)))
                    .Build();

            var package = eslClient.CreatePackage (customSenderPackage);

            var userAuthenticationToken = eslClient.AuthenticationTokenService.CreateUserAuthenticationToken();

            GeneratedLinkToPackageViewForSender = _authenticationClient.BuildRedirectToPackageViewForSender(userAuthenticationToken, package);

            Console.WriteLine("PackageView redirect url: " + GeneratedLinkToPackageViewForSender);
        }
    }
}

