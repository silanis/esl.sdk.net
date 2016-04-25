using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Globalization;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture()]
    public class DocumentPackageConverterTest
    {
		private Silanis.ESL.SDK.DocumentPackage sdkPackage1 = null;
		private Silanis.ESL.API.Package apiPackage1 = null;
		private Silanis.ESL.API.Package apiPackage2 = null;
		private DocumentPackageConverter converter = null;

		[Test()]
		public void ConvertNullSDKToAPI()
		{
			sdkPackage1 = null;
			converter = new DocumentPackageConverter(sdkPackage1);
			Assert.IsNull(converter.ToAPIPackage());
		}

		[Test()]
		public void ConvertNullAPIToAPI()
		{
			apiPackage1 = null;
			converter = new DocumentPackageConverter(apiPackage1);
			Assert.IsNull(converter.ToAPIPackage());
		}

		[Test()]
		public void ConvertAPIToAPI()
		{
			apiPackage1 = CreateTypicalAPIPackage();
			converter = new DocumentPackageConverter(apiPackage1);
			apiPackage2 = converter.ToAPIPackage();

			Assert.IsNotNull(apiPackage2);
			Assert.AreEqual(apiPackage2, apiPackage1);
		}

        [Test()]
        public void ConvertAPIToSDK()
        {
            apiPackage1 = CreateTypicalAPIPackage();
            sdkPackage1 = new DocumentPackageConverter(apiPackage1).ToSDKPackage();

            Assert.IsNotNull(sdkPackage1);
            Assert.AreEqual(apiPackage1.Id, sdkPackage1.Id.Id);
            Assert.AreEqual(apiPackage1.Autocomplete, sdkPackage1.Autocomplete);
            Assert.AreEqual(apiPackage1.Description, sdkPackage1.Description);
            Assert.AreEqual(apiPackage1.Due, sdkPackage1.ExpiryDate);
            Assert.AreEqual(apiPackage1.Status.ToString(), sdkPackage1.Status.ToString());
            Assert.AreEqual(apiPackage1.Name, sdkPackage1.Name);
            Assert.AreEqual(apiPackage1.Messages[0].Content, sdkPackage1.Messages[0].Content);
            Assert.AreEqual(apiPackage1.Messages[0].Created, sdkPackage1.Messages[0].Created);
            Assert.AreEqual(apiPackage1.Messages[0].Status.ToString(), sdkPackage1.Messages[0].Status.ToString());
            Assert.AreEqual(apiPackage1.Messages[0].From.FirstName, sdkPackage1.Messages[0].From.FirstName);
            Assert.AreEqual(apiPackage1.Messages[0].From.LastName, sdkPackage1.Messages[0].From.LastName);
            Assert.AreEqual(apiPackage1.Messages[0].From.Email, sdkPackage1.Messages[0].From.Email);
            Assert.AreEqual(apiPackage1.Messages[0].To[0].FirstName, sdkPackage1.Messages[0].To["email2@email.com"].FirstName);
            Assert.AreEqual(apiPackage1.Messages[0].To[0].LastName, sdkPackage1.Messages[0].To["email2@email.com"].LastName);
            Assert.AreEqual(apiPackage1.Messages[0].To[0].Email, sdkPackage1.Messages[0].To["email2@email.com"].Email);
            Assert.AreEqual(apiPackage1.Sender.Email, sdkPackage1.SenderInfo.Email);
        }

		[Test()]
		public void ConvertSDKToAPI()
		{
			sdkPackage1 = CreateTypicalSDKDocumentPackage();
			apiPackage1 = new DocumentPackageConverter(sdkPackage1).ToAPIPackage();

			Assert.IsNotNull(apiPackage1);
            Assert.AreEqual(apiPackage1.Id, sdkPackage1.Id.ToString());
			Assert.AreEqual(apiPackage1.Name, sdkPackage1.Name);
			Assert.AreEqual(apiPackage1.Description, sdkPackage1.Description);
			Assert.AreEqual(apiPackage1.EmailMessage, sdkPackage1.EmailMessage);
			Assert.AreEqual(apiPackage1.Language, sdkPackage1.Language.ToString());
			Assert.AreEqual(apiPackage1.Due, sdkPackage1.ExpiryDate);
			Assert.AreEqual(apiPackage1.Status, sdkPackage1.Status.getApiValue());
		}

		private Silanis.ESL.SDK.DocumentPackage CreateTypicalSDKDocumentPackage()
		{
			Silanis.ESL.SDK.DocumentPackage sdkDocumentPackage = PackageBuilder.NewPackageNamed("SDK Package Name")
                .WithID(new PackageId("packageId"))
                .WithStatus(DocumentPackageStatus.DRAFT)
				.DescribedAs("typical description")
				.WithEmailMessage("typical email message")
				.WithLanguage(CultureInfo.GetCultureInfo("en"))
				.Build();

			return sdkDocumentPackage;
		}

		private Silanis.ESL.API.Package CreateTypicalAPIPackage()
		{
			Silanis.ESL.API.Package apiPackage = new Silanis.ESL.API.Package();
			apiPackage.Id = "1";
			apiPackage.Language = "en";
			apiPackage.Autocomplete = true;
			apiPackage.Consent = "Consent";
			apiPackage.Completed = new DateTime?();
			apiPackage.Description = "API document package description";
			apiPackage.Due = new DateTime?();
			apiPackage.Name = "API package name";
            apiPackage.Status = DocumentPackageStatus.DRAFT.getApiValue();

            Silanis.ESL.API.Message apiMessage = new Silanis.ESL.API.Message();
            apiMessage.Content = "opt-out reason";
            apiMessage.Status = Silanis.ESL.SDK.MessageStatus.NEW.getApiValue();
            apiMessage.Created = DateTime.Now;
            User fromUser = new User();
            fromUser.FirstName = "John";
            fromUser.LastName = "Smith";
            fromUser.Email = "email@email.com";
            apiMessage.From = fromUser;
            apiPackage.AddMessage(apiMessage);
            User toUser = new User();
            toUser.FirstName = "Patty";
            toUser.LastName = "Galant";
            toUser.Email = "email2@email.com";
            apiMessage.AddTo(toUser);

            Silanis.ESL.API.Sender sender = new Silanis.ESL.API.Sender();
            sender.Email = "sender@email.com";
            apiPackage.Sender = sender;

			return apiPackage;
		}
    }
}

