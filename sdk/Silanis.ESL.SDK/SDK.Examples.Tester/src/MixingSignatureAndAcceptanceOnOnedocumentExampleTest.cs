using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class MixingSignatureAndAcceptanceOnOnedocumentExampleTest
    {
        [TestMethod]
        [ExpectedException(typeof(EslException))]
        public void VerifyResult()
        {
            var example = new MixingSignatureAndAcceptanceOnOnedocumentExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            var signatures = documentPackage.GetDocument("First Document").Signatures;

            Assert.AreEqual(2, signatures.Count);
            Assert.AreEqual(SignatureStyle.FULL_NAME, signatures[0].Style);
            Assert.AreEqual(SignatureStyle.ACCEPTANCE, signatures[1].Style);
        }
    }
}

