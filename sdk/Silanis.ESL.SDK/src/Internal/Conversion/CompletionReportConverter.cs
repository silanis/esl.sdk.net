namespace Silanis.ESL.SDK
{
	/// <summary>
	/// Converter for API CompletionReport to SDK CompletionReport. Contains conversions for all the
	/// sub-completion reports (ex: SenderCompletionReport, PackageCompletionReport, DocumentCompletionReport,
	/// SignerCompletionReport).
	/// </summary>
	internal class CompletionReportConverter
    {
		private CompletionReport sdkCompletionReport = null;
		private API.CompletionReport apiCompletionReport = null;

		public CompletionReportConverter(API.CompletionReport apiCompletionReport)
        {
			this.apiCompletionReport = apiCompletionReport;
        }

		/// <summary>
		/// Convert from API CompletionReport to SDK CompletionReport.
		/// </summary>
		/// <returns>The SDK completion report.</returns>
		public CompletionReport ToSDKCompletionReport()
		{
			if (apiCompletionReport == null)
			{
				return sdkCompletionReport;
			}

			var senderCompletionReportList = apiCompletionReport.Senders;

			if (senderCompletionReportList.Count != 0)
			{
				var result = new CompletionReport();
				result.From = apiCompletionReport.From;
				result.To = apiCompletionReport.To;

				var sdkSenderCompletionReport = new SenderCompletionReport();
				foreach (var apiSenderCompletionReport in senderCompletionReportList)
				{
					sdkSenderCompletionReport = ToSDKSenderCompletionReport(apiSenderCompletionReport);

					var packageCompletionReportList = apiSenderCompletionReport.Packages;
					PackageCompletionReport sdkPackageCompletionReport;
					foreach (var apiPackageCompletionReport in packageCompletionReportList)
					{
						sdkPackageCompletionReport = ToSDKPackageCompletionReport(apiPackageCompletionReport);

						var documentCompletionReportList = apiPackageCompletionReport.Documents;
						DocumentsCompletionReport sdkDocumentsCompletionReport;
						foreach (var apiDocumentsCompletionReport in documentCompletionReportList)
						{
							sdkDocumentsCompletionReport = ToSDKDocumentsCompletionReport(apiDocumentsCompletionReport);
							sdkPackageCompletionReport.AddDocument(sdkDocumentsCompletionReport);
						}

						var signersCompletionReportList = apiPackageCompletionReport.Signers;
						SignersCompletionReport sdkSignersCompletionReport;
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
		private SenderCompletionReport ToSDKSenderCompletionReport(API.SenderCompletionReport apiSenderCompletionReport)
		{
			var sdkSenderCompletionReport = new SenderCompletionReport();
			sdkSenderCompletionReport.Sender = new SenderConverter(apiSenderCompletionReport.Sender).ToSDKSender();

			return sdkSenderCompletionReport;
		}

		// Convert from API to SDK PackageCompletionReport
		private PackageCompletionReport ToSDKPackageCompletionReport(API.PackageCompletionReport apiPackageCompletionReport)
		{
			var sdkPackageCompletionReport = new PackageCompletionReport(apiPackageCompletionReport.Name);
			sdkPackageCompletionReport.Id = apiPackageCompletionReport.Id;
            
			sdkPackageCompletionReport.Created = apiPackageCompletionReport.Created;
			sdkPackageCompletionReport.DocumentPackageStatus = new PackageStatusConverter(apiPackageCompletionReport.Status).ToSDKPackageStatus();
		    sdkPackageCompletionReport.Trashed = apiPackageCompletionReport.Trashed.Value;

			return sdkPackageCompletionReport;
		}

		// Convert from API to SDK DocumentsCompletionReport
		private DocumentsCompletionReport ToSDKDocumentsCompletionReport(API.DocumentsCompletionReport apiDocumentsCompletionReport)
        {
            var sdkDocumentCompletionReport = new DocumentsCompletionReport(apiDocumentsCompletionReport.Name);
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
		private SignersCompletionReport ToSDKSignersCompletionReport(API.SignersCompletionReport apiSignersCompletionReport)
        {
            var sdkSignersCompletionReport = new SignersCompletionReport(apiSignersCompletionReport.FirstName, apiSignersCompletionReport.LastName);
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

