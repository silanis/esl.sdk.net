using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignerAuthenticationTokenExampleTest
    {
        /** 
        Will not be supported until later release.
        **/

        [Test()]
		public void VerifyResult()
        {
			SignerAuthenticationTokenExample example = new SignerAuthenticationTokenExample();
			example.Run();

			Assert.IsNotNull(example.SignerSessionId);
        }
    }
}

