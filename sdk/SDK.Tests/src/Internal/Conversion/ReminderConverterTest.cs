using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.API;

namespace SDK.Tests
{
	[TestClass]
    public class ReminderConverterTest
    {
        public ReminderConverterTest()
        {
        }

		[TestMethod]
		public void ToAPI()
		{
			var date = DateTime.Now;
			var sentDate = DateTime.Now.AddMonths(1);

			var sdk = new Reminder(date, sentDate);
			var api = new ReminderConverter(sdk).ToAPIPackageReminder();

			Assert.IsNotNull(api);
			Assert.AreEqual(date, api.Date);
			Assert.AreEqual(sentDate, api.SentDate);
		}

		[TestMethod]
		public void ToAPIWithNullSentDate()
		{
			var date = DateTime.Now;
			var sdk = new Reminder(date, null);
			var api = new ReminderConverter(sdk).ToAPIPackageReminder();

			Assert.IsNotNull(api);
			Assert.AreEqual(date, api.Date);
			Assert.IsNull(api.SentDate);
		}

		[TestMethod]
		public void ToSDK()
		{
			var date = DateTime.Now;
			var sentDate = DateTime.Now.AddMonths(1);
			var api = new PackageReminder();
			api.Date = date;
			api.SentDate = sentDate;
			var sdk = new ReminderConverter(api).ToSDKReminder();

			Assert.IsNotNull(sdk);
			Assert.AreEqual(date, sdk.Date);
			Assert.AreEqual(sentDate, sdk.SentDate);
		}

		[TestMethod]
		public void ToSDKWithNullSentDate()
		{
			var date = DateTime.Now;
			var api = new PackageReminder();
			api.Date = date;
			api.SentDate = null;
			var sdk = new ReminderConverter(api).ToSDKReminder();

			Assert.IsNotNull(sdk);
			Assert.AreEqual(date, sdk.Date);
			Assert.IsNull(sdk.SentDate);
		}
    }
}

