using System;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    internal class QRCodeApiClient
    {
        private UrlTemplate template;
        private RestClient restClient;
        private JsonSerializerSettings settings;

        public QRCodeApiClient(RestClient restClient, string baseUrl, JsonSerializerSettings settings)
        {
            template = new UrlTemplate(baseUrl);
            this.restClient = restClient;
            this.settings = settings;
        }
            
        public string AddQRCode(string packageId, string documentId, API.Field apiField)
        {
            var path = template.UrlFor(UrlTemplate.QRCODE_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Build();

            var json = JsonConvert.SerializeObject(apiField, settings);

            try
            {
                var response = restClient.Post(path, json);
                var result = JsonConvert.DeserializeObject<API.Field>(response, settings);
                return result.Id;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not add QR code to document." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not add QR code to document." + " Exception: " + e.Message, e);
            }
        }

        public void ModifyQRCode(string packageId, string documentId, API.Field apiField)
        {
            var path = template.UrlFor(UrlTemplate.QRCODE_ID_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Replace("{fieldId}", apiField.Id)
                .Build();

            var json = JsonConvert.SerializeObject(apiField, settings);

            try
            {
                restClient.Put(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not modify QR code in document." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not modify QR code in document." + " Exception: " + e.Message, e);
            }
        }

        public API.Field GetQRCode(string packageId, string documentId, string fieldId)
        {
            var path = template.UrlFor(UrlTemplate.QRCODE_ID_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Replace("{fieldId}", fieldId)
                .Build();

            try
            {
                var response = restClient.Get(path);
                return JsonConvert.DeserializeObject<API.Field>(response, settings);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get QR code from document." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get QR code from document." + " Exception: " + e.Message, e);
            }
        }

        public void DeleteQRCode(string packageId, string documentId, string fieldId)
        {
            var path = template.UrlFor(UrlTemplate.QRCODE_ID_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Replace("{fieldId}", fieldId)
                .Build();

            try
            {
                restClient.Delete(path);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not delete QR code from document." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not delete QR code from document." + " Exception: " + e.Message, e);
            }
        }

        public void UpdateQRCodes(string packageId, string documentId, IList<API.Field> qrCodeList)
        {
            var path = template.UrlFor(UrlTemplate.QRCODE_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Build();

            try
            {
                var json = JsonConvert.SerializeObject (qrCodeList, settings);
                restClient.Put(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not update QR codes in document." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not update QR codes in document." + " Exception: " + e.Message, e);
            }
        }
    }
}

