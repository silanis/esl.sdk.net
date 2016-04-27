using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class DeletePackageExampleTest
    {
        [TestMethod]
        [ExpectedException(typeof(EslServerException))]
        public void VerifyResult()
        {
            var example = new DeletePackageExample();
            example.Run();

            Assert.IsNull(example.RetrievedPackage);
        }
    }
}

