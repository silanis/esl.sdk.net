using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	/// <summary>
	/// Converter for API CompletionReport to SDK CompletionReport. Contains conversions for all the
	/// sub-completion reports (ex: SenderCompletionReport, PackageCompletionReport, DocumentCompletionReport,
	/// SignerCompletionReport).
	/// </summary>
	internal class CompletionReportConverter
    {
		private Silanis.ESL.SDK.CompletionReport sdkCompletionReport = null;
		private Silanis.ESL.API.CompletionReport apiCompletionReport = null;

		public CompletionReportConverter(Silanis.ESL.API.CompletionReport apiCompletionReport)
        {
			this.apiCompletionReport = apiCompletionReport;
        }

		/// <summary>
		/// Convert from API CompletionReport to SDK CompletionReport.
		/// </summary>
		/// <returns>The SDK completion report.</returns>
		public Silanis.ESL.SDK.CompletionReport ToSDKCompletionReport()
		{
			if (apiCompletionReport == null)
			{
				return sdkCompletionReport;
			}

			var senderCompletionReportList = apiCompletionReport.Senders;

			if (senderCompletionReportList.Count != 0)
			{
				var result = new Silanis.ESL.SDK.CompletionReport();
				result.From = apiCompletionReport.From;
				result.To = apiCompletionReport.To;

				var sdkSenderCompletionReport = new Silanis.ESL.SDK.SenderCompletionReport();
				foreach (var apiSenderCompletionReport in senderCompletionReportList)
				{
					sdkSenderCompletionReport = ToSDKSenderCompletionReport(apiSenderCompletionReport);

					var packageCompletionReportList = apiSenderCompletionReport.Packages;
					Silanis.ESL.SDK.PackageCompletionReport sdkPackageCompletionReport;
					foreach (var apiPackageCompletionReport in packageCompletionReportList)
					{
						sdkPackageCompletionReport = ToSDKPackageCompletionReport(apiPackageCompletionReport);

						var documentCompletionReportList = apiPackageCompletionReport.Documents;
						Silanis.ESL.SDK.DocumentsCompletionReport sdkDocumentsCompletionReport;
						foreach (var apiDocumentsCompletionReport in documentCompletionReportList)
						{
							sdkDocumentsCompletionReport = ToSDKDocumentsCompletionReport(apiDocumentsCompletionReport);
							sdkPackageCompletionReport.AddDocument(sdkDocumentsCompletionReport);
						}

						var signersCompletionReportList = apiPackageCompletionReport.Signers;
						Silanis.ESL.SDK.SignersCompletionReport sdkSignersCompletionReport;
						foreach (var apiSignersCompletionReport in signersCompletionReportList)
						{
							sdkSignersCompletionReport = ToSDKSignersCompletionReport(apiSignersCompletionReport);
							sdkPackageCompletionReport.AddSigner(sdkSignersCompletionReport);
						}

						sdkSenderCompletionReport.AddPackage(sdkPackageCompletionReport);
					}

					result.AddSender(sdkSenderCompletionReport);
				}

				return result;
			}

			return sdkCompletionReport;

		}

		// Convert from API to SDK SenderCompletionReport
		private Silanis.ESL.SDK.SenderCompletionReport ToSDKSenderCompletionReport(Silanis.ESL.API.SenderCompletionReport apiSenderCompletionReport)
		{
			var sdkSenderCompletionReport = new Silanis.ESL.SDK.SenderCompletionReport();
			sdkSenderCompletionReport.Sender = new SenderConverter(apiSenderCompletionReport.Sender).ToSDKSender();

			return sdkSenderCompletionReport;
		}

		// Convert from API to SDK PackageCompletionReport
		private Silanis.ESL.SDK.PackageCompletionReport ToSDKPackageCompletionReport(Silanis.ESL.API.PackageCompletionReport apiPackageCompletionReport)
		{
			var sdkPackageCompletionReport = new Silanis.ESL.SDK.PackageCompletionReport(apiPackageCompletionReport.Name);
			sdkPackageCompletionReport.Id = apiPackageCompletionReport.Id;
            
			sdkPackageCompletionReport.Created = apiPackageCompletionReport.Created;
			sdkPackageCompletionReport.DocumentPackageStatus = new PackageStatusConverter(apiPackageCompletionReport.Status).ToSDKPackageStatus();
		    sdkPackageCompletionReport.Trashed = apiPackageCompletionReport.Trashed.Value;

			return sdkPackageCompletionReport;
		}

		// Convert from API to SDK DocumentsCompletionReport
		private Silanis.ESL.SDK.DocumentsCompletionReport ToSDKDocumentsCompletionReport(Silanis.ESL.API.DocumentsCompletionReport apiDocumentsCompletionReport)
        {
            var sdkDocumentCompletionReport = new Silanis.ESL.SDK.DocumentsCompletionReport(apiDocumentsCompletionReport.Name);
            sdkDocumentCompletionReport.Id = apiDocumentsCompletionReport.Id;
            if (apiDocumentsCompletionReport.Completed.HasValue)
            {
                sdkDocumentCompletionReport.Completed = apiDocumentsCompletionReport.Completed.Value;
            }

			if (apiDocumentsCompletionReport.FirstSigned.HasValue)
			{
				sdkDocumentCompletionReport.FirstSigned = apiDocumentsCompletionReport.FirstSigned;
			}

			if (apiDocumentsCompletionReport.LastSigned.HasValue)
			{
				sdkDocumentCompletionReport.LastSigned = apiDocumentsCompletionReport.LastSigned;
			}

			return sdkDocumentCompletionReport;
		}

		// Convert from API to SDK SignersCompletionReport
		private Silanis.ESL.SDK.SignersCompletionReport ToSDKSignersCompletionReport(Silanis.ESL.API.SignersCompletionReport apiSignersCompletionReport)
        {
            var sdkSignersCompletionReport = new Silanis.ESL.SDK.SignersCompletionReport(apiSignersCompletionReport.FirstName, apiSignersCompletionReport.LastName);
            sdkSignersCompletionReport.Email = apiSignersCompletionReport.Email;
            sdkSignersCompletionReport.Id = apiSignersCompletionReport.Id;
            
            if (apiSignersCompletionReport.Completed.HasValue)
            {
                sdkSignersCompletionReport.Completed = apiSignersCompletionReport.Completed.Value;
            }

			if (apiSignersCompletionReport.FirstSigned.HasValue)
			{
				sdkSignersCompletionReport.FirstSigned = apiSignersCompletionReport.FirstSigned;
			}

			if (apiSignersCompletionReport.LastSigned.HasValue)
			{
				sdkSignersCompletionReport.LastSigned = apiSignersCompletionReport.LastSigned;
			}

			return sdkSignersCompletionReport;
		}
    }
}

