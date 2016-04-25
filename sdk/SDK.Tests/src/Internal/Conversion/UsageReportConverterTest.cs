using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Tests
{
    [TestFixture()]
    public class UsageReportConverterTest
    {
        private Silanis.ESL.SDK.UsageReport sdkUsageReport1 = null;
        private Silanis.ESL.API.UsageReport apiUsageReport1 = null;
        private UsageReportConverter converter;

        [Test]
        public void ConvertNullAPIToSDK()
        {
            apiUsageReport1 = null;
            converter = new UsageReportConverter(apiUsageReport1);
            Assert.IsNull(converter.ToSDKUsageReport());
        }

        [Test]
        public void ConvertAPIToSDK()
        {
            apiUsageReport1 = CreateTypicalAPIUsageReport();
            sdkUsageReport1 = new UsageReportConverter(apiUsageReport1).ToSDKUsageReport();

            Assert.AreEqual(sdkUsageReport1.From, apiUsageReport1.From);
            Assert.AreEqual(sdkUsageReport1.To, apiUsageReport1.To);

            Silanis.ESL.API.Sender apiSender = apiUsageReport1.Senders[0].Sender;
            Silanis.ESL.SDK.Sender sdkSender = sdkUsageReport1.SenderUsageReports[0].Sender;
            Assert.AreEqual(sdkSender.Email, apiSender.Email);
            Assert.AreEqual(sdkSender.FirstName, apiSender.FirstName);
            Assert.AreEqual(sdkSender.LastName, apiSender.LastName);
        
            IDictionary<string, object> apiPackageDictionary = apiUsageReport1.Senders[0].Packages;
            IDictionary<UsageReportCategory, int> sdkPackageDictionary = sdkUsageReport1.SenderUsageReports[0].CountByUsageReportCategory;
            Assert.AreEqual(sdkPackageDictionary[UsageReportCategory.ACTIVE], apiPackageDictionary["active"]);
            Assert.AreEqual(sdkPackageDictionary[UsageReportCategory.DRAFT], apiPackageDictionary["draft"]);
            Assert.AreEqual(sdkPackageDictionary[UsageReportCategory.DECLINED], apiPackageDictionary["declined"]);
        }

        // Create an API Usage Report object
        private Silanis.ESL.API.UsageReport CreateTypicalAPIUsageReport()
        {
            Silanis.ESL.API.UsageReport usageReport = new Silanis.ESL.API.UsageReport();
            usageReport.From = new DateTime(1234);
            usageReport.To = new DateTime(5678);

            Silanis.ESL.API.Sender sender = new Silanis.ESL.API.Sender();
            sender.Email = "sender@email.com";
            sender.FirstName = "SignerFirstName";
            sender.LastName = "SignerLastName";

            IDictionary<string, object> packages = new Dictionary<string, object>();
            packages.Add("active", 7);
            packages.Add("draft", 3);
            packages.Add("declined", 1);

            Silanis.ESL.API.SenderUsageReport senderUsageReport = new Silanis.ESL.API.SenderUsageReport();
            senderUsageReport.Sender = sender;
            senderUsageReport.Packages = packages;

            usageReport.AddSender(senderUsageReport);

            return usageReport;
        }
    }
}

