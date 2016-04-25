using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestFixture()]
    public class SenderManipulationExampleTest
    {
        private SenderManipulationExample example;

        [Test()]
        public void VerifyResult()
        {
            example = new SenderManipulationExample();            
            example.Run();

            // Invite three senders
            Assert.AreEqual(example.retrievedSender1.Email, example.email1);
            Assert.AreEqual(example.retrievedSender2.Email, example.email2);
            Assert.AreEqual(example.retrievedSender3.Email, example.email3);

            // Delete Sender
            Assert.IsTrue(AssertSenderWasDeleted(example.email2));

            // Update Sender
            Sender sender = example.retrievedUpdatedSender3;
            SenderInfo updatedInfo = example.updatedSenderInfo;

            Assert.AreEqual(updatedInfo.FirstName, sender.FirstName);
            Assert.AreEqual(updatedInfo.LastName, sender.LastName);
            Assert.AreEqual(updatedInfo.Company, sender.Company);
            Assert.AreEqual(updatedInfo.Title, sender.Title);
        }

        private bool AssertSenderWasDeleted(string senderEmail)
        {
            int i = 0;
            IDictionary<string, Sender> senders = example.EslClient.AccountService.GetSenders(Direction.ASCENDING, new PageRequest(1, 100));
            while (!senders.ContainsKey(senderEmail))
            {
                if (senders.Count == 100)
                {
                    senders = example.EslClient.AccountService.GetSenders(Direction.ASCENDING, new PageRequest(i++ * 100, 100));
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
