using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture]
    public class AttachmentRequirementConverterTest
    {
		private Silanis.ESL.SDK.AttachmentRequirement sdkAttachmentRequirement1 = null;
		private Silanis.ESL.SDK.AttachmentRequirement sdkAttachmentRequirement2 = null;
		private Silanis.ESL.API.AttachmentRequirement apiAttachmentRequirement1 = null;
		private Silanis.ESL.API.AttachmentRequirement apiAttachmentRequirement2 = null;
		private AttachmentRequirementConverter converter;

		[Test]
		public void ConvertNullSDKToAPI()
        {
			sdkAttachmentRequirement1 = null;
			converter = new AttachmentRequirementConverter(sdkAttachmentRequirement1);
			Assert.IsNull(converter.ToAPIAttachmentRequirement());
        }

		[Test]
		public void ConvertNullAPIToSDK()
		{
			apiAttachmentRequirement1 = null;
			converter = new AttachmentRequirementConverter(apiAttachmentRequirement1);
			Assert.IsNull(converter.ToSDKAttachmentRequirement());
		}

		[Test]
		public void ConvertNullSDKToSDK()
		{
			sdkAttachmentRequirement1 = null;
			converter = new AttachmentRequirementConverter(sdkAttachmentRequirement1);
			Assert.IsNull(converter.ToSDKAttachmentRequirement());
		}

		[Test]
		public void ConvertNullAPIToAPI()
		{
			apiAttachmentRequirement1 = null;
			converter = new AttachmentRequirementConverter(apiAttachmentRequirement1);
			Assert.IsNull(converter.ToAPIAttachmentRequirement());
		}

		[Test]
		public void ConvertSDKToSDK()
		{
			sdkAttachmentRequirement1 = CreateTypicalSDKAttachmentRequirement();
			sdkAttachmentRequirement2 = new AttachmentRequirementConverter(sdkAttachmentRequirement1).ToSDKAttachmentRequirement();

			Assert.IsNotNull(sdkAttachmentRequirement2);
			Assert.AreEqual(sdkAttachmentRequirement2, sdkAttachmentRequirement1);
		}

		[Test]
		public void ConvertAPIToAPI()
		{
			apiAttachmentRequirement1 = CreateTypicalAPIAttachmentRequirement();
			apiAttachmentRequirement2 = new AttachmentRequirementConverter(apiAttachmentRequirement1).ToAPIAttachmentRequirement();

			Assert.IsNotNull(apiAttachmentRequirement2);
			Assert.AreEqual(apiAttachmentRequirement2, apiAttachmentRequirement1);
		}

		[Test]
		public void ConvertAPIToSDK()
		{
			apiAttachmentRequirement1 = CreateTypicalAPIAttachmentRequirement();
			sdkAttachmentRequirement1 = new AttachmentRequirementConverter(apiAttachmentRequirement1).ToSDKAttachmentRequirement();

			Assert.AreEqual(sdkAttachmentRequirement1.Name, apiAttachmentRequirement1.Name);
			Assert.AreEqual(sdkAttachmentRequirement1.Description, apiAttachmentRequirement1.Description);
			Assert.AreEqual(sdkAttachmentRequirement1.Id, apiAttachmentRequirement1.Id);
			Assert.AreEqual(sdkAttachmentRequirement1.Required, apiAttachmentRequirement1.Required);
			Assert.AreEqual(sdkAttachmentRequirement1.Status.getApiValue(), apiAttachmentRequirement1.Status);
			Assert.AreEqual(sdkAttachmentRequirement1.SenderComment, apiAttachmentRequirement1.Comment);
		}

		[Test]
		public void ConvertSDKToAPI()
		{
			sdkAttachmentRequirement1 = CreateTypicalSDKAttachmentRequirement();
			apiAttachmentRequirement1 = new AttachmentRequirementConverter(sdkAttachmentRequirement1).ToAPIAttachmentRequirement();

			Assert.AreEqual(apiAttachmentRequirement1.Name, sdkAttachmentRequirement1.Name);
			Assert.AreEqual(apiAttachmentRequirement1.Description, sdkAttachmentRequirement1.Description);
			Assert.AreEqual(apiAttachmentRequirement1.Id, sdkAttachmentRequirement1.Id);
			Assert.AreEqual(apiAttachmentRequirement1.Required, sdkAttachmentRequirement1.Required);
			Assert.AreEqual(apiAttachmentRequirement1.Status, sdkAttachmentRequirement1.Status.ToString());
			Assert.AreEqual(apiAttachmentRequirement1.Comment, sdkAttachmentRequirement1.SenderComment);
		}

        [Test]
        public void ConvertSDKToAPIWhenSdkAttachmentRequirementIsNull()
        {
            sdkAttachmentRequirement1 = CreateTypicalSDKAttachmentRequirement();
            sdkAttachmentRequirement1.Id = null;
            apiAttachmentRequirement1 = new AttachmentRequirementConverter(sdkAttachmentRequirement1).ToAPIAttachmentRequirement();

            Assert.IsNull(apiAttachmentRequirement1.Id);
        }


		private Silanis.ESL.SDK.AttachmentRequirement CreateTypicalSDKAttachmentRequirement()
		{
			Silanis.ESL.SDK.AttachmentRequirement attachmentRequirement = AttachmentRequirementBuilder.NewAttachmentRequirementWithName("Driver's license")
				.WithDescription("Please upload a scanned copy of your driver's license")
				.IsRequiredAttachment()
				.Build();
			attachmentRequirement.Id = "attachmentId";

			return attachmentRequirement;
		}

		private Silanis.ESL.API.AttachmentRequirement CreateTypicalAPIAttachmentRequirement()
		{
			Silanis.ESL.API.AttachmentRequirement attachmentRequirement = new Silanis.ESL.API.AttachmentRequirement();
			attachmentRequirement.Name = "Driver's license";
			attachmentRequirement.Id = "attachment1";
			attachmentRequirement.Description = "Please upload a scanned copy of your driver's license";
			attachmentRequirement.Required = true;

			return attachmentRequirement;
		}
    }
}

