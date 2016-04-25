using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class SenderInfoTest
    {
        [Test()]
        public void TestFirstName()
        {
            SenderInfo senderInfo = new SenderInfo();
            senderInfo.FirstName = "firstName";
            Assert.AreEqual("firstName", senderInfo.FirstName);
        }
        [Test()]
        public void TestLastName()
        {
            SenderInfo senderInfo = new SenderInfo();
            senderInfo.LastName = "lastName";
            Assert.AreEqual("lastName", senderInfo.LastName);
        }
        [Test()]
        public void TestCompany()
        {
            SenderInfo senderInfo = new SenderInfo();
            senderInfo.Company = "company";
            Assert.AreEqual("company", senderInfo.Company);
        }
        [Test()]
        public void TestTitle()
        {
            SenderInfo senderInfo = new SenderInfo();
            senderInfo.Title = "title";
            Assert.AreEqual("title", senderInfo.Title);
        }
    }
}

