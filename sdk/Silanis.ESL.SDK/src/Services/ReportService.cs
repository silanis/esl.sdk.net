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

        private string BuildCompletionReportUrl(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            string toDate = DateHelper.dateToIsoUtcFormat(to);
            string fromDate = DateHelper.dateToIsoUtcFormat(from);

            return template.UrlFor(UrlTemplate.COMPLETION_REPORT_PATH)
                .Replace("{from}", fromDate)
                    .Replace("{to}", toDate)
                    .Replace("{status}", new PackageStatusConverter(packageStatus).ToAPIPackageStatus())
                    .Replace("{senderId}", senderId)
                    .Build();
        }

        private string BuildCompletionReportUrl(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            string toDate = DateHelper.dateToIsoUtcFormat(to);
            string fromDate = DateHelper.dateToIsoUtcFormat(from);

            return template.UrlFor(UrlTemplate.COMPLETION_REPORT_FOR_ALL_SENDERS_PATH)
                .Replace("{from}", fromDate)
                    .Replace("{to}", toDate)
                    .Replace("{status}", new PackageStatusConverter(packageStatus).ToAPIPackageStatus())
                    .Build();
        }

        private string BuildUsageReportUrl(DateTime from, DateTime to)
        {
            string toDate = DateHelper.dateToIsoUtcFormat(to);
            string fromDate = DateHelper.dateToIsoUtcFormat(from);

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
            string toDate = DateHelper.dateToIsoUtcFormat(to);
            string fromDate = DateHelper.dateToIsoUtcFormat(from);

            return template.UrlFor(UrlTemplate.DELEGATION_REPORT_PATH).Build() + "?from={from}&to={to}"
                    .Replace("{from}", fromDate)
                    .Replace("{to}", toDate); 
        }

        private string BuildDelegationReportUrl(string senderId, DateTime from, DateTime to)
        {
            string toDate = DateHelper.dateToIsoUtcFormat(to);
            string fromDate = DateHelper.dateToIsoUtcFormat(from);

            return template.UrlFor(UrlTemplate.DELEGATION_REPORT_PATH).Build() + "?senderId={senderId}&from={from}&to={to}"
                .Replace("{senderId}", senderId)
                .Replace("{from}", fromDate)
                .Replace("{to}", toDate); 
        }

        public Silanis.ESL.SDK.CompletionReport DownloadCompletionReport(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            try
            {
                string path = BuildCompletionReportUrl(packageStatus, senderId, from, to);
                string response = restClient.Get(path);
                Silanis.ESL.API.CompletionReport apiCompletionReport = JsonConvert.DeserializeObject<Silanis.ESL.API.CompletionReport>(response, settings);
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

        public string DownloadCompletionReportAsCSV(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            try
            {
                string path = BuildCompletionReportUrl(packageStatus, senderId, from, to);
                string response = restClient.Get(path, "text/csv");
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

        public Silanis.ESL.SDK.CompletionReport DownloadCompletionReport(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            try
            {
                string path = BuildCompletionReportUrl(packageStatus, from, to);
                string response = restClient.Get(path);
                Silanis.ESL.API.CompletionReport apiCompletionReport = JsonConvert.DeserializeObject<Silanis.ESL.API.CompletionReport>(response, settings);
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

        public string DownloadCompletionReportAsCSV(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            try
            {
                string path = BuildCompletionReportUrl(packageStatus, from, to);
                string response = restClient.Get(path, "text/csv");
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

        public Silanis.ESL.SDK.UsageReport DownloadUsageReport(DateTime from, DateTime to)
        {
            string path = BuildUsageReportUrl(from, to);

            try
            {
                string response = restClient.Get(path);
                Silanis.ESL.API.UsageReport apiUsageReport = JsonConvert.DeserializeObject<Silanis.ESL.API.UsageReport>(response, settings);
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
            string path = BuildUsageReportUrl(from, to);

            try
            {
                string response = restClient.Get(path, "text/csv");
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

        public Silanis.ESL.SDK.DelegationReport DownloadDelegationReport()
        {
            try
            {
                string path = BuildDelegationReportUrl();
                string response = restClient.Get(path);
                Silanis.ESL.API.DelegationReport apiDelegationReport = JsonConvert.DeserializeObject<Silanis.ESL.API.DelegationReport>(response, settings);
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

        public Silanis.ESL.SDK.DelegationReport DownloadDelegationReport(DateTime from, DateTime to)
        {
            try
            {
                string path = BuildDelegationReportUrl(from, to);
                string response = restClient.Get(path);
                Silanis.ESL.API.DelegationReport apiDelegationReport = JsonConvert.DeserializeObject<Silanis.ESL.API.DelegationReport>(response, settings);
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

        public Silanis.ESL.SDK.DelegationReport DownloadDelegationReport(string senderId, DateTime from, DateTime to)
        {
            try
            {
                string path = BuildDelegationReportUrl(senderId, from, to);
                string response = restClient.Get(path);
                Silanis.ESL.API.DelegationReport apiDelegationReport = JsonConvert.DeserializeObject<Silanis.ESL.API.DelegationReport>(response, settings);
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
                string path = BuildDelegationReportUrl();
                string response = restClient.Get(path, "text/csv");
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
                string path = BuildDelegationReportUrl(from, to);
                string response = restClient.Get(path, "text/csv");
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
                string path = BuildDelegationReportUrl(senderId, from, to);
                string response = restClient.Get(path, "text/csv");
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

