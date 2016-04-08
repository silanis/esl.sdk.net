using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class FieldInjectionExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new FieldInjectionExample(  );
            example.Run();
            
            // InjectedField list is not returned by the esl-backend.
            Assert.IsNotNull(example.PackageId);
        }
    }
}

