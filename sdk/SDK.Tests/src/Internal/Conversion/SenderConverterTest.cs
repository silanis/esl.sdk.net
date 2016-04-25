using NUnit.Framework;
using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class SenderConverterTest
    {
		private const string EMAIL = "bob@email.com";
		private const string FIRST_NAME = "firstName";
		private const string LAST_NAME = "lastName";
		private const string COMPANY = "company";
		private const string TITLE = "title";
        private const string EXTERNAL_ID = "externalId";
        private const string EXTERNAL_PROVIDER = "provider";
        private const string EXTERNAL_PROVIDER_NAME = "providerName";

		[Test()]
		public void ToSDKFromAPISender()
		{

			Silanis.ESL.API.Sender sender = CreateTypicalAPISender();

			SenderInfo senderInfo = new SenderConverter(sender).ToSDKSenderInfo();

			Assert.IsNotNull(senderInfo);
			Assert.AreEqual(sender.Email, senderInfo.Email);
			Assert.AreEqual(sender.FirstName, senderInfo.FirstName);
			Assert.AreEqual(sender.LastName, senderInfo.LastName);
			Assert.AreEqual(sender.Company, senderInfo.Company);
			Assert.AreEqual(sender.Title, senderInfo.Title);
		}

		[Test()]
		public void ToAPIFromSDKSenderInfo()
		{
			Silanis.ESL.SDK.SenderInfo senderInfo = new Silanis.ESL.SDK.SenderInfo();
			senderInfo.Email = EMAIL;
			senderInfo.FirstName = FIRST_NAME;
			senderInfo.LastName = LAST_NAME;
			senderInfo.Company = COMPANY;
			senderInfo.Title = TITLE;

			Silanis.ESL.API.Sender sender = new SenderConverter(senderInfo).ToAPISender();

			Assert.IsNotNull(sender);
			Assert.AreEqual(senderInfo.Email, sender.Email);
			Assert.AreEqual(senderInfo.FirstName, sender.FirstName);
			Assert.AreEqual(senderInfo.LastName, sender.LastName);
			Assert.AreEqual(senderInfo.Company, sender.Company);
			Assert.AreEqual(senderInfo.Title, sender.Title);
		}

		[Test()]
		[ExpectedException( typeof( ArgumentNullException) )]
		public void FromSDKNull()
		{
			Silanis.ESL.SDK.SenderInfo senderInfo = null;
			new SenderConverter(senderInfo);
		}

		[Test()]
		[ExpectedException( typeof( ArgumentNullException) )]
		public void FromAPINull()
		{
			Silanis.ESL.API.Sender sender = null;
			new SenderConverter(sender);
		}

		[Test()]
		public void ToSDKSenderFromAPISender()
		{
			Silanis.ESL.API.Sender apiSender = CreateTypicalAPISender();
			Silanis.ESL.SDK.Sender sdkSender = new SenderConverter(apiSender).ToSDKSender();

			Assert.AreEqual(sdkSender.Status.getApiValue(), apiSender.Status);
			Assert.AreEqual(sdkSender.LastName, apiSender.LastName);
			Assert.AreEqual(sdkSender.FirstName, apiSender.FirstName);
			Assert.AreEqual(sdkSender.Company, apiSender.Company);
			Assert.AreEqual(sdkSender.Created, apiSender.Created);
			Assert.AreEqual(sdkSender.Email, apiSender.Email);
			Assert.AreEqual(sdkSender.Language, apiSender.Language);
			Assert.AreEqual(sdkSender.Phone, apiSender.Phone);
			Assert.AreEqual(sdkSender.Name, apiSender.Name);
			Assert.AreEqual(sdkSender.Title, apiSender.Title);
			Assert.AreEqual(sdkSender.Type.ToString(), apiSender.Type.ToString());
			Assert.AreEqual(sdkSender.Updated, apiSender.Updated);
			Assert.AreEqual(sdkSender.Id, apiSender.Id);
            Assert.AreEqual(sdkSender.External.Id, apiSender.External.Id);
            Assert.AreEqual(sdkSender.External.Provider, apiSender.External.Provider);
            Assert.AreEqual(sdkSender.External.ProviderName, apiSender.External.ProviderName);
		}

		private Silanis.ESL.API.Sender CreateTypicalAPISender()
		{
			Silanis.ESL.API.Sender sender = new Silanis.ESL.API.Sender();
			sender.Email = EMAIL;
			sender.FirstName = FIRST_NAME;
			sender.LastName = LAST_NAME;
			sender.Company = COMPANY;
			sender.Title = TITLE;

            sender.External = new Silanis.ESL.API.External();
            sender.External.Id = EXTERNAL_ID;
            sender.External.Provider = EXTERNAL_PROVIDER;
            sender.External.ProviderName = EXTERNAL_PROVIDER_NAME;

			return sender;
		}
    }
}

