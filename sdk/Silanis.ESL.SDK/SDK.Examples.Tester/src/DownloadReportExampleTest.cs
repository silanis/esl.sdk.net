using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                var completionReportForSender = example.sdkCompletionReportForSenderDraft;
                var senderCompletionReportForSenderId1 = getSenderCompletionReportForSenderId(example.sdkCompletionReportForSenderDraft.Senders, example.senderUID);

                Assert.AreEqual(completionReportForSender.Senders.Count, 1, "There should be only 1 sender.");
                Assert.IsTrue(senderCompletionReportForSenderId1.Packages.Count >= 1, "Number of package completion reports should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId1.Packages[0].Documents.Count >= 1, "Number of document completion reports should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId1.Packages[0].Signers.Count >= 1, "Number of signer completion reports should be greater than 1.");

                AssertCreatedPackageIncludedInCompletionReport(completionReportForSender, example.senderUID, example.PackageId, "DRAFT");

                Assert.IsNotNull(example.csvCompletionReportForSenderDraft);
                Assert.IsTrue(example.csvCompletionReportForSenderDraft.Any());

                var reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvCompletionReportForSenderDraft))));
                var rows = reader.readAll();

                if (senderCompletionReportForSenderId1.Packages.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= senderCompletionReportForSenderId1.Packages.Count - 1);
                    Assert.IsTrue(rows.Count <= senderCompletionReportForSenderId1.Packages.Count + 3);
                }

                AssertCreatedPackageIncludedInCsv(rows, example.PackageId, "DRAFT");
                var senderCompletionReportForSenderId3 = getSenderCompletionReportForSenderId(example.sdkCompletionReportForSenderSent.Senders, example.senderUID);
                completionReportForSender = example.sdkCompletionReportForSenderSent;

                Assert.AreEqual(completionReportForSender.Senders.Count, 1, "There should be only 1 sender.");
                Assert.IsTrue(senderCompletionReportForSenderId3.Packages.Count >= 1, "Number of package completion reports should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId3.Packages[0].Documents.Count >= 1, "Number of document completion reports should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId3.Packages[0].Signers.Count >= 1, "Number of signer completion reports should be greater than 1.");

                AssertCreatedPackageIncludedInCompletionReport(completionReportForSender, example.senderUID, example.package2Id, "SENT");

                Assert.IsNotNull(example.csvCompletionReportForSenderSent);
                Assert.IsTrue(example.csvCompletionReportForSenderSent.Any());

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvCompletionReportForSenderSent))));
                rows = reader.readAll();

                if (senderCompletionReportForSenderId3.Packages.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= senderCompletionReportForSenderId3.Packages.Count - 1);
                    Assert.IsTrue(rows.Count <= senderCompletionReportForSenderId3.Packages.Count + 3);
                }

                AssertCreatedPackageIncludedInCsv(rows, example.package2Id, "SENT");

                // Assert correct download of completion report for all senders
                var completionReport = example.sdkCompletionReportDraft;
                var senderCompletionReportForSenderId2 = getSenderCompletionReportForSenderId(completionReport.Senders, example.senderUID);

                Assert.IsTrue(completionReport.Senders.Count >= 1, "Number of sender should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId2.Packages.Count >= 0, "Number of package completion reports should be greater than 0.");

                AssertCreatedPackageIncludedInCompletionReport(completionReport, example.senderUID, example.PackageId, "DRAFT");

                Assert.IsNotNull(example.csvCompletionReportDraft);
                Assert.IsTrue(example.csvCompletionReportDraft.Any());

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvCompletionReportDraft))));
                rows = reader.readAll();

                if (senderCompletionReportForSenderId2.Packages.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= GetCompletionReportCount(completionReport) - 1);
                    Assert.IsTrue(rows.Count <= GetCompletionReportCount(completionReport) + 3);
                }

                AssertCreatedPackageIncludedInCsv(rows, example.PackageId, "DRAFT");

                completionReport = example.sdkCompletionReportSent;
                Assert.IsTrue(completionReport.Senders.Count >= 1, "Number of sender should be greater than 1.");
                Assert.IsTrue(senderCompletionReportForSenderId2.Packages.Count >= 0, "Number of package completion reports should be greater than 0.");

                AssertCreatedPackageIncludedInCompletionReport(completionReport, example.senderUID, example.package2Id, "SENT");

                Assert.IsNotNull(example.csvCompletionReportSent);
                Assert.IsTrue(example.csvCompletionReportSent.Any());

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvCompletionReportSent))));
                rows = reader.readAll();

                if (senderCompletionReportForSenderId2.Packages.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= GetCompletionReportCount(completionReport) - 1);
                    Assert.IsTrue(rows.Count <= GetCompletionReportCount(completionReport) + 3);
                }

                AssertCreatedPackageIncludedInCsv(rows, example.package2Id, "SENT");

                // Assert correct download of usage report
                var usageReport = example.sdkUsageReport;
                var senderUsageReportForSenderId = GetSenderUsageReportForSenderId(usageReport.SenderUsageReports, example.senderUID);

                Assert.IsTrue(usageReport.SenderUsageReports.Count > 0, "There should be only 1 sender.");
                Assert.IsTrue(senderUsageReportForSenderId.CountByUsageReportCategory.Count >= 1, "Number of map entries should be greater or equal to 1.");
                Assert.IsTrue(senderUsageReportForSenderId.CountByUsageReportCategory.ContainsKey(UsageReportCategory.DRAFT), "There should be at a draft key in packages map.");
                Assert.IsTrue(senderUsageReportForSenderId.CountByUsageReportCategory[UsageReportCategory.DRAFT] >= 1, "Number of drafts should be greater or equal to 1.");

                Assert.IsNotNull(example.csvUsageReport, "Usage report in csv cannot be null.");
                Assert.IsTrue(example.csvUsageReport.Any(), "Usage report in csv cannot be empty.");

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvUsageReport))));
                rows = reader.readAll();

                if (usageReport.SenderUsageReports.Count > 0)
                {
                    Assert.IsTrue(rows.Count >= usageReport.SenderUsageReports.Count - 1);
                    Assert.IsTrue(rows.Count <= usageReport.SenderUsageReports.Count + 3);
                }

                // Assert correct download of delegation report
                var delegationReportForAccountWithoutDate = example.sdkDelegationReportForAccountWithoutDate;
                Assert.IsTrue(delegationReportForAccountWithoutDate.DelegationEvents.Count >= 0, "Number of DelegationEventReports should be greater than 0.");

                Assert.IsNotNull(example.csvDelegationReportForAccountWithoutDate, "Delegation report in csv cannot be null.");
                Assert.IsTrue(example.csvDelegationReportForAccountWithoutDate.Any(), "Delegation report in csv cannot be empty.");

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvDelegationReportForAccountWithoutDate))));
                rows = reader.readAll();

                if (delegationReportForAccountWithoutDate.DelegationEvents.Count > 0)
                {
                    rows = GetRowsBySender(rows, example.senderUID);
                    Assert.AreEqual(delegationReportForAccountWithoutDate.DelegationEvents[example.senderUID].Count, rows.Count);
                }

                var delegationReportForAccount = example.sdkDelegationReportForAccount;
                Assert.IsTrue(delegationReportForAccount.DelegationEvents.Count >= 0, "Number of DelegationEventReports should be greater than 0.");

                Assert.IsNotNull(example.csvDelegationReportForAccount, "Delegation report in csv cannot be null.");
                Assert.IsTrue(example.csvDelegationReportForAccount.Any(), "Delegation report in csv cannot be empty.");

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvDelegationReportForAccount))));
                rows = reader.readAll();

                if (delegationReportForAccount.DelegationEvents.Count > 0)
                {
                    rows = GetRowsBySender(rows, example.senderUID);
                    Assert.AreEqual(delegationReportForAccount.DelegationEvents[example.senderUID].Count, rows.Count);
                }

                var delegationReportForSender = example.sdkDelegationReportForSender;
                Assert.IsTrue(delegationReportForSender.DelegationEvents.Count >= 0, "Number of DelegationEventReports should be greater than 0.");

                Assert.IsNotNull(example.csvDelegationReportForSender, "Delegation report in csv cannot be null.");
                Assert.IsTrue(example.csvDelegationReportForSender.Any(), "Delegation report in csv cannot be empty.");

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvDelegationReportForSender))));
                rows = reader.readAll();

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
