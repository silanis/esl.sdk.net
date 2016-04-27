using System;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;
using System.Text;
using System.IO;

namespace Silanis.ESL.SDK
{
    internal class AttachmentRequirementApiClient
    {
        private readonly UrlTemplate _template;
        private readonly RestClient _restClient;

        public AttachmentRequirementApiClient(RestClient restClient, string apiUrl)
        {
            this._restClient = restClient;
            _template = new UrlTemplate (apiUrl);            
        }

        [Obsolete("AcceptAttachment() in AttachmentRequirementApiClient is deprecated, please use AcceptAttachment() in AttachmentRequirementService instead.")]
        public void AcceptAttachment(string packageId, Role role)
        {
            var path = _template.UrlFor(UrlTemplate.UPDATE_SIGNER_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{roleId}", role.Id)
                .Build();

            try 
            {
                var json = Json.SerializeWithSettings(role);
                _restClient.Put(path, json);
            } 
            catch (EslServerException e) 
            {
                throw new EslServerException("Could not accept attachment for signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) 
            {
                throw new EslException("Could not accept attachment for signer." + " Exception: " + e.Message,e);
            }
        }

        [Obsolete("RejectAttachment() in AttachmentRequirementApiClient is deprecated, please use RejectAttachment() in AttachmentRequirementService instead.")]
        public void RejectAttachment(string packageId, Role role)
        {
            var path = _template.UrlFor(UrlTemplate.UPDATE_SIGNER_PATH)
                .Replace("{packageId}", packageId)
                .Replace("{roleId}", role.Id)
                .Build();
                
            try 
            {
                var json = Json.SerializeWithSettings(role);
                _restClient.Put(path, json);              
            } 
            catch (EslServerException e) 
            {
                throw new EslServerException("Could not reject attachment for signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) 
            {
                throw new EslException("Could not reject attachment for signer." + " Exception: " + e.Message,e);
            }
        }

        [Obsolete("This method was replaced by DownloadAttachmentFile")]
        public byte[] DownloadAttachment(string packageId, string attachmentId)
        {
            return DownloadAttachmentFile(packageId, attachmentId).Contents;
        }

        public DownloadedFile DownloadAttachmentFile(string packageId, string attachmentId)
        {
            var path = _template.UrlFor(UrlTemplate.ATTACHMENT_REQUIREMENT_PATH)
                .Replace("{packageId}", packageId)
                    .Replace("{attachmentId}", attachmentId)
                    .Build();

            try 
            {
                return _restClient.GetBytes(path);
            }
            catch (EslServerException e) 
            {
                throw new EslServerException("Could not download the pdf attachment." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) 
            {
                throw new EslException("Could not download the pdf attachment." + " Exception: " + e.Message,e);
            }
        }

        [Obsolete("This method was replaced by DownloadAllAttachmentFilesForPackage")]
        public byte[] DownloadAllAttachmentsForPackage(string packageId)
        {
            return DownloadAllAttachmentFilesForPackage(packageId).Contents;
        }

        public DownloadedFile DownloadAllAttachmentFilesForPackage(string packageId)
        {
            var path = _template.UrlFor(UrlTemplate.ALL_ATTACHMENTS_PATH)
                .Replace("{packageId}", packageId)
                    .Build();

            try 
            {
                return _restClient.GetBytes(path);
            }
            catch (EslServerException e) 
            {
                throw new EslServerException("Could not download all attachments." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) 
            {
                throw new EslException("Could not download all attachments." + " Exception: " + e.Message,e);
            }
        }

        [Obsolete("This method was replaced by DownloadAllAttachmentFilesForSignerInPackage")]
        public byte[] DownloadAllAttachmentsForSignerInPackage(DocumentPackage sdkPackage, Signer signer)
        {
            return DownloadAllAttachmentFilesForSignerInPackage(sdkPackage, signer).Contents;
        }

        public DownloadedFile DownloadAllAttachmentFilesForSignerInPackage(DocumentPackage sdkPackage, Signer signer)
        {
            var apiPackage = new DocumentPackageConverter(sdkPackage).ToAPIPackage();
            var roleId = "";

            foreach(var role in apiPackage.Roles) 
            {
                foreach(var apiSigner in role.Signers) 
                {
                    if(signer.Email.Equals(apiSigner.Email)) 
                    {
                        roleId = role.Id;
                    }
                }
            }
            return DownloadAllAttachmentsForSignerInPackage(sdkPackage.Id.Id, roleId);
        }

        private DownloadedFile DownloadAllAttachmentsForSignerInPackage(string packageId, string roleId)
        {
            var path = _template.UrlFor(UrlTemplate.ALL_ATTACHMENTS_FOR_ROLE_PATH)
                .Replace("{packageId}", packageId)
                    .Replace("{roleId}", roleId)
                    .Build();

            try 
            {
                return _restClient.GetBytes(path);
            }
            catch (EslServerException e) 
            {
                throw new EslServerException("Could not download all attachments for the signer in the package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) 
            {
                throw new EslException("Could not download all attachments for the signer in the package." + " Exception: " + e.Message,e);
            }
        }

        public void UploadAttachment(PackageId packageId, string attachmentId, string fileName, byte[] fileBytes, string signerSessionId)
        {
            var client = new RestClient("");
            var path = _template.UrlFor(UrlTemplate.ATTACHMENT_REQUIREMENT_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{attachmentId}", attachmentId)
                    .Build();

            var boundary = GenerateBoundary();

            var bytes = new byte[fileName.Length * sizeof(char)];
            Buffer.BlockCopy(fileName.ToCharArray(), 0, bytes, 0, bytes.Length);

            var content = CreateMultipartContent(fileName, fileBytes, bytes, boundary);
            try {
                client.PostMultipartFile(path, content, boundary, signerSessionId, Converter.ToString(bytes));
            } catch (Exception e) {
                throw new EslException ("Could not upload attachment for signer." + " Exception: " + e.Message, e);
            }
        }

        private string GenerateBoundary ()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[16];
            var random = new Random ();

            for (var i = 0; i < stringChars.Length; i++) {
                stringChars [i] = chars [random.Next (chars.Length)];
            }

            return new String (stringChars);
        }  

        private byte[] CreateMultipartContent(string fileName, byte[] fileBytes, byte[] payloadBytes, string boundary)
        {

            var encoding = Encoding.UTF8;
            Stream formDataStream = new MemoryStream();

            var header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\n\r\n",
                                          boundary, "payload", "payload");
            formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));
            formDataStream.Write(payloadBytes, 0, payloadBytes.Length);

            formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

            var data = string.Format ("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                                         boundary, "file", fileName, MimeTypeUtil.GetMIMEType (fileName));
            formDataStream.Write(encoding.GetBytes(data), 0, encoding.GetByteCount(data));
            formDataStream.Write(fileBytes, 0, fileBytes.Length);

            var footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            //Dump the stream
            formDataStream.Position = 0;
            var formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }
    }
}

