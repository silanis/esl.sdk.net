using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.API;

namespace SDK.Tests
{
	[TestFixture]
    public class ReminderConverterTest
    {
        public ReminderConverterTest()
        {
        }

		[Test]
		public void ToAPI()
		{
			DateTime date = DateTime.Now;
			DateTime sentDate = DateTime.Now.AddMonths(1);

			Reminder sdk = new Reminder(date, sentDate);
			PackageReminder api = new ReminderConverter(sdk).ToAPIPackageReminder();

			Assert.IsNotNull(api);
			Assert.AreEqual(date, api.Date);
			Assert.AreEqual(sentDate, api.SentDate);
		}

		[Test]
		public void ToAPIWithNullSentDate()
		{
			DateTime date = DateTime.Now;
			Reminder sdk = new Reminder(date, null);
			PackageReminder api = new ReminderConverter(sdk).ToAPIPackageReminder();

			Assert.IsNotNull(api);
			Assert.AreEqual(date, api.Date);
			Assert.IsNull(api.SentDate);
		}

		[Test]
		public void ToSDK()
		{
			DateTime date = DateTime.Now;
			DateTime sentDate = DateTime.Now.AddMonths(1);
			PackageReminder api = new PackageReminder();
			api.Date = date;
			api.SentDate = sentDate;
			Reminder sdk = new ReminderConverter(api).ToSDKReminder();

			Assert.IsNotNull(sdk);
			Assert.AreEqual(date, sdk.Date);
			Assert.AreEqual(sentDate, sdk.SentDate);
		}

		[Test]
		public void ToSDKWithNullSentDate()
		{
			DateTime date = DateTime.Now;
			PackageReminder api = new PackageReminder();
			api.Date = date;
			api.SentDate = null;
			Reminder sdk = new ReminderConverter(api).ToSDKReminder();

			Assert.IsNotNull(sdk);
			Assert.AreEqual(date, sdk.Date);
			Assert.IsNull(sdk.SentDate);
		}
    }
}

