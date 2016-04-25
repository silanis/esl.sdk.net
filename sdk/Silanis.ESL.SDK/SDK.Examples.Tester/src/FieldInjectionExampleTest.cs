using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class FieldInjectionExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            FieldInjectionExample example = new FieldInjectionExample(  );
            example.Run();
            
            // InjectedField list is not returned by the esl-backend.
            Assert.IsNotNull(example.PackageId);
        }
    }
}

