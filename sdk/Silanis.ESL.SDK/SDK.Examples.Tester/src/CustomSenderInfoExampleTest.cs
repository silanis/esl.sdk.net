using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestClass]
    public class CustomSenderInfoExampleTest
    {
        private CustomSenderInfoExample example;

        [TestMethod]
		public void VerifyResult()
        {
			example = new CustomSenderInfoExample();
			example.Run();

            var package = example.RetrievedPackage;

			Assert.IsNotNull(package.SenderInfo);
			Assert.AreEqual(CustomSenderInfoExample.SenderFirstName, package.SenderInfo.FirstName);
			Assert.AreEqual(CustomSenderInfoExample.SenderSecondName, package.SenderInfo.LastName);
			Assert.AreEqual(CustomSenderInfoExample.SenderCompany, package.SenderInfo.Company);
			Assert.AreEqual(CustomSenderInfoExample.SenderTitle, package.SenderInfo.Title);

            var senders = AssertSenderWasAdded(100, example.SenderEmail);
            Assert.IsTrue(senders.ContainsKey(example.SenderEmail));
            Assert.AreEqual(senders[example.SenderEmail].Language, "fr");
        }

        private IDictionary<string, Sender> AssertSenderWasAdded(int numberOfResults, string senderEmail)
        {
            var i = 0;
            var senders = example.EslClient.AccountService.GetSenders(Direction.ASCENDING, new PageRequest(1, numberOfResults));
            while (!senders.ContainsKey(senderEmail))
            {
                Assert.AreEqual(senders.Count, numberOfResults);
                senders = example.EslClient.AccountService.GetSenders(Direction.ASCENDING, new PageRequest(i++ * numberOfResults, numberOfResults));
            }
            return senders;
        }
    }
}

