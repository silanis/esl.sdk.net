using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class CreatePackageFromTemplateWithAttachmentExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new CreatePackageFromTemplateWithAttachmentExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            foreach (var signer in documentPackage.Signers) {
                foreach (var attachmentRequirement in signer.Attachments) {
                    Assert.IsNotNull(attachmentRequirement);
                }
            }
        }
    }
}

