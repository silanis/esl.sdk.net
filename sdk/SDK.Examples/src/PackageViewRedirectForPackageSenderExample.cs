using System;
using Silanis.ESL.SDK;
using System.IO;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class PackageViewRedirectForPackageSenderExample: SDKSample
    {
        public static void Main (string[] args)
        {
            new PackageViewRedirectForPackageSenderExample().Run();
        }
        public string generatedLinkToPackageViewForSender;

        private AuthenticationClient authenticationClient;

        public PackageViewRedirectForPackageSenderExample()
        {
            this.authenticationClient = new AuthenticationClient(webpageUrl);
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

            var packageId = eslClient.CreatePackage (customSenderPackage);

            var userAuthenticationToken = eslClient.AuthenticationTokenService.CreateUserAuthenticationToken();

            generatedLinkToPackageViewForSender = authenticationClient.BuildRedirectToPackageViewForSender(userAuthenticationToken, packageId);

            System.Console.WriteLine("PackageView redirect url: " + generatedLinkToPackageViewForSender);
        }
    }
}

