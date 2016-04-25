using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class UpdateInjectedFieldsFromTemplateExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            UpdateInjectedFieldsFromTemplateExample example = new UpdateInjectedFieldsFromTemplateExample();
            example.Run();
        }
    }
}

