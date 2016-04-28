using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class UsageReport
    {
        private Nullable<DateTime> from;
        private Nullable<DateTime> to;
        private IList<SenderUsageReport> senderUsageReports = new List<SenderUsageReport>();

        public UsageReport()
        {
        }

        public Nullable<DateTime> From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        public Nullable<DateTime> To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        public IList<SenderUsageReport> SenderUsageReports
        {
            get
            {
                return senderUsageReports;
            }
            set
            {
                senderUsageReports = value;
            }
        }

        public void AddSenderUsageReport(SenderUsageReport senderUsageReport)
        {
            senderUsageReports.Add(senderUsageReport);
        }
    }
}

