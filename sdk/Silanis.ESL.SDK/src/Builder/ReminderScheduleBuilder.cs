using System;

namespace Silanis.ESL.SDK
{
    public class ReminderScheduleBuilder
    {
		public const int DEFAULT_DAYS_UNTIL_FIRST_REMINDER = 1;
		public const int DEFAULT_DAYS_BETWEEN_REMINDERS = 1;
		public const int DEFAULT_NUMBER_OF_REPETITIONS = 1;

		private PackageId packageId;
		private int daysUntilFirstReminder;
		private int daysBetweenReminders;
		private int numberOfRepetitions;

		public ReminderScheduleBuilder( PackageId packageId )
        {
			this.packageId = packageId;
			daysUntilFirstReminder = DEFAULT_DAYS_UNTIL_FIRST_REMINDER;
			daysBetweenReminders = DEFAULT_DAYS_BETWEEN_REMINDERS;
			numberOfRepetitions = DEFAULT_NUMBER_OF_REPETITIONS;
        }

		public static ReminderScheduleBuilder ForPackageWithId( String packageId )
		{
			return ForPackageWithId(new PackageId(packageId));
		}

		public static ReminderScheduleBuilder ForPackageWithId( PackageId packageId )
		{
			return new ReminderScheduleBuilder(packageId);
		}

		public ReminderScheduleBuilder WithDaysUntilFirstReminder( int daysUntilFirstReminder )
		{
			this.daysUntilFirstReminder = daysUntilFirstReminder;
			return this;
		}

		public ReminderScheduleBuilder WithDaysBetweenReminders( int daysBetweenReminders )
		{
			this.daysBetweenReminders = daysBetweenReminders;
			return this;
		}

		public ReminderScheduleBuilder WithNumberOfRepetitions( int numberOfRepetitions )
		{
			this.numberOfRepetitions = numberOfRepetitions;
			return this;
		}

		public ReminderSchedule Build()
		{
			var result = new ReminderSchedule();
			result.PackageId = packageId;
			result.DaysBetweenReminders = daysBetweenReminders;
			result.DaysUntilFirstReminder = daysUntilFirstReminder;
			result.NumberOfRepetitions = numberOfRepetitions;

			return result;
		}
    }
}

