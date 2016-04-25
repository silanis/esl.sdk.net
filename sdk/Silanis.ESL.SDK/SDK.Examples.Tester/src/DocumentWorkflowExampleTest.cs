using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class DocumentWorkflowExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            DocumentWorkflowExample example = new DocumentWorkflowExample(  );
            example.Run();
            
            DocumentPackage package = example.EslClient.GetPackage( example.PackageId );
            Assert.IsNotNull(package);
            
        }
    }
}

