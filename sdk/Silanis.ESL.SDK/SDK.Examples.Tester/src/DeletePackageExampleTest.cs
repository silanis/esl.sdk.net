using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class DeletePackageExampleTest
    {
        [Test()]
        [ExpectedException(typeof(Silanis.ESL.SDK.EslServerException))]
        public void VerifyResult()
        {
            DeletePackageExample example = new DeletePackageExample();
            example.Run();

            Assert.IsNull(example.RetrievedPackage);
        }
    }
}

