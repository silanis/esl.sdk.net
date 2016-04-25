using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.API;

namespace SDK.Tests
{
	[TestFixture]
	public class ReminderScheduleConverterTest
    {
		[Test]
		public void ToAPIWithNoIDAndNoReminders()
		{
			ReminderSchedule sdk = new ReminderSchedule();
			sdk.NumberOfRepetitions = 5;
			sdk.DaysUntilFirstReminder = 10;
			sdk.DaysBetweenReminders = 15;
			PackageReminderSchedule api = new ReminderScheduleConverter(sdk).ToAPIPackageReminderSchedule();

			Assert.IsNotNull(api);
			Assert.AreEqual("", api.PackageId);
			Assert.AreEqual(5, api.RepetitionsCount);
			Assert.AreEqual(10, api.StartInDaysDelay);
			Assert.AreEqual(15, api.IntervalInDays);
			Assert.IsNotNull(api.Reminders);
			Assert.AreEqual(0, api.Reminders.Count);
		}

		[Test]
		public void ToAPI()
		{
			ReminderSchedule sdk = new ReminderSchedule();
			sdk.PackageId = new PackageId("bob");
			sdk.NumberOfRepetitions = 5;
			sdk.DaysUntilFirstReminder = 10;
			sdk.DaysBetweenReminders = 15;
			sdk.Reminders.Add(new Reminder(DateTime.Now, DateTime.Now));
			sdk.Reminders.Add(new Reminder(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1)));
			sdk.Reminders.Add(new Reminder(DateTime.Now.AddDays(2), DateTime.Now.AddDays(2)));

			PackageReminderSchedule api = new ReminderScheduleConverter(sdk).ToAPIPackageReminderSchedule();

			Assert.IsNotNull(api);
			Assert.IsNotNull(api.PackageId);
			Assert.AreEqual("bob", api.PackageId);
			Assert.AreEqual(5, api.RepetitionsCount);
			Assert.AreEqual(10, api.StartInDaysDelay);
			Assert.AreEqual(15, api.IntervalInDays);

			Assert.IsNotNull(api.Reminders);
			Assert.AreEqual(3, api.Reminders.Count);

			foreach( Reminder reminder in sdk.Reminders )
			{
				PackageReminder apiReminder = null;

				foreach (PackageReminder packageReminder in api.Reminders)
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

		[Test]
		public void ToSDKWithNoIDAndNoReminders()
		{
			PackageReminderSchedule api = new PackageReminderSchedule();
			api.RepetitionsCount = 5;
			api.IntervalInDays = 10;
			api.StartInDaysDelay = 15;
			ReminderSchedule sdk = new ReminderScheduleConverter(api).ToSDKReminderSchedule();

			Assert.IsNotNull(sdk);
			Assert.IsNull(sdk.PackageId);
			Assert.AreEqual(5, sdk.NumberOfRepetitions);
			Assert.AreEqual(10, sdk.DaysBetweenReminders);
			Assert.AreEqual(15, sdk.DaysUntilFirstReminder);
			Assert.IsNotNull(sdk.Reminders);
			Assert.IsEmpty(sdk.Reminders);
		}

		[Test]
		public void ToSDK()
		{
			PackageReminderSchedule api = new PackageReminderSchedule();
			api.PackageId = "bob";
			api.RepetitionsCount = 5;
			api.IntervalInDays = 10;
			api.StartInDaysDelay = 15;

			PackageReminder reminder1 = new PackageReminder();
			reminder1.Date = reminder1.SentDate = DateTime.Now;
			api.Reminders.Add(reminder1);
			PackageReminder reminder2 = new PackageReminder();
			reminder2.Date = reminder2.SentDate = DateTime.Now.AddDays(1);
			api.Reminders.Add(reminder2);
			PackageReminder reminder3 = new PackageReminder();
			reminder3.Date = reminder3.SentDate = DateTime.Now.AddDays(2);
			api.Reminders.Add(reminder3);

			ReminderSchedule sdk = new ReminderScheduleConverter(api).ToSDKReminderSchedule();

			Assert.IsNotNull(sdk);
			Assert.IsNotNull(sdk.PackageId);
			Assert.AreEqual("bob",sdk.PackageId.Id);
			Assert.AreEqual(5, sdk.NumberOfRepetitions);
			Assert.AreEqual(10, sdk.DaysBetweenReminders);
			Assert.AreEqual(15, sdk.DaysUntilFirstReminder);
			Assert.IsNotNull(sdk.Reminders);
			Assert.AreEqual(3, sdk.Reminders.Count);

			foreach (PackageReminder packageReminder in api.Reminders)
			{
				Reminder sdkReminder = null;

				foreach (Reminder reminder in sdk.Reminders)
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

