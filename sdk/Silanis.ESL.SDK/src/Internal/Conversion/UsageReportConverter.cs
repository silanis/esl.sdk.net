using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    /// <summary>
    /// Conversion from API to SDK Usage Report.
    /// </summary>
    internal class UsageReportConverter
    {
        private UsageReport sdkUsageReport = null;
        private API.UsageReport apiUsageReport = null;

        internal UsageReportConverter(API.UsageReport apiUsageReport)
        {
            this.apiUsageReport = apiUsageReport;
        }

        /// <summary>
        /// Convert from API UsageReport to SDK UsageReport.
        /// </summary>
        /// <returns>The SDK usage report.</returns>
        public UsageReport ToSDKUsageReport()
        {
            if (apiUsageReport == null)
            {
                return sdkUsageReport;
            }

            var senderUsageReportList = apiUsageReport.Senders;

            if (senderUsageReportList.Count != 0)
            {
                var result = new UsageReport();
                result.From = apiUsageReport.From;
                result.To = apiUsageReport.To;

                SenderUsageReport sdkSenderUsageReport;
                foreach (var apiSenderUsageReport in senderUsageReportList)
                {
                    sdkSenderUsageReport = ToSDKSenderUsageReport(apiSenderUsageReport);
                    result.AddSenderUsageReport(sdkSenderUsageReport);
                }

                return result;
            }

            return sdkUsageReport;
        }

        // Convert from API to SDK SenderUsageReport.
        private SenderUsageReport ToSDKSenderUsageReport(API.SenderUsageReport apiSenderUsageReport)
        {
            var sdkSenderUsageReport = new SenderUsageReport();
            sdkSenderUsageReport.Sender = new SenderConverter(apiSenderUsageReport.Sender).ToSDKSender();

            IDictionary<UsageReportCategory, int> categoryCount = new Dictionary<UsageReportCategory, int>();
            foreach (var entry in apiSenderUsageReport.Packages)
            { 

                var usageReportCategory = UsageReportCategory.valueOf(entry.Key.ToUpper());
                categoryCount.Add(usageReportCategory, Convert.ToInt32(entry.Value));
            }
            sdkSenderUsageReport.CountByUsageReportCategory = categoryCount;

            return sdkSenderUsageReport;
        }

    }
}

