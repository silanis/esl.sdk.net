using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestClass]
    public class EventNotificationConfigConverterTest
    {
		private Callback apiCallback1;
		private Callback apiCallback2;
		private EventNotificationConfig sdkEventNotificationConfig1;
		private EventNotificationConfig sdkEventNotificationConfig2;
		private EventNotificationConfigConverter converter;

		[TestMethod]
		public void convertNullSDKToAPI() {
			sdkEventNotificationConfig1 = null;
			converter = new EventNotificationConfigConverter(sdkEventNotificationConfig1);
			Assert.IsNull(converter.ToAPICallback());
		}

		[TestMethod]
		public void convertNullAPIToSDK() {
			apiCallback1 = null;
			converter = new EventNotificationConfigConverter(apiCallback1);
			Assert.IsNull(converter.ToSDKEventNotificationConfig());
		}

		[TestMethod]
		public void convertNullSDKToSDK() {
			sdkEventNotificationConfig1 = null;
			converter = new EventNotificationConfigConverter(sdkEventNotificationConfig1);
			Assert.IsNull(converter.ToSDKEventNotificationConfig());
		}

		[TestMethod]
		public void convertNullAPIToAPI() {
			apiCallback1 = null;
			converter = new EventNotificationConfigConverter(apiCallback1);
			Assert.IsNull(converter.ToAPICallback());
		}

		[TestMethod]
		public void convertSDKToSDK() {
			sdkEventNotificationConfig1 = CreateTypicalSDKEventNotificationConfig();
			sdkEventNotificationConfig2 = new EventNotificationConfigConverter(sdkEventNotificationConfig1).ToSDKEventNotificationConfig();

			Assert.IsNotNull(sdkEventNotificationConfig2);
			Assert.AreEqual(sdkEventNotificationConfig2, sdkEventNotificationConfig1);
		}

		[TestMethod]
		public void convertAPIToAPI() {
			apiCallback1 = CreateTypicalAPICallback();
			apiCallback2 = new EventNotificationConfigConverter(apiCallback1).ToAPICallback();

			Assert.IsNotNull(apiCallback2);
			Assert.AreEqual(apiCallback2, apiCallback1);
		}

		[TestMethod]
		public void convertAPIToSDK() {
			apiCallback1 = CreateTypicalAPICallback();
			sdkEventNotificationConfig1 = new EventNotificationConfigConverter(apiCallback1).ToSDKEventNotificationConfig();

			Assert.IsNotNull(sdkEventNotificationConfig1);
			Assert.AreEqual(sdkEventNotificationConfig1.Url, apiCallback1.Url);
			Assert.AreEqual(sdkEventNotificationConfig1.NotificationEvents.Count, 3);
            Assert.AreEqual(sdkEventNotificationConfig1.NotificationEvents[0].getApiValue(), apiCallback1.Events[0]);
            Assert.AreEqual(sdkEventNotificationConfig1.NotificationEvents[1].getApiValue(), apiCallback1.Events[1]);
            Assert.AreEqual(sdkEventNotificationConfig1.NotificationEvents[2].getApiValue(), apiCallback1.Events[2]);
		}

		
		[TestMethod]
		public void convertSDKToAPI() {
			sdkEventNotificationConfig1 = CreateTypicalSDKEventNotificationConfig();
			apiCallback1 = new EventNotificationConfigConverter(sdkEventNotificationConfig1).ToAPICallback();

			Assert.IsNotNull(apiCallback1);
			Assert.AreEqual(apiCallback1.Url, sdkEventNotificationConfig1.Url);
			Assert.AreEqual(apiCallback1.Events.Count, 3);
            Assert.AreEqual(apiCallback1.Events[0], sdkEventNotificationConfig1.NotificationEvents[0].getApiValue());
            Assert.AreEqual(apiCallback1.Events[1], sdkEventNotificationConfig1.NotificationEvents[1].getApiValue());
            Assert.AreEqual(apiCallback1.Events[2], sdkEventNotificationConfig1.NotificationEvents[2].getApiValue());
		}

		private Callback CreateTypicalAPICallback() {
			var callback = new Callback();
			callback.Url = "callback url";
            callback.AddEvent(NotificationEvent.DOCUMENT_SIGNED.getApiValue());
            callback.AddEvent(NotificationEvent.PACKAGE_CREATE.getApiValue());
            callback.AddEvent(NotificationEvent.PACKAGE_TRASH.getApiValue());

			return callback;
		}

		private EventNotificationConfig CreateTypicalSDKEventNotificationConfig() {
			var eventNotificationConfig = EventNotificationConfigBuilder.NewEventNotificationConfig("callback url")
				.ForEvent(NotificationEvent.PACKAGE_DECLINE)
				.ForEvent(NotificationEvent.PACKAGE_RESTORE)
				.ForEvent(NotificationEvent.SIGNER_COMPLETE)
				.build();

			return eventNotificationConfig;
		}
    }
}

