using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class CreateSenderTemplateExampleTest
    {

        [TestMethod]
        public void VerifyResult()
        {
            var example = new CreateSenderTemplateExample();
            example.Run();

            var retrievedTemplate = example.EslClient.GetPackage(example.templateId);

            Assert.AreEqual(retrievedTemplate.Visibility, example.visibility);
        }
    }
}

