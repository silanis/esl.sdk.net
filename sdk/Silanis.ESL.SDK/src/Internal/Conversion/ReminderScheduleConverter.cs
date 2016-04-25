using System;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
	internal class ReminderScheduleConverter
    {
		private PackageReminderSchedule api;
		private ReminderSchedule sdk;

		public ReminderScheduleConverter( PackageReminderSchedule api )
        {
			this.api = api;
			this.sdk = null;
        }

		public ReminderScheduleConverter( ReminderSchedule sdk )
		{
			this.api = null;
			this.sdk = sdk;
		}

		public PackageReminderSchedule ToAPIPackageReminderSchedule()
		{
			if (api != null)
			{
				return api;
			}
			else
			{
				PackageReminderSchedule result = new PackageReminderSchedule();
				if (sdk.PackageId != null)
				{
					result.PackageId = sdk.PackageId.Id;
				}
				else
				{
					result.PackageId = "";
				}

				result.StartInDaysDelay = sdk.DaysUntilFirstReminder;
				result.IntervalInDays = sdk.DaysBetweenReminders;
				result.RepetitionsCount = sdk.NumberOfRepetitions;

				foreach ( Reminder sdkReminder in sdk.Reminders )
				{
					result.Reminders.Add(new ReminderConverter(sdkReminder).ToAPIPackageReminder());
				}
				return result;
			}
		}

		public ReminderSchedule ToSDKReminderSchedule()
		{
			if (sdk != null)
			{
				return sdk;
			}
			else
			{
				ReminderSchedule result = new ReminderSchedule();
				if (api.PackageId != null && !api.PackageId.Equals(""))
				{
					result.PackageId = new PackageId(api.PackageId);
				}
                if (api.StartInDaysDelay.HasValue)
				    result.DaysUntilFirstReminder = api.StartInDaysDelay.Value;
                if (api.IntervalInDays.HasValue)
				    result.DaysBetweenReminders = api.IntervalInDays.Value;
                if (api.RepetitionsCount.HasValue)
				    result.NumberOfRepetitions = api.RepetitionsCount.Value;

				foreach (PackageReminder apiReminder in api.Reminders)
				{
					result.Reminders.Add(new ReminderConverter(apiReminder).ToSDKReminder());
				}
				return result;
			}
		}
    }
}

