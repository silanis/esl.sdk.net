using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CustomSenderInfoExample : SdkSample
    {
        public const string SenderFirstName = "Rob";
        public const string SenderSecondName = "Mason";
        public const string SenderTitle = "Chief Vizier";
        public const string SenderCompany = "The Masons";

        public static void Main(string[] args)
        {
            var example = new CustomSenderInfoExample();
            example.Run();

            var documentPackage = example.eslClient.GetPackage(example.PackageId);
            Console.WriteLine("Document packages = " + documentPackage.Id);
        }

        private DocumentPackage _package;

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
                return _package;
            }
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
                .WithLanguage( "fr" )
                .WithPhoneNumber( "phoneNumber" )
                .WithStatus(SenderStatus.ACTIVE)
                .Build()
            );

            var senderInfo = SenderInfoBuilder.NewSenderInfo(senderEmail)
                                    .WithName(SenderFirstName, SenderSecondName)
                                    .WithTitle(SenderTitle)
                                    .WithCompany(SenderCompany)
                                    .Build();

            _package = PackageBuilder.NewPackageNamed(PackageName)
                      .WithSenderInfo( senderInfo )
                      .DescribedAs( "This is a package created using the e-SignLive SDK" )
                      .ExpiresOn( DateTime.Now.AddMonths(1) )
                      .WithEmailMessage( "This message should be delivered to all signers" )
                      .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                                    .FromStream(fileStream1, DocumentType.PDF)
									.WithId("doc1"))
                      .Build();

            packageId = eslClient.CreatePackage( _package );

			eslClient.DownloadDocument(packageId, "doc1");
            retrievedPackage = eslClient.GetPackage(packageId);

			Console.WriteLine("Downloaded document");
        }
    }
}