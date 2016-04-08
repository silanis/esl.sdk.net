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
            
            Assert.AreEqual(example.createdGroup1.Id.Id, example.retrievedGroup1.Id.Id);
            Assert.AreEqual(example.createdGroup2.Id.Id, example.retrievedGroup2.Id.Id);
            Assert.AreEqual(example.createdGroup3.Id.Id, example.retrievedGroup3.Id.Id);

            Assert.IsTrue(example.groupMemberEmailsAfterUpdate.Contains(example.email2));
            Assert.IsTrue(example.groupMemberEmailsAfterUpdate.Contains(example.email3));
            Assert.IsTrue(example.groupMemberEmailsAfterUpdate.Contains(example.email4));
        }

        private List<string> GetGroupsId(IEnumerable<Group> groups)
        {
            return groups.Select(@group => @group.Id.Id).ToList();
        }
    }
}