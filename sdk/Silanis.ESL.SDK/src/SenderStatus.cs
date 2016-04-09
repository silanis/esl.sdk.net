using System;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class SenderStatus : EslEnumeration
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static SenderStatus INVITED = new SenderStatus("INVITED","INVITED", 0);
        public static SenderStatus ACTIVE = new SenderStatus("ACTIVE","ACTIVE", 1);
        public static SenderStatus LOCKED = new SenderStatus("LOCKED","LOCKED", 2);
        private static Dictionary<string,SenderStatus> allSenderStatus = new Dictionary<string,SenderStatus>();

        static SenderStatus()
        {
            allSenderStatus.Add(INVITED.getApiValue(), INVITED);
            allSenderStatus.Add(ACTIVE.getApiValue(), ACTIVE);
            allSenderStatus.Add(LOCKED.getApiValue(), LOCKED);
        }

        
        private SenderStatus(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static SenderStatus valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allSenderStatus.ContainsKey(apiValue))
            {
                return allSenderStatus[apiValue];
            }
            log.Warn("Unknown API SenderStatus {0}. The upgrade is required.", apiValue);
            return new SenderStatus(apiValue, "UNRECOGNIZED", allSenderStatus.Values.Count);
        }

        public static string[] GetNames()
        {
            var names = new string[allSenderStatus.Count];
            var i = 0;
            foreach(var senderStatus in allSenderStatus.Values)
            {
                names[i] = senderStatus.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator SenderStatus(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static SenderStatus[] Values()
        {
            return (new List<SenderStatus>(allSenderStatus.Values)).ToArray();
        }

        public static SenderStatus parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(var senderStatus in allSenderStatus.Values)
            {
                if (String.Equals(senderStatus.GetName(), value))
                {
                    return senderStatus;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the SenderStatus");
        }
    }
}

