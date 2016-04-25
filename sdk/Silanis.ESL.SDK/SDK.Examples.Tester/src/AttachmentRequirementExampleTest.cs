using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using Silanis.ESL.API;
using Silanis.ESL.SDK.Internal;
using System.IO;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK.Builder.Internal;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace SDK.Examples
{
	[TestFixture]
	public class AttachmentRequirementExampleTest
    {
		private AttachmentRequirementExample example;

		[Test]
		public void VerifyResult()
		{
			example = new AttachmentRequirementExample(  );
			example.Run();

			// Asserts the attachment requirements for each signer is set correctly.
            Assert.AreEqual(1, example.signer1Attachments.Count);
            Assert.AreEqual(example.NAME1, example.signer1Att1.Name);
            Assert.AreEqual(example.DESCRIPTION1, example.signer1Att1.Description);
            Assert.AreEqual(true, example.signer1Att1.Required);
            Assert.AreEqual(RequirementStatus.INCOMPLETE.ToString(), example.retrievedSigner1Att1RequirementStatus.ToString());
                               
            Assert.AreEqual(2, example.signer2Attachments.Count);
            // Check Attachments ordering
            Assert.AreEqual(example.NAME2, example.signer2Attachments[0].Name);
            Assert.AreEqual(example.NAME3, example.signer2Attachments[1].Name);

            Assert.AreEqual(example.NAME2, example.signer2Att1.Name);
            Assert.AreEqual(example.DESCRIPTION2, example.signer2Att1.Description);
            Assert.AreEqual(false, example.signer2Att1.Required);
            Assert.AreEqual(RequirementStatus.INCOMPLETE.ToString(), example.retrievedSigner2Att1RequirementStatus.ToString());
            Assert.AreEqual(example.NAME3, example.signer2Att2.Name);
            Assert.AreEqual(example.DESCRIPTION3, example.signer2Att2.Description);
            Assert.AreEqual(true, example.signer2Att2.Required);
            Assert.AreEqual(RequirementStatus.INCOMPLETE.ToString(), example.retrievedSigner2Att2RequirementStatus.ToString());

            Assert.AreEqual(RequirementStatus.REJECTED.ToString(), example.retrievedSigner1Att1RequirementStatusAfterRejection.ToString());
            Assert.AreEqual(example.REJECTION_COMMENT, example.retrievedSigner1Att1RequirementSenderCommentAfterRejection);

            Assert.AreEqual(RequirementStatus.COMPLETE.ToString(), example.retrievedSigner1Att1RequirementStatusAfterAccepting.ToString());
            Assert.AreEqual("", example.retrievedSigner1Att1RequirementSenderCommentAfterAccepting);

            Assert.AreEqual(example.ATTACHMENT_FILE_NAME1, example.downloadedAttachemnt1.Name);
            Assert.AreEqual(example.attachment1ForSigner1FileSize, example.downloadedAttachemnt1.Length);

            Assert.AreEqual(3, example.downloadedAllAttachmentsForPackageZip.Size);
            Assert.AreEqual(1, example.downloadedAllAttachmentsForSigner1InPackageZip.Size);
            Assert.AreEqual(2, example.downloadedAllAttachmentsForSigner2InPackageZip.Size);
		}
    }
}

