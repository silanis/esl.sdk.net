using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestFixture()]
    public class CreatePackageFromTemplateWithReplacingPlaceholderExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            CreatePackageFromTemplateWithReplacingPlaceholderExample example = new CreatePackageFromTemplateWithReplacingPlaceholderExample();
            example.Run();

            Assert.AreEqual(3, example.RetrievedPackage.Signers.Count);
            Assert.AreEqual(0, example.RetrievedPackage.Placeholders.Count);

            Signer signer1 = example.RetrievedPackage.Signers[1];
            Signer signer2 = example.RetrievedPackage.Signers[2];

            Assert.AreEqual(example.TEMPLATE_SIGNER_FIRST, signer1.FirstName);
            Assert.AreEqual(example.TEMPLATE_SIGNER_LAST, signer1.LastName);
            Assert.AreEqual(example.PACKAGE_SIGNER_FIRST, signer2.FirstName);
            Assert.AreEqual(example.PACKAGE_SIGNER_LAST, signer2.LastName);
            Assert.AreEqual(example.PLACEHOLDER_ID, signer2.Id);


            List<Signature> signatures = example.RetrievedPackage.GetDocument(example.DOCUMENT_NAME).Signatures;

            Assert.AreEqual(2, signatures.Count);

            Signature sig1 = getSignatureForEmail(signatures, example.email1);
            Assert.IsNotNull(sig1);
            Signature sig2 = getSignatureForEmail(signatures, example.email2);
            Assert.IsNotNull(sig2);
        }

        private Signature getSignatureForEmail(List<Signature> signatures, string email) 
        {
            foreach (Signature signature in signatures) 
            {
                if (String.Equals(signature.SignerEmail, email)) 
                {
                    return signature;
                }
            }
            return null;
        }

    }
}