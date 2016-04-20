using NUnit.Framework;
using System;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    [TestFixture()]
    public class StartFastTrackExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            StartFastTrackExample example = new StartFastTrackExample();
            example.Run();

            Assert.IsNotEmpty(example.signingUrl);
        }
    }
}

