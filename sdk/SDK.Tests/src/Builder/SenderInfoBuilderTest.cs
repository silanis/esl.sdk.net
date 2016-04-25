using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class SenderInfoBuilderTest
    {
        [Test()]
        public void DefaultBuildCase()
        {
			SenderInfo senderInfo = SenderInfoBuilder.NewSenderInfo("bob@email.com")
                .WithName("firstName", "lastName")
                .WithCompany("company")
                .WithTitle("title")
                .Build();

            Assert.IsNotNull(senderInfo);
            Assert.AreEqual("firstName", senderInfo.FirstName);
            Assert.AreEqual("lastName", senderInfo.LastName);
            Assert.AreEqual("company", senderInfo.Company);
            Assert.AreEqual("title", senderInfo.Title);
        }
    }
}

