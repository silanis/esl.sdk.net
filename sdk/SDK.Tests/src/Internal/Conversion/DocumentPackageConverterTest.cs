using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Globalization;
using Silanis.ESL.API;
using Message = Silanis.ESL.API.Message;
using Sender = Silanis.ESL.API.Sender;

namespace SDK.Tests
{
    [TestClass]
    public class DocumentPackageConverterTest
    {
		private DocumentPackage _sdkPackage1;
		private Package _apiPackage1;
		private Package _apiPackage2;
		private DocumentPackageConverter _converter;

		[TestMethod]
		public void ConvertNullSDKToAPI()
		{
			_sdkPackage1 = null;
			_converter = new DocumentPackageConverter(_sdkPackage1);
			Assert.IsNull(_converter.ToAPIPackage());
		}

		[TestMethod]
		public void ConvertNullAPIToAPI()
		{
			_apiPackage1 = null;
			_converter = new DocumentPackageConverter(_apiPackage1);
			Assert.IsNull(_converter.ToAPIPackage());
		}

		[TestMethod]
		public void ConvertAPIToAPI()
		{
			_apiPackage1 = CreateTypicalAPIPackage();
			_converter = new DocumentPackageConverter(_apiPackage1);
			_apiPackage2 = _converter.ToAPIPackage();

			Assert.IsNotNull(_apiPackage2);
			Assert.AreEqual(_apiPackage2, _apiPackage1);
		}

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            _apiPackage1 = CreateTypicalAPIPackage();
            _sdkPackage1 = new DocumentPackageConverter(_apiPackage1).ToSDKPackage();

            Assert.IsNotNull(_sdkPackage1);
            Assert.AreEqual(_apiPackage1.Id, _sdkPackage1.Id.Id);
            Assert.AreEqual(_apiPackage1.Autocomplete, _sdkPackage1.Autocomplete);
            Assert.AreEqual(_apiPackage1.Description, _sdkPackage1.Description);
            Assert.AreEqual(_apiPackage1.Due, _sdkPackage1.ExpiryDate);
            Assert.AreEqual(_apiPackage1.Status.ToString(), _sdkPackage1.Status.ToString());
            Assert.AreEqual(_apiPackage1.Name, _sdkPackage1.Name);
            Assert.AreEqual(_apiPackage1.Messages[0].Content, _sdkPackage1.Messages[0].Content);
            Assert.AreEqual(_apiPackage1.Messages[0].Created, _sdkPackage1.Messages[0].Created);
            Assert.AreEqual(_apiPackage1.Messages[0].Status.ToString(), _sdkPackage1.Messages[0].Status.ToString());
            Assert.AreEqual(_apiPackage1.Messages[0].From.FirstName, _sdkPackage1.Messages[0].From.FirstName);
            Assert.AreEqual(_apiPackage1.Messages[0].From.LastName, _sdkPackage1.Messages[0].From.LastName);
            Assert.AreEqual(_apiPackage1.Messages[0].From.Email, _sdkPackage1.Messages[0].From.Email);
            Assert.AreEqual(_apiPackage1.Messages[0].To[0].FirstName, _sdkPackage1.Messages[0].To["email2@email.com"].FirstName);
            Assert.AreEqual(_apiPackage1.Messages[0].To[0].LastName, _sdkPackage1.Messages[0].To["email2@email.com"].LastName);
            Assert.AreEqual(_apiPackage1.Messages[0].To[0].Email, _sdkPackage1.Messages[0].To["email2@email.com"].Email);
            Assert.AreEqual(_apiPackage1.Sender.Email, _sdkPackage1.SenderInfo.Email);
        }

		[TestMethod]
		public void ConvertSDKToAPI()
		{
			_sdkPackage1 = CreateTypicalSDKDocumentPackage();
			_apiPackage1 = new DocumentPackageConverter(_sdkPackage1).ToAPIPackage();

			Assert.IsNotNull(_apiPackage1);
            Assert.AreEqual(_apiPackage1.Id, _sdkPackage1.Id.ToString());
			Assert.AreEqual(_apiPackage1.Name, _sdkPackage1.Name);
			Assert.AreEqual(_apiPackage1.Description, _sdkPackage1.Description);
			Assert.AreEqual(_apiPackage1.EmailMessage, _sdkPackage1.EmailMessage);
			Assert.AreEqual(_apiPackage1.Language, _sdkPackage1.Language.ToString());
			Assert.AreEqual(_apiPackage1.Due, _sdkPackage1.ExpiryDate);
			Assert.AreEqual(_apiPackage1.Status, _sdkPackage1.Status.getApiValue());
		}

		private DocumentPackage CreateTypicalSDKDocumentPackage()
		{
			var sdkDocumentPackage = PackageBuilder.NewPackageNamed("SDK Package Name")
                .WithID(new PackageId("packageId"))
                .WithStatus(DocumentPackageStatus.DRAFT)
				.DescribedAs("typical description")
				.WithEmailMessage("typical email message")
				.WithLanguage(CultureInfo.GetCultureInfo("en"))
				.Build();

			return sdkDocumentPackage;
		}

		private Package CreateTypicalAPIPackage()
		{
			var apiPackage = new Package
		{
			    Id = "1",
			    Language = "en",
			    Autocomplete = true,
			    Consent = "Consent",
			    Completed = new DateTime?(),
			    Description = "API document package description",
			    Due = new DateTime?(),
			    Name = "API package name",
			    Status = DocumentPackageStatus.DRAFT.getApiValue()
			};

		    var apiMessage = new Message
		    {
		        Content = "opt-out reason",
		        Status = MessageStatus.NEW.getApiValue(),
		        Created = DateTime.Now
		    };
		    var fromUser = new User {FirstName = "John", LastName = "Smith", Email = "email@email.com"};
            apiMessage.From = fromUser;
            apiPackage.AddMessage(apiMessage);
            var toUser = new User {FirstName = "Patty", LastName = "Galant", Email = "email2@email.com"};
            apiMessage.AddTo(toUser);

            var sender = new Sender {Email = "sender@email.com"};
            apiPackage.Sender = sender;

			return apiPackage;
		}
    }
}

