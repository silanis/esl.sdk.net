using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SDK.Examples
{
	[TestFixture()]
    public class DownloadReportExampleTest
    {
        private System.Object lockThis = new System.Object();

		[Test()]
		public void VerifyResult()
		{
            lock (lockThis)
            {
                DownloadReportExample example = new DownloadReportExample();
                example.Run();

                // Assert correct download of completion report for a sender
                CompletionReport completionReportForSender = example.sdkCompletionReportForSenderDraft;
                SenderCompletionReport senderCompletionReportForSenderId1 = getSenderCompletionReportForSenderId(example.sdkCompletionReportForSenderDraft.Senders, example.senderUID);

                Assert.AreEqual(completionReportForSender.Senders.Count, 1, "There should be only 1 sender.");
                Assert.GreaterOrEqual(senderCompletionReportForSenderId1.Packages.Count, 1, "Number of package completion reports should be greater than 1.");
                Assert.GreaterOrEqual(senderCompletionReportForSenderId1.Packages[0].Documents.Count, 1, "Number of document completion reports should be greater than 1.");
                Assert.GreaterOrEqual(senderCompletionReportForSenderId1.Packages[0].Signers.Count, 1, "Number of signer completion reports should be greater than 1.");

                AssertCreatedPackageIncludedInCompletionReport(completionReportForSender, example.senderUID, example.PackageId, "DRAFT");

                Assert.IsNotNull(example.csvCompletionReportForSenderDraft);
                Assert.IsNotEmpty(example.csvCompletionReportForSenderDraft);

                CSVReader reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvCompletionReportForSenderDraft))));
                IList<string[]> rows = reader.readAll();

                if (senderCompletionReportForSenderId1.Packages.Count > 0)
                {
                    Assert.GreaterOrEqual(rows.Count, senderCompletionReportForSenderId1.Packages.Count - 1);
                    Assert.LessOrEqual(rows.Count, senderCompletionReportForSenderId1.Packages.Count + 3);
                }

                AssertCreatedPackageIncludedInCSV(rows, example.PackageId, "DRAFT");
                SenderCompletionReport senderCompletionReportForSenderId3 = getSenderCompletionReportForSenderId(example.sdkCompletionReportForSenderSent.Senders, example.senderUID);
                completionReportForSender = example.sdkCompletionReportForSenderSent;

                Assert.AreEqual(completionReportForSender.Senders.Count, 1, "There should be only 1 sender.");
                Assert.GreaterOrEqual(senderCompletionReportForSenderId3.Packages.Count, 1, "Number of package completion reports should be greater than 1.");
                Assert.GreaterOrEqual(senderCompletionReportForSenderId3.Packages[0].Documents.Count, 1, "Number of document completion reports should be greater than 1.");
                Assert.GreaterOrEqual(senderCompletionReportForSenderId3.Packages[0].Signers.Count, 1, "Number of signer completion reports should be greater than 1.");

                AssertCreatedPackageIncludedInCompletionReport(completionReportForSender, example.senderUID, example.package2Id, "SENT");

                Assert.IsNotNull(example.csvCompletionReportForSenderSent);
                Assert.IsNotEmpty(example.csvCompletionReportForSenderSent);

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvCompletionReportForSenderSent))));
                rows = reader.readAll();

                if (senderCompletionReportForSenderId3.Packages.Count > 0)
                {
                    Assert.GreaterOrEqual(rows.Count, senderCompletionReportForSenderId3.Packages.Count - 1);
                    Assert.LessOrEqual(rows.Count, senderCompletionReportForSenderId3.Packages.Count + 3);
                }

                AssertCreatedPackageIncludedInCSV(rows, example.package2Id, "SENT");

                // Assert correct download of completion report for all senders
                CompletionReport completionReport = example.sdkCompletionReportDraft;
                SenderCompletionReport senderCompletionReportForSenderId2 = getSenderCompletionReportForSenderId(completionReport.Senders, example.senderUID);

                Assert.GreaterOrEqual(completionReport.Senders.Count, 1, "Number of sender should be greater than 1.");
                Assert.GreaterOrEqual(senderCompletionReportForSenderId2.Packages.Count, 0, "Number of package completion reports should be greater than 0.");

                AssertCreatedPackageIncludedInCompletionReport(completionReport, example.senderUID, example.PackageId, "DRAFT");

                Assert.IsNotNull(example.csvCompletionReportDraft);
                Assert.IsNotEmpty(example.csvCompletionReportDraft);

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvCompletionReportDraft))));
                rows = reader.readAll();

                if (senderCompletionReportForSenderId2.Packages.Count > 0)
                {
                    Assert.GreaterOrEqual(rows.Count, GetCompletionReportCount(completionReport) - 1);
                    Assert.LessOrEqual(rows.Count, GetCompletionReportCount(completionReport) + 3);
                }

                AssertCreatedPackageIncludedInCSV(rows, example.PackageId, "DRAFT");

                completionReport = example.sdkCompletionReportSent;
                Assert.GreaterOrEqual(completionReport.Senders.Count, 1, "Number of sender should be greater than 1.");
                Assert.GreaterOrEqual(senderCompletionReportForSenderId2.Packages.Count, 0, "Number of package completion reports should be greater than 0.");

                AssertCreatedPackageIncludedInCompletionReport(completionReport, example.senderUID, example.package2Id, "SENT");

                Assert.IsNotNull(example.csvCompletionReportSent);
                Assert.IsNotEmpty(example.csvCompletionReportSent);

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvCompletionReportSent))));
                rows = reader.readAll();

                if (senderCompletionReportForSenderId2.Packages.Count > 0)
                {
                    Assert.GreaterOrEqual(rows.Count, GetCompletionReportCount(completionReport) - 1);
                    Assert.LessOrEqual(rows.Count, GetCompletionReportCount(completionReport) + 3);
                }

                AssertCreatedPackageIncludedInCSV(rows, example.package2Id, "SENT");

                // Assert correct download of usage report
                UsageReport usageReport = example.sdkUsageReport;
                SenderUsageReport senderUsageReportForSenderId = getSenderUsageReportForSenderId(usageReport.SenderUsageReports, example.senderUID);

                Assert.Greater(usageReport.SenderUsageReports.Count, 0, "There should be only 1 sender.");
                Assert.GreaterOrEqual(senderUsageReportForSenderId.CountByUsageReportCategory.Count, 1, "Number of map entries should be greater or equal to 1.");
                Assert.IsTrue(senderUsageReportForSenderId.CountByUsageReportCategory.ContainsKey(UsageReportCategory.DRAFT), "There should be at a draft key in packages map.");
                Assert.GreaterOrEqual(senderUsageReportForSenderId.CountByUsageReportCategory[UsageReportCategory.DRAFT], 1, "Number of drafts should be greater or equal to 1.");

                Assert.IsNotNull(example.csvUsageReport, "Usage report in csv cannot be null.");
                Assert.IsNotEmpty(example.csvUsageReport, "Usage report in csv cannot be empty.");

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvUsageReport))));
                rows = reader.readAll();

                if (usageReport.SenderUsageReports.Count > 0)
                {
                    Assert.GreaterOrEqual(rows.Count, usageReport.SenderUsageReports.Count - 1);
                    Assert.LessOrEqual(rows.Count, usageReport.SenderUsageReports.Count + 3);
                }

                // Assert correct download of delegation report
                DelegationReport delegationReportForAccountWithoutDate = example.sdkDelegationReportForAccountWithoutDate;
                Assert.GreaterOrEqual(delegationReportForAccountWithoutDate.DelegationEvents.Count, 0, "Number of DelegationEventReports should be greater than 0.");

                Assert.IsNotNull(example.csvDelegationReportForAccountWithoutDate, "Delegation report in csv cannot be null.");
                Assert.IsNotEmpty(example.csvDelegationReportForAccountWithoutDate, "Delegation report in csv cannot be empty.");

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvDelegationReportForAccountWithoutDate))));
                rows = reader.readAll();

                if (delegationReportForAccountWithoutDate.DelegationEvents.Count > 0)
                {
                    rows = GetRowsBySender(rows, example.senderUID);
                    Assert.AreEqual(delegationReportForAccountWithoutDate.DelegationEvents[example.senderUID].Count, rows.Count);
                }

                DelegationReport delegationReportForAccount = example.sdkDelegationReportForAccount;
                Assert.GreaterOrEqual(delegationReportForAccount.DelegationEvents.Count, 0, "Number of DelegationEventReports should be greater than 0.");

                Assert.IsNotNull(example.csvDelegationReportForAccount, "Delegation report in csv cannot be null.");
                Assert.IsNotEmpty(example.csvDelegationReportForAccount, "Delegation report in csv cannot be empty.");

                reader = new CSVReader(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(example.csvDelegationReportForAccount))));
                rows = reader.readAll();

                if (delegationReportForAccount.DelegationEvents.Count > 0)
                {
                    rows = GetRowsBySender(rows, example.senderUID);
                    Assert.AreEqual(delegationReportForAccount.DelegationEvents[example.senderUID].Count, rows.Count);
                }

                DelegationReport delegationReportForSender = example.sdkDelegationReportForSender;
                Assert.GreaterOrEqual(delegationReportForSender.DelegationEvents.Count, 0, "Number of DelegationEventReports should be greater than 0.");

                Assert.IsNotNull(example.csvDelegationReportForSender, "Delegation report in csv cannot be null.");
                Assert.IsNotEmpty(example.csvDelegationReportForSender, "Delegation report in csv cannot be empty.");

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
            foreach (SenderCompletionReport senderCompletionReport in senderCompletionReports) 
            {
                if (String.Equals(senderId, senderCompletionReport.Sender.Id)) 
                {
                    return senderCompletionReport;
                }
            }
            throw new AssertionException("Could not find SenderCompletionReport for SenderId " + senderId);
        }

        private SenderUsageReport getSenderUsageReportForSenderId(IList<SenderUsageReport> senderUsageReports, String senderId) 
        {
            foreach (SenderUsageReport senderUsageReport in senderUsageReports) 
            {
                if (String.Equals(senderId, senderUsageReport.Sender.Id)) 
                {
                    return senderUsageReport;
                }
            }
            throw new AssertionException("Could not find SenderUsageReport for SenderId " + senderId);
        }

        private int GetCompletionReportCount(CompletionReport completionReport) {
            int count = 0;
            foreach(SenderCompletionReport senderCompletionReport in completionReport.Senders) {
                count += senderCompletionReport.Packages.Count;
            }
            return count;
        }

        private void AssertCreatedPackageIncludedInCompletionReport(CompletionReport completionReport, string sender, PackageId packageId, string packageStatus) {
            PackageCompletionReport createdPackageCompletionReport = GetCreatedPackageCompletionReport(completionReport, sender, packageId);

            Assert.IsNotNull(createdPackageCompletionReport);
            Assert.IsNotNull(createdPackageCompletionReport.DocumentPackageStatus);
            Assert.AreEqual(packageStatus, createdPackageCompletionReport.DocumentPackageStatus.GetName());
        }

        private void AssertCreatedPackageIncludedInCSV(IList<string[]> rows, PackageId packageId, string packageStatus) {
            string[] createdPackageRow = GetCreatedPackageCSVRow(rows, packageId);
            Assert.IsNotNull(createdPackageRow);
            Assert.IsTrue(HasItems(createdPackageRow, packageId.Id, packageStatus));
        }

        private bool HasItems(string[] row, string packageId, string packageStatus) {
            bool hasPackageId = false;
            bool hasPackageStatus = false;

            foreach(string data in row) {
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
            SenderCompletionReport senderCompletionReport = GetSenderCompletionReport(completionReport, sender);

            IList<PackageCompletionReport> packageCompletionReports = senderCompletionReport.Packages;
            foreach(PackageCompletionReport packageCompletionReport in packageCompletionReports) {
                if(packageCompletionReport.Id.Equals(packageId.Id)) {
                    return packageCompletionReport;
                }
            }
            return null;
        }

        private SenderCompletionReport GetSenderCompletionReport(CompletionReport completionReport, string sender) {
            foreach(SenderCompletionReport senderCompletionReport in completionReport.Senders) {
                if(senderCompletionReport.Sender.Id.Equals(sender)) {
                    return senderCompletionReport;
                }
            }
            return null;
        }

        private string[] GetCreatedPackageCSVRow(IList<string[]> rows, PackageId packageId) {
            foreach(string[] row in rows) {
                foreach(string word in row) {
                    if(word.Contains(packageId.Id)) {
                        return row;
                    }
                }
            }
            return null;
        }

        private IList<string[]> GetRowsBySender(IList<string[]> rows, string sender) {
            IList<string[]> result = new List<string[]>();
            foreach(string[] row in rows) {
                foreach(string word in row) {
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
