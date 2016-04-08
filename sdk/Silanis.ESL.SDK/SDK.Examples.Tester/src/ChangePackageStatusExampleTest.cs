using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class ChangePackageStatusExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new ChangePackageStatusExample();
            example.Run();

            Assert.AreEqual(DocumentPackageStatus.SENT, example.sentPackage.Status);
            Assert.AreEqual(DocumentPackageStatus.DRAFT, example.RetrievedPackage.Status);
            Assert.IsTrue(example.trashedPackage.Trashed);
            Assert.IsFalse(example.restoredPackage.Trashed);
        }
    }
}

