using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SDK.Examples
{
    [TestClass]
    public class DocumentPackageAttributesExampleTest
    {
        public const string OriginKey = "origin";

        [TestMethod]
        public void VerifyResult()
        {
            var example = new DocumentPackageAttributesExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;
            var attributes = documentPackage.Attributes;
            var attributeMap = attributes.Contents;

            Assert.IsTrue(attributeMap.ContainsKey(OriginKey));
            Assert.IsTrue(attributeMap.ContainsKey(example.AttributeKey1));
            Assert.IsTrue(attributeMap.ContainsKey(example.AttributeKey2));
            Assert.IsTrue(attributeMap.ContainsKey(example.AttributeKey3));

            Assert.AreEqual(example.Dynamics2015, attributeMap[OriginKey]);
            Assert.AreEqual(example.Attribute1, attributeMap[example.AttributeKey1]);
            Assert.AreEqual(example.Attribute2, attributeMap[example.AttributeKey2]);
            Assert.AreEqual(example.Attribute3, attributeMap[example.AttributeKey3]);
        }
    }
}

