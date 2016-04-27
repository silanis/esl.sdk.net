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
            Assert.AreEqual(1, _example.Signer1Attachments.Count);
            Assert.AreEqual(_example.Name1, _example.Signer1Att1.Name);
            Assert.AreEqual(_example.Description1, _example.Signer1Att1.Description);
            Assert.AreEqual(true, _example.Signer1Att1.Required);
            Assert.AreEqual(RequirementStatus.INCOMPLETE.ToString(), _example.RetrievedSigner1Att1RequirementStatus.ToString());
                               
            Assert.AreEqual(2, _example.Signer2Attachments.Count);
            // Check Attachments ordering
            Assert.AreEqual(_example.Name2, _example.Signer2Attachments[0].Name);
            Assert.AreEqual(_example.Name3, _example.Signer2Attachments[1].Name);

            Assert.AreEqual(_example.Name2, _example.Signer2Att1.Name);
            Assert.AreEqual(_example.Description2, _example.Signer2Att1.Description);
            Assert.AreEqual(false, _example.Signer2Att1.Required);
            Assert.AreEqual(RequirementStatus.INCOMPLETE.ToString(), _example.RetrievedSigner2Att1RequirementStatus.ToString());
            Assert.AreEqual(_example.Name3, _example.Signer2Att2.Name);
            Assert.AreEqual(_example.Description3, _example.Signer2Att2.Description);
            Assert.AreEqual(true, _example.Signer2Att2.Required);
            Assert.AreEqual(RequirementStatus.INCOMPLETE.ToString(), _example.RetrievedSigner2Att2RequirementStatus.ToString());

            Assert.AreEqual(RequirementStatus.REJECTED.ToString(), _example.RetrievedSigner1Att1RequirementStatusAfterRejection.ToString());
            Assert.AreEqual(_example.RejectionComment, _example.RetrievedSigner1Att1RequirementSenderCommentAfterRejection);

            Assert.AreEqual(RequirementStatus.COMPLETE.ToString(), _example.RetrievedSigner1Att1RequirementStatusAfterAccepting.ToString());
            Assert.AreEqual("", _example.RetrievedSigner1Att1RequirementSenderCommentAfterAccepting);

            Assert.AreEqual(_example.AttachmentFileName1, _example.DownloadedAttachemnt1.Name);
            Assert.AreEqual(_example.Attachment1ForSigner1FileSize, _example.DownloadedAttachemnt1.Length);

            Assert.AreEqual(3, _example.downloadedAllAttachmentsForPackageZip.Size);
            Assert.AreEqual(1, _example.downloadedAllAttachmentsForSigner1InPackageZip.Size);
            Assert.AreEqual(2, _example.downloadedAllAttachmentsForSigner2InPackageZip.Size);
		}
    }
}

