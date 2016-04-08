using System;

namespace Silanis.ESL.SDK
{
    public class DelegationEventReportConverter
    {
        private Silanis.ESL.SDK.DelegationEventReport sdkDelegationEventReport = null;
        private Silanis.ESL.API.DelegationEventReport apiDelegationEventReport = null;

        public DelegationEventReportConverter(Silanis.ESL.SDK.DelegationEventReport sdkDelegationEventReport)
        {
            this.sdkDelegationEventReport = sdkDelegationEventReport;
        }

        internal DelegationEventReportConverter(Silanis.ESL.API.DelegationEventReport apiDelegationEventReport)
        {
            this.apiDelegationEventReport = apiDelegationEventReport;
        }

        internal Silanis.ESL.API.DelegationEventReport ToAPIDelegationEventReport()
        {
            if (sdkDelegationEventReport == null)
            {
                return apiDelegationEventReport;
            }

            var result = new Silanis.ESL.API.DelegationEventReport();

            result.EventDate = sdkDelegationEventReport.EventDate;
            result.EventDescription = sdkDelegationEventReport.EventDescription;
            result.EventType = sdkDelegationEventReport.EventType;
            result.EventUser = sdkDelegationEventReport.EventUser;

            return result;
        }

        public Silanis.ESL.SDK.DelegationEventReport ToSDKDelegationEventReport()
        {
            if (apiDelegationEventReport == null)
            {
                return sdkDelegationEventReport;
            }

            var result = new Silanis.ESL.SDK.DelegationEventReport();

            result.EventDate = apiDelegationEventReport.EventDate;
            result.EventDescription = apiDelegationEventReport.EventDescription;
            result.EventType = apiDelegationEventReport.EventType;
            result.EventUser = apiDelegationEventReport.EventUser;

            return result;
        }
    }
}

