using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SenderAuthenticationTokenExampleTest
    {
        [TestMethod]
		public void VerifyResult()
        {
			var example = new SenderAuthenticationTokenExample();
			example.Run();

			Assert.IsNotNull(example.SenderSessionId);
        }
    }
}

