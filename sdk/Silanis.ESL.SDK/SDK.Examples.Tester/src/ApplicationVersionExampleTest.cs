using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [DeploymentItem("../signers.json", "/")]
    [DeploymentItem("../prêt.pdf", "/src/")]
    [DeploymentItem("../document.pdf", "/src/")]
    [DeploymentItem("../document-for-anchor-extraction.pdf", "/src/")]
    [DeploymentItem("../document-with-fields.pdf", "/src/")]
    [DeploymentItem("../extract_document.pdf", "/src/")]
    [DeploymentItem("../field_groups.pdf", "/src/")]
    [DeploymentItem("../document.odt", "/src/")]
    [DeploymentItem("../document.rtf", "/src/")]
    [TestClass]
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

