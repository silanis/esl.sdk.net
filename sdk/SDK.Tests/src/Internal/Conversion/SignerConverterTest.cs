using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Tests
{
    [TestFixture()]
    public class SignerConverterTest
    {
		private Silanis.ESL.SDK.Signer sdkSigner1 = null;
		private Silanis.ESL.API.Signer apiSigner1 = null;
		private Silanis.ESL.API.Role apiRole = null;
		private SignerConverter converter = null;

		[Test()]
		public void ConvertAPIToAPI()
		{
			apiRole = CreateTypicalAPIRole();
			apiSigner1 = new SignerConverter(apiRole).ToAPISigner();

			Assert.IsNotNull(apiSigner1);
			Assert.AreEqual(apiSigner1, apiRole.Signers[0]);
		}

		[Test()]
		public void ConvertNullAPIToAPI()
		{
			apiRole = null;
			converter = new SignerConverter(apiRole);

			Assert.IsNull(converter.ToAPISigner());
		}

		[Test()]
		public void ConvertNullSDKToAPI()
		{
			sdkSigner1 = null;
			converter = new SignerConverter(sdkSigner1);

			Assert.IsNull(converter.ToAPISigner());
		}

		[Test()]
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

		[Test()]
		public void ConvertSDKSignerToAPIRole()
		{
			sdkSigner1 = CreateTypicalSDKSigner();
			String roleId = System.Guid.NewGuid().ToString().Replace("-", "");
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

			string attachmentName = apiRole.AttachmentRequirements[0].Name;
			Assert.AreEqual(apiRole.AttachmentRequirements[0].Name, sdkSigner1.GetAttachmentRequirement(attachmentName).Name);
			Assert.AreEqual(apiRole.AttachmentRequirements[0].Description, sdkSigner1.GetAttachmentRequirement(attachmentName).Description);
			Assert.AreEqual(apiRole.AttachmentRequirements[0].Required, sdkSigner1.GetAttachmentRequirement(attachmentName).Required);
		}

        [Test()]
		public void ConvertSDKSignerWithNullEntriesToAPIRole()
        {
			String roleId = System.Guid.NewGuid().ToString().Replace("-", "");
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

        [Test()]
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

            string attachmentName = apiRole.AttachmentRequirements[0].Name;
            Silanis.ESL.API.AttachmentRequirement apiAttachment = apiRole.AttachmentRequirements[0];
            Silanis.ESL.SDK.AttachmentRequirement sdkAttachment = sdkSigner1.GetAttachmentRequirement(attachmentName);
            Assert.AreEqual(attachmentName, sdkSigner1.GetAttachmentRequirement(attachmentName).Name);
            Assert.AreEqual(apiAttachment.Description, sdkAttachment.Description);
            Assert.AreEqual(apiAttachment.Required, sdkAttachment.Required);
            Assert.AreEqual(apiAttachment.Status.ToString(), sdkAttachment.Status.ToString());
            Assert.AreEqual(apiAttachment.Comment, sdkAttachment.SenderComment);
        }

		private Silanis.ESL.SDK.Signer CreateTypicalSDKSigner()
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

		private Silanis.ESL.API.Role CreateTypicalAPIRole()
		{
			Silanis.ESL.API.Role apiRole = new Silanis.ESL.API.Role();

            Silanis.ESL.API.Signer apiSigner = new Silanis.ESL.API.Signer();
            apiSigner.Email = "test@abc.com";
            apiSigner.FirstName = "Signer first name";
            apiSigner.LastName = "Signer last name";
            apiSigner.Company = "ABC Inc.";
            apiSigner.Title = "Doctor";

            Silanis.ESL.API.Delivery delivery = new Silanis.ESL.API.Delivery();
            delivery.Download = true;
            delivery.Email = true;

            apiSigner.Delivery = delivery;
            apiSigner.Id = "1";

			apiRole.AddSigner(apiSigner);
			apiRole.Id = "3";
			apiRole.Name = "Signer name";
			apiRole.Index = 0;
			apiRole.Reassign = true;
			Silanis.ESL.API.BaseMessage baseMessage = new Silanis.ESL.API.BaseMessage();
			baseMessage.Content = "Base message content.";
			apiRole.EmailMessage = baseMessage;
			apiRole.Locked = true;

			Silanis.ESL.API.AttachmentRequirement attachmentRequirement = new Silanis.ESL.API.AttachmentRequirement();
			attachmentRequirement.Name = "Driver's license";
			attachmentRequirement.Description = "Please upload your scanned driver's license.";
            attachmentRequirement.Status = Silanis.ESL.SDK.RequirementStatus.INCOMPLETE.getApiValue();
			attachmentRequirement.Required = true;
			attachmentRequirement.Comment = "Attachment was not uploaded";
			apiRole.AddAttachmentRequirement(attachmentRequirement);

			return apiRole;
		}

	}
}

