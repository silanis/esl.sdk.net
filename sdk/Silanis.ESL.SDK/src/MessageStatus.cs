using System;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class MessageStatus : EslEnumeration
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static MessageStatus NEW = new MessageStatus("NEW", "NEW", 0);
        public static MessageStatus READ = new MessageStatus("READ", "READ", 1);
        public static MessageStatus TRASHED = new MessageStatus("TRASHED", "TRASHED", 2);
        private static Dictionary<string,MessageStatus> allMessageStatus = new Dictionary<string,MessageStatus>();

        static MessageStatus()
        {
            allMessageStatus.Add(NEW.getApiValue(), NEW);
            allMessageStatus.Add(READ.getApiValue(), READ);
            allMessageStatus.Add(TRASHED.getApiValue(), TRASHED);
        }

        private MessageStatus(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static MessageStatus valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allMessageStatus.ContainsKey(apiValue))
            {
                return allMessageStatus[apiValue];
            }
            log.Warn("Unknown API MessageStatus {0}. The upgrade is required.", apiValue);
            return new MessageStatus(apiValue, "UNRECOGNIZED", allMessageStatus.Values.Count);
        }

        public static string[] GetNames()
        {
            var names = new string[allMessageStatus.Count];
            var i = 0;
            foreach(var messageStatus in allMessageStatus.Values)
            {
                names[i] = messageStatus.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator MessageStatus(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static MessageStatus[] Values()
        {
            return (new List<MessageStatus>(allMessageStatus.Values)).ToArray();
        }

        public static MessageStatus parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(var messageStatus in allMessageStatus.Values)
            {
                if (String.Equals(messageStatus.GetName(), value))
                {
                    return messageStatus;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the MessageStatus");
        }
    }
}

