using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.IO;
using System.Collections.Generic;
using Silanis.ESL.SDK.Builder.Internal;
using ICSharpCode.SharpZipLib.Zip;

namespace SDK.Examples
{
    public class AttachmentRequirementExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new AttachmentRequirementExample().Run();
        }

        private Stream attachmentInputStream1, attachmentInputStream2, attachmentInputStream3;

        private Signer signer1;
        private string attachment1Id;

        public readonly string NAME1 = "Driver's license";
        public readonly string DESCRIPTION1 = "Please upload a scanned copy of your driver's license.";
        public readonly string NAME2 = "Medicare card";
        public readonly string DESCRIPTION2 = "Optional attachment.";
        public readonly string NAME3 = "Attachment3";
        public readonly string DESCRIPTION3 = "Third description";
        public readonly string SIGNER1_ID = "signer1Id";
        public readonly string SIGNER2_ID = "signer2Id";
        public readonly string REJECTION_COMMENT = "Reject: uploaded wrong attachment.";

        public readonly string ATTACHMENT_FILE_NAME1 = "The attachment1 for signer1.pdf";
        public readonly string ATTACHMENT_FILE_NAME2 = DocumentTypeUtility.NormalizeName (DocumentType.PDF, "The attachment2 for signer1");
        public readonly string ATTACHMENT_FILE_NAME3 = DocumentTypeUtility.NormalizeName (DocumentType.PDF, "The attachment2 for signer2");

        public readonly string DOWNLOADED_ALL_ATTACHMENTS_FOR_PACKAGE_ZIP = "downloadedAllAttachmentsForPackage.zip";
        public readonly string DOWNLOADED_ALL_ATTACHMENTS_FOR_SIGNER1_IN_PACKAGE_ZIP = "downloadedAllAttachmentsForSigner1InPackage.zip";
        public readonly string DOWNLOADED_ALL_ATTACHMENTS_FOR_SIGNER2_IN_PACKAGE_ZIP = "downloadedAllAttachmentsForSigner2InPackage.zip";

        public DocumentPackage retrievedPackageAfterRejection, retrievedPackageAfterAccepting;
        public IList<AttachmentRequirement> signer1Attachments, signer2Attachments;
        public AttachmentRequirement signer1Att1, signer2Att1, signer2Att2;
        public RequirementStatus retrievedSigner1Att1RequirementStatus, retrievedSigner2Att1RequirementStatus,
            retrievedSigner2Att2RequirementStatus, retrievedSigner1Att1RequirementStatusAfterRejection,
            retrievedSigner1Att1RequirementStatusAfterAccepting;

        public string retrievedSigner1Att1RequirementSenderCommentAfterRejection,
            retrievedSigner1Att1RequirementSenderCommentAfterAccepting;

        public FileInfo downloadedAttachemnt1;
        public long attachment1ForSigner1FileSize;
        public ZipFile downloadedAllAttachmentsForPackageZip, downloadedAllAttachmentsForSigner1InPackageZip, downloadedAllAttachmentsForSigner2InPackageZip;

        public AttachmentRequirementExample()
        {
            this.attachmentInputStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-for-anchor-extraction.pdf").FullName);
            this.attachmentInputStream2 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document-with-fields.pdf").FullName);
            this.attachmentInputStream3 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/extract_document.pdf").FullName);
        }

        override public void Execute()
        {
            // Signer1 with 1 attachment requirement
            signer1 = SignerBuilder.NewSignerWithEmail(email1)
                .WithFirstName("John")
                    .WithLastName("Smith")
                    .WithCustomId(SIGNER1_ID)
                    .WithAttachmentRequirement(AttachmentRequirementBuilder.NewAttachmentRequirementWithName(NAME1)
                                               .WithDescription(DESCRIPTION1)
                                               .IsRequiredAttachment()
                                               .Build())
                    .Build();

            // Signer2 with 2 attachment requirements
            var signer2 = SignerBuilder.NewSignerWithEmail(email2)
                .WithFirstName("Patty")
                    .WithLastName("Galant")
                    .WithCustomId(SIGNER2_ID)
                    .WithAttachmentRequirement(AttachmentRequirementBuilder.NewAttachmentRequirementWithName(NAME2)
                                               .WithDescription(DESCRIPTION2)
                                               .Build())
                    .WithAttachmentRequirement(AttachmentRequirementBuilder.NewAttachmentRequirementWithName(NAME3)
                                               .WithDescription(DESCRIPTION3)
                                               .IsRequiredAttachment()
                                               .Build())
                    .Build();

            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                    .WithSigner(signer1)
                    .WithSigner(signer2)
                    .WithDocument(DocumentBuilder.NewDocumentNamed("test document")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .Build())
                                  .Build())
                    .Build();

            packageId = eslClient.CreateAndSendPackage(superDuperPackage);

            retrievedPackage = eslClient.GetPackage(packageId);

            attachment1Id = retrievedPackage.GetSigner(email1).GetAttachmentRequirement(NAME1).Id;
            signer1 = retrievedPackage.GetSigner(email1);

            signer1Attachments = retrievedPackage.GetSigner(email1).Attachments;
            signer2Attachments = retrievedPackage.GetSigner(email2).Attachments;

            signer1Att1 = signer1Attachments[0];
            signer2Att1 = signer2Attachments[0];
            signer2Att2 = signer2Attachments[1];

            retrievedSigner1Att1RequirementStatus = signer1Att1.Status;
            retrievedSigner2Att1RequirementStatus = signer2Att1.Status;
            retrievedSigner2Att2RequirementStatus = signer2Att2.Status;

            // Upload attachment for signer1

            var attachment1ForSigner1FileContent = new StreamDocumentSource(attachmentInputStream1).Content();
            attachment1ForSigner1FileSize = attachment1ForSigner1FileContent.Length;
            eslClient.UploadAttachment(packageId, signer1Att1.Id, ATTACHMENT_FILE_NAME1, attachment1ForSigner1FileContent, SIGNER1_ID);
            eslClient.UploadAttachment(packageId, signer2Att1.Id, ATTACHMENT_FILE_NAME2, 
                                       new StreamDocumentSource(attachmentInputStream2).Content(), SIGNER2_ID);
            eslClient.UploadAttachment(PackageId, signer2Att2.Id, ATTACHMENT_FILE_NAME3, 
                                       new StreamDocumentSource(attachmentInputStream3).Content(), SIGNER2_ID);

            // Sender rejects Signer1's uploaded attachment
            eslClient.AttachmentRequirementService.RejectAttachment(packageId, signer1, NAME1, REJECTION_COMMENT);
            retrievedPackageAfterRejection = eslClient.GetPackage(packageId);
            retrievedSigner1Att1RequirementStatusAfterRejection = retrievedPackageAfterRejection.GetSigner(email1).GetAttachmentRequirement(NAME1).Status;
            retrievedSigner1Att1RequirementSenderCommentAfterRejection = retrievedPackageAfterRejection.GetSigner(email1).GetAttachmentRequirement(NAME1).SenderComment;

            // Sender accepts Signer1's uploaded attachment
            eslClient.AttachmentRequirementService.AcceptAttachment(packageId, signer1, NAME1);
            retrievedPackageAfterAccepting = eslClient.GetPackage(packageId);

            retrievedSigner1Att1RequirementStatusAfterAccepting = retrievedPackageAfterAccepting.GetSigner(email1).GetAttachmentRequirement(NAME1).Status;
            retrievedSigner1Att1RequirementSenderCommentAfterAccepting = retrievedPackageAfterAccepting.GetSigner(email1).GetAttachmentRequirement(NAME1).SenderComment;

            // Download signer1's attachment
            var downloadedAttachment = eslClient.AttachmentRequirementService.DownloadAttachmentFile(packageId, attachment1Id);
            System.IO.File.WriteAllBytes(downloadedAttachment.Filename, downloadedAttachment.Contents);

            // Download all attachments for the package
            var downloadedAllAttachmentsForPackage = eslClient.AttachmentRequirementService.DownloadAllAttachmentFilesForPackage(packageId);
            System.IO.File.WriteAllBytes(DOWNLOADED_ALL_ATTACHMENTS_FOR_PACKAGE_ZIP, downloadedAllAttachmentsForPackage.Contents);

            // Download all attachments for the signer1 in the package
            var downloadedAllAttachmentsForSigner1InPackage = eslClient.AttachmentRequirementService.DownloadAllAttachmentFilesForSignerInPackage(retrievedPackage, signer1);
            System.IO.File.WriteAllBytes(DOWNLOADED_ALL_ATTACHMENTS_FOR_SIGNER1_IN_PACKAGE_ZIP, downloadedAllAttachmentsForSigner1InPackage.Contents);

            // Download all attachments for the signer2 in the package
            var downloadedAllAttachmentsForSigner2InPackage = eslClient.AttachmentRequirementService.DownloadAllAttachmentFilesForSignerInPackage(retrievedPackage, signer2);
            System.IO.File.WriteAllBytes(DOWNLOADED_ALL_ATTACHMENTS_FOR_SIGNER2_IN_PACKAGE_ZIP, downloadedAllAttachmentsForSigner2InPackage.Contents);

            downloadedAttachemnt1 = new FileInfo(downloadedAttachment.Filename);
            downloadedAllAttachmentsForPackageZip = new ZipFile(DOWNLOADED_ALL_ATTACHMENTS_FOR_PACKAGE_ZIP);
            downloadedAllAttachmentsForSigner1InPackageZip = new ZipFile(DOWNLOADED_ALL_ATTACHMENTS_FOR_SIGNER1_IN_PACKAGE_ZIP);
            downloadedAllAttachmentsForSigner2InPackageZip = new ZipFile(DOWNLOADED_ALL_ATTACHMENTS_FOR_SIGNER2_IN_PACKAGE_ZIP);
        }
    }
}

