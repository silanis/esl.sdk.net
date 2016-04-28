using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class DocumentWorkflowExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new DocumentWorkflowExample(  );
            example.Run();
            
            var package = example.EslClient.GetPackage( example.PackageId );
            Assert.IsNotNull(package);
            
        }
    }
}

