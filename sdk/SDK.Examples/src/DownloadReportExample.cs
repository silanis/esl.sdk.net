using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DownloadReportExample : SdkSample
	{
        public PackageId Package2Id;
        public CompletionReport SdkCompletionReportForSenderDraft, SdkCompletionReportForSenderSent, SdkCompletionReportDraft, SdkCompletionReportSent;
        public UsageReport SdkUsageReport;
        public DelegationReport SdkDelegationReportForAccountWithoutDate;
        public DelegationReport SdkDelegationReportForAccount;
        public DelegationReport SdkDelegationReportForSender;

        public string CsvCompletionReportForSenderDraft, CsvCompletionReportForSenderSent, CsvCompletionReportDraft, CsvCompletionReportSent;
        public string CsvUsageReport;
        public string CsvDelegationReportForAccountWithoutDate;
        public string CsvDelegationReportForAccount;
        public string CsvDelegationReportForSender;


		public static void Main(string[] args)
		{
            new DownloadReportExample().Run();
		}

		override public void Execute()
		{
			var superDuperPackage =
                PackageBuilder.NewPackageNamed(PackageName)
					.DescribedAs("This is a package created using the e-SignLive SDK")
					.ExpiresOn(DateTime.Now.AddMonths(100))
					.WithEmailMessage("This message should be delivered to all signers")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
						.WithCustomId("Client1")
						.WithFirstName("John")
						.WithLastName("Smith")
						.WithTitle("Managing Director")
						.WithCompany("Acme Inc.")
					)
					.WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
						.FromStream(fileStream1, DocumentType.PDF)
						.WithSignature(SignatureBuilder.SignatureFor(email1)
							.OnPage(0)
							.WithField(FieldBuilder.CheckBox()
								.OnPage(0)
								.AtPosition(400, 200)
								.WithValue(FieldBuilder.CHECKBOX_CHECKED)
							)
							.AtPosition(100, 100)
						)
					)
					.Build();

			packageId = eslClient.CreatePackage(superDuperPackage);

            var superDuperPackage2 =
                PackageBuilder.NewPackageNamed("DownloadReportForSent: " + DateTime.Now)
                    .DescribedAs("This is a package created using the e-SignLive SDK")
                    .ExpiresOn(DateTime.Now.AddMonths(100))
                    .WithEmailMessage("This message should be delivered to all signers")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithCustomId("Client1")
                                .WithFirstName("John")
                                .WithLastName("Smith")
                                .WithTitle("Managing Director")
                                .WithCompany("Acme Inc.")
                                )
                    .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                                  .FromStream(fileStream2, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .WithField(FieldBuilder.CheckBox()
                               .OnPage(0)
                               .AtPosition(400, 200)
                               .WithValue(FieldBuilder.CHECKBOX_CHECKED)
                               )
                                   .AtPosition(100, 100)
                                   )
                                  )
                    .Build();

            Package2Id = eslClient.CreateAndSendPackage(superDuperPackage2);

			// Date and time range to get completion report.

            var from = DateTime.Now.AddMinutes(-5);
            var to = DateTime.Now.AddMinutes(5);

            // Download the completion report for a sender
            SdkCompletionReportForSenderDraft = eslClient.ReportService.DownloadCompletionReport(DocumentPackageStatus.DRAFT, senderUID, from, to);
            CsvCompletionReportForSenderDraft = eslClient.ReportService.DownloadCompletionReportAsCSV(DocumentPackageStatus.DRAFT, senderUID, from, to);

            SdkCompletionReportForSenderSent = eslClient.ReportService.DownloadCompletionReport(DocumentPackageStatus.SENT, senderUID, from, to);
            CsvCompletionReportForSenderSent = eslClient.ReportService.DownloadCompletionReportAsCSV(DocumentPackageStatus.SENT, senderUID, from, to);

            // Download the completion report for all senders
            SdkCompletionReportDraft = eslClient.ReportService.DownloadCompletionReport(DocumentPackageStatus.DRAFT, from, to);
            CsvCompletionReportDraft = eslClient.ReportService.DownloadCompletionReportAsCSV(DocumentPackageStatus.DRAFT, from, to);

            SdkCompletionReportSent = eslClient.ReportService.DownloadCompletionReport(DocumentPackageStatus.SENT, from, to);
            CsvCompletionReportSent = eslClient.ReportService.DownloadCompletionReportAsCSV(DocumentPackageStatus.SENT, from, to);

            // Download the usage report
            SdkUsageReport = eslClient.ReportService.DownloadUsageReport(from, to);
            CsvUsageReport = eslClient.ReportService.DownloadUsageReportAsCSV(from, to);

            // Download the delegation report for a sender
            SdkDelegationReportForAccountWithoutDate = eslClient.ReportService.DownloadDelegationReport();
            CsvDelegationReportForAccountWithoutDate = eslClient.ReportService.DownloadDelegationReportAsCSV();

            SdkDelegationReportForAccount = eslClient.ReportService.DownloadDelegationReport(from, to);
            CsvDelegationReportForAccount = eslClient.ReportService.DownloadDelegationReportAsCSV(from, to);

            SdkDelegationReportForSender = eslClient.ReportService.DownloadDelegationReport(senderUID, from, to);
            CsvDelegationReportForSender = eslClient.ReportService.DownloadDelegationReportAsCSV(senderUID, from, to);
		}
    }
}

