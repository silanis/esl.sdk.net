using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.API;

namespace SDK.Tests
{
	[TestClass]
	public class ReminderScheduleConverterTest
    {
		[TestMethod]
		public void ToAPIWithNoIDAndNoReminders()
		{
			var sdk = new ReminderSchedule();
			sdk.NumberOfRepetitions = 5;
			sdk.DaysUntilFirstReminder = 10;
			sdk.DaysBetweenReminders = 15;
			var api = new ReminderScheduleConverter(sdk).ToAPIPackageReminderSchedule();

			Assert.IsNotNull(api);
			Assert.AreEqual("", api.PackageId);
			Assert.AreEqual(5, api.RepetitionsCount);
			Assert.AreEqual(10, api.StartInDaysDelay);
			Assert.AreEqual(15, api.IntervalInDays);
			Assert.IsNotNull(api.Reminders);
			Assert.AreEqual(0, api.Reminders.Count);
		}

		[TestMethod]
		public void ToAPI()
		{
			var sdk = new ReminderSchedule();
			sdk.PackageId = new PackageId("bob");
			sdk.NumberOfRepetitions = 5;
			sdk.DaysUntilFirstReminder = 10;
			sdk.DaysBetweenReminders = 15;
			sdk.Reminders.Add(new Reminder(DateTime.Now, DateTime.Now));
			sdk.Reminders.Add(new Reminder(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1)));
			sdk.Reminders.Add(new Reminder(DateTime.Now.AddDays(2), DateTime.Now.AddDays(2)));

			var api = new ReminderScheduleConverter(sdk).ToAPIPackageReminderSchedule();

			Assert.IsNotNull(api);
			Assert.IsNotNull(api.PackageId);
			Assert.AreEqual("bob", api.PackageId);
			Assert.AreEqual(5, api.RepetitionsCount);
			Assert.AreEqual(10, api.StartInDaysDelay);
			Assert.AreEqual(15, api.IntervalInDays);

			Assert.IsNotNull(api.Reminders);
			Assert.AreEqual(3, api.Reminders.Count);

			foreach( var reminder in sdk.Reminders )
			{
				PackageReminder apiReminder = null;

				foreach (var packageReminder in api.Reminders)
				{
					if (reminder.Date.Equals(packageReminder.Date) && reminder.SentDate.Equals(packageReminder.SentDate))
					{
						apiReminder = packageReminder;
						break;
					}
				}

				Assert.IsNotNull(apiReminder);
			}
		}

		[TestMethod]
		public void ToSDKWithNoIDAndNoReminders()
		{
			var api = new PackageReminderSchedule();
			api.RepetitionsCount = 5;
			api.IntervalInDays = 10;
			api.StartInDaysDelay = 15;
			var sdk = new ReminderScheduleConverter(api).ToSDKReminderSchedule();

			Assert.IsNotNull(sdk);
			Assert.IsNull(sdk.PackageId);
			Assert.AreEqual(5, sdk.NumberOfRepetitions);
			Assert.AreEqual(10, sdk.DaysBetweenReminders);
			Assert.AreEqual(15, sdk.DaysUntilFirstReminder);
			Assert.IsNotNull(sdk.Reminders);
			Assert.IsTrue(!sdk.Reminders.Any());
		}

		[TestMethod]
		public void ToSDK()
		{
			var api = new PackageReminderSchedule();
			api.PackageId = "bob";
			api.RepetitionsCount = 5;
			api.IntervalInDays = 10;
			api.StartInDaysDelay = 15;

			var reminder1 = new PackageReminder();
			reminder1.Date = reminder1.SentDate = DateTime.Now;
			api.Reminders.Add(reminder1);
			var reminder2 = new PackageReminder();
			reminder2.Date = reminder2.SentDate = DateTime.Now.AddDays(1);
			api.Reminders.Add(reminder2);
			var reminder3 = new PackageReminder();
			reminder3.Date = reminder3.SentDate = DateTime.Now.AddDays(2);
			api.Reminders.Add(reminder3);

			var sdk = new ReminderScheduleConverter(api).ToSDKReminderSchedule();

			Assert.IsNotNull(sdk);
			Assert.IsNotNull(sdk.PackageId);
			Assert.AreEqual("bob",sdk.PackageId.Id);
			Assert.AreEqual(5, sdk.NumberOfRepetitions);
			Assert.AreEqual(10, sdk.DaysBetweenReminders);
			Assert.AreEqual(15, sdk.DaysUntilFirstReminder);
			Assert.IsNotNull(sdk.Reminders);
			Assert.AreEqual(3, sdk.Reminders.Count);

			foreach (var packageReminder in api.Reminders)
			{
				Reminder sdkReminder = null;

				foreach (var reminder in sdk.Reminders)
				{
					if (packageReminder.Date.Equals(reminder.Date) && packageReminder.SentDate.Equals(reminder.SentDate))
					{
						sdkReminder = reminder;
					}
				}

				Assert.IsNotNull(sdkReminder);
			}
		}
    }
}

