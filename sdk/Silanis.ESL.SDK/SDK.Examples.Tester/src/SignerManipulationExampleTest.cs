using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class SignerManipulationExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            SignerManipulationExample example = new SignerManipulationExample();
            example.Run();
        }
    }
}

