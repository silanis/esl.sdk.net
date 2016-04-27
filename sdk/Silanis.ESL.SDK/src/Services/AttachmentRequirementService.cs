using System;
using Silanis.ESL.SDK.Services;

namespace Silanis.ESL.SDK
{
	/// <summary>
	/// The AttachmentRequirementService class provides methods to help create attachments for signers.
	/// </summary>
    public class AttachmentRequirementService
    {
        private readonly AttachmentRequirementApiClient _apiClient;
        private readonly PackageService _packageService;

        internal AttachmentRequirementService(RestClient restClient, string baseUrl)
        {
            _packageService = new PackageService(restClient, baseUrl);
            _apiClient = new AttachmentRequirementApiClient(restClient, baseUrl);
        }

		/// <summary>
		/// Sender accepts signer's attachment requirement.
		/// </summary>
		/// <param name="packageId">Package identifier.</param>
		/// <param name="signer">Signer.</param>
        /// <param name="attachmentName">Attachment identifier.</param>
		public void AcceptAttachment(PackageId packageId, Signer signer, String attachmentName)
        {
            signer.GetAttachmentRequirement(attachmentName).SenderComment = "";
            signer.GetAttachmentRequirement(attachmentName).Status = RequirementStatus.COMPLETE;
            
            _packageService.UpdateSigner(packageId, signer);
        }

		/// <summary>
		/// Sender rejects signer's attachment requirement with a comment.
		/// </summary>
		/// <param name="packageId">Package identifier.</param>
		/// <param name="signer">Signer.</param>
        /// <param name="attachmentName">Attachment identifier.</param>
		/// <param name="senderComment">Sender comment.</param>
        public void RejectAttachment(PackageId packageId, Signer signer, String attachmentName, String senderComment)
        {
            signer.GetAttachmentRequirement(attachmentName).SenderComment = senderComment;
            signer.GetAttachmentRequirement(attachmentName).Status = RequirementStatus.REJECTED;
            
            _packageService.UpdateSigner(packageId, signer);
        }

        [Obsolete("This method was replaced by DownloadAttachmentFile")]
        public byte[] DownloadAttachment(PackageId packageId, String attachmentId)
		{
            return DownloadAttachmentFile(packageId, attachmentId).Contents;
		}

        /// <summary>
        /// Sender downloads the attachment file.
        /// </summary>
        /// <returns>The attachment file with file name.</returns>
        /// <param name="packageId">Package identifier.</param>
        /// <param name="attachmentId">Attachment identifier.</param>
        public DownloadedFile DownloadAttachmentFile(PackageId packageId, String attachmentId)
        {
            return _apiClient.DownloadAttachmentFile(packageId.Id, attachmentId);
        }

        [Obsolete("This method was replaced by DownloadAllAttachmentFilesForPackage")]
        public byte[] DownloadAllAttachmentsForPackage(PackageId packageId)
        {
            return DownloadAllAttachmentFilesForPackage(packageId).Contents;
        }

        /// <summary>
        /// Sender downloads all attachment files for the package.
        /// </summary>
        /// <returns>The attachment files with file name.</returns>
        /// <param name="packageId">Package identifier.</param>
        public DownloadedFile DownloadAllAttachmentFilesForPackage(PackageId packageId)
        {
            return _apiClient.DownloadAllAttachmentFilesForPackage(packageId.Id);
        }

        [Obsolete("This method was replaced by DownloadAllAttachmentFilesForSignerInPackage")]
        public byte[] DownloadAllAttachmentsForSignerInPackage(DocumentPackage sdkPackage, Signer signer)
        {
            return DownloadAllAttachmentFilesForSignerInPackage(sdkPackage, signer).Contents;
        }

        /// <summary>
        /// Sender downloads all attachment files for the signer in the package.
        /// </summary>
        /// <returns>The attachment files with file name.</returns>
        /// <param name="sdkPackage">Package identifier.</param>
        /// <param name="signer">Signer.</param>
        public DownloadedFile DownloadAllAttachmentFilesForSignerInPackage(DocumentPackage sdkPackage, Signer signer)
        {
            return _apiClient.DownloadAllAttachmentFilesForSignerInPackage(sdkPackage, signer);
        }

        public void UploadAttachment(PackageId packageId, string attachmentId, string fileName, byte[] fileBytes, string signerSessionId)
        {
            _apiClient.UploadAttachment(packageId, attachmentId, fileName, fileBytes, signerSessionId);
        }
    }
}

