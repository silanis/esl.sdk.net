using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.IO;
using System.Collections.Generic;
using Silanis.ESL.SDK.Builder.Internal;
using ICSharpCode.SharpZipLib.Zip;

namespace SDK.Examples
{
    public class AttachmentRequirementExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new AttachmentRequirementExample().Run();
        }

        private readonly Stream _attachmentInputStream1;
        private readonly Stream _attachmentInputStream2;
        private readonly Stream _attachmentInputStream3;

        private Signer _signer1;
        private string _attachment1Id;

        public readonly string Name1 = "Driver's license";
        public readonly string Description1 = "Please upload a scanned copy of your driver's license.";
        public readonly string Name2 = "Medicare card";
        public readonly string Description2 = "Optional attachment.";
        public readonly string Name3 = "Attachment3";
        public readonly string Description3 = "Third description";
        public readonly string Signer1Id = "signer1Id";
        public readonly string Signer2Id = "signer2Id";
        public readonly string RejectionComment = "Reject: uploaded wrong attachment.";

        public readonly string AttachmentFileName1 = "The attachment1 for signer1.pdf";
        public readonly string AttachmentFileName2 = DocumentTypeUtility.NormalizeName (DocumentType.PDF, "The attachment2 for signer1");
        public readonly string AttachmentFileName3 = DocumentTypeUtility.NormalizeName (DocumentType.PDF, "The attachment2 for signer2");

        public readonly string DownloadedAllAttachmentsForPackageZip = "downloadedAllAttachmentsForPackage.zip";
        public readonly string DownloadedAllAttachmentsForSigner1InPackageZip = "downloadedAllAttachmentsForSigner1InPackage.zip";
        public readonly string DownloadedAllAttachmentsForSigner2InPackageZip = "downloadedAllAttachmentsForSigner2InPackage.zip";

        public DocumentPackage RetrievedPackageAfterRejection, RetrievedPackageAfterAccepting;
        public IList<AttachmentRequirement> Signer1Attachments, Signer2Attachments;
        public AttachmentRequirement Signer1Att1, Signer2Att1, Signer2Att2;
        public RequirementStatus RetrievedSigner1Att1RequirementStatus, RetrievedSigner2Att1RequirementStatus,
            RetrievedSigner2Att2RequirementStatus, RetrievedSigner1Att1RequirementStatusAfterRejection,
            RetrievedSigner1Att1RequirementStatusAfterAccepting;

        public string RetrievedSigner1Att1RequirementSenderCommentAfterRejection,
            RetrievedSigner1Att1RequirementSenderCommentAfterAccepting;

        public FileInfo DownloadedAttachemnt1;
        public long Attachment1ForSigner1FileSize;
        public ZipFile downloadedAllAttachmentsForPackageZip;
        public ZipFile downloadedAllAttachmentsForSigner1InPackageZip;
        public ZipFile downloadedAllAttachmentsForSigner2InPackageZip;

        public AttachmentRequirementExample()
        {
            _attachmentInputStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-for-anchor-extraction.pdf").FullName);
            _attachmentInputStream2 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-with-fields.pdf").FullName);
            _attachmentInputStream3 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/extract_document.pdf").FullName);
        }

        override public void Execute()
        {
            // Signer1 with 1 attachment requirement
            _signer1 = SignerBuilder.NewSignerWithEmail(email1)
                .WithFirstName("John")
                    .WithLastName("Smith")
                    .WithCustomId(Signer1Id)
                    .WithAttachmentRequirement(AttachmentRequirementBuilder.NewAttachmentRequirementWithName(Name1)
                                               .WithDescription(Description1)
                                               .IsRequiredAttachment()
                                               .Build())
                    .Build();

            // Signer2 with 2 attachment requirements
            var signer2 = SignerBuilder.NewSignerWithEmail(email2)
                .WithFirstName("Patty")
                    .WithLastName("Galant")
                    .WithCustomId(Signer2Id)
                    .WithAttachmentRequirement(AttachmentRequirementBuilder.NewAttachmentRequirementWithName(Name2)
                                               .WithDescription(Description2)
                                               .Build())
                    .WithAttachmentRequirement(AttachmentRequirementBuilder.NewAttachmentRequirementWithName(Name3)
                                               .WithDescription(Description3)
                                               .IsRequiredAttachment()
                                               .Build())
                    .Build();

            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                    .WithSigner(_signer1)
                    .WithSigner(signer2)
                    .WithDocument(DocumentBuilder.NewDocumentNamed("test document")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .Build())
                                  .Build())
                    .Build();

            packageId = eslClient.CreateAndSendPackage(superDuperPackage);

            retrievedPackage = eslClient.GetPackage(packageId);

            _attachment1Id = retrievedPackage.GetSigner(email1).GetAttachmentRequirement(Name1).Id;
            _signer1 = retrievedPackage.GetSigner(email1);

            Signer1Attachments = retrievedPackage.GetSigner(email1).Attachments;
            Signer2Attachments = retrievedPackage.GetSigner(email2).Attachments;

            Signer1Att1 = Signer1Attachments[0];
            Signer2Att1 = Signer2Attachments[0];
            Signer2Att2 = Signer2Attachments[1];

            RetrievedSigner1Att1RequirementStatus = Signer1Att1.Status;
            RetrievedSigner2Att1RequirementStatus = Signer2Att1.Status;
            RetrievedSigner2Att2RequirementStatus = Signer2Att2.Status;

            // Upload attachment for signer1

            var attachment1ForSigner1FileContent = new StreamDocumentSource(_attachmentInputStream1).Content();
            Attachment1ForSigner1FileSize = attachment1ForSigner1FileContent.Length;
            eslClient.UploadAttachment(packageId, Signer1Att1.Id, AttachmentFileName1, attachment1ForSigner1FileContent, Signer1Id);
            eslClient.UploadAttachment(packageId, Signer2Att1.Id, AttachmentFileName2, 
                                       new StreamDocumentSource(_attachmentInputStream2).Content(), Signer2Id);
            eslClient.UploadAttachment(PackageId, Signer2Att2.Id, AttachmentFileName3, 
                                       new StreamDocumentSource(_attachmentInputStream3).Content(), Signer2Id);

            // Sender rejects Signer1's uploaded attachment
            eslClient.AttachmentRequirementService.RejectAttachment(packageId, _signer1, Name1, RejectionComment);
            RetrievedPackageAfterRejection = eslClient.GetPackage(packageId);
            RetrievedSigner1Att1RequirementStatusAfterRejection = RetrievedPackageAfterRejection.GetSigner(email1).GetAttachmentRequirement(Name1).Status;
            RetrievedSigner1Att1RequirementSenderCommentAfterRejection = RetrievedPackageAfterRejection.GetSigner(email1).GetAttachmentRequirement(Name1).SenderComment;

            // Sender accepts Signer1's uploaded attachment
            eslClient.AttachmentRequirementService.AcceptAttachment(packageId, _signer1, Name1);
            RetrievedPackageAfterAccepting = eslClient.GetPackage(packageId);

            RetrievedSigner1Att1RequirementStatusAfterAccepting = RetrievedPackageAfterAccepting.GetSigner(email1).GetAttachmentRequirement(Name1).Status;
            RetrievedSigner1Att1RequirementSenderCommentAfterAccepting = RetrievedPackageAfterAccepting.GetSigner(email1).GetAttachmentRequirement(Name1).SenderComment;

            // Download signer1's attachment
            var downloadedAttachment = eslClient.AttachmentRequirementService.DownloadAttachmentFile(packageId, _attachment1Id);
            File.WriteAllBytes(downloadedAttachment.Filename, downloadedAttachment.Contents);

            // Download all attachments for the package
            var downloadedAllAttachmentsForPackage = eslClient.AttachmentRequirementService.DownloadAllAttachmentFilesForPackage(packageId);
            File.WriteAllBytes(DownloadedAllAttachmentsForPackageZip, downloadedAllAttachmentsForPackage.Contents);

            // Download all attachments for the signer1 in the package
            var downloadedAllAttachmentsForSigner1InPackage = eslClient.AttachmentRequirementService.DownloadAllAttachmentFilesForSignerInPackage(retrievedPackage, _signer1);
            File.WriteAllBytes(DownloadedAllAttachmentsForSigner1InPackageZip, downloadedAllAttachmentsForSigner1InPackage.Contents);

            // Download all attachments for the signer2 in the package
            var downloadedAllAttachmentsForSigner2InPackage = eslClient.AttachmentRequirementService.DownloadAllAttachmentFilesForSignerInPackage(retrievedPackage, signer2);
            File.WriteAllBytes(DownloadedAllAttachmentsForSigner2InPackageZip, downloadedAllAttachmentsForSigner2InPackage.Contents);

            DownloadedAttachemnt1 = new FileInfo(downloadedAttachment.Filename);
            downloadedAllAttachmentsForPackageZip = new ZipFile(DownloadedAllAttachmentsForPackageZip);
            downloadedAllAttachmentsForSigner1InPackageZip = new ZipFile(DownloadedAllAttachmentsForSigner1InPackageZip);
            downloadedAllAttachmentsForSigner2InPackageZip = new ZipFile(DownloadedAllAttachmentsForSigner2InPackageZip);
        }
    }
}

