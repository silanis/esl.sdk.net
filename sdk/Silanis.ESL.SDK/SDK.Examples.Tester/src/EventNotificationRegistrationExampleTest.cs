using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
	[TestFixture()]
	public class EventNotificationRegistrationExampleTest
	{
		[Test()]
        [Category("NotFor60")]
		public void VerifyResult()
		{
			EventNotificationRegistrationExample example = new EventNotificationRegistrationExample();
			example.Run();

            EventNotificationConfig config = example.config;

			Assert.IsNotNull(config);
            Assert.AreEqual(config.Url, example.URL);
            Assert.AreEqual(config.Key, example.KEY);
			Assert.AreEqual(config.NotificationEvents.Count, 18);

            AssertEvents(config, example.events);

            EventNotificationConfig connectorsConfig = example.connectorsConfig;

            Assert.IsNotNull(connectorsConfig);
            Assert.AreEqual(connectorsConfig.Url, example.CONNECTORS_URL);
            Assert.AreEqual(connectorsConfig.Key, example.CONNECTORS_KEY);
            Assert.AreEqual(connectorsConfig.NotificationEvents.Count, 9);

            AssertEvents(connectorsConfig, example.connectorsEvents);
		}

        private void AssertEvents(EventNotificationConfig config, IList<NotificationEvent> events)
        {
            foreach (NotificationEvent notificationEvent in events)
            {
                bool found = false;
                foreach (NotificationEvent receivedEvent in config.NotificationEvents) 
                {
                    if (receivedEvent.ToString().Equals(notificationEvent.ToString())) 
                    {
                        found = true;
                        break;
                    }
                }
                Assert.IsTrue(found, "Callback has wrong event for EVENT" + (events.IndexOf(notificationEvent) + 1));
            }
        }
	}
}

