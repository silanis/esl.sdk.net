using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
    internal class ReminderApiClient
    {
        private UrlTemplate template;
        private JsonSerializerSettings settings;
        private RestClient restClient;

        public ReminderApiClient(RestClient restClient, string baseUrl, JsonSerializerSettings settings)
        {
            this.restClient = restClient;
            template = new UrlTemplate (baseUrl);
            this.settings = settings;
        }
        
        private string Path( string packageId )
        {
            return template.UrlFor (UrlTemplate.REMINDER_PATH)
                .Replace( "{packageId}", packageId )
                .Build ();
        }
        
        public PackageReminderSchedule GetReminderScheduleForPackage( string packageId )
        {
            try {
                var response = restClient.Get(Path(packageId));
                if (response.Length == 0) {
                    return null;
                }
                var apiResponse = JsonConvert.DeserializeObject<PackageReminderSchedule> (response, settings );
                return apiResponse;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to retrieve reminder schedule for package with id: " + packageId + ". Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to retrieve reminder schedule for package with id: " + packageId + ". Exception: " + e.Message, e);
            }
        }

        [Obsolete("Please use CreateReminderScheduleForPackage(ReminderSchedule) instead")]  
        public PackageReminderSchedule SetReminderScheduleForPackage( PackageReminderSchedule apiPayload )
        {
            return CreateReminderScheduleForPackage(apiPayload);
        }

        public PackageReminderSchedule CreateReminderScheduleForPackage( PackageReminderSchedule apiPayload )
        {
            try {
                var response = restClient.Post(Path(apiPayload.PackageId), JsonConvert.SerializeObject (apiPayload, settings));
                var apiResponse = JsonConvert.DeserializeObject<PackageReminderSchedule> (response, settings );
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to create reminder schedule for package with id: " + apiPayload.PackageId + ". Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to create reminder schedule for package with id: " + apiPayload.PackageId + ". Exception: " + e.Message, e);
            }
        }

        public PackageReminderSchedule UpdateReminderScheduleForPackage( PackageReminderSchedule apiPayload )
        {
            try {
                var response = restClient.Put(Path(apiPayload.PackageId), JsonConvert.SerializeObject (apiPayload, settings));
                var apiResponse = JsonConvert.DeserializeObject<PackageReminderSchedule> (response, settings );
                return apiResponse;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Failed to update reminder schedule for package with id: " + apiPayload.PackageId + ". Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to update reminder schedule for package with id: " + apiPayload.PackageId + ". Exception: " + e.Message, e);
            }
        }

        public void ClearReminderScheduleForPackage( string packageId )
        {
            try {
                restClient.Delete(Path(packageId));
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Failed to remove reminder schedule for package with id: " + packageId + ". Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Failed to remove reminder schedule for package with id: " + packageId + ". Exception: " + e.Message, e);
            }
        }
    }
}

