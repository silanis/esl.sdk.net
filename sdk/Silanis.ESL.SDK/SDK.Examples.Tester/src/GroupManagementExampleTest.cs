using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestClass]
    public class GroupManagementExampleTest
    {
        [TestMethod]
        public void verify() {
            var example = new GroupManagementExample();
            example.Run();
            
            Assert.AreEqual(example.CreatedGroup1.Id.Id, example.RetrievedGroup1.Id.Id);
            Assert.AreEqual(example.CreatedGroup2.Id.Id, example.RetrievedGroup2.Id.Id);
            Assert.AreEqual(example.CreatedGroup3.Id.Id, example.RetrievedGroup3.Id.Id);

            Assert.IsTrue(example.GroupMemberEmailsAfterUpdate.Contains(example.email2));
            Assert.IsTrue(example.GroupMemberEmailsAfterUpdate.Contains(example.email3));
            Assert.IsTrue(example.GroupMemberEmailsAfterUpdate.Contains(example.email4));
        }

        private List<string> GetGroupsId(IEnumerable<Group> groups)
            {
            return groups.Select(@group => @group.Id.Id).ToList();
        }
    }
}