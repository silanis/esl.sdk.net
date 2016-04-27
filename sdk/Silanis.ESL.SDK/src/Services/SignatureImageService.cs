using System;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class SignatureImageService
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _client;

        public SignatureImageService(RestClient client, string baseUrl)
        {
            _client = client;
            _template = new UrlTemplate(baseUrl);
        }

        public DownloadedFile GetSignatureImageForSender(string senderId, SignatureImageFormat format) 
        {
            var path = _template.UrlFor( UrlTemplate.SIGNATURE_IMAGE_FOR_SENDER_PATH)
                .Replace("{senderId}", senderId)
                .Build();
            try 
            {
                return _client.GetBytes(path, AcceptType(format));
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
            var path = _template.UrlFor(UrlTemplate.SIGNATURE_IMAGE_FOR_PACKAGE_ROLE_PATH)
                .Replace("{packageId}", packageId.Id)
                .Replace("{roleId}", signerId)
                .Build();
            try 
            {
                return _client.GetBytes(path, AcceptType(format));
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

