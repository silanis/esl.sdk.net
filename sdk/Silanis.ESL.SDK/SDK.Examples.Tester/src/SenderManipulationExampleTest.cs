using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class SenderManipulationExampleTest
    {
        private SenderManipulationExample example;

        [TestMethod]
        public void VerifyResult()
        {
            example = new SenderManipulationExample();            
            example.Run();

            // Invite three senders
            Assert.AreEqual(example.RetrievedSender1.Email, example.email1);
            Assert.AreEqual(example.RetrievedSender2.Email, example.email2);
            Assert.AreEqual(example.RetrievedSender3.Email, example.email3);

            // Delete Sender
            Assert.IsTrue(AssertSenderWasDeleted(example.email2));

            // Update Sender
            var sender = example.RetrievedUpdatedSender3;
            var updatedInfo = example.UpdatedSenderInfo;

            Assert.AreEqual(updatedInfo.FirstName, sender.FirstName);
            Assert.AreEqual(updatedInfo.LastName, sender.LastName);
            Assert.AreEqual(updatedInfo.Company, sender.Company);
            Assert.AreEqual(updatedInfo.Title, sender.Title);
        }

        private bool AssertSenderWasDeleted(string senderEmail)
        {
            var i = 0;
            var senders = example.EslClient.AccountService.GetSenders(Direction.ASCENDING, new PageRequest(1, 100));
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
