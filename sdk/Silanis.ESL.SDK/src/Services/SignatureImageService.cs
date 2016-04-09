using System;
using Silanis.ESL.SDK.Internal;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
    public class SignatureImageService
    {
        private UrlTemplate template;
        private JsonSerializerSettings settings;
        private RestClient client;

        public SignatureImageService(RestClient client, string baseUrl, JsonSerializerSettings settings)
        {
            this.client = client;
            template = new UrlTemplate(baseUrl);
            this.settings = settings;
        }

        public DownloadedFile GetSignatureImageForSender(string senderId, SignatureImageFormat format) 
        {
            var path = template.UrlFor( UrlTemplate.SIGNATURE_IMAGE_FOR_SENDER_PATH)
                .Replace("{senderId}", senderId)
                .Build();
            try 
            {
                return client.GetBytes(path, AcceptType(format));
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download signature image for sender." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download signature image for sender." + " Exception: " + e.Message, e);
            }
        }

        public DownloadedFile GetSignatureImageForPackageRole(PackageId packageId, string signerId, SignatureImageFormat format) 
        {
            var path = template.UrlFor(UrlTemplate.SIGNATURE_IMAGE_FOR_PACKAGE_ROLE_PATH)
                .Replace("{packageId}", packageId.Id)
                .Replace("{roleId}", signerId)
                .Build();
            try 
            {
                return client.GetBytes(path, AcceptType(format));
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download signature image for package signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download signature image for package signer." + " Exception: " + e.Message, e);
            }
        }

        private string AcceptType(SignatureImageFormat format)
        {
            switch (format)
            {
                case SignatureImageFormat.PNG:
                    return "image/png";
                case SignatureImageFormat.JPG:
                    return "image/jpeg";
                case SignatureImageFormat.GIF:
                    return "image/gif";
                default:
                    throw new EslException("Unknown SignatureImageFormat: " + format, null);
            }
        }
    }
}

