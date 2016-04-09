using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	public class EventNotificationConfig
	{
        private string url;
		private string key;
		private List<NotificationEvent> notificationEvents;

		public EventNotificationConfig(string url)
		{
			this.url = url;
			notificationEvents = new List<NotificationEvent>();
		}

        public EventNotificationConfig(string url, string key)
        {
            this.url = url;
            this.key = key;
            notificationEvents = new List<NotificationEvent>();
        }

		public string Url
		{
			get
			{
				return url;
			}
			set
			{
				url = value;
			}
		}

        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

		public List<NotificationEvent> NotificationEvents
		{
			get
			{
				return notificationEvents;
			}
			set
			{
				notificationEvents = value;
			}
		}

		public void AddEvent(NotificationEvent notificationEvent)
		{
			notificationEvents.Add(notificationEvent);
		}
	}
}
