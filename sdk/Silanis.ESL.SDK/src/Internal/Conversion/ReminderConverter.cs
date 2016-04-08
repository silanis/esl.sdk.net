using System;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
	internal class ReminderConverter
    {
		private PackageReminder apiReminder;
		private Reminder sdkReminder;

		public ReminderConverter( PackageReminder apiReminder )
        {
			this.apiReminder = apiReminder;
			this.sdkReminder = null;
        }

		public ReminderConverter( Reminder sdkReminder )
		{
			this.sdkReminder = sdkReminder;
			this.apiReminder = null;
		}

		public PackageReminder ToAPIPackageReminder()
		{
			if (apiReminder != null)
			{
				return apiReminder;
			}
			else
			{
				var result = new PackageReminder();
				result.Date = sdkReminder.Date;
				result.SentDate = sdkReminder.SentDate;

				return result;
			}
		}

		public Reminder ToSDKReminder()
		{
			if (sdkReminder != null)
			{
				return sdkReminder;
			}
			else
			{
				var result = new Reminder(apiReminder.Date.Value, apiReminder.SentDate);
				return result;
			}
		}
    }
}

