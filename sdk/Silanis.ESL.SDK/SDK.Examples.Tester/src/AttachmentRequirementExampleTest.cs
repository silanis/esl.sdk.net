using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
	[TestClass]
	public class AttachmentRequirementExampleTest
    {
		private AttachmentRequirementExample _example;

		[TestMethod]
		public void VerifyResult()
		{
			_example = new AttachmentRequirementExample(  );
			_example.Run();

			// Asserts the attachment requirements for each signer is set correctly.
            Assert.AreEqual(1, _example.signer1Attachments.Count);
            Assert.AreEqual(_example.NAME1, _example.signer1Att1.Name);
            Assert.AreEqual(_example.DESCRIPTION1, _example.signer1Att1.Description);
            Assert.AreEqual(true, _example.signer1Att1.Required);
            Assert.AreEqual(RequirementStatus.INCOMPLETE.ToString(), _example.retrievedSigner1Att1RequirementStatus.ToString());
                               
            Assert.AreEqual(2, _example.signer2Attachments.Count);
            // Check Attachments ordering
            Assert.AreEqual(_example.NAME2, _example.signer2Attachments[0].Name);
            Assert.AreEqual(_example.NAME3, _example.signer2Attachments[1].Name);

            Assert.AreEqual(_example.NAME2, _example.signer2Att1.Name);
            Assert.AreEqual(_example.DESCRIPTION2, _example.signer2Att1.Description);
            Assert.AreEqual(false, _example.signer2Att1.Required);
            Assert.AreEqual(RequirementStatus.INCOMPLETE.ToString(), _example.retrievedSigner2Att1RequirementStatus.ToString());
            Assert.AreEqual(_example.NAME3, _example.signer2Att2.Name);
            Assert.AreEqual(_example.DESCRIPTION3, _example.signer2Att2.Description);
            Assert.AreEqual(true, _example.signer2Att2.Required);
            Assert.AreEqual(RequirementStatus.INCOMPLETE.ToString(), _example.retrievedSigner2Att2RequirementStatus.ToString());

            Assert.AreEqual(RequirementStatus.REJECTED.ToString(), _example.retrievedSigner1Att1RequirementStatusAfterRejection.ToString());
            Assert.AreEqual(_example.REJECTION_COMMENT, _example.retrievedSigner1Att1RequirementSenderCommentAfterRejection);

            Assert.AreEqual(RequirementStatus.COMPLETE.ToString(), _example.retrievedSigner1Att1RequirementStatusAfterAccepting.ToString());
            Assert.AreEqual("", _example.retrievedSigner1Att1RequirementSenderCommentAfterAccepting);

            Assert.AreEqual(_example.ATTACHMENT_FILE_NAME1, _example.downloadedAttachemnt1.Name);
            Assert.AreEqual(_example.attachment1ForSigner1FileSize, _example.downloadedAttachemnt1.Length);

            Assert.AreEqual(3, _example.downloadedAllAttachmentsForPackageZip.Size);
            Assert.AreEqual(1, _example.downloadedAllAttachmentsForSigner1InPackageZip.Size);
            Assert.AreEqual(2, _example.downloadedAllAttachmentsForSigner2InPackageZip.Size);
		}
    }
}

