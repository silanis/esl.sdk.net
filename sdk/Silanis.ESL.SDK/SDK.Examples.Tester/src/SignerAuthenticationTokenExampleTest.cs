using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class SignerAuthenticationTokenExampleTest
    {
        /** 
        Will not be supported until later release.
        **/

        [TestMethod]
		public void VerifyResult()
        {
			var example = new SignerAuthenticationTokenExample();
			example.Run();

			Assert.IsNotNull(example.SignerSessionId);
        }
    }
}

