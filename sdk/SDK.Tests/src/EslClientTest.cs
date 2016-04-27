using Microsoft.VisualStudio.TestTools.UnitTesting;

using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Tests
{
	[TestClass]
	public class EslClientTest
	{
		[TestMethod]
		[ExpectedException(typeof(EslException))]
		public void CannotCreateClientWithNullAPIKey()
		{
			new EslClient (null, "http://localhost");
		}

		[TestMethod]
		[ExpectedException(typeof(EslException))]
		public void CannotCreateClientWithNullURL() 
		{
			new EslClient ("key", null);
		}
        
        [TestMethod]
        public void GetVersionFromAbsentAttributes()
        {
            var package = CreateDefaultDocumentPackage();
            var eslClient = CreateDefaultEslClient();
            Assert.AreEqual( false, eslClient.IsSdkVersionSetInPackageData(package) );
        }
        
        [TestMethod]
        public void GetVersionFromEmptyAttributes()
        {
            var package = CreateDefaultDocumentPackage();
            package.Attributes = new DocumentPackageAttributes();
            var eslClient = CreateDefaultEslClient();
            Assert.AreEqual( false, eslClient.IsSdkVersionSetInPackageData(package) );
        }
        
        [TestMethod]
        public void GetVersionFromNonEmptyAttributes()
        {
            var package = CreateDefaultDocumentPackage();
            package.Attributes = new DocumentPackageAttributes();
            package.Attributes.Append("key", "value");
            var eslClient = CreateDefaultEslClient();
            Assert.AreEqual( false, eslClient.IsSdkVersionSetInPackageData(package) );
        }
        
        [TestMethod]
        public void GetVersionWhenPresentInAttributes()
        {
            var package = CreateDefaultDocumentPackage();
            package.Attributes = new DocumentPackageAttributes();
            package.Attributes.Append("key", "value");
            package.Attributes.Append("sdk", "v???");
            var eslClient = CreateDefaultEslClient();
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