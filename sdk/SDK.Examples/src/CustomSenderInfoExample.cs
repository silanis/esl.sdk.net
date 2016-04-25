using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CustomSenderInfoExample : SDKSample
    {
        public const string SENDER_FIRST_NAME = "Rob";
        public const string SENDER_SECOND_NAME = "Mason";
        public const string SENDER_TITLE = "Chief Vizier";
        public const string SENDER_COMPANY = "The Masons";

        public static void Main(string[] args)
        {
            CustomSenderInfoExample example = new CustomSenderInfoExample();
            example.Run();

            DocumentPackage documentPackage = example.eslClient.GetPackage(example.PackageId);
            Console.WriteLine("Document packages = " + documentPackage.Id);
        }

        private DocumentPackage package;

        public string SenderEmail
        {
            get
            {
                return senderEmail;
            }
        }

        public DocumentPackage Package
        {
            get
            {
                return package;
            }
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
                .WithLanguage( "fr" )
                .WithPhoneNumber( "phoneNumber" )
                .WithStatus(SenderStatus.ACTIVE)
                .Build()
            );

            SenderInfo senderInfo = SenderInfoBuilder.NewSenderInfo(senderEmail)
                                    .WithName(SENDER_FIRST_NAME, SENDER_SECOND_NAME)
                                    .WithTitle(SENDER_TITLE)
                                    .WithCompany(SENDER_COMPANY)
                                    .Build();

            package = PackageBuilder.NewPackageNamed(PackageName)
                      .WithSenderInfo( senderInfo )
                      .DescribedAs( "This is a package created using the e-SignLive SDK" )
                      .ExpiresOn( DateTime.Now.AddMonths(1) )
                      .WithEmailMessage( "This message should be delivered to all signers" )
                      .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                                    .FromStream(fileStream1, DocumentType.PDF)
									.WithId("doc1"))
                      .Build();

            packageId = eslClient.CreatePackage( package );

			eslClient.DownloadDocument(packageId, "doc1");
            retrievedPackage = eslClient.GetPackage(packageId);

			Console.WriteLine("Downloaded document");
        }
    }
}