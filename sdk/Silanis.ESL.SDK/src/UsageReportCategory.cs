using System;
using System.Collections.Generic;
using System.Reflection;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class UsageReportCategory : EslEnumeration
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static UsageReportCategory ACTIVE = new UsageReportCategory("ACTIVE", "ACTIVE", 0);
        public static UsageReportCategory DRAFT = new UsageReportCategory("DRAFT", "DRAFT", 1);
        public static UsageReportCategory SENT = new UsageReportCategory("SENT", "SENT", 2);
        public static UsageReportCategory COMPLETED = new UsageReportCategory("COMPLETED", "COMPLETED", 3);
        public static UsageReportCategory ARCHIVED = new UsageReportCategory("ARCHIVED", "ARCHIVED", 4);
        public static UsageReportCategory DECLINED = new UsageReportCategory("DECLINED", "DECLINED", 5);
        public static UsageReportCategory OPTED_OUT = new UsageReportCategory("OPTED_OUT", "OPTED_OUT", 6);
        public static UsageReportCategory EXPIRED = new UsageReportCategory("EXPIRED", "EXPIRED", 7);
        public static UsageReportCategory TRASHED = new UsageReportCategory("TRASHED", "TRASHED", 8);

        private static Dictionary<string,UsageReportCategory> allUsageReportCategorys = new Dictionary<string,UsageReportCategory>();

        static UsageReportCategory()
        {
            allUsageReportCategorys.Add(ACTIVE.getApiValue(), UsageReportCategory.ACTIVE);
            allUsageReportCategorys.Add(DRAFT.getApiValue(), UsageReportCategory.DRAFT);
            allUsageReportCategorys.Add(SENT.getApiValue(), UsageReportCategory.SENT);
            allUsageReportCategorys.Add(COMPLETED.getApiValue(), UsageReportCategory.COMPLETED);
            allUsageReportCategorys.Add(ARCHIVED.getApiValue(), UsageReportCategory.ARCHIVED);
            allUsageReportCategorys.Add(DECLINED.getApiValue(), UsageReportCategory.DECLINED);
            allUsageReportCategorys.Add(OPTED_OUT.getApiValue(), UsageReportCategory.OPTED_OUT);
            allUsageReportCategorys.Add(EXPIRED.getApiValue(), UsageReportCategory.EXPIRED);
            allUsageReportCategorys.Add(TRASHED.getApiValue(), UsageReportCategory.TRASHED);
        }

        
        private UsageReportCategory(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static UsageReportCategory valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allUsageReportCategorys.ContainsKey(apiValue))
            {
                return allUsageReportCategorys[apiValue];
            }
            log.Warn("Unknown API UsageReportCategory {0}. The upgrade is required.", apiValue);
            return new UsageReportCategory(apiValue, "UNRECOGNIZED", allUsageReportCategorys.Values.Count);
        }

        public static string[] GetNames()
        {
            var names = new string[allUsageReportCategorys.Count];
            var i = 0;
            foreach(var usageReportCategory in allUsageReportCategorys.Values)
            {
                names[i] = usageReportCategory.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator UsageReportCategory(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static UsageReportCategory[] Values()
        {
            return (new List<UsageReportCategory>(allUsageReportCategorys.Values)).ToArray();
        }

        public static UsageReportCategory parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(var usageReportCategory in allUsageReportCategorys.Values)
            {
                if (String.Equals(usageReportCategory.GetName(), value))
                {
                    return usageReportCategory;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the UsageReportCategory");
        }
    }
}

