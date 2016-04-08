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
            Assert.IsTrue(attributeMap.ContainsKey(example.ATTRIBUTE_KEY_1));
            Assert.IsTrue(attributeMap.ContainsKey(example.ATTRIBUTE_KEY_2));
            Assert.IsTrue(attributeMap.ContainsKey(example.ATTRIBUTE_KEY_3));

            Assert.AreEqual(example.DYNAMICS_2015, attributeMap[OriginKey]);
            Assert.AreEqual(example.ATTRIBUTE_1, attributeMap[example.ATTRIBUTE_KEY_1]);
            Assert.AreEqual(example.ATTRIBUTE_2, attributeMap[example.ATTRIBUTE_KEY_2]);
            Assert.AreEqual(example.ATTRIBUTE_3, attributeMap[example.ATTRIBUTE_KEY_3]);
        }
    }
}

