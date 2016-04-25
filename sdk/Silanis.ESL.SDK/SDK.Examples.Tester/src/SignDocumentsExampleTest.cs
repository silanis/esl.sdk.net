using NUnit.Framework;
using System;
using System.Collections.Generic;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignDocumentsExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignDocumentsExample example = new SignDocumentsExample();
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
            foreach(Document document in documents)
            {
                foreach(Signature signature in document.Signatures) 
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

