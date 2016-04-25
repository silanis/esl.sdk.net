using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CustomSenderInfoInCreateNewTemplateExample : SDKSample
    {
        public const string SENDER_FIRST_NAME = "Rob";
        public const string SENDER_SECOND_NAME = "Mason";
        public const string SENDER_TITLE = "Chief Vizier";
        public const string SENDER_COMPANY = "The Masons";

        private PackageId templateId;
        public PackageId TemplateId
        {
            get
            {
                return templateId;
            }
        }      

        public static void Main(string[] args)
        {
            new CustomSenderInfoInCreateNewTemplateExample().Run();
        }

        override public void Execute()
        {
            senderEmail = System.Guid.NewGuid().ToString().Replace("-","") + "@e-signlive.com";
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

            SenderInfo senderInfo = SenderInfoBuilder.NewSenderInfo(senderEmail)
                                    .WithName(SENDER_FIRST_NAME, SENDER_SECOND_NAME)
                                    .WithTitle(SENDER_TITLE)
                                    .WithCompany(SENDER_COMPANY)
                                    .Build();
        
            DocumentPackage template =
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

            templateId = eslClient.CreateTemplate(template);
        }
    }
}

