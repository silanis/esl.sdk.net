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

            Assert.AreEqual(example.email1, example.RetrievedSender1.Email);
            Assert.AreEqual(example.email2, example.RetrievedSender2.Email);
            Assert.AreEqual(example.email3, example.RetrievedSender3.Email);

            Assert.AreEqual(3, example.DelegationUserListAfterAdding.Count);

            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterAdding, example.DelegationUser1));
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterAdding, example.DelegationUser2));
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterAdding, example.DelegationUser3));

            Assert.AreEqual(2, example.DelegationUserListAfterRemoving.Count);
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterRemoving, example.DelegationUser1));
            Assert.IsFalse(AssertContainDelegationUser(example.DelegationUserListAfterRemoving, example.DelegationUser2));
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterRemoving, example.DelegationUser3));

            Assert.AreEqual(6, example.DelegationUserListAfterUpdating.Count);
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterUpdating, example.DelegationUser4));
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterUpdating, example.DelegationUser5));
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterUpdating, example.DelegationUser6));
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterUpdating, example.DelegationUser7));
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterUpdating, example.DelegationUser8));
            Assert.IsTrue(AssertContainDelegationUser(example.DelegationUserListAfterUpdating, example.DelegationUser9));

            Assert.AreEqual(0, example.DelegationUserListAfterClearing.Count);
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

