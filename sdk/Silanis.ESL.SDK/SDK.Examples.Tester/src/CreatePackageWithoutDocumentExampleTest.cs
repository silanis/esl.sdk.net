using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class CreatePackageWithoutDocumentExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            CreatePackageWithoutDocumentExample example = new CreatePackageWithoutDocumentExample();
            example.Run();

            Assert.AreEqual(example.PackageName, example.RetrievedPackage.Name);
        }
    }
}

