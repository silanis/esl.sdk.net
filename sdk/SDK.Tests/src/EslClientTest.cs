using System;
using Silanis.ESL.SDK;
using NUnit.Framework;
using Silanis.ESL.SDK.Builder;

namespace SDK.Tests
{
	[TestFixture]
	public class EslClientTest
	{
		[Test]
		[ExpectedException(typeof(EslException))]
		public void CannotCreateClientWithNullAPIKey()
		{
			new EslClient (null, "http://localhost");
		}

		[Test]
		[ExpectedException(typeof(EslException))]
		public void CannotCreateClientWithNullURL() 
		{
			new EslClient ("key", null);
		}
        
        [Test]
        public void GetVersionFromAbsentAttributes()
        {
            DocumentPackage package = CreateDefaultDocumentPackage();
            EslClient eslClient = CreateDefaultEslClient();
            Assert.AreEqual( false, eslClient.IsSdkVersionSetInPackageData(package) );
        }
        
        [Test]
        public void GetVersionFromEmptyAttributes()
        {
            DocumentPackage package = CreateDefaultDocumentPackage();
            package.Attributes = new DocumentPackageAttributes();
            EslClient eslClient = CreateDefaultEslClient();
            Assert.AreEqual( false, eslClient.IsSdkVersionSetInPackageData(package) );
        }
        
        [Test]
        public void GetVersionFromNonEmptyAttributes()
        {
            DocumentPackage package = CreateDefaultDocumentPackage();
            package.Attributes = new DocumentPackageAttributes();
            package.Attributes.Append("key", "value");
            EslClient eslClient = CreateDefaultEslClient();
            Assert.AreEqual( false, eslClient.IsSdkVersionSetInPackageData(package) );
        }
        
        [Test]
        public void GetVersionWhenPresentInAttributes()
        {
            DocumentPackage package = CreateDefaultDocumentPackage();
            package.Attributes = new DocumentPackageAttributes();
            package.Attributes.Append("key", "value");
            package.Attributes.Append("sdk", "v???");
            EslClient eslClient = CreateDefaultEslClient();
            Assert.AreEqual( true, eslClient.IsSdkVersionSetInPackageData(package) );
        }
        
        private DocumentPackage CreateDefaultDocumentPackage()
        {
            return PackageBuilder.NewPackageNamed("Package Name").Build();
        }
        
        private EslClient CreateDefaultEslClient()
        {
            return new EslClient("key","url");
        }
	}
}