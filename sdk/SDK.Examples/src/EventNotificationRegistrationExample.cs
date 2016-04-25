using System;
using Silanis.ESL.SDK;
using System.IO;
using System.Collections.Generic;

namespace SDK.Examples
{
	public class EventNotificationRegistrationExample : SDKSample
	{
        public EventNotificationConfig config, connectorsConfig;
		public readonly string URL = "http://my.url.com";
        public readonly string KEY = "abc";
        public readonly string CONNECTORS_URL = "http://connectors.url.com";
        public readonly string CONNECTORS_KEY = "1234";
        public readonly string ORIGIN = "dynamics2013";

        public readonly NotificationEvent EVENT1 = NotificationEvent.PACKAGE_CREATE;
        public readonly NotificationEvent EVENT2 = NotificationEvent.PACKAGE_ACTIVATE;
        public readonly NotificationEvent EVENT3 = NotificationEvent.PACKAGE_DEACTIVATE;
        public readonly NotificationEvent EVENT4 = NotificationEvent.PACKAGE_READY_FOR_COMPLETION;
        public readonly NotificationEvent EVENT5 = NotificationEvent.PACKAGE_COMPLETE;
        public readonly NotificationEvent EVENT6 = NotificationEvent.PACKAGE_TRASH;
        public readonly NotificationEvent EVENT7 = NotificationEvent.PACKAGE_RESTORE;
        public readonly NotificationEvent EVENT8 = NotificationEvent.PACKAGE_DELETE;
        public readonly NotificationEvent EVENT9 = NotificationEvent.PACKAGE_DECLINE;
        public readonly NotificationEvent EVENT10 = NotificationEvent.PACKAGE_EXPIRE;
        public readonly NotificationEvent EVENT11 = NotificationEvent.PACKAGE_OPT_OUT;
        public readonly NotificationEvent EVENT12 = NotificationEvent.DOCUMENT_SIGNED;
        public readonly NotificationEvent EVENT13 = NotificationEvent.ROLE_REASSIGN;
        public readonly NotificationEvent EVENT14 = NotificationEvent.SIGNER_COMPLETE;
        public readonly NotificationEvent EVENT15 = NotificationEvent.KBA_FAILURE;
        public readonly NotificationEvent EVENT16 = NotificationEvent.EMAIL_BOUNCE;
        public readonly NotificationEvent EVENT17 = NotificationEvent.PACKAGE_ATTACHMENT;
        public readonly NotificationEvent EVENT18 = NotificationEvent.SIGNER_LOCKED;

        public List<NotificationEvent> events = new List<NotificationEvent>();
        public List<NotificationEvent> connectorsEvents = new List<NotificationEvent>();

		public static void Main(string[] args)
		{
			new EventNotificationRegistrationExample().Run();
		}

		override public void Execute()
		{
			// Register for event notification
            events.Add(EVENT1);
            events.Add(EVENT2);
            events.Add(EVENT3);
            events.Add(EVENT4);
            events.Add(EVENT5);
            events.Add(EVENT6);
            events.Add(EVENT7);
            events.Add(EVENT8);
            events.Add(EVENT9);
            events.Add(EVENT10);
            events.Add(EVENT11);
            events.Add(EVENT12);
            events.Add(EVENT13);
            events.Add(EVENT14);
            events.Add(EVENT15);
            events.Add(EVENT16);
            events.Add(EVENT17);
            events.Add(EVENT18);

			eslClient.EventNotificationService.Register(EventNotificationConfigBuilder.NewEventNotificationConfig(URL)
                .WithKey(KEY).SetEvents(events));

			// Get the registered event notifications
			config = eslClient.EventNotificationService.GetEventNotificationConfig();

            // Register event notifications for dynamics2013 connector
            connectorsEvents.Add(EVENT1);
            connectorsEvents.Add(EVENT3);
            connectorsEvents.Add(EVENT6);
            connectorsEvents.Add(EVENT9);
            connectorsEvents.Add(EVENT11);
            connectorsEvents.Add(EVENT12);
            connectorsEvents.Add(EVENT14);
            connectorsEvents.Add(EVENT17);
            connectorsEvents.Add(EVENT18);

            eslClient.EventNotificationService.Register(ORIGIN, EventNotificationConfigBuilder.NewEventNotificationConfig(CONNECTORS_URL)
                .WithKey(CONNECTORS_KEY).SetEvents(connectorsEvents));

            // Get the registered event notifications for dynamics2013 connector
            connectorsConfig = eslClient.EventNotificationService.GetEventNotificationConfig(ORIGIN);
		}
	}
}
