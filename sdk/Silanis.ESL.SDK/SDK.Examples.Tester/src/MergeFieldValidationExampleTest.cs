using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class MergeFieldValidationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new MergeFieldValidationExample();
            example.Run();
        }
    }
}

