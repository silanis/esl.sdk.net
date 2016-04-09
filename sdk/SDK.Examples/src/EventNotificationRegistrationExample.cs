using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
	public class EventNotificationRegistrationExample : SdkSample
	{
        public EventNotificationConfig Config, ConnectorsConfig;
		public readonly string Url = "http://my.url.com";
        public readonly string Key = "abc";
        public readonly string ConnectorsUrl = "http://connectors.url.com";
        public readonly string ConnectorsKey = "1234";
        public readonly string Origin = "dynamics2013";

        public readonly NotificationEvent Event1 = NotificationEvent.PACKAGE_CREATE;
        public readonly NotificationEvent Event2 = NotificationEvent.PACKAGE_ACTIVATE;
        public readonly NotificationEvent Event3 = NotificationEvent.PACKAGE_DEACTIVATE;
        public readonly NotificationEvent Event4 = NotificationEvent.PACKAGE_READY_FOR_COMPLETION;
        public readonly NotificationEvent Event5 = NotificationEvent.PACKAGE_COMPLETE;
        public readonly NotificationEvent Event6 = NotificationEvent.PACKAGE_TRASH;
        public readonly NotificationEvent Event7 = NotificationEvent.PACKAGE_RESTORE;
        public readonly NotificationEvent Event8 = NotificationEvent.PACKAGE_DELETE;
        public readonly NotificationEvent Event9 = NotificationEvent.PACKAGE_DECLINE;
        public readonly NotificationEvent Event10 = NotificationEvent.PACKAGE_EXPIRE;
        public readonly NotificationEvent Event11 = NotificationEvent.PACKAGE_OPT_OUT;
        public readonly NotificationEvent Event12 = NotificationEvent.DOCUMENT_SIGNED;
        public readonly NotificationEvent Event13 = NotificationEvent.ROLE_REASSIGN;
        public readonly NotificationEvent Event14 = NotificationEvent.SIGNER_COMPLETE;
        public readonly NotificationEvent Event15 = NotificationEvent.KBA_FAILURE;
        public readonly NotificationEvent Event16 = NotificationEvent.EMAIL_BOUNCE;
        public readonly NotificationEvent Event17 = NotificationEvent.PACKAGE_ATTACHMENT;
        public readonly NotificationEvent Event18 = NotificationEvent.SIGNER_LOCKED;

        public List<NotificationEvent> Events = new List<NotificationEvent>();
        public List<NotificationEvent> ConnectorsEvents = new List<NotificationEvent>();

		public static void Main(string[] args)
		{
			new EventNotificationRegistrationExample().Run();
		}

		override public void Execute()
		{
			// Register for event notification
            Events.Add(Event1);
            Events.Add(Event2);
            Events.Add(Event3);
            Events.Add(Event4);
            Events.Add(Event5);
            Events.Add(Event6);
            Events.Add(Event7);
            Events.Add(Event8);
            Events.Add(Event9);
            Events.Add(Event10);
            Events.Add(Event11);
            Events.Add(Event12);
            Events.Add(Event13);
            Events.Add(Event14);
            Events.Add(Event15);
            Events.Add(Event16);
            Events.Add(Event17);
            Events.Add(Event18);

			eslClient.EventNotificationService.Register(EventNotificationConfigBuilder.NewEventNotificationConfig(Url)
                .WithKey(Key).SetEvents(Events));

			// Get the registered event notifications
			Config = eslClient.EventNotificationService.GetEventNotificationConfig();

            // Register event notifications for dynamics2013 connector
            ConnectorsEvents.Add(Event1);
            ConnectorsEvents.Add(Event3);
            ConnectorsEvents.Add(Event6);
            ConnectorsEvents.Add(Event9);
            ConnectorsEvents.Add(Event11);
            ConnectorsEvents.Add(Event12);
            ConnectorsEvents.Add(Event14);
            ConnectorsEvents.Add(Event17);
            ConnectorsEvents.Add(Event18);

            eslClient.EventNotificationService.Register(Origin, EventNotificationConfigBuilder.NewEventNotificationConfig(ConnectorsUrl)
                .WithKey(ConnectorsKey).SetEvents(ConnectorsEvents));

            // Get the registered event notifications for dynamics2013 connector
            ConnectorsConfig = eslClient.EventNotificationService.GetEventNotificationConfig(Origin);
		}
	}
}
