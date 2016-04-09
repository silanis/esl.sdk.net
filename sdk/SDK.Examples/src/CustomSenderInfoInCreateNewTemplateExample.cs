using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CustomSenderInfoInCreateNewTemplateExample : SdkSample
    {
        public const string SenderFirstName = "Rob";
        public const string SenderSecondName = "Mason";
        public const string SenderTitle = "Chief Vizier";
        public const string SenderCompany = "The Masons";

        public PackageId TemplateId { get; private set; }

        public static void Main(string[] args)
        {
            new CustomSenderInfoInCreateNewTemplateExample().Run();
        }

        override public void Execute()
        {
            senderEmail = Guid.NewGuid().ToString().Replace("-","") + "@e-signlive.com";
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

            var senderInfo = SenderInfoBuilder.NewSenderInfo(senderEmail)
                                    .WithName(SenderFirstName, SenderSecondName)
                                    .WithTitle(SenderTitle)
                                    .WithCompany(SenderCompany)
                                    .Build();
        
            var template =
                PackageBuilder.NewPackageNamed(PackageName)
                    .DescribedAs("This is a template created using the e-SignLive SDK")                 
                    .WithEmailMessage("This message should be delivered to all signers")
                    .WithSenderInfo(senderInfo)
                    .WithSigner(SignerBuilder.NewSignerPlaceholder(new Placeholder("PlaceholderId1")))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                              .FromStream(fileStream1, DocumentType.PDF)
                              .WithSignature(SignatureBuilder.SignatureFor(new Placeholder("PlaceholderId1"))
                                             .OnPage(0)
                                             .AtPosition(100, 100)
                                            )
                             )
                .Build();

            TemplateId = eslClient.CreateTemplate(template);
        }
    }
}

