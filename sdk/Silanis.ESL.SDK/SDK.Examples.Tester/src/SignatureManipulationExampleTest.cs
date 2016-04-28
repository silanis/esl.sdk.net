using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestClass]
    public class SignatureManipulationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignatureManipulationExample();
            example.Run();

            // Test if all signatures are added properly
            var signaturesDictionary = ConvertListToMap(example.AddedSignatures);

            Assert.IsTrue(signaturesDictionary.ContainsKey(example.email1));
            Assert.IsTrue(signaturesDictionary.ContainsKey(example.email2));
            Assert.IsTrue(signaturesDictionary.ContainsKey(example.email3));

            // Test if signature1 is deleted properly
            signaturesDictionary = ConvertListToMap(example.DeletedSignatures);

            Assert.IsFalse(signaturesDictionary.ContainsKey(example.email1));
            Assert.IsTrue(signaturesDictionary.ContainsKey(example.email2));
            Assert.IsTrue(signaturesDictionary.ContainsKey(example.email3));

            // Test if signature3 is updated properly and is assigned to signer1
            signaturesDictionary = ConvertListToMap(example.ModifiedSignatures);

            Assert.IsTrue(signaturesDictionary.ContainsKey(example.email1));
            Assert.IsTrue(signaturesDictionary.ContainsKey(example.email2));
            Assert.IsFalse(signaturesDictionary.ContainsKey(example.email3));

            // Test if the signatures were updated with the new list of signatures
            signaturesDictionary = ConvertListToMap(example.UpdatedSignatures);

            Assert.IsFalse(signaturesDictionary.ContainsKey(example.email1));
            Assert.IsTrue(signaturesDictionary.ContainsKey(example.email2));
            Assert.IsTrue(signaturesDictionary.ContainsKey(example.email3));
            Assert.AreEqual(signaturesDictionary[example.email2].Fields[0].Style, FieldStyle.BOUND_NAME);
        }

        private Dictionary<string,Signature> ConvertListToMap(List<Signature> signaturesList)
        {
            var signaturesDictionary = new Dictionary<string,Signature>();
            foreach(var signature in signaturesList)
            {
                signaturesDictionary.Add(signature.SignerEmail, signature);
            }
            return signaturesDictionary;
        }

    }
}

