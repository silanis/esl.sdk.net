using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class SenderInfoTest
    {
        [TestMethod]
        public void TestFirstName()
        {
            var senderInfo = new SenderInfo {FirstName = "firstName"};
            Assert.AreEqual("firstName", senderInfo.FirstName);
        }
        [TestMethod]
        public void TestLastName()
        {
            var senderInfo = new SenderInfo {LastName = "lastName"};
            Assert.AreEqual("lastName", senderInfo.LastName);
        }
        [TestMethod]
        public void TestCompany()
        {
            var senderInfo = new SenderInfo {Company = "company"};
            Assert.AreEqual("company", senderInfo.Company);
        }
        [TestMethod]
        public void TestTitle()
        {
            var senderInfo = new SenderInfo {Title = "title"};
            Assert.AreEqual("title", senderInfo.Title);
        }
    }
}

