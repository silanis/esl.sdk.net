using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class UserAuthenticationTokenExampleTest
    {
        [TestMethod]
		public void VerifyResult()
        {
			var example = new UserAuthenticationTokenExample();
			example.Run();

			Assert.IsNotNull(example.UserSessionId);
        }
    }
}

