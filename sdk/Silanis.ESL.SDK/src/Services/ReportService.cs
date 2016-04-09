using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK.Services
{
    public class ReportService
    {
        private UrlTemplate template;
        private JsonSerializerSettings settings;
        private RestClient restClient;

        public ReportService(RestClient restClient, string baseUrl, JsonSerializerSettings settings)
        {
            this.restClient = restClient;
            template = new UrlTemplate(baseUrl);
            this.settings = settings;
        }

        private string BuildCompletionReportUrl(DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            var toDate = DateHelper.dateToIsoUtcFormat(to);
            var fromDate = DateHelper.dateToIsoUtcFormat(from);

            return template.UrlFor(UrlTemplate.COMPLETION_REPORT_PATH)
                .Replace("{from}", fromDate)
                    .Replace("{to}", toDate)
                    .Replace("{status}", new PackageStatusConverter(packageStatus).ToAPIPackageStatus())
                    .Replace("{senderId}", senderId)
                    .Build();
        }

        private string BuildCompletionReportUrl(DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            var toDate = DateHelper.dateToIsoUtcFormat(to);
            var fromDate = DateHelper.dateToIsoUtcFormat(from);

            return template.UrlFor(UrlTemplate.COMPLETION_REPORT_FOR_ALL_SENDERS_PATH)
                .Replace("{from}", fromDate)
                    .Replace("{to}", toDate)
                    .Replace("{status}", new PackageStatusConverter(packageStatus).ToAPIPackageStatus())
                    .Build();
        }

        private string BuildUsageReportUrl(DateTime from, DateTime to)
        {
            var toDate = DateHelper.dateToIsoUtcFormat(to);
            var fromDate = DateHelper.dateToIsoUtcFormat(from);

            return template.UrlFor(UrlTemplate.USAGE_REPORT_PATH)
                .Replace("{from}", fromDate)
                    .Replace("{to}", toDate)
                    .Build(); 
        }

        private string BuildDelegationReportUrl()
        {
            return template.UrlFor(UrlTemplate.DELEGATION_REPORT_PATH)
                    .Build(); 
        }

        private string BuildDelegationReportUrl(DateTime from, DateTime to)
        {
            var toDate = DateHelper.dateToIsoUtcFormat(to);
            var fromDate = DateHelper.dateToIsoUtcFormat(from);

            return template.UrlFor(UrlTemplate.DELEGATION_REPORT_PATH).Build() + "?from={from}&to={to}"
                    .Replace("{from}", fromDate)
                    .Replace("{to}", toDate); 
        }

        private string BuildDelegationReportUrl(string senderId, DateTime from, DateTime to)
        {
            var toDate = DateHelper.dateToIsoUtcFormat(to);
            var fromDate = DateHelper.dateToIsoUtcFormat(from);

            return template.UrlFor(UrlTemplate.DELEGATION_REPORT_PATH).Build() + "?senderId={senderId}&from={from}&to={to}"
                .Replace("{senderId}", senderId)
                .Replace("{from}", fromDate)
                .Replace("{to}", toDate); 
        }

        public CompletionReport DownloadCompletionReport(DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            try
            {
                var path = BuildCompletionReportUrl(packageStatus, senderId, from, to);
                var response = restClient.Get(path);
                var apiCompletionReport = JsonConvert.DeserializeObject<API.CompletionReport>(response, settings);
                return new CompletionReportConverter(apiCompletionReport).ToSDKCompletionReport();
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the completion report." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the completion report." + " Exception: " + e.Message, e);
            }
        }

        public string DownloadCompletionReportAsCSV(DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            try
            {
                var path = BuildCompletionReportUrl(packageStatus, senderId, from, to);
                var response = restClient.Get(path, "text/csv");
                return response;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the completion report in csv." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the completion report in csv." + " Exception: " + e.Message, e);
            }
        }

        public CompletionReport DownloadCompletionReport(DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            try
            {
                var path = BuildCompletionReportUrl(packageStatus, from, to);
                var response = restClient.Get(path);
                var apiCompletionReport = JsonConvert.DeserializeObject<API.CompletionReport>(response, settings);
                return new CompletionReportConverter(apiCompletionReport).ToSDKCompletionReport();
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the completion report." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the completion report." + " Exception: " + e.Message, e);
            }
        }

        public string DownloadCompletionReportAsCSV(DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            try
            {
                var path = BuildCompletionReportUrl(packageStatus, from, to);
                var response = restClient.Get(path, "text/csv");
                return response;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the completion report in csv." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the completion report in csv." + " Exception: " + e.Message, e);
            }
        }

        public UsageReport DownloadUsageReport(DateTime from, DateTime to)
        {
            var path = BuildUsageReportUrl(from, to);

            try
            {
                var response = restClient.Get(path);
                var apiUsageReport = JsonConvert.DeserializeObject<API.UsageReport>(response, settings);
                return new UsageReportConverter(apiUsageReport).ToSDKUsageReport();
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the usage report." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the usage report." + " Exception: " + e.Message, e);
            }
        }

        public string DownloadUsageReportAsCSV(DateTime from, DateTime to)
        {
            var path = BuildUsageReportUrl(from, to);

            try
            {
                var response = restClient.Get(path, "text/csv");
                return response;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the usage report in csv." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the usage report in csv." + " Exception: " + e.Message, e);
            }
        }

        public DelegationReport DownloadDelegationReport()
        {
            try
            {
                var path = BuildDelegationReportUrl();
                var response = restClient.Get(path);
                var apiDelegationReport = JsonConvert.DeserializeObject<API.DelegationReport>(response, settings);
                return new DelegationReportConverter(apiDelegationReport).ToSDKDelegationReport();
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the delegation report." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the delegation report." + " Exception: " + e.Message, e);
            }
        }

        public DelegationReport DownloadDelegationReport(DateTime from, DateTime to)
        {
            try
            {
                var path = BuildDelegationReportUrl(from, to);
                var response = restClient.Get(path);
                var apiDelegationReport = JsonConvert.DeserializeObject<API.DelegationReport>(response, settings);
                return new DelegationReportConverter(apiDelegationReport).ToSDKDelegationReport();
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the delegation report." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the delegation report." + " Exception: " + e.Message, e);
            }
        }

        public DelegationReport DownloadDelegationReport(string senderId, DateTime from, DateTime to)
        {
            try
            {
                var path = BuildDelegationReportUrl(senderId, from, to);
                var response = restClient.Get(path);
                var apiDelegationReport = JsonConvert.DeserializeObject<API.DelegationReport>(response, settings);
                return new DelegationReportConverter(apiDelegationReport).ToSDKDelegationReport();
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the delegation report." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the delegation report." + " Exception: " + e.Message, e);
            }
        }

        public string DownloadDelegationReportAsCSV()
        {
            try
            {
                var path = BuildDelegationReportUrl();
                var response = restClient.Get(path, "text/csv");
                return response;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the delegation report in csv." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the delegation report in csv." + " Exception: " + e.Message, e);
            }
        }

        public string DownloadDelegationReportAsCSV(DateTime from, DateTime to)
        {
            try
            {
                var path = BuildDelegationReportUrl(from, to);
                var response = restClient.Get(path, "text/csv");
                return response;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the delegation report in csv." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the delegation report in csv." + " Exception: " + e.Message, e);
            }
        }

        public string DownloadDelegationReportAsCSV(string senderId, DateTime from, DateTime to)
        {
            try
            {
                var path = BuildDelegationReportUrl(senderId, from, to);
                var response = restClient.Get(path, "text/csv");
                return response;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the delegation report in csv." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the delegation report in csv." + " Exception: " + e.Message, e);
            }
        }

    }
}

