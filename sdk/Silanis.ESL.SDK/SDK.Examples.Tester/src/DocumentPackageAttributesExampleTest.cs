using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using System.Collections;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestFixture()]
    public class DocumentPackageAttributesExampleTest
    {
        public const string ORIGIN_KEY = "origin";

        [Test()]
        public void VerifyResult()
        {
            DocumentPackageAttributesExample example = new DocumentPackageAttributesExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;
            DocumentPackageAttributes attributes = documentPackage.Attributes;
            IDictionary<string, object> attributeMap = attributes.Contents;

            Assert.IsTrue(attributeMap.ContainsKey(ORIGIN_KEY));
            Assert.IsTrue(attributeMap.ContainsKey(example.ATTRIBUTE_KEY_1));
            Assert.IsTrue(attributeMap.ContainsKey(example.ATTRIBUTE_KEY_2));
            Assert.IsTrue(attributeMap.ContainsKey(example.ATTRIBUTE_KEY_3));

            Assert.AreEqual(example.DYNAMICS_2015, attributeMap[ORIGIN_KEY]);
            Assert.AreEqual(example.ATTRIBUTE_1, attributeMap[example.ATTRIBUTE_KEY_1]);
            Assert.AreEqual(example.ATTRIBUTE_2, attributeMap[example.ATTRIBUTE_KEY_2]);
            Assert.AreEqual(example.ATTRIBUTE_3, attributeMap[example.ATTRIBUTE_KEY_3]);
        }
    }
}

