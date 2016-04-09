using Microsoft.VisualStudio.TestTools.UnitTesting;

using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Tests
{
    [TestClass]
    public class DocumentPackageAttributesBuilderTest
    {
        public DocumentPackageAttributesBuilderTest()
        {
        }

        [TestMethod]
        public void buildWithSpecifiedValues()
        {

            var documentPackageAttributesBuilder = new DocumentPackageAttributesBuilder()
                                        .WithAttribute("First Name", "Adam")
                                        .WithAttribute("Last Name", "Smith");
			var documentPackageAttributes = documentPackageAttributesBuilder.Build();

            Assert.AreEqual("Adam", documentPackageAttributes.Contents["First Name"]);
            Assert.AreEqual("Smith", documentPackageAttributes.Contents["Last Name"]);

        }

    }
}

