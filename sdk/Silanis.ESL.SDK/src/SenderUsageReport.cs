using System;
using System.Collections.Generic;
using System.Collections;

namespace Silanis.ESL.SDK
{
    public class SenderUsageReport
    {
        private IDictionary<UsageReportCategory, int> countByUsageReportCategory = new Dictionary<UsageReportCategory, int>();
        private Sender sender;

        public SenderUsageReport()
        {
        }

        public IDictionary<UsageReportCategory, int> CountByUsageReportCategory
        {
            get
            {
                return countByUsageReportCategory;
            }
            set
            {
                countByUsageReportCategory = value;
            }
        }

        public Sender Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }
    }
}

