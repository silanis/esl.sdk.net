using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.API;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using AttachmentRequirement = Silanis.ESL.API.AttachmentRequirement;
using Signer = Silanis.ESL.SDK.Signer;

namespace SDK.Tests
{
    [TestClass]
    public class SignerConverterTest
    {
		private Signer sdkSigner1;
		private Silanis.ESL.API.Signer apiSigner1;
		private Role apiRole;
		private SignerConverter converter;

		[TestMethod]
		public void ConvertAPIToAPI()
		{
			apiRole = CreateTypicalAPIRole();
			apiSigner1 = new SignerConverter(apiRole).ToAPISigner();

			Assert.IsNotNull(apiSigner1);
			Assert.AreEqual(apiSigner1, apiRole.Signers[0]);
		}

		[TestMethod]
		public void ConvertNullAPIToAPI()
		{
			apiRole = null;
			converter = new SignerConverter(apiRole);

			Assert.IsNull(converter.ToAPISigner());
		}

		[TestMethod]
		public void ConvertNullSDKToAPI()
		{
			sdkSigner1 = null;
			converter = new SignerConverter(sdkSigner1);

			Assert.IsNull(converter.ToAPISigner());
		}

		[TestMethod]
		public void ConvertSDKToAPI()
		{
			sdkSigner1 = CreateTypicalSDKSigner();
			apiSigner1 = new SignerConverter(sdkSigner1).ToAPISigner();

			Assert.IsNotNull(apiSigner1);
			Assert.AreEqual(apiSigner1.Email, sdkSigner1.Email);
			Assert.AreEqual(apiSigner1.FirstName, sdkSigner1.FirstName);
			Assert.AreEqual(apiSigner1.LastName, sdkSigner1.LastName);
			Assert.AreEqual(apiSigner1.Company, sdkSigner1.Company);
			Assert.AreEqual(apiSigner1.Title, sdkSigner1.Title);
		}

		[TestMethod]
		public void ConvertSDKSignerToAPIRole()
		{
			sdkSigner1 = CreateTypicalSDKSigner();
			var roleId = Guid.NewGuid().ToString().Replace("-", "");
			apiRole = new SignerConverter(sdkSigner1).ToAPIRole(roleId);

			Assert.IsNotNull(apiRole);
			Assert.AreEqual(apiRole.Signers[0].Email, sdkSigner1.Email);
			Assert.AreEqual(apiRole.Signers[0].FirstName, sdkSigner1.FirstName);
			Assert.AreEqual(apiRole.Signers[0].LastName, sdkSigner1.LastName);
			Assert.AreEqual(apiRole.Signers[0].Company, sdkSigner1.Company);
			Assert.AreEqual(apiRole.Signers[0].Title, sdkSigner1.Title);
			Assert.AreEqual(apiRole.Id, sdkSigner1.Id);
			Assert.AreEqual(apiRole.Name, sdkSigner1.Id);
			Assert.AreEqual(apiRole.EmailMessage.Content, sdkSigner1.Message);

			var attachmentName = apiRole.AttachmentRequirements[0].Name;
			Assert.AreEqual(apiRole.AttachmentRequirements[0].Name, sdkSigner1.GetAttachmentRequirement(attachmentName).Name);
			Assert.AreEqual(apiRole.AttachmentRequirements[0].Description, sdkSigner1.GetAttachmentRequirement(attachmentName).Description);
			Assert.AreEqual(apiRole.AttachmentRequirements[0].Required, sdkSigner1.GetAttachmentRequirement(attachmentName).Required);
		}

        [TestMethod]
		public void ConvertSDKSignerWithNullEntriesToAPIRole()
        {
			var roleId = Guid.NewGuid().ToString().Replace("-", "");
			sdkSigner1 = SignerBuilder.NewSignerWithEmail("abc@test.com")
				.CanChangeSigner()
				.DeliverSignedDocumentsByEmail()
				.SigningOrder(1)
				.WithCompany("ABC Inc.")
				.WithFirstName("first name")
				.WithLastName("last name")
				.WithTitle("Miss")
				.Build();

			apiRole = new SignerConverter(sdkSigner1).ToAPIRole(roleId);

			Assert.IsNotNull(apiRole);
			Assert.AreEqual(apiRole.Signers[0].Email, sdkSigner1.Email);
			Assert.AreEqual(apiRole.Signers[0].FirstName, sdkSigner1.FirstName);
			Assert.AreEqual(apiRole.Signers[0].LastName, sdkSigner1.LastName);
			Assert.AreEqual(apiRole.Signers[0].Company, sdkSigner1.Company);
			Assert.AreEqual(apiRole.Signers[0].Title, sdkSigner1.Title);
			Assert.AreEqual(apiRole.Id, roleId);
			Assert.AreEqual(apiRole.Name, roleId);
			Assert.IsNull(apiRole.EmailMessage);
        }

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            apiRole = CreateTypicalAPIRole();
            apiSigner1 = apiRole.Signers[0];

