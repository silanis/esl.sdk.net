using System;
using Silanis.ESL.SDK.Internal;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    internal class QRCodeApiClient
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _restClient;

        public QRCodeApiClient(RestClient restClient, string baseUrl)
        {
            _template = new UrlTemplate(baseUrl);
            _restClient = restClient;
        }
            
        public string AddQRCode(string packageId, string documentId, API.Field apiField)
        {
            var path = _template.UrlFor(UrlTemplate.QRCODE_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Build();

            var json = Json.SerializeWithSettings(apiField);

            try
            {
                var response = _restClient.Post(path, json);
                var result = Json.DeserializeWithSettings<API.Field>(response);
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
            var path = _template.UrlFor(UrlTemplate.QRCODE_ID_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Replace("{fieldId}", apiField.Id)
                .Build();

            var json = Json.SerializeWithSettings(apiField);

            try
            {
                _restClient.Put(path, json);
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
            var path = _template.UrlFor(UrlTemplate.QRCODE_ID_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Replace("{fieldId}", fieldId)
                .Build();

            try
            {
                var response = _restClient.Get(path);
                return Json.DeserializeWithSettings<API.Field>(response);
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
            var path = _template.UrlFor(UrlTemplate.QRCODE_ID_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Replace("{fieldId}", fieldId)
                .Build();

            try
            {
                _restClient.Delete(path);
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
            var path = _template.UrlFor(UrlTemplate.QRCODE_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{documentId}", documentId)
                .Build();

            try
            {
                var json = Json.SerializeWithSettings(qrCodeList);
                _restClient.Put(path, json);
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

