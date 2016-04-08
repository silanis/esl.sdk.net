using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class StartFastTrackExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new StartFastTrackExample().Run();
        }

        public PackageId templateId;
        public string signingUrl;

        public readonly string TEMPLATE_DESCRIPTION = "This is a package created using the e-SignLive SDK";
        public readonly string TEMPLATE_EMAIL_MESSAGE = "This message should be delivered to all signers";
        public readonly string TEMPLATE_SIGNER_FIRST = "John";
        public readonly string TEMPLATE_SIGNER_LAST = "Smith";
        public readonly string PLACEHOLDER_ID = "PlaceholderId1";

        public readonly string FAST_TRACK_SIGNER_FIRST = "Patty";
        public readonly string FAST_TRACK_SIGNER_LAST = "Galant";

        public readonly string DOCUMENT_NAME = "First Document";
        public readonly string DOCUMENT_ID = "doc1";

        override public void Execute()
        {

            var signer1 = SignerBuilder.NewSignerWithEmail(email1)
                .WithFirstName(TEMPLATE_SIGNER_FIRST)
                    .WithLastName(TEMPLATE_SIGNER_LAST).Build();
            var signer2 = SignerBuilder.NewSignerPlaceholder(new Placeholder(PLACEHOLDER_ID)).Build();

            var template = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs(TEMPLATE_DESCRIPTION)
                    .WithEmailMessage(TEMPLATE_EMAIL_MESSAGE)
                    .WithSigner(signer1)
                    .WithSigner(signer2)
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .WithId(DOCUMENT_ID)
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100,100))
                                  .WithSignature(SignatureBuilder.SignatureFor(new Placeholder(PLACEHOLDER_ID))
                                   .OnPage(0)
                                   .AtPosition(400,100))
                                  .Build())
                    .Build();

            templateId = eslClient.CreateTemplate(template);

            var signer = FastTrackSignerBuilder.NewSignerWithId(signer2.Id)
                .WithEmail(GetRandomEmail())
                    .WithFirstName(FAST_TRACK_SIGNER_FIRST)
                    .WithLastName(FAST_TRACK_SIGNER_LAST)
                    .Build();

            var signers = new List<FastTrackSigner>();
            signers.Add(signer);
            signingUrl = eslClient.PackageService.StartFastTrack(templateId, signers);
        }
    }
}

