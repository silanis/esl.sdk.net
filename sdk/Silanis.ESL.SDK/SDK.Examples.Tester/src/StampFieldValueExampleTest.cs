using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class StampFieldValueExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            StampFieldValueExample example = new StampFieldValueExample();
            example.Run();

        }
    }
}

