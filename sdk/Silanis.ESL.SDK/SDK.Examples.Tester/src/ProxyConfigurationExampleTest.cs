using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using NUnit.Framework.SyntaxHelpers;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestFixture()]
    public class ProxyConfigurationExampleTest
    {
        [Test]
        public void verifyResult()
        {
            ProxyConfigurationExample example = new ProxyConfigurationExample(Props.GetInstance());
            example.Run();

            DocumentPackage documentPackage1 = example.eslClientWithHttpProxy.GetPackage(example.packageId1);
            DocumentPackage documentPackage2 = example.EslClient.GetPackage(example.packageId1);
            Assert.AreEqual(example.packageId1.Id, documentPackage1.Id.Id);
            Assert.AreEqual(example.packageId1.Id, documentPackage2.Id.Id);

            DocumentPackage documentPackage3 = example.eslClientWithHttpProxyHasCredentials.GetPackage(example.packageId2);
            DocumentPackage documentPackage4 = example.EslClient.GetPackage(example.packageId2);
            Assert.AreEqual(example.packageId2.Id, documentPackage3.Id.Id);
            Assert.AreEqual(example.packageId2.Id, documentPackage4.Id.Id);
        }
    }
}

