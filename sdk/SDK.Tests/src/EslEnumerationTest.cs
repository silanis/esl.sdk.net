using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class EslEnumerationTest
    {
        [Test()]
        public void TestAuthenticationMethod()
        {
            foreach(AuthenticationMethod authenticationMethod in AuthenticationMethod.Values()) 
            {
                Assert.IsNotNull(authenticationMethod.ToString());
                Assert.IsNotEmpty(authenticationMethod.ToString());
            }
            Assert.AreEqual(1, AuthenticationMethod.CHALLENGE);
            Assert.AreEqual("SMS", (string)AuthenticationMethod.SMS);
            Assert.AreEqual("SMS", AuthenticationMethod.SMS.GetName());
        }

        [Test()]
        public void TestFieldStyle()
        {
            foreach(FieldStyle fieldStyle in FieldStyle.Values()) 
            {
                Assert.IsNotNull(fieldStyle.ToString());
                Assert.IsNotEmpty(fieldStyle.ToString());
            }
            Assert.AreEqual(0, FieldStyle.BOUND_DATE);
            Assert.AreEqual("BOUND_NAME", (string)FieldStyle.BOUND_NAME);
            Assert.AreEqual("TEXT_AREA", FieldStyle.TEXT_AREA.GetName());
        }

        [Test()]
        public void TestDocumentPackageStatus()
        {
            foreach(DocumentPackageStatus documentPackageStatus in DocumentPackageStatus.Values()) 
            {
                Assert.IsNotNull(documentPackageStatus.ToString());
                Assert.IsNotEmpty(documentPackageStatus.ToString());
            }
            Assert.AreEqual(0, DocumentPackageStatus.DRAFT);
            Assert.AreEqual("SENT", (string)DocumentPackageStatus.SENT);
            Assert.AreEqual("COMPLETED", DocumentPackageStatus.COMPLETED.GetName());
        }

        [Test()]
        public void TestNotificationEvent()
        {
            foreach(NotificationEvent notificationEvent in NotificationEvent.Values()) 
            {
                Assert.IsNotNull(notificationEvent.ToString());
                Assert.IsNotEmpty(notificationEvent.ToString());
            }
            Assert.AreEqual(0, NotificationEvent.PACKAGE_ACTIVATE);
            Assert.AreEqual("PACKAGE_COMPLETE", (string)NotificationEvent.PACKAGE_COMPLETE);
            Assert.AreEqual("PACKAGE_EXPIRE", NotificationEvent.PACKAGE_EXPIRE.GetName());
        }

        [Test()]
        public void TestTextAnchorPosition()
        {
            foreach(TextAnchorPosition textAnchorPosition in TextAnchorPosition.Values()) 
            {
                Assert.IsNotNull(textAnchorPosition.ToString());
                Assert.IsNotEmpty(textAnchorPosition.ToString());
            }
            Assert.AreEqual(0, TextAnchorPosition.TOPLEFT);
            Assert.AreEqual("TOPRIGHT", (string)TextAnchorPosition.TOPRIGHT);
            Assert.AreEqual("BOTTOMLEFT", TextAnchorPosition.BOTTOMLEFT.GetName());
        }

        [Test()]
        public void TestSignatureStyle()
        {
            foreach(SignatureStyle signatureStyle in SignatureStyle.Values()) 
            {
                Assert.IsNotNull(signatureStyle.ToString());
                Assert.IsNotEmpty(signatureStyle.ToString());
            }
            Assert.AreEqual(0, SignatureStyle.HAND_DRAWN);
            Assert.AreEqual("FULL_NAME", (string)SignatureStyle.FULL_NAME);
            Assert.AreEqual("INITIALS", SignatureStyle.INITIALS.GetName());
        }

        [Test()]
        public void TestSenderType()
        {
            foreach(SenderType senderType in SenderType.Values()) 
            {
                Assert.IsNotNull(senderType.ToString());
                Assert.IsNotEmpty(senderType.ToString());
            }
            Assert.AreEqual(0, SenderType.REGULAR);
            Assert.AreEqual("MANAGER", (string)SenderType.MANAGER);
            Assert.AreEqual("MANAGER", SenderType.MANAGER.GetName());
        }

        [Test()]
        public void TestSenderStatus()
        {
            foreach(SenderStatus senderStatus in SenderStatus.Values()) 
            {
                Assert.IsNotNull(senderStatus.ToString());
                Assert.IsNotEmpty(senderStatus.ToString());
            }
            Assert.AreEqual(0, SenderStatus.INVITED);
            Assert.AreEqual("ACTIVE", (string)SenderStatus.ACTIVE);
            Assert.AreEqual("LOCKED", SenderStatus.LOCKED.GetName());
        }

        [Test()]
        public void TestRequirementStatus()
        {
            foreach(RequirementStatus requirementStatus in RequirementStatus.Values()) 
            {
                Assert.IsNotNull(requirementStatus.ToString());
                Assert.IsNotEmpty(requirementStatus.ToString());
            }
            Assert.AreEqual(0, RequirementStatus.INCOMPLETE);
            Assert.AreEqual("REJECTED", (string)RequirementStatus.REJECTED);
            Assert.AreEqual("COMPLETE", RequirementStatus.COMPLETE.GetName());
        }

        [Test()]
        public void TestMessageStatus()
        {
            foreach(MessageStatus messageStatus in MessageStatus.Values()) 
            {
                Assert.IsNotNull(messageStatus.ToString());
                Assert.IsNotEmpty(messageStatus.ToString());
            }
            Assert.AreEqual(0, MessageStatus.NEW);
            Assert.AreEqual("READ", (string)MessageStatus.READ);
            Assert.AreEqual("TRASHED", MessageStatus.TRASHED.GetName());
        }

        [Test()]
        public void TestUsageReportCategory()
        {
            foreach(UsageReportCategory usageReportCategory in UsageReportCategory.Values()) 
            {
                Assert.IsNotNull(usageReportCategory.ToString());
                Assert.IsNotEmpty(usageReportCategory.ToString());
            }
            Assert.AreEqual(0, UsageReportCategory.ACTIVE);
            Assert.AreEqual("DRAFT", (string)UsageReportCategory.DRAFT);
            Assert.AreEqual("SENT", UsageReportCategory.SENT.GetName());
        }

        [Test()]
        public void TestGroupMemberType()
        {
            foreach(GroupMemberType groupMemberType in GroupMemberType.Values()) 
            {
                Assert.IsNotNull(groupMemberType.ToString());
                Assert.IsNotEmpty(groupMemberType.ToString());
            }
            Assert.AreEqual(0, GroupMemberType.REGULAR);
            Assert.AreEqual("MANAGER", (string)GroupMemberType.MANAGER);
            Assert.AreEqual("MANAGER", GroupMemberType.MANAGER.GetName());
        }

        [Test()]
        public void TestKnowledgeBasedAuthenticationStatus()
        {
            foreach(KnowledgeBasedAuthenticationStatus knowledgeBasedAuthenticationStatus in KnowledgeBasedAuthenticationStatus.Values()) 
            {
                Assert.IsNotNull(knowledgeBasedAuthenticationStatus.ToString());
                Assert.IsNotEmpty(knowledgeBasedAuthenticationStatus.ToString());
            }
            Assert.AreEqual(0, KnowledgeBasedAuthenticationStatus.NOT_YET_ATTEMPTED);
            Assert.AreEqual("PASSED", (string)KnowledgeBasedAuthenticationStatus.PASSED);
            Assert.AreEqual("FAILED", KnowledgeBasedAuthenticationStatus.FAILED.GetName());
        }

        [Test()]
        public void TestFieldType()
        {
            foreach(FieldType fieldType in FieldType.Values()) 
            {
                Assert.IsNotNull(fieldType.ToString());
                Assert.IsNotEmpty(fieldType.ToString());
            }
            Assert.AreEqual(0, FieldType.SIGNATURE);
            Assert.AreEqual("INPUT", (string)FieldType.INPUT);
            Assert.AreEqual("IMAGE", FieldType.IMAGE.GetName());
        }
    }
}

