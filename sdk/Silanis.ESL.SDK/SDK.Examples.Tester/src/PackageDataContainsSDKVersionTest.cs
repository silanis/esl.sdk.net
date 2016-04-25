using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class PackageDataContainsSDKVersionTest
    {
        [Test()]
        public void VerifyResult()
        {
            BasicPackageCreationExample example = new BasicPackageCreationExample();
            example.Run();
            DocumentPackage documentPackage = example.RetrievedPackage;
            
            Assert.IsTrue(documentPackage.Attributes.Contents.ContainsKey( "sdk" ));
            Assert.IsTrue(documentPackage.Attributes.Contents["sdk"].ToString().Contains(".NET"));
        }
    }
}

