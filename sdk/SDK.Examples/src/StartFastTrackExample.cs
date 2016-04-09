using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class StartFastTrackExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new StartFastTrackExample().Run();
        }

        public PackageId TemplateId;
        public string SigningUrl;

        public readonly string TemplateDescription = "This is a package created using the e-SignLive SDK";
        public readonly string TemplateEmailMessage = "This message should be delivered to all signers";
        public readonly string TemplateSignerFirst = "John";
        public readonly string TemplateSignerLast = "Smith";
        public readonly string PlaceholderId = "PlaceholderId1";

        public readonly string FastTrackSignerFirst = "Patty";
        public readonly string FastTrackSignerLast = "Galant";

        public readonly string DocumentName = "First Document";
        public readonly string DocumentId = "doc1";

        override public void Execute()
        {

            var signer1 = SignerBuilder.NewSignerWithEmail(email1)
                .WithFirstName(TemplateSignerFirst)
                    .WithLastName(TemplateSignerLast).Build();
            var signer2 = SignerBuilder.NewSignerPlaceholder(new Placeholder(PlaceholderId)).Build();

            var template = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(TemplateDescription)
                    .WithEmailMessage(TemplateEmailMessage)
                    .WithSigner(signer1)
                    .WithSigner(signer2)
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .WithId(DocumentId)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100,100))
                                  .WithSignature(SignatureBuilder.SignatureFor(new Placeholder(PlaceholderId))
                                   .OnPage(0)
                                   .AtPosition(400,100))
                                  .Build())
                    .Build();

            TemplateId = eslClient.CreateTemplate(template);

            var signer = FastTrackSignerBuilder.NewSignerWithId(signer2.Id)
                .WithEmail(GetRandomEmail())
                    .WithFirstName(FastTrackSignerFirst)
                    .WithLastName(FastTrackSignerLast)
                    .Build();

            var signers = new List<FastTrackSigner>();
            signers.Add(signer);
            SigningUrl = eslClient.PackageService.StartFastTrack(TemplateId, signers);
        }
    }
}

