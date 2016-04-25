using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class ChangePackageStatusExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            ChangePackageStatusExample example = new ChangePackageStatusExample();
            example.Run();

            Assert.AreEqual(DocumentPackageStatus.SENT, example.sentPackage.Status);
            Assert.AreEqual(DocumentPackageStatus.DRAFT, example.RetrievedPackage.Status);
            Assert.IsTrue(example.trashedPackage.Trashed);
            Assert.IsFalse(example.restoredPackage.Trashed);
        }
    }
}

