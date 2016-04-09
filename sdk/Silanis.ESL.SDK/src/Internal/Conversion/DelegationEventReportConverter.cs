namespace Silanis.ESL.SDK
{
    public class DelegationEventReportConverter
    {
        private DelegationEventReport sdkDelegationEventReport = null;
        private API.DelegationEventReport apiDelegationEventReport = null;

        public DelegationEventReportConverter(DelegationEventReport sdkDelegationEventReport)
        {
            this.sdkDelegationEventReport = sdkDelegationEventReport;
        }

        internal DelegationEventReportConverter(API.DelegationEventReport apiDelegationEventReport)
        {
            this.apiDelegationEventReport = apiDelegationEventReport;
        }

        internal API.DelegationEventReport ToAPIDelegationEventReport()
        {
            if (sdkDelegationEventReport == null)
            {
                return apiDelegationEventReport;
            }

            var result = new API.DelegationEventReport();

            result.EventDate = sdkDelegationEventReport.EventDate;
            result.EventDescription = sdkDelegationEventReport.EventDescription;
            result.EventType = sdkDelegationEventReport.EventType;
            result.EventUser = sdkDelegationEventReport.EventUser;

            return result;
        }

        public DelegationEventReport ToSDKDelegationEventReport()
        {
            if (apiDelegationEventReport == null)
            {
                return sdkDelegationEventReport;
            }

            var result = new DelegationEventReport();

            result.EventDate = apiDelegationEventReport.EventDate;
            result.EventDescription = apiDelegationEventReport.EventDescription;
            result.EventType = apiDelegationEventReport.EventType;
            result.EventUser = apiDelegationEventReport.EventUser;

            return result;
        }
    }
}

