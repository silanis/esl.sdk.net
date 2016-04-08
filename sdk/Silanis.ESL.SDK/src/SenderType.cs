using System;
using System.Collections.Generic;
using System.Reflection;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class SenderType : EslEnumeration
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static SenderType REGULAR = new SenderType("REGULAR", "REGULAR", 0);
        public static SenderType MANAGER = new SenderType("MANAGER", "MANAGER", 1);
        private static Dictionary<string,SenderType> allSenderTypes = new Dictionary<string,SenderType>();

        static SenderType()
        {
            allSenderTypes.Add(REGULAR.getApiValue(), SenderType.REGULAR);
            allSenderTypes.Add(MANAGER.getApiValue(), SenderType.MANAGER);
        }

        
        private SenderType(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static SenderType valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allSenderTypes.ContainsKey(apiValue))
            {
                return allSenderTypes[apiValue];
            }
            log.Warn("Unknown API SenderType {0}. The upgrade is required.", apiValue);
            return new SenderType(apiValue, "UNRECOGNIZED", allSenderTypes.Values.Count);
        }

        public static string[] GetNames()
        {
            var names = new string[allSenderTypes.Count];
            var i = 0;
            foreach(var senderType in allSenderTypes.Values)
            {
                names[i] = senderType.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator SenderType(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static SenderType[] Values()
        {
            return (new List<SenderType>(allSenderTypes.Values)).ToArray();
        }

        public static SenderType parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(var senderType in allSenderTypes.Values)
            {
                if (String.Equals(senderType.GetName(), value))
                {
                    return senderType;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the SenderType");
        }
    }
}

