using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class GettingStartedExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            GettingStartedExample example = new GettingStartedExample();
            example.Run();

        }
    }
}

