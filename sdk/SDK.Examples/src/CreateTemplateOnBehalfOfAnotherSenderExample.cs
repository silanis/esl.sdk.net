using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CreateTemplateOnBehalfOfAnotherSenderExample : SDKSample
    {
        public PackageId templateId;

        public readonly string SENDER_FIRST_NAME = "Rob";
        public readonly string SENDER_LAST_NAME = "Mason";
        public readonly string SENDER_TITLE = "Chief Vizier";
        public readonly string SENDER_COMPANY = "The Masons";

        public static void Main(string[] args)
        {
            new CreateTemplateOnBehalfOfAnotherSenderExample().Run();
        }

        override public void Execute()
        {
            this.senderEmail = GetRandomEmail();

            // Invite the sender to account
            eslClient.AccountService.InviteUser(AccountMemberBuilder.NewAccountMember(senderEmail)
                .WithFirstName("firstName")
                .WithLastName("lastName")
                .WithCompany("company")
                .WithTitle("title")
                .WithPhoneNumber("phoneNumber")
                .WithStatus(SenderStatus.ACTIVE)
                .Build()
            );

            // Create the template specifying the sender
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .WithEmailMessage("This message should be delivered to all signers")
                .WithSenderInfo(SenderInfoBuilder.NewSenderInfo(senderEmail)
                    .WithName(SENDER_FIRST_NAME, SENDER_LAST_NAME)
                    .WithTitle(SENDER_TITLE)
                    .WithCompany(SENDER_COMPANY)
                    .Build())
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName("Patty")
                    .WithLastName("Galant"))
                .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                    .WithId("documentId")
                    .FromStream(fileStream1, DocumentType.PDF)
                    .WithSignature(SignatureBuilder.SignatureFor(senderEmail)
                        .AtPosition(200, 200)
                        .OnPage(0))
                    .WithSignature(SignatureBuilder.SignatureFor(email1)
                        .AtPosition(200, 400)
                        .OnPage(0)))
                .Build();

            // Create a template on behalf of another sender
            templateId = eslClient.CreateTemplate(superDuperPackage);

            var packageFromTemplate = PackageBuilder.NewPackageNamed("PackageFromTemplateOnBehalfOfSender" + DateTime.Now)
                .WithSenderInfo(SenderInfoBuilder.NewSenderInfo(senderEmail)
                    .WithName(SENDER_FIRST_NAME, SENDER_LAST_NAME)
                    .WithTitle(SENDER_TITLE)
                    .WithCompany(SENDER_COMPANY)
                    .Build())
                .WithDocument(DocumentBuilder.NewDocumentNamed("Second Document")
                    .WithId("documentId2")
                    .FromStream(fileStream2, DocumentType.PDF))
                .Build();

            // Create package from template on behalf of another sender
            packageId = eslClient.CreatePackageFromTemplate(templateId, packageFromTemplate);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

