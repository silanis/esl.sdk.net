using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestFixture()]
    public class CustomSenderInfoExampleTest
    {
        private CustomSenderInfoExample example;

        [Test()]
		public void VerifyResult()
        {
			example = new CustomSenderInfoExample();
			example.Run();

            DocumentPackage package = example.RetrievedPackage;

			Assert.IsNotNull(package.SenderInfo);
			Assert.AreEqual(CustomSenderInfoExample.SENDER_FIRST_NAME, package.SenderInfo.FirstName);
			Assert.AreEqual(CustomSenderInfoExample.SENDER_SECOND_NAME, package.SenderInfo.LastName);
			Assert.AreEqual(CustomSenderInfoExample.SENDER_COMPANY, package.SenderInfo.Company);
			Assert.AreEqual(CustomSenderInfoExample.SENDER_TITLE, package.SenderInfo.Title);

            IDictionary<string, Silanis.ESL.SDK.Sender> senders = assertSenderWasAdded(100, example.SenderEmail);
            Assert.IsTrue(senders.ContainsKey(example.SenderEmail));
            Assert.AreEqual(senders[example.SenderEmail].Language, "fr");
        }

        private IDictionary<string, Sender> assertSenderWasAdded(int numberOfResults, string senderEmail)
        {
            int i = 0;
            IDictionary<string, Sender> senders = example.EslClient.AccountService.GetSenders(Direction.ASCENDING, new PageRequest(1, numberOfResults));
            while (!senders.ContainsKey(senderEmail))
            {
                Assert.AreEqual(senders.Count, numberOfResults);
                senders = example.EslClient.AccountService.GetSenders(Direction.ASCENDING, new PageRequest(i++ * numberOfResults, numberOfResults));
            }
            return senders;
        }
    }
}

