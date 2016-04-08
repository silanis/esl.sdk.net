using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class SignDocumentsExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignDocumentsExample();
            example.Run();

            AssertSignedSignatures(example.retrievedPackageBeforeSigning.Documents, example.senderEmail, false);
            AssertSignedSignatures(example.retrievedPackageBeforeSigning.Documents, example.email1, false);
            Assert.AreEqual(DocumentPackageStatus.SENT, example.retrievedPackageBeforeSigning.Status);

            AssertSignedSignatures(example.retrievedPackageAfterSigningApproval1.Documents, example.senderEmail, true);
            AssertSignedSignatures(example.retrievedPackageAfterSigningApproval1.Documents, example.email1, false);
            Assert.AreEqual(DocumentPackageStatus.SENT, example.retrievedPackageAfterSigningApproval1.Status);

            AssertSignedSignatures(example.retrievedPackageAfterSigningApproval2.Documents, example.senderEmail, true);
            AssertSignedSignatures(example.retrievedPackageAfterSigningApproval2.Documents, example.email1, true);
            Assert.AreEqual(DocumentPackageStatus.COMPLETED, example.retrievedPackageAfterSigningApproval2.Status);
        }

        private void AssertSignedSignatures(IList<Document> documents, string signerEmail, bool signed) 
        {
            foreach(var document in documents)
            {
                foreach(var signature in document.Signatures) 
                {
                    if (signerEmail.Equals(signature.SignerEmail))
                    {
                        if (signed)
                        {
                            Assert.IsNotNull(signature.Accepted);
                        } 
                        else
                        {
                            Assert.IsNull(signature.Accepted);
                        }
                    }
                }
            }
        }
    }
}

