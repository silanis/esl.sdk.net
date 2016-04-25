using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class UserAuthenticationTokenExampleTest
    {
        [Test()]
		public void VerifyResult()
        {
			UserAuthenticationTokenExample example = new UserAuthenticationTokenExample();
			example.Run();

			Assert.IsNotNull(example.UserSessionId);
        }
    }
}

