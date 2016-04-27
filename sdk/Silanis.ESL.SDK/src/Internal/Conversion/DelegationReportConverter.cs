using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class DelegationReportConverter
    {
        private DelegationReport sdkDelegationReport = null;
        private API.DelegationReport apiDelegationReport = null;

        public DelegationReportConverter(DelegationReport sdkDelegationReport)
        {
            this.sdkDelegationReport = sdkDelegationReport;
        }

        internal DelegationReportConverter(API.DelegationReport apiDelegationReport)
        {
            this.apiDelegationReport = apiDelegationReport;
        }

        internal API.DelegationReport ToAPIDelegationReport()
        {
            if (sdkDelegationReport == null)
            {
                return apiDelegationReport;
            }

            var result = new API.DelegationReport();

            result.From = sdkDelegationReport.From;
            result.To = sdkDelegationReport.To;

            foreach(var sdkDelegationEventDictionary in sdkDelegationReport.DelegationEvents) 
            {
                result.DelegationEvents.Add(sdkDelegationEventDictionary.Key, GetAPIDelegationEventList(sdkDelegationEventDictionary.Value));
            }

            return result;
        }

        private IList<API.DelegationEventReport> GetAPIDelegationEventList(IList<DelegationEventReport> sdkDelegationEventList) 
        {
            IList<API.DelegationEventReport> apiDelegationEventList = new List<API.DelegationEventReport>();
            foreach(var sdkDelegationEventReport in sdkDelegationEventList) 
            {
                apiDelegationEventList.Add(new DelegationEventReportConverter(sdkDelegationEventReport).ToAPIDelegationEventReport());
            }
            return apiDelegationEventList;
        }

        public DelegationReport ToSDKDelegationReport()
        {
            if (apiDelegationReport == null)
            {
                return sdkDelegationReport;
            }

            var result = new DelegationReport();

            result.From = apiDelegationReport.From;
            result.To = apiDelegationReport.To;

            foreach(var apiDelegationEventDictionary in apiDelegationReport.DelegationEvents) 
            {
                result.DelegationEvents.Add(apiDelegationEventDictionary.Key, GetSDKDelegationEventList(apiDelegationEventDictionary.Value));
            }

            return result;
        }

        private IList<DelegationEventReport> GetSDKDelegationEventList(IList<API.DelegationEventReport> apiDelegationEventList) 
        {
            IList<DelegationEventReport> sdkDelegationEventList = new List<DelegationEventReport>();
            foreach(var apiDelegationEventReport in apiDelegationEventList) 
            {
                sdkDelegationEventList.Add(new DelegationEventReportConverter(apiDelegationEventReport).ToSDKDelegationEventReport());
            }
            return sdkDelegationEventList;
        }
    }
}

