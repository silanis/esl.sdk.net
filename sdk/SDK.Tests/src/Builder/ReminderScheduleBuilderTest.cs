using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	[TestFixture]
    public class ReminderScheduleBuilderTest
    {
		[Test]
		public void BuildWithStringConstructor()
		{
			String packageId = "myPackageId";
			ReminderScheduleBuilder builder = ReminderScheduleBuilder.ForPackageWithId(packageId);
			ReminderSchedule built = builder.Build();
			Assert.AreEqual(packageId, built.PackageId.Id);
		}

		[Test]
		public void BuildWithPackageIdConstructor()
		{
			PackageId packageId = new PackageId("myPackageId");
			ReminderScheduleBuilder builder = ReminderScheduleBuilder.ForPackageWithId(packageId);
			ReminderSchedule built = builder.Build();
			Assert.AreEqual(packageId, built.PackageId);
		}

		[Test]
		public void BuildWithDefaultValues()
		{
			ReminderScheduleBuilder builder = ReminderScheduleBuilder.ForPackageWithId("whoCares");
			ReminderSchedule built = builder.Build();
			Assert.AreEqual(ReminderScheduleBuilder.DEFAULT_DAYS_BETWEEN_REMINDERS, built.DaysBetweenReminders);
			Assert.AreEqual(ReminderScheduleBuilder.DEFAULT_DAYS_UNTIL_FIRST_REMINDER, built.DaysUntilFirstReminder);
			Assert.AreEqual(ReminderScheduleBuilder.DEFAULT_NUMBER_OF_REPETITIONS, built.NumberOfRepetitions);
		}

		[Test]
		public void BuildWithNonDefaultValues()
		{
			int daysBetweenReminders = 10;
			int daysUntilFirstReminder = 100;
			int numberOfRepetitions = 5;

			ReminderScheduleBuilder builder = ReminderScheduleBuilder.ForPackageWithId("whoCares")
				.WithDaysBetweenReminders(daysBetweenReminders)
				.WithDaysUntilFirstReminder(daysUntilFirstReminder)
				.WithNumberOfRepetitions(numberOfRepetitions);

			ReminderSchedule built = builder.Build();
			Assert.AreEqual(daysBetweenReminders, built.DaysBetweenReminders);
			Assert.AreEqual(daysUntilFirstReminder, built.DaysUntilFirstReminder);
			Assert.AreEqual(numberOfRepetitions, built.NumberOfRepetitions);
		}
    }
}

