using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class ReminderSchedule
    {
		private PackageId packageId;
		private int daysUntilFirstReminder;
		private int daysBetweenReminders;
		private int numberOfRepetitions;
		private List<Reminder> reminders;

        public ReminderSchedule()
        {
			reminders = new List<Reminder>();
        }

		public PackageId PackageId
		{
			get
			{
				return packageId;
			}
			set
			{
				packageId = value;
			}
		}

		public int DaysUntilFirstReminder
		{
			get
			{
				return daysUntilFirstReminder;
			}
			set
			{
				daysUntilFirstReminder = value;
			}
		}

		public int DaysBetweenReminders
		{
			get
			{
				return daysBetweenReminders;
			}
			set
			{
				daysBetweenReminders = value;
			}
		}

		public int NumberOfRepetitions
		{
			get
			{
				return numberOfRepetitions;
			}
			set
			{
				numberOfRepetitions = value;
			}
		}

		public List<Reminder> Reminders
		{
			get
			{
				return reminders;
			}
			set
			{
				reminders = value;
			}
		}
    }
}

