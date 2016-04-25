using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestFixture()]
    public class MixingSignatureAndAcceptanceOnOnedocumentExampleTest
    {
        [Test()]
        [ExpectedException(typeof(Silanis.ESL.SDK.EslException))]
        public void VerifyResult()
        {
            MixingSignatureAndAcceptanceOnOnedocumentExample example = new MixingSignatureAndAcceptanceOnOnedocumentExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            List<Signature> signatures = documentPackage.GetDocument("First Document").Signatures;

            Assert.AreEqual(2, signatures.Count);
            Assert.AreEqual(SignatureStyle.FULL_NAME, signatures[0].Style);
            Assert.AreEqual(SignatureStyle.ACCEPTANCE, signatures[1].Style);
        }
    }
}

