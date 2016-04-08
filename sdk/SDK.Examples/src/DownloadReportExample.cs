using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK.Internal;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class DownloadReportExample : SDKSample
	{
        public PackageId package2Id;
        public Silanis.ESL.SDK.CompletionReport sdkCompletionReportForSenderDraft, sdkCompletionReportForSenderSent, sdkCompletionReportDraft, sdkCompletionReportSent;
        public Silanis.ESL.SDK.UsageReport sdkUsageReport;
        public Silanis.ESL.SDK.DelegationReport sdkDelegationReportForAccountWithoutDate;
        public Silanis.ESL.SDK.DelegationReport sdkDelegationReportForAccount;
        public Silanis.ESL.SDK.DelegationReport sdkDelegationReportForSender;

        public string csvCompletionReportForSenderDraft, csvCompletionReportForSenderSent, csvCompletionReportDraft, csvCompletionReportSent;
        public string csvUsageReport;
        public string csvDelegationReportForAccountWithoutDate;
        public string csvDelegationReportForAccount;
        public string csvDelegationReportForSender;


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

            package2Id = eslClient.CreateAndSendPackage(superDuperPackage2);

			// Date and time range to get completion report.

            var from = DateTime.Now.AddMinutes(-5);
            var to = DateTime.Now.AddMinutes(5);

            // Download the completion report for a sender
            sdkCompletionReportForSenderDraft = eslClient.ReportService.DownloadCompletionReport(DocumentPackageStatus.DRAFT, senderUID, from, to);
            csvCompletionReportForSenderDraft = eslClient.ReportService.DownloadCompletionReportAsCSV(DocumentPackageStatus.DRAFT, senderUID, from, to);

            sdkCompletionReportForSenderSent = eslClient.ReportService.DownloadCompletionReport(DocumentPackageStatus.SENT, senderUID, from, to);
            csvCompletionReportForSenderSent = eslClient.ReportService.DownloadCompletionReportAsCSV(DocumentPackageStatus.SENT, senderUID, from, to);

            // Download the completion report for all senders
            sdkCompletionReportDraft = eslClient.ReportService.DownloadCompletionReport(DocumentPackageStatus.DRAFT, from, to);
            csvCompletionReportDraft = eslClient.ReportService.DownloadCompletionReportAsCSV(DocumentPackageStatus.DRAFT, from, to);

            sdkCompletionReportSent = eslClient.ReportService.DownloadCompletionReport(DocumentPackageStatus.SENT, from, to);
            csvCompletionReportSent = eslClient.ReportService.DownloadCompletionReportAsCSV(DocumentPackageStatus.SENT, from, to);

            // Download the usage report
            sdkUsageReport = eslClient.ReportService.DownloadUsageReport(from, to);
            csvUsageReport = eslClient.ReportService.DownloadUsageReportAsCSV(from, to);

            // Download the delegation report for a sender
            sdkDelegationReportForAccountWithoutDate = eslClient.ReportService.DownloadDelegationReport();
            csvDelegationReportForAccountWithoutDate = eslClient.ReportService.DownloadDelegationReportAsCSV();

            sdkDelegationReportForAccount = eslClient.ReportService.DownloadDelegationReport(from, to);
            csvDelegationReportForAccount = eslClient.ReportService.DownloadDelegationReportAsCSV(from, to);

            sdkDelegationReportForSender = eslClient.ReportService.DownloadDelegationReport(senderUID, from, to);
            csvDelegationReportForSender = eslClient.ReportService.DownloadDelegationReportAsCSV(senderUID, from, to);
		}
    }
}

