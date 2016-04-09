using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
	[TestClass]
	public class EventNotificationRegistrationExampleTest
	{
		[TestMethod]
		public void VerifyResult()
		{
			var example = new EventNotificationRegistrationExample();
			example.Run();

            var config = example.Config;

			Assert.IsNotNull(config);
            Assert.AreEqual(config.Url, example.Url);
            Assert.AreEqual(config.Key, example.Key);
			Assert.AreEqual(config.NotificationEvents.Count, 18);

            AssertEvents(config, example.Events);

            var connectorsConfig = example.ConnectorsConfig;

            Assert.IsNotNull(connectorsConfig);
            Assert.AreEqual(connectorsConfig.Url, example.ConnectorsUrl);
            Assert.AreEqual(connectorsConfig.Key, example.ConnectorsKey);
            Assert.AreEqual(connectorsConfig.NotificationEvents.Count, 9);

            AssertEvents(connectorsConfig, example.ConnectorsEvents);
		}

        private void AssertEvents(EventNotificationConfig config, IList<NotificationEvent> events)
        {
            foreach (var notificationEvent in events)
            {
                var found = false;
                foreach (var receivedEvent in config.NotificationEvents) 
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

