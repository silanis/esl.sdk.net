using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	[TestClass]
    public class ReminderScheduleBuilderTest
    {
		[TestMethod]
		public void BuildWithStringConstructor()
		{
			var packageId = "myPackageId";
			var builder = ReminderScheduleBuilder.ForPackageWithId(packageId);
			var built = builder.Build();
			Assert.AreEqual(packageId, built.PackageId.Id);
		}

		[TestMethod]
		public void BuildWithPackageIdConstructor()
		{
			var packageId = new PackageId("myPackageId");
			var builder = ReminderScheduleBuilder.ForPackageWithId(packageId);
			var built = builder.Build();
			Assert.AreEqual(packageId, built.PackageId);
		}

		[TestMethod]
		public void BuildWithDefaultValues()
		{
			var builder = ReminderScheduleBuilder.ForPackageWithId("whoCares");
			var built = builder.Build();
			Assert.AreEqual(ReminderScheduleBuilder.DEFAULT_DAYS_BETWEEN_REMINDERS, built.DaysBetweenReminders);
			Assert.AreEqual(ReminderScheduleBuilder.DEFAULT_DAYS_UNTIL_FIRST_REMINDER, built.DaysUntilFirstReminder);
			Assert.AreEqual(ReminderScheduleBuilder.DEFAULT_NUMBER_OF_REPETITIONS, built.NumberOfRepetitions);
		}

		[TestMethod]
		public void BuildWithNonDefaultValues()
		{
			var daysBetweenReminders = 10;
			var daysUntilFirstReminder = 100;
			var numberOfRepetitions = 5;

			var builder = ReminderScheduleBuilder.ForPackageWithId("whoCares")
				.WithDaysBetweenReminders(daysBetweenReminders)
				.WithDaysUntilFirstReminder(daysUntilFirstReminder)
				.WithNumberOfRepetitions(numberOfRepetitions);

			var built = builder.Build();
			Assert.AreEqual(daysBetweenReminders, built.DaysBetweenReminders);
			Assert.AreEqual(daysUntilFirstReminder, built.DaysUntilFirstReminder);
			Assert.AreEqual(numberOfRepetitions, built.NumberOfRepetitions);
		}
    }
}

