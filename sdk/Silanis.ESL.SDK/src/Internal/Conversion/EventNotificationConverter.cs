using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;
using System;
using System.Reflection;

namespace Silanis.ESL.SDK
{
	internal class EventNotificationConverter
    {
		private Silanis.ESL.SDK.NotificationEvent sdkNotificationEvent;
		private string apiCallbackEvent;

		/// <summary>
		/// Construct with SDK notification event object involved in conversion.
		/// </summary>
		/// <param name="sdkNotificationEvent">SDK notification event.</param>
		public EventNotificationConverter(Silanis.ESL.SDK.NotificationEvent sdkNotificationEvent)
        {
			this.sdkNotificationEvent = sdkNotificationEvent;
        }

		/// <summary>
		/// Construct with API callback event object involved in conversion.
		/// </summary>
		/// <param name="apiCallbackEvent">API callback event.</param>
		public EventNotificationConverter(string apiCallbackEvent)
		{
			this.apiCallbackEvent = apiCallbackEvent;
		}

		/// <summary>
		/// Convert from SDK notification event to API callback event.
		/// </summary>
		/// <returns>The API callback event.</returns>
		internal string ToAPICallbackEvent()
		{
            return sdkNotificationEvent.getApiValue();
		}

		/// <summary>
		/// Convert from API callback event to SDK notification event.
		/// </summary>
		/// <returns>The SDK notification event.</returns>
		internal Silanis.ESL.SDK.NotificationEvent ToSDKNotificationEvent()
		{
            return Silanis.ESL.SDK.NotificationEvent.valueOf(apiCallbackEvent);
		}
    }
}
