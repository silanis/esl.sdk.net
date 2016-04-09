using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SessionCreationExampleTest
    {
        [TestMethod]
		public void VerifyResult()
        {
			var example = new SessionCreationExample();
			example.Run();

			Assert.IsNotNull(example.SignerSessionToken);
        }
    }
}

