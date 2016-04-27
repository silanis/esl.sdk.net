using System;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class KnowledgeBasedAuthenticationStatus : EslEnumeration
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static KnowledgeBasedAuthenticationStatus NOT_YET_ATTEMPTED = new KnowledgeBasedAuthenticationStatus("NOT_YET_ATTEMPTED", "NOT_YET_ATTEMPTED", 0);
        public static KnowledgeBasedAuthenticationStatus PASSED = new KnowledgeBasedAuthenticationStatus("PASSED", "PASSED", 1);
        public static KnowledgeBasedAuthenticationStatus FAILED = new KnowledgeBasedAuthenticationStatus("FAILED", "FAILED", 2);
        private static Dictionary<string,KnowledgeBasedAuthenticationStatus> allKnowledgeBasedAuthenticationStatus = new Dictionary<string,KnowledgeBasedAuthenticationStatus>();


        static KnowledgeBasedAuthenticationStatus()
        {
            allKnowledgeBasedAuthenticationStatus.Add(NOT_YET_ATTEMPTED.getApiValue(), NOT_YET_ATTEMPTED);
            allKnowledgeBasedAuthenticationStatus.Add(PASSED.getApiValue(), PASSED);
            allKnowledgeBasedAuthenticationStatus.Add(FAILED.getApiValue(), FAILED);
        }

        private KnowledgeBasedAuthenticationStatus(string apiValue, string sdkValue, int index):base(apiValue, sdkValue,index) 
        {           
        }
       
        internal static KnowledgeBasedAuthenticationStatus valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allKnowledgeBasedAuthenticationStatus.ContainsKey(apiValue))
            {
                return allKnowledgeBasedAuthenticationStatus[apiValue];
            }
            log.Warn("Unknown API KnowledgeBasedAuthenticationStatus {0}. The upgrade is required.", apiValue);
            return new KnowledgeBasedAuthenticationStatus(apiValue, "UNRECOGNIZED", allKnowledgeBasedAuthenticationStatus.Values.Count);
        }

        public static string[] GetNames()
        {
            var names = new string[allKnowledgeBasedAuthenticationStatus.Count];
            var i = 0;
            foreach(var kbaStatus in allKnowledgeBasedAuthenticationStatus.Values)
            {
                names[i] = kbaStatus.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator KnowledgeBasedAuthenticationStatus(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static KnowledgeBasedAuthenticationStatus[] Values()
        {
            return (new List<KnowledgeBasedAuthenticationStatus>(allKnowledgeBasedAuthenticationStatus.Values)).ToArray();
        }

        public static KnowledgeBasedAuthenticationStatus parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(var kbaStatus in allKnowledgeBasedAuthenticationStatus.Values)
            {
                if (String.Equals(kbaStatus.GetName(), value))
                {
                    return kbaStatus;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the KnowledgeBasedAuthenticationStatus");
        }
    }
}

