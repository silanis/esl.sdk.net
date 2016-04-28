using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class CreatePackageWithoutDocumentExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new CreatePackageWithoutDocumentExample();
            example.Run();

            Assert.AreEqual(example.PackageName, example.RetrievedPackage.Name);
        }
    }
}

