using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class SessionCreationExampleTest
    {
        [Test()]
		public void VerifyResult()
        {
			SessionCreationExample example = new SessionCreationExample();
			example.Run();

			Assert.IsNotNull(example.signerSessionToken);
        }
    }
}

