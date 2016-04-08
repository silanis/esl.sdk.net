using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestClass]
    public class DelegationExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new DelegationExample();
            example.Run();

            Assert.AreEqual(example.email1, example.retrievedSender1.Email);
            Assert.AreEqual(example.email2, example.retrievedSender2.Email);
            Assert.AreEqual(example.email3, example.retrievedSender3.Email);

            Assert.AreEqual(3, example.delegationUserListAfterAdding.Count);

            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterAdding, example.delegationUser1));
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterAdding, example.delegationUser2));
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterAdding, example.delegationUser3));

            Assert.AreEqual(2, example.delegationUserListAfterRemoving.Count);
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterRemoving, example.delegationUser1));
            Assert.IsFalse(AssertContainDelegationUser(example.delegationUserListAfterRemoving, example.delegationUser2));
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterRemoving, example.delegationUser3));

            Assert.AreEqual(6, example.delegationUserListAfterUpdating.Count);
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterUpdating, example.delegationUser4));
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterUpdating, example.delegationUser5));
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterUpdating, example.delegationUser6));
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterUpdating, example.delegationUser7));
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterUpdating, example.delegationUser8));
            Assert.IsTrue(AssertContainDelegationUser(example.delegationUserListAfterUpdating, example.delegationUser9));

            Assert.AreEqual(0, example.delegationUserListAfterClearing.Count);
        }

        private bool AssertContainDelegationUser(IList<DelegationUser> delegationUserList, DelegationUser delegationUser) 
        {
            foreach(var delegationUserToCompare in delegationUserList) 
            {
                if(delegationUserToCompare.Email.Equals(delegationUser.Email)) 
                {
                    Assert.AreEqual(delegationUser.Id, delegationUserToCompare.Id);
                    Assert.AreEqual(delegationUser.FirstName, delegationUserToCompare.FirstName);
                    Assert.AreEqual(delegationUser.LastName, delegationUserToCompare.LastName);
                    return true;
                }
            }
            return false;
        }
    }
}

