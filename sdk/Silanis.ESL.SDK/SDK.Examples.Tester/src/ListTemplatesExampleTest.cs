using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class ListTemplatesExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new ListTemplatesExample();
            example.Run();

            var templateList = example.Templates;

            Assert.IsTrue(templateList.Size >= 0);
        }
    }
}

