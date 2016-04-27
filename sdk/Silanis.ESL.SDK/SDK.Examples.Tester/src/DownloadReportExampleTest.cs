using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Examples.Internal;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDK.Examples
{
	[TestClass]
    public class DownloadReportExampleTest
    {
        private readonly Object _lockThis = new Object();

		[TestMethod]
		public void VerifyResult()
		{
            lock (_lockThis)
            {
                var example = new DownloadReportExample();
                example.Run();

                // Assert correct download of completion report for a sender
                var completionReportForSender = example.SdkCompletionReportForSenderDraft;
                var senderCompletionReportForSenderId1 = getSenderCompletionReportForSenderId(example.SdkCompletionReportForSenderDraft.Senders, example.senderUID);

                Assert.AreEqual(completionReportForSender.Senders.Count, 1, "There should be only 1 sender.");
                Assert.IsTrue(senderCompletionReportForSenderId1.Packages.Count >= 1, "Number of package completion reports should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId1.Packages[0].Documents.Count >= 1, "Number of document completion reports should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId1.Packages[0].Signers.Count >= 1, "Number of signer completion reports should be greater than 1.");

                AssertCreatedPackageIncludedInCompletionReport(completionReportForSender, example.senderUID, example.PackageId, "DRAFT");

                Assert.IsNotNull(example.CsvCompletionReportForSenderDraft);
                Assert.IsTrue(example.CsvCompletionReportForSenderDraft.Any());

                var reader = new CsvReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.CsvCompletionReportForSenderDraft))));
                var rows = reader.ReadAll();

                if (senderCompletionReportForSenderId1.Packages.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= senderCompletionReportForSenderId1.Packages.Count - 1);
                    Assert.IsTrue(rows.Count <= senderCompletionReportForSenderId1.Packages.Count + 3);
                }

                AssertCreatedPackageIncludedInCsv(rows, example.PackageId, "DRAFT");
                var senderCompletionReportForSenderId3 = getSenderCompletionReportForSenderId(example.SdkCompletionReportForSenderSent.Senders, example.senderUID);
                completionReportForSender = example.SdkCompletionReportForSenderSent;

                Assert.AreEqual(completionReportForSender.Senders.Count, 1, "There should be only 1 sender.");
                Assert.IsTrue(senderCompletionReportForSenderId3.Packages.Count >= 1, "Number of package completion reports should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId3.Packages[0].Documents.Count >= 1, "Number of document completion reports should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId3.Packages[0].Signers.Count >= 1, "Number of signer completion reports should be greater than 1.");

                AssertCreatedPackageIncludedInCompletionReport(completionReportForSender, example.senderUID, example.Package2Id, "SENT");

                Assert.IsNotNull(example.CsvCompletionReportForSenderSent);
                Assert.IsTrue(example.CsvCompletionReportForSenderSent.Any());

                reader = new CsvReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.CsvCompletionReportForSenderSent))));
                rows = reader.ReadAll();

                if (senderCompletionReportForSenderId3.Packages.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= senderCompletionReportForSenderId3.Packages.Count - 1);
                    Assert.IsTrue(rows.Count <= senderCompletionReportForSenderId3.Packages.Count + 3);
                }

                AssertCreatedPackageIncludedInCsv(rows, example.Package2Id, "SENT");

                // Assert correct download of completion report for all senders
                var completionReport = example.SdkCompletionReportDraft;
                var senderCompletionReportForSenderId2 = getSenderCompletionReportForSenderId(completionReport.Senders, example.senderUID);

                Assert.IsTrue(completionReport.Senders.Count >= 1, "Number of sender should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId2.Packages.Count >= 0, "Number of package completion reports should be greater than 0.");

                AssertCreatedPackageIncludedInCompletionReport(completionReport, example.senderUID, example.PackageId, "DRAFT");

                Assert.IsNotNull(example.CsvCompletionReportDraft);
                Assert.IsTrue(example.CsvCompletionReportDraft.Any());

                reader = new CsvReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.CsvCompletionReportDraft))));
                rows = reader.ReadAll();

                if (senderCompletionReportForSenderId2.Packages.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= GetCompletionReportCount(completionReport) - 1);
                    Assert.IsTrue(rows.Count <= GetCompletionReportCount(completionReport) + 3);
                }

                AssertCreatedPackageIncludedInCsv(rows, example.PackageId, "DRAFT");

                completionReport = example.SdkCompletionReportSent;
                Assert.IsTrue(completionReport.Senders.Count >= 1, "Number of sender should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId2.Packages.Count >= 0, "Number of package completion reports should be greater than 0.");

                AssertCreatedPackageIncludedInCompletionReport(completionReport, example.senderUID, example.Package2Id, "SENT");

                Assert.IsNotNull(example.CsvCompletionReportSent);
                Assert.IsTrue(example.CsvCompletionReportSent.Any());

                reader = new CsvReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.CsvCompletionReportSent))));
                rows = reader.ReadAll();

                if (senderCompletionReportForSenderId2.Packages.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= GetCompletionReportCount(completionReport) - 1);
                    Assert.IsTrue(rows.Count <= GetCompletionReportCount(completionReport) + 3);
                }

                AssertCreatedPackageIncludedInCsv(rows, example.Package2Id, "SENT");

                // Assert correct download of usage report
                var usageReport = example.SdkUsageReport;
                var senderUsageReportForSenderId = GetSenderUsageReportForSenderId(usageReport.SenderUsageReports, example.senderUID);

                Assert.IsTrue(usageReport.SenderUsageReports.Count > 0, "There should be only 1 sender.");
                Assert.IsTrue(senderUsageReportForSenderId.CountByUsageReportCategory.Count >= 1, "Number of map entries should be greater or equal to 1.");
                Assert.IsTrue(senderUsageReportForSenderId.CountByUsageReportCategory.ContainsKey(UsageReportCategory.DRAFT), "There should be at a draft key in packages map.");
                Assert.IsTrue(senderUsageReportForSenderId.CountByUsageReportCategory[UsageReportCategory.DRAFT] >= 1, "Number of drafts should be greater or equal to 1.");

                Assert.IsNotNull(example.CsvUsageReport, "Usage report in csv cannot be null.");
                Assert.IsTrue(example.CsvUsageReport.Any(), "Usage report in csv cannot be empty.");

                reader = new CsvReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.CsvUsageReport))));
                rows = reader.ReadAll();

                if (usageReport.SenderUsageReports.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= usageReport.SenderUsageReports.Count - 1);
                    Assert.IsTrue(rows.Count <= usageReport.SenderUsageReports.Count + 3);
                }

                // Assert correct download of delegation report
                var delegationReportForAccountWithoutDate = example.SdkDelegationReportForAccountWithoutDate;
                Assert.IsTrue(delegationReportForAccountWithoutDate.DelegationEvents.Count >= 0, "Number of DelegationEventReports should be greater than 0.");

                Assert.IsNotNull(example.CsvDelegationReportForAccountWithoutDate, "Delegation report in csv cannot be null.");
                Assert.IsTrue(example.CsvDelegationReportForAccountWithoutDate.Any(), "Delegation report in csv cannot be empty.");

                reader = new CsvReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.CsvDelegationReportForAccountWithoutDate))));
                rows = reader.ReadAll();

                if (delegationReportForAccountWithoutDate.DelegationEvents.Count > 0)
                {
                    rows = GetRowsBySender(rows, example.senderUID);
                    Assert.AreEqual(delegationReportForAccountWithoutDate.DelegationEvents[example.senderUID].Count, rows.Count);
                }

                var delegationReportForAccount = example.SdkDelegationReportForAccount;
                Assert.IsTrue(delegationReportForAccount.DelegationEvents.Count >= 0, "Number of DelegationEventReports should be greater than 0.");

                Assert.IsNotNull(example.CsvDelegationReportForAccount, "Delegation report in csv cannot be null.");
                Assert.IsTrue(example.CsvDelegationReportForAccount.Any(), "Delegation report in csv cannot be empty.");

                reader = new CsvReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.CsvDelegationReportForAccount))));
                rows = reader.ReadAll();

                if (delegationReportForAccount.DelegationEvents.Count > 0)
                {
                    rows = GetRowsBySender(rows, example.senderUID);
                    Assert.AreEqual(delegationReportForAccount.DelegationEvents[example.senderUID].Count, rows.Count);
                }

                var delegationReportForSender = example.SdkDelegationReportForSender;
                Assert.IsTrue(delegationReportForSender.DelegationEvents.Count >= 0, "Number of DelegationEventReports should be greater than 0.");

                Assert.IsNotNull(example.CsvDelegationReportForSender, "Delegation report in csv cannot be null.");
                Assert.IsTrue(example.CsvDelegationReportForSender.Any(), "Delegation report in csv cannot be empty.");

                reader = new CsvReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.CsvDelegationReportForSender))));
                rows = reader.ReadAll();

                if (delegationReportForSender.DelegationEvents.Count > 0)
                {
                    rows = GetRowsBySender(rows, example.senderUID);
                    Assert.AreEqual(delegationReportForSender.DelegationEvents[example.senderUID].Count, rows.Count);
                }
            }
		}

        private SenderCompletionReport getSenderCompletionReportForSenderId(IList<SenderCompletionReport> senderCompletionReports, String senderId) 
        {
            foreach (var senderCompletionReport in senderCompletionReports) 
            {
                if (String.Equals(senderId, senderCompletionReport.Sender.Id)) 
                {
                    return senderCompletionReport;
                }
            }
            throw new AssertFailedException("Could not find SenderCompletionReport for SenderId " + senderId);
        }

        private static SenderUsageReport GetSenderUsageReportForSenderId(IEnumerable<SenderUsageReport> senderUsageReports, String senderId)
            {
            foreach (var senderUsageReport in senderUsageReports.Where(senderUsageReport => String.Equals(senderId, senderUsageReport.Sender.Id)))
                {
                    return senderUsageReport;
                }
            throw new AssertFailedException("Could not find SenderUsageReport for SenderId " + senderId);
        }

	    private static int GetCompletionReportCount(CompletionReport completionReport) {
            var count = 0;
            foreach(var senderCompletionReport in completionReport.Senders) {
                count += senderCompletionReport.Packages.Count;
            }
            return count;
        }

        private void AssertCreatedPackageIncludedInCompletionReport(CompletionReport completionReport, string sender, PackageId packageId, string packageStatus) {
            var createdPackageCompletionReport = GetCreatedPackageCompletionReport(completionReport, sender, packageId);

            Assert.IsNotNull(createdPackageCompletionReport);
            Assert.IsNotNull(createdPackageCompletionReport.DocumentPackageStatus);
            Assert.AreEqual(packageStatus, createdPackageCompletionReport.DocumentPackageStatus.GetName());
        }

        private void AssertCreatedPackageIncludedInCsv(IList<string[]> rows, PackageId packageId, string packageStatus) {
            var createdPackageRow = GetCreatedPackageCSVRow(rows, packageId);
            Assert.IsNotNull(createdPackageRow);
            Assert.IsTrue(HasItems(createdPackageRow, packageId.Id, packageStatus));
        }

        private bool HasItems(string[] row, string packageId, string packageStatus) {
            var hasPackageId = false;
            var hasPackageStatus = false;

            foreach(var data in row) {
                if(data.Equals(packageId)) {
                    hasPackageId = true;
                }
                if(data.Equals(packageStatus)) {
                    hasPackageStatus = true;
                }
            }
            return (hasPackageId && hasPackageStatus);
        }

        private PackageCompletionReport GetCreatedPackageCompletionReport(CompletionReport completionReport, string sender, PackageId packageId) {
            var senderCompletionReport = GetSenderCompletionReport(completionReport, sender);

            var packageCompletionReports = senderCompletionReport.Packages;
            foreach(var packageCompletionReport in packageCompletionReports) {
                if(packageCompletionReport.Id.Equals(packageId.Id)) {
                    return packageCompletionReport;
                }
            }
            return null;
        }

        private SenderCompletionReport GetSenderCompletionReport(CompletionReport completionReport, string sender) {
            foreach(var senderCompletionReport in completionReport.Senders) {
                if(senderCompletionReport.Sender.Id.Equals(sender)) {
                    return senderCompletionReport;
                }
            }
            return null;
        }

        private string[] GetCreatedPackageCSVRow(IList<string[]> rows, PackageId packageId) {
            foreach(var row in rows) {
                foreach(var word in row) {
                    if(word.Contains(packageId.Id)) {
                        return row;
                    }
                }
            }
            return null;
        }

        private IList<string[]> GetRowsBySender(IList<string[]> rows, string sender) {
            IList<string[]> result = new List<string[]>();
            foreach(var row in rows) {
                foreach(var word in row) {
                    if(word.Contains(sender)) {
                        result.Add(row);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
