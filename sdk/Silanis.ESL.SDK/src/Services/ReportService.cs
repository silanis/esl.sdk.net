using System;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK.Services
{
    public class ReportService
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _restClient;

        [Obsolete("Please use EslClient")]
        public ReportService(RestClient restClient, string baseUrl, JsonSerializerSettings jsonSerializerSettings)
        {
            Json.JsonSerializerSettings = jsonSerializerSettings;
            _restClient = restClient;
            _template = new UrlTemplate(baseUrl);
        }
        internal ReportService(RestClient restClient, string baseUrl)
        {
            _restClient = restClient;
            _template = new UrlTemplate(baseUrl);
        }

        private string BuildCompletionReportUrl(DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            var toDate = DateHelper.dateToIsoUtcFormat(to);
            var fromDate = DateHelper.dateToIsoUtcFormat(from);

            return _template.UrlFor(UrlTemplate.COMPLETION_REPORT_PATH)
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

            return _template.UrlFor(UrlTemplate.COMPLETION_REPORT_FOR_ALL_SENDERS_PATH)
                .Replace("{from}", fromDate)
                    .Replace("{to}", toDate)
                    .Replace("{status}", new PackageStatusConverter(packageStatus).ToAPIPackageStatus())
                    .Build();
        }

        private string BuildUsageReportUrl(DateTime from, DateTime to)
        {
            var toDate = DateHelper.dateToIsoUtcFormat(to);
            var fromDate = DateHelper.dateToIsoUtcFormat(from);

            return _template.UrlFor(UrlTemplate.USAGE_REPORT_PATH)
                .Replace("{from}", fromDate)
                    .Replace("{to}", toDate)
                    .Build(); 
        }

        private string BuildDelegationReportUrl()
        {
            return _template.UrlFor(UrlTemplate.DELEGATION_REPORT_PATH)
                    .Build(); 
        }

        private string BuildDelegationReportUrl(DateTime from, DateTime to)
        {
            var toDate = DateHelper.dateToIsoUtcFormat(to);
            var fromDate = DateHelper.dateToIsoUtcFormat(from);

            return _template.UrlFor(UrlTemplate.DELEGATION_REPORT_PATH).Build() + "?from={from}&to={to}"
                    .Replace("{from}", fromDate)
                    .Replace("{to}", toDate); 
        }

        private string BuildDelegationReportUrl(string senderId, DateTime from, DateTime to)
        {
            var toDate = DateHelper.dateToIsoUtcFormat(to);
            var fromDate = DateHelper.dateToIsoUtcFormat(from);

            return _template.UrlFor(UrlTemplate.DELEGATION_REPORT_PATH).Build() + "?senderId={senderId}&from={from}&to={to}"
                .Replace("{senderId}", senderId)
                .Replace("{from}", fromDate)
                .Replace("{to}", toDate); 
        }

        public CompletionReport DownloadCompletionReport(DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            try
            {
                var path = BuildCompletionReportUrl(packageStatus, senderId, from, to);
                var response = _restClient.Get(path);
                var apiCompletionReport = Json.DeserializeWithSettings<API.CompletionReport>(response);
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
                var response = _restClient.Get(path, "text/csv");
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
                var response = _restClient.Get(path);
                var apiCompletionReport = Json.DeserializeWithSettings<API.CompletionReport>(response);
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
                var response = _restClient.Get(path, "text/csv");
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
                var response = _restClient.Get(path);
                var apiUsageReport = Json.DeserializeWithSettings<API.UsageReport>(response);
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
                var response = _restClient.Get(path, "text/csv");
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
                var response = _restClient.Get(path);
                var apiDelegationReport = Json.DeserializeWithSettings<API.DelegationReport>(response);
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
                var response = _restClient.Get(path);
                var apiDelegationReport = Json.DeserializeWithSettings<API.DelegationReport>(response);
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
                var response = _restClient.Get(path);
                var apiDelegationReport = Json.DeserializeWithSettings<API.DelegationReport>(response);
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
                var response = _restClient.Get(path, "text/csv");
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
                var response = _restClient.Get(path, "text/csv");
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
                var response = _restClient.Get(path, "text/csv");
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

