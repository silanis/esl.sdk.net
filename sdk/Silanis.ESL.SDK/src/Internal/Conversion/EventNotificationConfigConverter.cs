using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
	internal class EventNotificationConfigConverter
	{
		private Callback apiCallback = null;
		private EventNotificationConfig sdkEventNotificationConfig = null;

		public EventNotificationConfigConverter(Callback apiCallback)
		{
			this.apiCallback = apiCallback;
		}

		public EventNotificationConfigConverter(EventNotificationConfig sdkEventNotificationConfig)
		{
			this.sdkEventNotificationConfig = sdkEventNotificationConfig;
		}

		public Callback ToAPICallback()
		{
			if (sdkEventNotificationConfig == null)
			{
				return apiCallback;
			}

			var callback = new Callback();
            callback.Url = sdkEventNotificationConfig.Url;
			callback.Key = sdkEventNotificationConfig.Key;
			foreach (var notificationEvent in sdkEventNotificationConfig.NotificationEvents)
			{
				callback.AddEvent(new EventNotificationConverter(notificationEvent).ToAPICallbackEvent());
			}

			return callback;
		}

		public EventNotificationConfig ToSDKEventNotificationConfig()
		{
			if (apiCallback == null)
			{
				return sdkEventNotificationConfig;
			}

			var eventNotificationConfig = new EventNotificationConfig(apiCallback.Url);
            eventNotificationConfig.Key = apiCallback.Key;
			foreach (var callbackEvent in apiCallback.Events)
			{
				eventNotificationConfig.AddEvent(new EventNotificationConverter(callbackEvent).ToSDKNotificationEvent());
			}

			return eventNotificationConfig;
		}
	}
}
