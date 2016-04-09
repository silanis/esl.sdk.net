using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    [DeploymentItem("signers.json")]
    [DeploymentItem("prêt.pdf")]
    [DeploymentItem("document.pdf")]
    [DeploymentItem("document-for-anchor-extraction.pdf")]
    [DeploymentItem("document-with-fields.pdf")]
    [DeploymentItem("extract_document.pdf")]
    [DeploymentItem("field_groups.pdf")]
    [DeploymentItem("document.odt")]
    [DeploymentItem("document.rtf")]
    public class ApplicationVersionExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new ApplicationVersionExample();
            example.Run();

            Assert.IsNotNull(example.applicationVersion);
            Assert.IsTrue(example.applicationVersion.Any());
        }
    }
}

