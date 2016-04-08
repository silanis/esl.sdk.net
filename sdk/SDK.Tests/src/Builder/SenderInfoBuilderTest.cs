using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class SenderInfoBuilderTest
    {
        [TestMethod]
        public void DefaultBuildCase()
        {
			var senderInfo = SenderInfoBuilder.NewSenderInfo("bob@email.com")
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

