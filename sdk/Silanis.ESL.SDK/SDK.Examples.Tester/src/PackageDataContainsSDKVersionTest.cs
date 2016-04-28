using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class PackageDataContainsSDKVersionTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new BasicPackageCreationExample();
            example.Run();
            var documentPackage = example.RetrievedPackage;
            
            Assert.IsTrue(documentPackage.Attributes.Contents.ContainsKey( "sdk" ));
            Assert.IsTrue(documentPackage.Attributes.Contents["sdk"].ToString().Contains(".NET"));
        }
    }
}

