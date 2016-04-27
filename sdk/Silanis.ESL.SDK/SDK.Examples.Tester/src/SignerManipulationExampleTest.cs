using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SignerManipulationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new SignerManipulationExample();
            example.Run();
        }
    }
}

