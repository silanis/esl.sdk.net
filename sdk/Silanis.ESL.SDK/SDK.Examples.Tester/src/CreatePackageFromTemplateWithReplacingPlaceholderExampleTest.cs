using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestClass]
    public class CreatePackageFromTemplateWithReplacingPlaceholderExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new CreatePackageFromTemplateWithReplacingPlaceholderExample();
            example.Run();

            Assert.AreEqual(3, example.RetrievedPackage.Signers.Count);
            Assert.AreEqual(0, example.RetrievedPackage.Placeholders.Count);

            var signer1 = example.RetrievedPackage.Signers[1];
            var signer2 = example.RetrievedPackage.Signers[2];

            Assert.AreEqual(example.TemplateSignerFirst, signer1.FirstName);
            Assert.AreEqual(example.TemplateSignerLast, signer1.LastName);
            Assert.AreEqual(example.PackageSignerFirst, signer2.FirstName);
            Assert.AreEqual(example.PackageSignerLast, signer2.LastName);
            Assert.AreEqual(example.PlaceholderId, signer2.Id);


            var signatures = example.RetrievedPackage.GetDocument(example.DocumentName).Signatures;

            Assert.AreEqual(2, signatures.Count);

            var sig1 = getSignatureForEmail(signatures, example.email1);
            Assert.IsNotNull(sig1);
            var sig2 = getSignatureForEmail(signatures, example.email2);
            Assert.IsNotNull(sig2);
        }

        private Signature getSignatureForEmail(List<Signature> signatures, string email) 
        {
            foreach (var signature in signatures) 
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