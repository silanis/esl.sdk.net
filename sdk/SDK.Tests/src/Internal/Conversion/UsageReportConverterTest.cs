using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using SenderUsageReport = Silanis.ESL.API.SenderUsageReport;

namespace SDK.Tests
{
    [TestClass]
    public class UsageReportConverterTest
    {
        private UsageReport sdkUsageReport1;
        private Silanis.ESL.API.UsageReport apiUsageReport1;
        private UsageReportConverter converter;

        [TestMethod]
        public void ConvertNullAPIToSDK()
        {
            apiUsageReport1 = null;
            converter = new UsageReportConverter(apiUsageReport1);
            Assert.IsNull(converter.ToSDKUsageReport());
        }

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            apiUsageReport1 = CreateTypicalAPIUsageReport();
            sdkUsageReport1 = new UsageReportConverter(apiUsageReport1).ToSDKUsageReport();

            Assert.AreEqual(sdkUsageReport1.From, apiUsageReport1.From);
            Assert.AreEqual(sdkUsageReport1.To, apiUsageReport1.To);

            var apiSender = apiUsageReport1.Senders[0].Sender;
            var sdkSender = sdkUsageReport1.SenderUsageReports[0].Sender;
            Assert.AreEqual(sdkSender.Email, apiSender.Email);
            Assert.AreEqual(sdkSender.FirstName, apiSender.FirstName);
            Assert.AreEqual(sdkSender.LastName, apiSender.LastName);
        
            var apiPackageDictionary = apiUsageReport1.Senders[0].Packages;
            var sdkPackageDictionary = sdkUsageReport1.SenderUsageReports[0].CountByUsageReportCategory;
            Assert.AreEqual(sdkPackageDictionary[UsageReportCategory.ACTIVE], apiPackageDictionary["active"]);
            Assert.AreEqual(sdkPackageDictionary[UsageReportCategory.DRAFT], apiPackageDictionary["draft"]);
            Assert.AreEqual(sdkPackageDictionary[UsageReportCategory.DECLINED], apiPackageDictionary["declined"]);
        }

        // Create an API Usage Report object
        private Silanis.ESL.API.UsageReport CreateTypicalAPIUsageReport()
        {
            var usageReport = new Silanis.ESL.API.UsageReport();
            usageReport.From = new DateTime(1234);
            usageReport.To = new DateTime(5678);

            var sender = new Silanis.ESL.API.Sender();
            sender.Email = "sender@email.com";
            sender.FirstName = "SignerFirstName";
            sender.LastName = "SignerLastName";

            IDictionary<string, object> packages = new Dictionary<string, object>();
            packages.Add("active", 7);
            packages.Add("draft", 3);
            packages.Add("declined", 1);

            var senderUsageReport = new SenderUsageReport();
            senderUsageReport.Sender = sender;
            senderUsageReport.Packages = packages;

            usageReport.AddSender(senderUsageReport);

            return usageReport;
        }
    }
}

