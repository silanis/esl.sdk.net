using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK.Services
{
    public class ReminderService
    {
        private ReminderApiClient apiClient;
		internal ReminderService(ReminderApiClient apiClient)
		{   
            this.apiClient = apiClient;
		}

		public ReminderSchedule GetReminderScheduleForPackage( PackageId packageId )
		{
            PackageReminderSchedule apiResponse = apiClient.GetReminderScheduleForPackage(packageId.Id);
            if (null == apiResponse) 
            {
                return null;
            }
            ReminderSchedule sdkReminderSchedule = new ReminderScheduleConverter( apiResponse ).ToSDKReminderSchedule();
            return sdkReminderSchedule;
		}

        [Obsolete("Please use CreateReminderScheduleForPackage(ReminderSchedule) instead")]    
		public ReminderSchedule SetReminderScheduleForPackage( ReminderSchedule reminderSchedule )
		{
            return CreateReminderScheduleForPackage(reminderSchedule);
		}

        public ReminderSchedule CreateReminderScheduleForPackage( ReminderSchedule reminderSchedule )
        {
            PackageReminderSchedule apiPayload = new ReminderScheduleConverter(reminderSchedule).ToAPIPackageReminderSchedule();
            PackageReminderSchedule apiResponse = apiClient.CreateReminderScheduleForPackage(apiPayload);
            return new ReminderScheduleConverter( apiResponse ).ToSDKReminderSchedule();
        }

        public ReminderSchedule UpdateReminderScheduleForPackage( ReminderSchedule reminderSchedule )
        {
            PackageReminderSchedule apiPayload = new ReminderScheduleConverter(reminderSchedule).ToAPIPackageReminderSchedule();
            PackageReminderSchedule apiResponse = apiClient.UpdateReminderScheduleForPackage(apiPayload);
            return new ReminderScheduleConverter( apiResponse ).ToSDKReminderSchedule();
        }

		public void ClearReminderScheduleForPackage( PackageId packageId )
		{
            apiClient.ClearReminderScheduleForPackage(packageId.Id);
		}
    }
}

