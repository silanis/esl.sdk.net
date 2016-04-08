using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class EslEnumerationTest
    {
        [TestMethod]
        public void TestAuthenticationMethod()
        {
            foreach(var authenticationMethod in AuthenticationMethod.Values()) 
            {
                Assert.IsNotNull(authenticationMethod.ToString());
                Assert.IsTrue(!String.IsNullOrEmpty(authenticationMethod.ToString()));
            }
            Assert.AreEqual(1, AuthenticationMethod.CHALLENGE);
            Assert.AreEqual("SMS", AuthenticationMethod.SMS);
            Assert.AreEqual("SMS", AuthenticationMethod.SMS.GetName());
        }

        [TestMethod]
        public void TestFieldStyle()
        {
            foreach(var fieldStyle in FieldStyle.Values()) 
            {
                Assert.IsNotNull(fieldStyle.ToString());
                Assert.IsTrue(fieldStyle.ToString().Any());
            }
            Assert.AreEqual(0, FieldStyle.BOUND_DATE);
            Assert.AreEqual("BOUND_NAME", (string)FieldStyle.BOUND_NAME);
            Assert.AreEqual("TEXT_AREA", FieldStyle.TEXT_AREA.GetName());
        }

        [TestMethod]
        public void TestDocumentPackageStatus()
        {
            foreach(var documentPackageStatus in DocumentPackageStatus.Values()) 
            {
                Assert.IsNotNull(documentPackageStatus.ToString());
                Assert.IsTrue(documentPackageStatus.ToString().Any());
            }
            Assert.AreEqual(0, DocumentPackageStatus.DRAFT);
            Assert.AreEqual("SENT", (string)DocumentPackageStatus.SENT);
            Assert.AreEqual("COMPLETED", DocumentPackageStatus.COMPLETED.GetName());
        }


        [TestMethod]
        public void TestNotificationEvent()
        {
            foreach(var notificationEvent in NotificationEvent.Values()) 
            {
                Assert.IsNotNull(notificationEvent.ToString());
                Assert.IsTrue(notificationEvent.ToString().Any());
            }
            Assert.AreEqual(0, NotificationEvent.PACKAGE_ACTIVATE);
            Assert.AreEqual("PACKAGE_COMPLETE", (string)NotificationEvent.PACKAGE_COMPLETE);
            Assert.AreEqual("PACKAGE_EXPIRE", NotificationEvent.PACKAGE_EXPIRE.GetName());
        }

        [TestMethod]
        public void TestTextAnchorPosition()
        {
            foreach(var textAnchorPosition in TextAnchorPosition.Values()) 
            {
                Assert.IsNotNull(textAnchorPosition.ToString());
                Assert.IsTrue(textAnchorPosition.ToString().Any());
            }
            Assert.AreEqual(0, TextAnchorPosition.TOPLEFT);
            Assert.AreEqual("TOPRIGHT", (string)TextAnchorPosition.TOPRIGHT);
            Assert.AreEqual("BOTTOMLEFT", TextAnchorPosition.BOTTOMLEFT.GetName());
        }

        [TestMethod]
        public void TestSignatureStyle()
        {
            foreach(var signatureStyle in SignatureStyle.Values()) 
            {
                Assert.IsNotNull(signatureStyle.ToString());
                Assert.IsTrue(signatureStyle.ToString().Any());
            }
            Assert.AreEqual(0, SignatureStyle.HAND_DRAWN);
            Assert.AreEqual("FULL_NAME", (string)SignatureStyle.FULL_NAME);
            Assert.AreEqual("INITIALS", SignatureStyle.INITIALS.GetName());
        }

        [TestMethod]
        public void TestSenderType()
        {
            foreach(var senderType in SenderType.Values()) 
            {
                Assert.IsNotNull(senderType.ToString());
                Assert.IsTrue(senderType.ToString().Any());
            }
            Assert.AreEqual(0, SenderType.REGULAR);
            Assert.AreEqual("MANAGER", (string)SenderType.MANAGER);
            Assert.AreEqual("MANAGER", SenderType.MANAGER.GetName());
        }

        [TestMethod]
        public void TestSenderStatus()
        {
            foreach(var senderStatus in SenderStatus.Values()) 
            {
                Assert.IsNotNull(senderStatus.ToString());
                Assert.IsTrue(senderStatus.ToString().Any());
            }
            Assert.AreEqual(0, SenderStatus.INVITED);
            Assert.AreEqual("ACTIVE", (string)SenderStatus.ACTIVE);
            Assert.AreEqual("LOCKED", SenderStatus.LOCKED.GetName());
        }

        [TestMethod]
        public void TestRequirementStatus()
        {
            foreach(var requirementStatus in RequirementStatus.Values()) 
            {
                Assert.IsNotNull(requirementStatus.ToString());
                Assert.IsTrue(requirementStatus.ToString().Any());
            }
            Assert.AreEqual(0, RequirementStatus.INCOMPLETE);
            Assert.AreEqual("REJECTED", (string)RequirementStatus.REJECTED);
            Assert.AreEqual("COMPLETE", RequirementStatus.COMPLETE.GetName());
        }

        [TestMethod]
        public void TestMessageStatus()
        {
            foreach(var messageStatus in MessageStatus.Values()) 
            {
                Assert.IsNotNull(messageStatus.ToString());
                Assert.IsTrue(messageStatus.ToString().Any());
            }
            Assert.AreEqual(0, MessageStatus.NEW);
            Assert.AreEqual("READ", (string)MessageStatus.READ);
            Assert.AreEqual("TRASHED", MessageStatus.TRASHED.GetName());
        }

        [TestMethod]
        public void TestUsageReportCategory()
        {
            foreach(var usageReportCategory in UsageReportCategory.Values()) 
            {
                Assert.IsNotNull(usageReportCategory.ToString());
                Assert.IsTrue(usageReportCategory.ToString().Any());
            }
            Assert.AreEqual(0, UsageReportCategory.ACTIVE);
            Assert.AreEqual("DRAFT", (string)UsageReportCategory.DRAFT);
            Assert.AreEqual("SENT", UsageReportCategory.SENT.GetName());
        }

        [TestMethod]
        public void TestGroupMemberType()
        {
            foreach(var groupMemberType in GroupMemberType.Values()) 
            {
                Assert.IsNotNull(groupMemberType.ToString());
                Assert.IsTrue(groupMemberType.ToString().Any());
            }
            Assert.AreEqual(0, GroupMemberType.REGULAR);
            Assert.AreEqual("MANAGER", (string)GroupMemberType.MANAGER);
            Assert.AreEqual("MANAGER", GroupMemberType.MANAGER.GetName());
        }

        [TestMethod]
        public void TestKnowledgeBasedAuthenticationStatus()
        {
            foreach(var knowledgeBasedAuthenticationStatus in KnowledgeBasedAuthenticationStatus.Values()) 
            {
                Assert.IsNotNull(knowledgeBasedAuthenticationStatus.ToString());
                Assert.IsTrue(knowledgeBasedAuthenticationStatus.ToString().Any());
            }
            Assert.AreEqual(0, KnowledgeBasedAuthenticationStatus.NOT_YET_ATTEMPTED);
            Assert.AreEqual("PASSED", (string)KnowledgeBasedAuthenticationStatus.PASSED);
            Assert.AreEqual("FAILED", KnowledgeBasedAuthenticationStatus.FAILED.GetName());
        }

        [TestMethod]
        public void TestFieldType()
        {
            foreach(var fieldType in FieldType.Values()) 
            {
                Assert.IsNotNull(fieldType.ToString());
                Assert.IsTrue(fieldType.ToString().Any());
            }
            Assert.AreEqual(0, FieldType.SIGNATURE);
            Assert.AreEqual("INPUT", (string)FieldType.INPUT);
            Assert.AreEqual("IMAGE", FieldType.IMAGE.GetName());
        }
    }
}