            sdkSigner1 = new SignerConverter(apiRole).ToSDKSigner();

            Assert.IsNotNull(sdkSigner1);
            Assert.AreEqual(apiSigner1.Email, sdkSigner1.Email);
            Assert.AreEqual(apiSigner1.FirstName, sdkSigner1.FirstName);
            Assert.AreEqual(apiSigner1.LastName, sdkSigner1.LastName);
            Assert.AreEqual(apiSigner1.Company, sdkSigner1.Company);
            Assert.AreEqual(apiSigner1.Title, sdkSigner1.Title);
            Assert.AreEqual(apiRole.Id, sdkSigner1.Id);
            Assert.AreEqual(apiRole.Index, sdkSigner1.SigningOrder);
            Assert.AreEqual(apiRole.Reassign, sdkSigner1.CanChangeSigner);
            Assert.AreEqual(apiRole.EmailMessage.Content, sdkSigner1.Message);
            Assert.AreEqual(apiSigner1.Delivery.Email, sdkSigner1.DeliverSignedDocumentsByEmail);

            var attachmentName = apiRole.AttachmentRequirements[0].Name;
            var apiAttachment = apiRole.AttachmentRequirements[0];
            var sdkAttachment = sdkSigner1.GetAttachmentRequirement(attachmentName);
            Assert.AreEqual(attachmentName, sdkSigner1.GetAttachmentRequirement(attachmentName).Name);
            Assert.AreEqual(apiAttachment.Description, sdkAttachment.Description);
            Assert.AreEqual(apiAttachment.Required, sdkAttachment.Required);
            Assert.AreEqual(apiAttachment.Status.ToString(), sdkAttachment.Status.ToString());
            Assert.AreEqual(apiAttachment.Comment, sdkAttachment.SenderComment);
        }

		private Signer CreateTypicalSDKSigner()
		{
            return SignerBuilder.NewSignerWithEmail("abc@test.com")
				.CanChangeSigner()
				.DeliverSignedDocumentsByEmail()
				.SigningOrder(1)
				.WithCompany("ABC Inc")
				.WithCustomId("1")
				.WithFirstName("first name")
				.WithLastName("last name")
				.WithEmailMessage("Email message")
				.WithTitle("Miss")
				.WithAttachmentRequirement(AttachmentRequirementBuilder.NewAttachmentRequirementWithName("driver's license")
					.WithDescription("Please upload your scanned driver's license")
					.IsRequiredAttachment()
					.Build())
				.Build();
		}

		private Role CreateTypicalAPIRole()
		{
			var apiRole = new Role();

            var apiSigner = new Silanis.ESL.API.Signer();
            apiSigner.Email = "test@abc.com";
            apiSigner.FirstName = "Signer first name";
            apiSigner.LastName = "Signer last name";
            apiSigner.Company = "ABC Inc.";
            apiSigner.Title = "Doctor";

            var delivery = new Delivery();
            delivery.Download = true;
            delivery.Email = true;

            apiSigner.Delivery = delivery;
            apiSigner.Id = "1";

			apiRole.AddSigner(apiSigner);
			apiRole.Id = "3";
			apiRole.Name = "Signer name";
			apiRole.Index = 0;
			apiRole.Reassign = true;
			var baseMessage = new BaseMessage();
			baseMessage.Content = "Base message content.";
			apiRole.EmailMessage = baseMessage;
			apiRole.Locked = true;

			var attachmentRequirement = new AttachmentRequirement();
			attachmentRequirement.Name = "Driver's license";
			attachmentRequirement.Description = "Please upload your scanned driver's license.";
            attachmentRequirement.Status = RequirementStatus.INCOMPLETE.getApiValue();
			attachmentRequirement.Required = true;
			attachmentRequirement.Comment = "Attachment was not uploaded";
			apiRole.AddAttachmentRequirement(attachmentRequirement);

			return apiRole;
		}

	}
}

