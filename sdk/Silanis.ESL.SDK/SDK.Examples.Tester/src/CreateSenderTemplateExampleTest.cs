using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class CreateSenderTemplateExampleTest
    {

        [Test()]
        public void VerifyResult()
        {
            CreateSenderTemplateExample example = new CreateSenderTemplateExample();
            example.Run();

            DocumentPackage retrievedTemplate = example.EslClient.GetPackage(example.templateId);

            Assert.AreEqual(retrievedTemplate.Visibility, example.visibility);
        }
    }
}

