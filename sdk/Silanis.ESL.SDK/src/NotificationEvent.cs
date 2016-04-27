using System;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class NotificationEvent : EslEnumeration
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static NotificationEvent PACKAGE_ACTIVATE = new NotificationEvent("PACKAGE_ACTIVATE", "PACKAGE_ACTIVATE", 0);
        public static NotificationEvent PACKAGE_COMPLETE = new NotificationEvent("PACKAGE_COMPLETE", "PACKAGE_COMPLETE", 1);
        public static NotificationEvent PACKAGE_EXPIRE = new NotificationEvent("PACKAGE_EXPIRE", "PACKAGE_EXPIRE", 2);
        public static NotificationEvent PACKAGE_OPT_OUT = new NotificationEvent("PACKAGE_OPT_OUT", "PACKAGE_OPT_OUT", 3);
        public static NotificationEvent PACKAGE_DECLINE = new NotificationEvent("PACKAGE_DECLINE", "PACKAGE_DECLINE", 4);
        public static NotificationEvent SIGNER_COMPLETE = new NotificationEvent("SIGNER_COMPLETE", "SIGNER_COMPLETE", 5);
        public static NotificationEvent DOCUMENT_SIGNED = new NotificationEvent("DOCUMENT_SIGNED", "DOCUMENT_SIGNED", 6);
        public static NotificationEvent ROLE_REASSIGN = new NotificationEvent("ROLE_REASSIGN", "ROLE_REASSIGN", 7);
        public static NotificationEvent PACKAGE_CREATE = new NotificationEvent("PACKAGE_CREATE", "PACKAGE_CREATE", 8);
        public static NotificationEvent PACKAGE_DEACTIVATE = new NotificationEvent("PACKAGE_DEACTIVATE", "PACKAGE_DEACTIVATE", 9);
        public static NotificationEvent PACKAGE_READY_FOR_COMPLETION = new NotificationEvent("PACKAGE_READY_FOR_COMPLETE", "PACKAGE_READY_FOR_COMPLETION", 10);
        public static NotificationEvent PACKAGE_TRASH = new NotificationEvent("PACKAGE_TRASH", "PACKAGE_TRASH", 11);
        public static NotificationEvent PACKAGE_RESTORE = new NotificationEvent("PACKAGE_RESTORE", "PACKAGE_RESTORE", 12);
        public static NotificationEvent PACKAGE_DELETE = new NotificationEvent("PACKAGE_DELETE", "PACKAGE_DELETE", 13);
        public static NotificationEvent KBA_FAILURE = new NotificationEvent("KBA_FAILURE", "KBA_FAILURE", 14);
        public static NotificationEvent EMAIL_BOUNCE = new NotificationEvent("EMAIL_BOUNCE", "EMAIL_BOUNCE", 15);
        public static NotificationEvent PACKAGE_ATTACHMENT = new NotificationEvent("PACKAGE_ATTACHMENT", "PACKAGE_ATTACHMENT", 16);
        public static NotificationEvent SIGNER_LOCKED = new NotificationEvent("SIGNER_LOCKED", "SIGNER_LOCKED", 17);

        private static Dictionary<string,NotificationEvent> allNotificationEvents = new Dictionary<string,NotificationEvent>();

        static NotificationEvent()
        {
            allNotificationEvents.Add(PACKAGE_ACTIVATE.getApiValue(), PACKAGE_ACTIVATE);
            allNotificationEvents.Add(PACKAGE_COMPLETE.getApiValue(), PACKAGE_COMPLETE);
            allNotificationEvents.Add(PACKAGE_EXPIRE.getApiValue(), PACKAGE_EXPIRE);
            allNotificationEvents.Add(PACKAGE_OPT_OUT.getApiValue(), PACKAGE_OPT_OUT);
            allNotificationEvents.Add(PACKAGE_DECLINE.getApiValue(), PACKAGE_DECLINE);
            allNotificationEvents.Add(SIGNER_COMPLETE.getApiValue(), SIGNER_COMPLETE);
            allNotificationEvents.Add(DOCUMENT_SIGNED.getApiValue(), DOCUMENT_SIGNED);
            allNotificationEvents.Add(ROLE_REASSIGN.getApiValue(), ROLE_REASSIGN);
            allNotificationEvents.Add(PACKAGE_CREATE.getApiValue(), PACKAGE_CREATE);
            allNotificationEvents.Add(PACKAGE_DEACTIVATE.getApiValue(), PACKAGE_DEACTIVATE);
            allNotificationEvents.Add(PACKAGE_READY_FOR_COMPLETION.getApiValue(), PACKAGE_READY_FOR_COMPLETION);
            allNotificationEvents.Add(PACKAGE_TRASH.getApiValue(), PACKAGE_TRASH);
            allNotificationEvents.Add(PACKAGE_RESTORE.getApiValue(), PACKAGE_RESTORE);
            allNotificationEvents.Add(PACKAGE_DELETE.getApiValue(), PACKAGE_DELETE);
            allNotificationEvents.Add(KBA_FAILURE.getApiValue(), KBA_FAILURE);
            allNotificationEvents.Add(EMAIL_BOUNCE.getApiValue(), EMAIL_BOUNCE);
            allNotificationEvents.Add(PACKAGE_ATTACHMENT.getApiValue(), PACKAGE_ATTACHMENT);
            allNotificationEvents.Add(SIGNER_LOCKED.getApiValue(), SIGNER_LOCKED);
        }

        private NotificationEvent(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static NotificationEvent valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allNotificationEvents.ContainsKey(apiValue))
            {
                return allNotificationEvents[apiValue];
            }
            log.Warn("Unknown API NotificationEvent {0}. The upgrade is required.", apiValue);
            return new NotificationEvent(apiValue, "UNRECOGNIZED", allNotificationEvents.Values.Count);
        }

        public static string[] GetNames()
        {
            var names = new string[allNotificationEvents.Count];
            var i = 0;
            foreach(var notificationEvent in allNotificationEvents.Values)
            {
                names[i] = notificationEvent.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator NotificationEvent(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static NotificationEvent[] Values(){
            return (new List<NotificationEvent>(allNotificationEvents.Values)).ToArray();
        }
        
        public static NotificationEvent parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(var notificationEvent in allNotificationEvents.Values){
                if (String.Equals(notificationEvent.GetName(), value))
                {
                    return notificationEvent;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the NotificationEvent");
        }
    }
}

