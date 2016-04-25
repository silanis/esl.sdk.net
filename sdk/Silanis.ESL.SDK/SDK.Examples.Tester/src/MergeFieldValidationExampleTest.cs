using NUnit.Framework;
using System;

namespace SDK.Examples
{
    [TestFixture()]
    public class MergeFieldValidationExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            MergeFieldValidationExample example = new MergeFieldValidationExample();
            example.Run();
        }
    }
}

