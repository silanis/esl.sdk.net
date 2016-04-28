using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SignerOrderingExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignerOrderingExample(  );
            example.Run();

            // Initial signing order
            var beforeReorder = example.SavedPackage;
            Assert.AreEqual(beforeReorder.GetSigner(example.email1).SigningOrder, 1);
            Assert.AreEqual(beforeReorder.GetSigner(example.email2).SigningOrder, 2);

            // After reordering signers
            var afterReorder = example.AfterReorder;
            Assert.AreEqual(afterReorder.GetSigner(example.email1).SigningOrder, 2);
            Assert.AreEqual(afterReorder.GetSigner(example.email2).SigningOrder, 1);
        }
    }
}

