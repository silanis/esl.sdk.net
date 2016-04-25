using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class CreatePackageFromTemplateWithAttachmentExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            CreatePackageFromTemplateWithAttachmentExample example = new CreatePackageFromTemplateWithAttachmentExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            foreach (Signer signer in documentPackage.Signers) {
                foreach (AttachmentRequirement attachmentRequirement in signer.Attachments) {
                    Assert.IsNotNull(attachmentRequirement);
                }
            }
        }
    }
}

