using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class DelegationReportConverter
    {
        private Silanis.ESL.SDK.DelegationReport sdkDelegationReport = null;
        private Silanis.ESL.API.DelegationReport apiDelegationReport = null;

        public DelegationReportConverter(Silanis.ESL.SDK.DelegationReport sdkDelegationReport)
        {
            this.sdkDelegationReport = sdkDelegationReport;
        }

        internal DelegationReportConverter(Silanis.ESL.API.DelegationReport apiDelegationReport)
        {
            this.apiDelegationReport = apiDelegationReport;
        }

        internal Silanis.ESL.API.DelegationReport ToAPIDelegationReport()
        {
            if (sdkDelegationReport == null)
            {
                return apiDelegationReport;
            }

            Silanis.ESL.API.DelegationReport result = new Silanis.ESL.API.DelegationReport();

            result.From = sdkDelegationReport.From;
            result.To = sdkDelegationReport.To;

            foreach(KeyValuePair<string, IList<DelegationEventReport>> sdkDelegationEventDictionary in sdkDelegationReport.DelegationEvents) 
            {
                result.DelegationEvents.Add(sdkDelegationEventDictionary.Key, GetAPIDelegationEventList(sdkDelegationEventDictionary.Value));
            }

            return result;
        }

        private IList<Silanis.ESL.API.DelegationEventReport> GetAPIDelegationEventList(IList<Silanis.ESL.SDK.DelegationEventReport> sdkDelegationEventList) 
        {
            IList<Silanis.ESL.API.DelegationEventReport> apiDelegationEventList = new List<Silanis.ESL.API.DelegationEventReport>();
            foreach(Silanis.ESL.SDK.DelegationEventReport sdkDelegationEventReport in sdkDelegationEventList) 
            {
                apiDelegationEventList.Add(new DelegationEventReportConverter(sdkDelegationEventReport).ToAPIDelegationEventReport());
            }
            return apiDelegationEventList;
        }

        public Silanis.ESL.SDK.DelegationReport ToSDKDelegationReport()
        {
            if (apiDelegationReport == null)
            {
                return sdkDelegationReport;
            }

            Silanis.ESL.SDK.DelegationReport result = new Silanis.ESL.SDK.DelegationReport();

            result.From = apiDelegationReport.From;
            result.To = apiDelegationReport.To;

            foreach(KeyValuePair<string, IList<Silanis.ESL.API.DelegationEventReport>> apiDelegationEventDictionary in apiDelegationReport.DelegationEvents) 
            {
                result.DelegationEvents.Add(apiDelegationEventDictionary.Key, GetSDKDelegationEventList(apiDelegationEventDictionary.Value));
            }

            return result;
        }

        private IList<Silanis.ESL.SDK.DelegationEventReport> GetSDKDelegationEventList(IList<Silanis.ESL.API.DelegationEventReport> apiDelegationEventList) 
        {
            IList<Silanis.ESL.SDK.DelegationEventReport> sdkDelegationEventList = new List<Silanis.ESL.SDK.DelegationEventReport>();
            foreach(Silanis.ESL.API.DelegationEventReport apiDelegationEventReport in apiDelegationEventList) 
            {
                sdkDelegationEventList.Add(new DelegationEventReportConverter(apiDelegationEventReport).ToSDKDelegationEventReport());
            }
            return sdkDelegationEventList;
        }
    }
}

