using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using DocumentsCompletionReport = Silanis.ESL.API.DocumentsCompletionReport;
using PackageCompletionReport = Silanis.ESL.API.PackageCompletionReport;
using SenderCompletionReport = Silanis.ESL.API.SenderCompletionReport;
using SignersCompletionReport = Silanis.ESL.API.SignersCompletionReport;

namespace SDK.Tests
{
	[TestClass]
    public class CompletionReportConverterTest
    {
		private CompletionReport sdkCompletionReport1;
		private Silanis.ESL.API.CompletionReport apiCompletionReport1;
		private CompletionReportConverter converter;

		[TestMethod]
		public void ConvertNullAPIToSDK()
		{
			apiCompletionReport1 = null;
			converter = new CompletionReportConverter(apiCompletionReport1);
			Assert.IsNull(converter.ToSDKCompletionReport());
		}

		[TestMethod]
		public void ConvertAPIToSDK()
		{
			apiCompletionReport1 = CreateTypicalAPICompletionReport();
			sdkCompletionReport1 = new CompletionReportConverter(apiCompletionReport1).ToSDKCompletionReport();

			Assert.AreEqual(sdkCompletionReport1.From, apiCompletionReport1.From);
			Assert.AreEqual(sdkCompletionReport1.To, apiCompletionReport1.To);

			Assert.AreEqual(sdkCompletionReport1.Senders[0].Sender.Id, apiCompletionReport1.Senders[0].Sender.Id);
			Assert.AreEqual(sdkCompletionReport1.Senders[0].Sender.FirstName, apiCompletionReport1.Senders[0].Sender.FirstName);
			Assert.AreEqual(sdkCompletionReport1.Senders[0].Sender.LastName, apiCompletionReport1.Senders[0].Sender.LastName);

			var apiPackageCompletionReport = apiCompletionReport1.Senders[0].Packages[0];
			var sdkPackageCompletionReport = sdkCompletionReport1.Senders[0].Packages[0];
			Assert.AreEqual(sdkPackageCompletionReport.Id, apiPackageCompletionReport.Id);
			Assert.AreEqual(sdkPackageCompletionReport.Name, apiPackageCompletionReport.Name);
			Assert.AreEqual(sdkPackageCompletionReport.DocumentPackageStatus.ToString(), apiPackageCompletionReport.Status.ToString());
			Assert.AreEqual(sdkPackageCompletionReport.Created, apiPackageCompletionReport.Created);
			Assert.AreEqual(sdkPackageCompletionReport.Documents.Count, 1);
			Assert.AreEqual(sdkPackageCompletionReport.Signers.Count, 1);

			var apiDocumentsCompletionReport = apiPackageCompletionReport.Documents[0];
			var sdkDocumentsCompletionReport = sdkPackageCompletionReport.Documents[0];
			Assert.AreEqual(sdkDocumentsCompletionReport.Id, apiDocumentsCompletionReport.Id);
			Assert.AreEqual(sdkDocumentsCompletionReport.Name, apiDocumentsCompletionReport.Name);
			Assert.AreEqual(sdkDocumentsCompletionReport.FirstSigned, apiDocumentsCompletionReport.FirstSigned);
			Assert.AreEqual(sdkDocumentsCompletionReport.LastSigned, apiDocumentsCompletionReport.LastSigned);

			var apiSignersCompletionReport = apiPackageCompletionReport.Signers[0];
			var sdkSignersCompletionReport = sdkPackageCompletionReport.Signers[0];
			Assert.AreEqual(sdkSignersCompletionReport.Id, apiSignersCompletionReport.Id);
			Assert.AreEqual(sdkSignersCompletionReport.Email, apiSignersCompletionReport.Email);
			Assert.AreEqual(sdkSignersCompletionReport.FirstName, apiSignersCompletionReport.FirstName);
			Assert.AreEqual(sdkSignersCompletionReport.LastName, apiSignersCompletionReport.LastName);
			Assert.AreEqual(sdkSignersCompletionReport.FirstSigned, apiSignersCompletionReport.FirstSigned);
			Assert.AreEqual(sdkSignersCompletionReport.LastSigned, apiSignersCompletionReport.LastSigned);
		}

		private Silanis.ESL.API.CompletionReport CreateTypicalAPICompletionReport()
		{
			var documentCompletionReport = new DocumentsCompletionReport();
			documentCompletionReport.Id = "docId";
			documentCompletionReport.Completed = false;
			documentCompletionReport.Name = "documentName";
			documentCompletionReport.FirstSigned = new DateTime(9);

			var signersCompletionReport = new SignersCompletionReport();
			signersCompletionReport.Id = "signerId";
			signersCompletionReport.Email = "email@email.com";
			signersCompletionReport.FirstName = "Patty";
			signersCompletionReport.LastName = "Galant";
			signersCompletionReport.Completed = false;	

			var packageCompletionReport = new PackageCompletionReport();
            packageCompletionReport.Trashed = false;
			packageCompletionReport.Id = "packageId";
			packageCompletionReport.Name = "PackageName";
            packageCompletionReport.Status = DocumentPackageStatus.SENT.getApiValue();
			packageCompletionReport.AddSigner(signersCompletionReport);
			packageCompletionReport.AddDocument(documentCompletionReport);

			var sender = new Silanis.ESL.API.Sender();
			sender.Email = "sender@email.com";
			sender.FirstName = "SignerFirstName";
			sender.LastName = "SignerLastName";

			var senderCompletionReport = new SenderCompletionReport();
			senderCompletionReport.AddPackage(packageCompletionReport);
			senderCompletionReport.Sender = sender;

			var completionReport = new Silanis.ESL.API.CompletionReport();
			completionReport.To = new DateTime(1234);
			completionReport.From = new DateTime(5678);
			completionReport.AddSender(senderCompletionReport);

			return completionReport;
		}
    }
}

