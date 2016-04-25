using System;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
	internal class EventNotificationConfigConverter
	{
		private Silanis.ESL.API.Callback apiCallback = null;
		private Silanis.ESL.SDK.EventNotificationConfig sdkEventNotificationConfig = null;

		public EventNotificationConfigConverter(Silanis.ESL.API.Callback apiCallback)
		{
			this.apiCallback = apiCallback;
		}

		public EventNotificationConfigConverter(Silanis.ESL.SDK.EventNotificationConfig sdkEventNotificationConfig)
		{
			this.sdkEventNotificationConfig = sdkEventNotificationConfig;
		}

		public Silanis.ESL.API.Callback ToAPICallback()
		{
			if (sdkEventNotificationConfig == null)
			{
				return apiCallback;
			}

			Callback callback = new Callback();
            callback.Url = sdkEventNotificationConfig.Url;
			callback.Key = sdkEventNotificationConfig.Key;
			foreach (NotificationEvent notificationEvent in sdkEventNotificationConfig.NotificationEvents)
			{
				callback.AddEvent(new EventNotificationConverter(notificationEvent).ToAPICallbackEvent());
			}

			return callback;
		}

		public Silanis.ESL.SDK.EventNotificationConfig ToSDKEventNotificationConfig()
		{
			if (apiCallback == null)
			{
				return sdkEventNotificationConfig;
			}

			EventNotificationConfig eventNotificationConfig = new EventNotificationConfig(apiCallback.Url);
            eventNotificationConfig.Key = apiCallback.Key;
			foreach (string callbackEvent in apiCallback.Events)
			{
				eventNotificationConfig.AddEvent(new EventNotificationConverter(callbackEvent).ToSDKNotificationEvent());
			}

			return eventNotificationConfig;
		}
	}
}
