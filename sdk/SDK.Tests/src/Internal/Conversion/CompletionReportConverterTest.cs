using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	[TestFixture]
    public class CompletionReportConverterTest
    {
		private Silanis.ESL.SDK.CompletionReport sdkCompletionReport1 = null;
		private Silanis.ESL.API.CompletionReport apiCompletionReport1 = null;
		private CompletionReportConverter converter;

		[Test]
		public void ConvertNullAPIToSDK()
		{
			apiCompletionReport1 = null;
			converter = new CompletionReportConverter(apiCompletionReport1);
			Assert.IsNull(converter.ToSDKCompletionReport());
		}

		[Test]
		public void ConvertAPIToSDK()
		{
			apiCompletionReport1 = CreateTypicalAPICompletionReport();
			sdkCompletionReport1 = new CompletionReportConverter(apiCompletionReport1).ToSDKCompletionReport();

			Assert.AreEqual(sdkCompletionReport1.From, apiCompletionReport1.From);
			Assert.AreEqual(sdkCompletionReport1.To, apiCompletionReport1.To);

			Assert.AreEqual(sdkCompletionReport1.Senders[0].Sender.Id, apiCompletionReport1.Senders[0].Sender.Id);
			Assert.AreEqual(sdkCompletionReport1.Senders[0].Sender.FirstName, apiCompletionReport1.Senders[0].Sender.FirstName);
			Assert.AreEqual(sdkCompletionReport1.Senders[0].Sender.LastName, apiCompletionReport1.Senders[0].Sender.LastName);

			Silanis.ESL.API.PackageCompletionReport apiPackageCompletionReport = apiCompletionReport1.Senders[0].Packages[0];
			Silanis.ESL.SDK.PackageCompletionReport sdkPackageCompletionReport = sdkCompletionReport1.Senders[0].Packages[0];
			Assert.AreEqual(sdkPackageCompletionReport.Id, apiPackageCompletionReport.Id);
			Assert.AreEqual(sdkPackageCompletionReport.Name, apiPackageCompletionReport.Name);
			Assert.AreEqual(sdkPackageCompletionReport.DocumentPackageStatus.ToString(), apiPackageCompletionReport.Status.ToString());
			Assert.AreEqual(sdkPackageCompletionReport.Created, apiPackageCompletionReport.Created);
			Assert.AreEqual(sdkPackageCompletionReport.Documents.Count, 1);
			Assert.AreEqual(sdkPackageCompletionReport.Signers.Count, 1);

			Silanis.ESL.API.DocumentsCompletionReport apiDocumentsCompletionReport = apiPackageCompletionReport.Documents[0];
			Silanis.ESL.SDK.DocumentsCompletionReport sdkDocumentsCompletionReport = sdkPackageCompletionReport.Documents[0];
			Assert.AreEqual(sdkDocumentsCompletionReport.Id, apiDocumentsCompletionReport.Id);
			Assert.AreEqual(sdkDocumentsCompletionReport.Name, apiDocumentsCompletionReport.Name);
			Assert.AreEqual(sdkDocumentsCompletionReport.FirstSigned, apiDocumentsCompletionReport.FirstSigned);
			Assert.AreEqual(sdkDocumentsCompletionReport.LastSigned, apiDocumentsCompletionReport.LastSigned);

			Silanis.ESL.API.SignersCompletionReport apiSignersCompletionReport = apiPackageCompletionReport.Signers[0];
			Silanis.ESL.SDK.SignersCompletionReport sdkSignersCompletionReport = sdkPackageCompletionReport.Signers[0];
			Assert.AreEqual(sdkSignersCompletionReport.Id, apiSignersCompletionReport.Id);
			Assert.AreEqual(sdkSignersCompletionReport.Email, apiSignersCompletionReport.Email);
			Assert.AreEqual(sdkSignersCompletionReport.FirstName, apiSignersCompletionReport.FirstName);
			Assert.AreEqual(sdkSignersCompletionReport.LastName, apiSignersCompletionReport.LastName);
			Assert.AreEqual(sdkSignersCompletionReport.FirstSigned, apiSignersCompletionReport.FirstSigned);
			Assert.AreEqual(sdkSignersCompletionReport.LastSigned, apiSignersCompletionReport.LastSigned);
		}

		private Silanis.ESL.API.CompletionReport CreateTypicalAPICompletionReport()
		{
			Silanis.ESL.API.DocumentsCompletionReport documentCompletionReport = new Silanis.ESL.API.DocumentsCompletionReport();
			documentCompletionReport.Id = "docId";
			documentCompletionReport.Completed = false;
			documentCompletionReport.Name = "documentName";
			documentCompletionReport.FirstSigned = new DateTime(9);

			Silanis.ESL.API.SignersCompletionReport signersCompletionReport = new Silanis.ESL.API.SignersCompletionReport();
			signersCompletionReport.Id = "signerId";
			signersCompletionReport.Email = "email@email.com";
			signersCompletionReport.FirstName = "Patty";
			signersCompletionReport.LastName = "Galant";
			signersCompletionReport.Completed = false;	

			Silanis.ESL.API.PackageCompletionReport packageCompletionReport = new Silanis.ESL.API.PackageCompletionReport();
            packageCompletionReport.Trashed = false;
			packageCompletionReport.Id = "packageId";
			packageCompletionReport.Name = "PackageName";
            packageCompletionReport.Status = DocumentPackageStatus.SENT.getApiValue();
			packageCompletionReport.AddSigner(signersCompletionReport);
			packageCompletionReport.AddDocument(documentCompletionReport);

			Silanis.ESL.API.Sender sender = new Silanis.ESL.API.Sender();
			sender.Email = "sender@email.com";
			sender.FirstName = "SignerFirstName";
			sender.LastName = "SignerLastName";

			Silanis.ESL.API.SenderCompletionReport senderCompletionReport = new Silanis.ESL.API.SenderCompletionReport();
			senderCompletionReport.AddPackage(packageCompletionReport);
			senderCompletionReport.Sender = sender;

			Silanis.ESL.API.CompletionReport completionReport = new Silanis.ESL.API.CompletionReport();
			completionReport.To = new DateTime(1234);
			completionReport.From = new DateTime(5678);
			completionReport.AddSender(senderCompletionReport);

			return completionReport;
		}
    }
}

