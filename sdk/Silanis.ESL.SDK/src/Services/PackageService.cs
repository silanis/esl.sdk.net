using System;
using System.Globalization;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK.Services
{
    /// <summary>
    /// The PackageService class provides methods to help create packages and download documents after 
    /// the package is complete.
    /// </summary>
    public class PackageService
    {
        private readonly UrlTemplate _template;
        private readonly JsonSerializerSettings _settings;
        private readonly RestClient _restClient;
        private readonly ReportService _reportService;

        private static readonly object SyncLock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="PackageService"/> class.
        /// </summary>
        /// <param name="restClient"></param>
        /// <param name="baseUrl">Base URL.</param>
        public PackageService(RestClient restClient, string baseUrl)
        {
            _restClient = restClient;
            _template = new UrlTemplate(baseUrl);
            _settings = Json.JsonSerializerSettings;
            _reportService = new ReportService(restClient, baseUrl);
        }

        /// <summary>
        /// Creates a package based on the settings of the pacakge parameter.
        /// </summary>
        /// <returns>The package id.</returns>
        /// <param name="package">The package to create.</param>
        internal PackageId CreatePackage(Package package)
        {
            var path = _template.UrlFor(UrlTemplate.PACKAGE_PATH)
				.Build();
            try
            {
                var json = Json.SerializeWithSettings(package);
                var response = _restClient.Post(path, json);
                var result = Json.DeserializeWithSettings<PackageId>(response);

                return result;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not create a new package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not create a new package." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Creates a package based on the settings of the package parameter.
        /// 
        /// WARNING: This method does not work if the sender has a signature
        /// 
        /// </summary>
        /// <returns>The package id.</returns>
        /// <param name="package">The package to create.</param>
        /// <param name="documents">document to include in the package</param>
        internal PackageId CreatePackageOneStep(Package package, ICollection<Document> documents)
        {
            lock (SyncLock)
            {
                var path = _template.UrlFor(UrlTemplate.PACKAGE_PATH)
                .Build();
                try
                {
                    var json = Json.SerializeWithSettings(package);
                    var payloadBytes = Converter.ToBytes(json);

                    var boundary = GenerateBoundary();
                    var content = CreateMultipartPackage(documents, payloadBytes, boundary);

                    var response = _restClient.PostMultipartPackage(path, content, boundary, json); 

                    var result = Json.DeserializeWithSettings<PackageId>(response);

                    return result;
                }
                catch (EslServerException e)
                {
                    throw new EslServerException("Could not create a new package one step." + " Exception: " + e.Message, e.ServerError, e);
                }
                catch (Exception e)
                {
                    throw new EslException("Could not create a new package one step." + " Exception: " + e.Message, e);
                }
            }
        }

        /// <summary>
        /// Gets the package.
        /// </summary>
        /// <returns>The package.</returns>
        /// <param name="packageId">The package id.</param>
        internal Package GetPackage(PackageId packageId)
        {
            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
				.Replace("{packageId}", packageId.Id)
				.Build();

            try
            {
                var response = _restClient.Get(path);
                return Json.DeserializeWithSettings<Package>(response);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get package." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Deletes the document from the package.
        /// </summary>
        /// <param name="packageId">The package id.</param>
        /// <param name="document">The document to delete.</param>
        public void DeleteDocument(PackageId packageId, Document document)
        {
            DeleteDocument(packageId, document.Id);
        }

        public void DeleteDocument(PackageId packageId, string documentId)
        {
            var path = _template.UrlFor(UrlTemplate.DOCUMENT_ID_PATH)
							.Replace("{packageId}", packageId.Id)
							.Replace("{documentId}", documentId)
							.Build();

            try
            {
                _restClient.Delete(path);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not delete document from package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not delete document from package." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Get the document's metadata from the package.
        /// </summary>
        /// <returns>The document's metadata.</returns>
        /// <param name="package">The DocumentPackage we want to get document from.</param>
        /// <param name="documentId">Id of document to get.</param>
        public Document GetDocumentMetadata(DocumentPackage package, string documentId)
        {
            var path = _template.UrlFor(UrlTemplate.DOCUMENT_ID_PATH)
                .Replace("{packageId}", package.Id.Id)
                .Replace("{documentId}", documentId)
                .Build();

            try
            {
                var response = _restClient.Get(path);
                var apiDocument = Json.DeserializeWithSettings<API.Document>(response);

                // Wipe out the members not related to the metadata

                return new DocumentConverter(apiDocument, new DocumentPackageConverter(package).ToAPIPackage()).ToSDKDocument();
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get the document's metadata." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get the document's metadata." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Updates the document's data, but not the actually document binary..
        /// </summary>
        /// <param name="package">The DocumentPackage to update.</param>
        /// <param name="document">The Document to update.</param>
        public void UpdateDocumentMetadata(DocumentPackage package, Document document)
        {
            var path = _template.UrlFor(UrlTemplate.DOCUMENT_ID_PATH)
                .Replace("{packageId}", package.Id.Id)
                    .Replace("{documentId}", document.Id)
                    .Build();

            var internalDoc = new DocumentConverter(document).ToAPIDocument();

            // Wipe out the members not related to the metadata
            internalDoc.Approvals = null;
            internalDoc.Fields = null;
            internalDoc.Pages = null;

            PostInternalDocToESignLive(internalDoc, path);

            PostMetaDataToESignLive(internalDoc, path);
        }

        private void PostInternalDocToESignLive(API.Document internalDoc, string path)
        {
            try
            {
                var json = SerializeInternalDocument(internalDoc);
                _restClient.Put(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not update the document's metadata." + " Exception: " + e.Message,
                    e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not update the document's metadata." + " Exception: " + e.Message, e);
            }
        }

        internal string SerializeInternalDocument(API.Document internalDoc)
        {
            var json = Json.SerializeWithSettings(internalDoc);
            return json;
        }

        private void PostMetaDataToESignLive(API.Document internalDoc, string path)
        {
            try
            {
                var json = SerializeDocumentMetaData(internalDoc);
                _restClient.Put(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not update the document's metadata." + " Exception: " + e.Message,
                    e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not update the document's metadata." + " Exception: " + e.Message, e);
            }
        }

        internal string SerializeDocumentMetaData(API.Document internalDoc)
        {
            var prevContractResolver = _settings.ContractResolver;
            _settings.ContractResolver = DocumentMetadataContractResolver.Instance;
            string json;

            try
            {
                json = Json.SerializeWithSettings(internalDoc);
            }
            finally
            {
                _settings.ContractResolver = prevContractResolver;
            }
            return json;
        }

        public void OrderDocuments(DocumentPackage package)
        {
            var path = _template.UrlFor(UrlTemplate.DOCUMENT_PATH)
				.Replace("{packageId}", package.Id.Id)
				.Build();

            var documents = new List<API.Document>();
            foreach (var doc in package.Documents)
            {
                documents.Add(new DocumentConverter(doc).ToAPIDocument());
            }

            try
            {
                var json = Json.SerializeWithSettings(documents);
                _restClient.Put(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not order documents." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not order documents." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Uploads the list of documents from external providers.
        /// In most cases, adding a document from an external provider requires pre-development configurations.
        /// Please contact us for more information.
        /// </summary>
        /// <param name="packageId">The package id.</param>
        /// <param name="providerDocuments">external provider documents</param>
        public void AddDocumentWithExternalContent(string packageId, IList<Document> providerDocuments)
        {
            var path = _template.UrlFor(UrlTemplate.DOCUMENT_PATH)
                .Replace("{packageId}", packageId)
                    .Build();

            IList<API.Document> apiDocuments = new List<API.Document>();
            foreach (var document in providerDocuments)
            {
                apiDocuments.Add(new DocumentConverter(document).ToAPIDocument());
            }
            try
            {
                var json = Json.SerializeWithSettings(apiDocuments);

                _restClient.Post(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not add document with external content." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not add document with external content." + " Exception: " + e.Message, e);
            }
        }

        public IList<Document> GetDocuments()
        {
            var path = _template.UrlFor(UrlTemplate.PROVIDER_DOCUMENTS).Build();

            try
            {
                var response = _restClient.Get(path);
                var apiResponse = 
                    Json.DeserializeWithSettings<IList<API.Document>>(response);
                IList<Document> documents = new List<Document>();
                foreach (var document in apiResponse)
                {
                    documents.Add(new DocumentConverter(document, null).ToSDKDocument());
                }
                return documents;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get documents." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get documents." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Sends the package.
        /// </summary>
        /// <param name="packageId">The package id.</param>
        public void SendPackage(PackageId packageId)
        {
            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                .Build();

            try
            {			
                _restClient.Post(path, "{\"status\":\"SENT\"}");
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not send the package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not send the package." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Downloads a document from the package and returns it in a byte array.
        /// </summary>
        /// <returns>The document to download.</returns>
        /// <param name="packageId">The package id.</param>
        /// <param name="documentId">The id of the document to download.</param>
        public byte[] DownloadDocument(PackageId packageId, String documentId)
        {
            var path = _template.UrlFor(UrlTemplate.PDF_PATH)
				.Replace("{packageId}", packageId.Id)
					.Replace("{documentId}", documentId)
					.Build();

            try
            {
                return _restClient.GetHttpAsOctetStream(path).Contents;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the pdf document." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the pdf document." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Downloads the orginal document (without fields) from the package and returns a byte array.
        /// </summary>
        /// <returns>The original document in bytes.</returns>
        /// <param name="packageId">Package identifier.</param>
        /// <param name="documentId">Document identifier.</param>
        public byte[] DownloadOriginalDocument(PackageId packageId, String documentId)
        {
            var path = _template.UrlFor(UrlTemplate.ORIGINAL_PATH)
                .Replace("{packageId}", packageId.Id)
                .Replace("{documentId}", documentId)
                .Build();

            try
            {
                return _restClient.GetHttpAsOctetStream(path).Contents;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the original document." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the original document." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Downloads the documents from the package in a zip file and returns it in a byte array.
        /// </summary>
        /// <returns>The zipped documents in byte array.</returns>
        /// <param name="packageId">.</param>
        public byte[] DownloadZippedDocuments(PackageId packageId)
        {
            var path = _template.UrlFor(UrlTemplate.ZIP_PATH)
            .Replace("{packageId}", packageId.Id)
            .Build();

            try
            {
                return _restClient.GetBytes(path).Contents;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the documents to a zip file." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the documents to a zip file." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Downloads the evidence summary from the package and returns it in a byte array.
        /// </summary>
        /// <returns>The evidence summary in byte array.</returns>
        /// <param name="packageId">The package id.</param>
        public byte[] DownloadEvidenceSummary(PackageId packageId)
        {
            var path = _template.UrlFor(UrlTemplate.EVIDENCE_SUMMARY_PATH)
                .Replace("{packageId}", packageId.Id)
                .Build();

            try
            {
                return _restClient.GetBytes(path).Contents;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not download the evidence summary." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not download the evidence summary." + " Exception: " + e.Message, e);
            }
        }

        internal void UpdatePackage(PackageId packageId, Package package)
        {
            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                .Build();
                
            try
            {
                _restClient.Put(path, Json.SerializeWithSettings(package));
                _restClient.GetBytes(path);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Unable to update package settings." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Unable to update package settings." + " Exception: " + e.Message, e);
            }
        }

        internal void ChangePackageStatusToDraft(PackageId packageId) 
        {
            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                .Build();

            try
            {
                _restClient.Put(path, "{\"status\":\"DRAFT\"}");
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Unable to change the package status to DRAFT." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Unable to change the package status to DRAFT." + " Exception: " + e.Message, e);
            }
        }

        /// <summary>
        /// Uploads the Document and file in byte[] to the package.
        /// </summary>
        /// <param name="package">The package id.</param>
        /// <param name="fileName">The name of the document.</param>
        /// <param name="fileBytes">The file to upload in bytes.</param>
        /// <param name="document">The document object that has field settings.</param>
        internal Document UploadDocument(DocumentPackage package, string fileName, byte[] fileBytes, Document document)
        {
            lock (SyncLock)
            {
                var path = _template.UrlFor(UrlTemplate.DOCUMENT_PATH)
				.Replace("{packageId}", package.Id.Id)
					.Build();

                var internalPackage = new DocumentPackageConverter(package).ToAPIPackage();
                var internalDoc = new DocumentConverter(document).ToAPIDocument(internalPackage);

                try
                {
                    var json = Json.SerializeWithSettings(internalDoc);
                    var payloadBytes = Converter.ToBytes(json);

                    var boundary = GenerateBoundary();
                    var content = CreateMultipartContent(fileName, fileBytes, payloadBytes, boundary);

                    var response = _restClient.PostMultipartFile(path, content, boundary, json);

                    var uploadedDoc = Json.DeserializeWithSettings<API.Document>(response);
                    return new DocumentConverter(uploadedDoc, internalPackage).ToSDKDocument();
                }
                catch (EslServerException e)
                {
                    throw new EslServerException("Could not upload document to package." + " Exception: " + e.Message, e.ServerError, e);
                }
                catch (Exception e)
                {
                    throw new EslException("Could not upload document to package." + " Exception: " + e.Message, e);
                }
            }
        }

        private byte[] CreateMultipartContent (string fileName, byte[] fileBytes, byte[] payloadBytes, string boundary)
        {

            var encoding = Encoding.UTF8;
            Stream formDataStream = new MemoryStream ();

            var header = string.Format ("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\n\r\n",
                                           boundary, "payload", "paylaod");
            formDataStream.Write (encoding.GetBytes (header), 0, encoding.GetByteCount (header));
            formDataStream.Write (payloadBytes, 0, payloadBytes.Length);

            formDataStream.Write (encoding.GetBytes ("\r\n"), 0, encoding.GetByteCount ("\r\n"));

            var data = string.Format ("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n",
                                         boundary, "file", fileName, MimeTypeUtil.GetMIMEType (fileName));
            formDataStream.Write (encoding.GetBytes (data), 0, encoding.GetByteCount (data));
            formDataStream.Write (fileBytes, 0, fileBytes.Length);

            var footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write (encoding.GetBytes (footer), 0, encoding.GetByteCount (footer));

            //Dump the stream
            formDataStream.Position = 0;
            var formData = new byte[formDataStream.Length];
            formDataStream.Read (formData, 0, formData.Length);
            formDataStream.Close ();

            return formData;
        }

        private byte[] CreateMultipartPackage(ICollection<Document> documents, byte[] payloadBytes, string boundary)
        {

            var encoding = Encoding.UTF8;
            Stream formDataStream = new MemoryStream();

            var header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\n\r\n",
                                           boundary, "payload", "payload");
            formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));
            formDataStream.Write(payloadBytes, 0, payloadBytes.Length);

            formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

            foreach (var document in documents)
            {
                var fileName = document.FileName;
                var fileBytes = document.Content;

                var data = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\n\r\n",
                                            boundary, "file", fileName);
                formDataStream.Write(encoding.GetBytes(data), 0, encoding.GetByteCount(data));
                formDataStream.Write(fileBytes, 0, fileBytes.Length);
            }

            var footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            //Dump the stream
            formDataStream.Position = 0;
            var formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);
            formDataStream.Close();

            return formData;
        }

        public SigningStatus GetSigningStatus(PackageId packageId, string signerId, string documentId)
        {
            var path = _template.UrlFor(UrlTemplate.SIGNING_STATUS_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{signerId}", !String.IsNullOrEmpty(signerId) ? signerId : "")
				.Replace("{documentId}", !String.IsNullOrEmpty(documentId) ? documentId : "")
				.Build();

            try
            {
                var response = _restClient.Get(path);
                var reader = new JsonTextReader(new StringReader(response));

                //Loop 'till we get to the status value
                while (reader.Read () && reader.TokenType != JsonToken.String)
                {
                }

                return SigningStatusUtility.FromString(reader.Value.ToString());
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get signing status. Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get signing status. Exception: " + e.Message, e);
            }
        }

        internal IList<Role> GetRoles(PackageId packageId)
        {
            var path = _template.UrlFor(UrlTemplate.ROLE_PATH)
				.Replace("{packageId}", packageId.Id)
				.Build();

            Result<Role> response;
            try
            {
                var stringResponse = _restClient.Get(path);
                response = Json.DeserializeWithSettings<Result<Role>>(stringResponse);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Unable to retrieve role list for package with id " + packageId.Id + ".  " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Unable to retrieve role list for package with id " + packageId.Id + ".  " + e.Message, e);
            }
            return response.Results;
        }

        public void DeletePackage(PackageId id)
        {
            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                _restClient.Delete(path);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not delete package. Exception: " + e.Message, e.ServerError, e);    
            }
            catch (Exception e)
            {
                throw new EslException("Could not delete package. Exception: " + e.Message, e);	
            }
        }

        public void Restore(PackageId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                _restClient.Post(path, "{\"trashed\":false}");
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Unable to restore the package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Unable to restore the package." + " Exception: " + e.Message, e);
            }
        }

        public void Trash(PackageId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                _restClient.Post(path, "{\"trashed\":true}");
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Unable to trash the package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Unable to trash the package." + " Exception: " + e.Message, e);
            }
        }

        public void Archive(PackageId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                _restClient.Put(path, "{\"status\":\"ARCHIVED\"}");
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Unable to archive the package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Unable to archive the package." + " Exception: " + e.Message, e);
            }
        }

        public void MarkComplete(PackageId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                _restClient.Put(path, "{\"status\":\"COMPLETED\"}");
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Unable to mark complete on the package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Unable to mark complete on the package." + " Exception: " + e.Message, e);
            }
        }

        public void Edit(PackageId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            var path = _template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                _restClient.Put(path, "{\"status\":\"DRAFT\"}");
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Unable to edit package." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Unable to edit package." + " Exception: " + e.Message, e);
            }
        }

        private Role FindRoleForGroup(PackageId packageId, string groupId)
        {
            var roles = GetRoles(packageId);

            foreach (var role in roles)
            {
                if (role.Signers.Count > 0)
                {
                    var signer = role.Signers[0];
                    if (signer.Group != null && signer.Group.Id.Equals(groupId))
                    {
                        return role;
                    }
                }
            }
            return null;
        }

        public void NotifySigner(PackageId packageId, GroupId groupId)
        {
            var role = FindRoleForGroup(packageId, groupId.Id);
            NotifySigner(packageId, role.Id);
        }

        public void NotifySigner(PackageId packageId, string roleId)
        {

            var path = _template.UrlFor(UrlTemplate.NOTIFY_ROLE_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{roleId}", roleId)
				.Build();

            try
            {
                _restClient.Post(path, "");
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Unable to send email notification.  " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Unable to send email notification.  " + e.Message, e);
            }
        }

        public void NotifySigner(PackageId packageId, string signerEmail, string message)
        {
            var path = _template.UrlFor(UrlTemplate.NOTIFICATIONS_PATH).Replace("{packageId}", packageId.Id).Build();
            var sw = new StringWriter();

            using (JsonWriter json = new JsonTextWriter(sw))
            {
                json.Formatting = Formatting.Indented;
                json.WriteStartObject();
                json.WritePropertyName("email");
                json.WriteValue(signerEmail);
                json.WritePropertyName("message");
                json.WriteValue(message);
                json.WriteEndObject();
            }

            try
            {
                _restClient.Post(path, sw.ToString());
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not send email notification to signer. Exception: " + e.Message, e.ServerError, e); 
            }
            catch (Exception e)
            {
                throw new EslException("Could not send email notification to signer. Exception: " + e.Message, e);	
            }
        }

        public Page<DocumentPackage> GetPackages(DocumentPackageStatus status, PageRequest request)
        {
            var path = _template.UrlFor(UrlTemplate.PACKAGE_LIST_PATH)
                .Replace("{status}", new PackageStatusConverter(status).ToAPIPackageStatus())
				.Replace("{from}", request.From.ToString(CultureInfo.InvariantCulture))
				.Replace("{to}", request.To.ToString(CultureInfo.InvariantCulture))
				.Build();

            try
            {
                var response = _restClient.Get(path);
                var results = Json.DeserializeWithSettings<Result<Package>>(response);

                return ConvertToPage(results, request);
            }
            catch (EslServerException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new EslServerException("Could not get package list. Exception: " + e.Message, e.ServerError, e);  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new EslException("Could not get package list. Exception: " + e.Message, e);	
            }
        }

        public Page<DocumentPackage> GetUpdatedPackagesWithinDateRange(DocumentPackageStatus status, PageRequest request, DateTime from, DateTime to)
        {
            var fromDate = DateHelper.dateToIsoUtcFormat(from);
            var toDate = DateHelper.dateToIsoUtcFormat(to);

            var path = _template.UrlFor(UrlTemplate.PACKAGE_LIST_STATUS_DATE_RANGE_PATH)
                    .Replace("{status}", new PackageStatusConverter(status).ToAPIPackageStatus())
                    .Replace("{from}", request.From.ToString(CultureInfo.InvariantCulture))
                    .Replace("{to}", request.To.ToString(CultureInfo.InvariantCulture))
                    .Replace("{lastUpdatedStartDate}", fromDate)
                    .Replace("{lastUpdatedEndDate}", toDate)
                    .Build();

            try
            {
                var response = _restClient.Get(path);
                var results = Json.DeserializeWithSettings<Result<Package>>(response);

                return ConvertToPage(results, request);
            }
            catch (EslServerException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new EslServerException("Could not get package list. Exception: " + e.Message, e.ServerError, e);  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new EslException("Could not get package list. Exception: " + e.Message, e);  
            }
        }

        public Page<DocumentPackage> GetTemplates(PageRequest request)
        {
            var path = _template.UrlFor(UrlTemplate.TEMPLATE_LIST_PATH)
                    .Replace("{from}", request.From.ToString(CultureInfo.InvariantCulture))
                    .Replace("{to}", request.To.ToString(CultureInfo.InvariantCulture))
                    .Build();

            try
            {
                var response = _restClient.Get(path);
                var results = Json.DeserializeWithSettings<Result<Package>>(response);

                return ConvertToPage(results, request);
            }
            catch (EslServerException e)
            {
                Console.WriteLine(e.StackTrace);
                throw new EslServerException("Could not get template list. Exception: " + e.Message, e.ServerError, e); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new EslException("Could not get template list. Exception: " + e.Message, e); 
            }
        }

        private static Page<DocumentPackage> ConvertToPage(Result<Package> results, PageRequest request)
        {
            IList<DocumentPackage> converted = new List<DocumentPackage>();

            foreach (var package in results.Results)
            {
                var dp = new DocumentPackageConverter(package).ToSDKPackage();

                converted.Add(dp);
            }

            return new Page<DocumentPackage>(converted, results.Count.Value, request);
        }

        private static string GenerateBoundary()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[16];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }

        public string AddSigner(PackageId packageId, Signer signer)
        {
            var apiPayload = new SignerConverter(signer).ToAPIRole(Guid.NewGuid().ToString());

            var path = _template.UrlFor(UrlTemplate.ADD_SIGNER_PATH)
				.Replace("{packageId}", packageId.Id)
				.Build();
            try
            {
                var json = Json.SerializeWithSettings(apiPayload);
                var response = _restClient.Post(path, json);              
                var apiRole = Json.DeserializeWithSettings<Role>(response);

                return apiRole.Id;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not add signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not add signer." + " Exception: " + e.Message, e);
            }
        }

        public Signer GetSigner(PackageId packageId, string signerId)
        {
            var path = _template.UrlFor(UrlTemplate.GET_SIGNER_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{roleId}", signerId)
				.Build();

            try
            {
                var response = _restClient.Get(path);
                var apiRole = Json.DeserializeWithSettings<Role>(response);
                return new SignerConverter(apiRole).ToSDKSigner();
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not retrieve signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not retrieve signer." + " Exception: " + e.Message, e);
            }
        }

        public void UpdateSigner(PackageId packageId, Signer signer)
        {
            var apiPayload = new SignerConverter(signer).ToAPIRole(Guid.NewGuid().ToString());

            var path = _template.UrlFor(UrlTemplate.UPDATE_SIGNER_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{roleId}", signer.Id)
				.Build();
            try
            {
                var json = Json.SerializeWithSettings(apiPayload);
                _restClient.Put(path, json);              
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not update signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not update signer." + " Exception: " + e.Message, e);
            }
        }

        public void RemoveSigner(PackageId packageId, string signerId)
        {
            var path = _template.UrlFor(UrlTemplate.REMOVE_SIGNER_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{roleId}", signerId)
				.Build();

            try
            {
                _restClient.Delete(path);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not delete signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not delete signer." + " Exception: " + e.Message, e);
            }
        }

        public void OrderSigners(DocumentPackage package)
        {
            var path = _template.UrlFor(UrlTemplate.ROLE_PATH)
				.Replace("{packageId}", package.Id.Id)
				.Build();

            var roles = new List<Role>();
            foreach (var signer in package.Signers)
            {
                roles.Add(new SignerConverter(signer).ToAPIRole(signer.Id));
            }

            try
            {
                var json = Json.SerializeWithSettings(roles);
                _restClient.Put(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not order signers." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not order signers." + " Exception: " + e.Message, e);
            }
        }

        public void UnlockSigner(PackageId packageId, string senderId)
        {
            var path = _template.UrlFor(UrlTemplate.ROLE_UNLOCK_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{roleId}", senderId)
                    .Build();

            try
            {
                _restClient.Post(path, null);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not unlock signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not unlock signer." + " Exception: " + e.Message, e);
            }
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadCompletionReportAsCSV")]
        public string DownloadCompletionReportAsCSV(DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            return _reportService.DownloadCompletionReportAsCSV(packageStatus, senderId, from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadCompletionReport")]
        public CompletionReport DownloadCompletionReport(DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            return _reportService.DownloadCompletionReport(packageStatus, senderId, from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadCompletionReportAsCSV")]
        public string DownloadCompletionReportAsCSV(DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            return _reportService.DownloadCompletionReportAsCSV(packageStatus, from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadCompletionReport")]
        public CompletionReport DownloadCompletionReport(DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            return _reportService.DownloadCompletionReport(packageStatus, from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadUsageReportAsCSV")]
        public string DownloadUsageReportAsCSV(DateTime from, DateTime to)
        {
            return _reportService.DownloadUsageReportAsCSV(from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadUsageReport")]
        public UsageReport DownloadUsageReport(DateTime from, DateTime to)
        {
            return _reportService.DownloadUsageReport(from, to);
        }

        public string GetSigningUrl(PackageId packageId, string signerId) 
        {
            var package = GetPackage(packageId);

            return GetSigningUrl(packageId, GetRole(package, signerId));
        }

        private Role GetRole(Package package, string sigenrId) 
        {
            foreach(var role in package.Roles) 
            {
                foreach(var signer in role.Signers) 
                {
                    if(signer.Id.Equals(sigenrId)) 
                    {
                        return role;
                    }
                }
            }
            return new Role();
        }

        private string GetSigningUrl(PackageId packageId, Role role) 
        {

            var path = _template.UrlFor(UrlTemplate.SIGNER_URL_PATH)
                         .Replace("{packageId}", packageId.Id)
                         .Replace("{roleId}", role.Id)
                         .Build();

            try 
            {
                var response = _restClient.Get(path);
                var signingUrl = Json.DeserializeWithSettings<SigningUrl>(response);
                return signingUrl.Url;
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get a signing url." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get a signing url." + " Exception: " + e.Message, e);
            }
        }

        public string StartFastTrack(PackageId packageId, List<FastTrackSigner> signers) 
        {
            var token = GetFastTrackToken(packageId, true);
            var path = _template.UrlFor(UrlTemplate.START_FAST_TRACK_PATH)
                         .Replace("{token}", token)
                         .Build();

            var roles = new List<FastTrackRole>();
            foreach(var signer in signers) {
                var role = FastTrackRoleBuilder.NewRoleWithId(signer.Id)
                        .WithName(signer.Id)
                        .WithSigner(signer)
                        .Build();
                roles.Add(role);
            }

            var json = Json.SerializeWithSettings(roles);

            try
            {
                var response = _restClient.Post(path, json);
                var signingUrl = Json.DeserializeWithSettings<SigningUrl>(response);
                return signingUrl.Url;
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not start fast track." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not start fast track." + " Exception: " + e.Message, e);
            }
        }

        private string GetFastTrackToken(PackageId packageId, Boolean signing) 
        {
            var fastTrackUrl = GetFastTrackUrl(packageId, signing);
            var finalUrl = RedirectResolver.ResolveUrlAfterRedirect(fastTrackUrl);

            return finalUrl.Substring(finalUrl.LastIndexOf('=') + 1);
        }

        private string GetFastTrackUrl(PackageId packageId, Boolean signing) 
        {
            var path = _template.UrlFor(UrlTemplate.FAST_TRACK_URL_PATH)
                                  .Replace("{packageId}", packageId.Id)
                                  .Replace("{signing}", signing.ToString())
                                  .Build();

            try 
            {
                var response = _restClient.Get(path);
                var signingUrl = Json.DeserializeWithSettings<SigningUrl>(response);
                return signingUrl.Url;
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get a fastTrack url." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get a fastTrack url." + " Exception: " + e.Message, e);
            }
        }

        public void SendSmsToSigner(PackageId packageId, Signer signer) 
        {
            var role = new SignerConverter(signer).ToAPIRole(Guid.NewGuid().ToString());
            SendSmsToSigner(packageId, role);
        }

        private void SendSmsToSigner(PackageId packageId, Role role) 
        {
            var path = _template.UrlFor(UrlTemplate.SEND_SMS_TO_SIGNER_PATH)
                                  .Replace("{packageId}", packageId.Id)
                                  .Replace("{roleId}", role.Id)
                                  .Build();

            try
            {
                _restClient.Post(path, null);
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not send SMS to the signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not send SMS to the signer." + " Exception: " + e.Message, e);
            }
        }

        public List<NotaryJournalEntry> GetJournalEntries(string userId) 
        {
            var result = new List<NotaryJournalEntry>();

            var path = _template.UrlFor(UrlTemplate.NOTARY_JOURNAL_PATH)
                    .Replace("{userId}", userId)
                    .Build();

            try
            {
                var response = _restClient.Get(path);
                var apiResponse = Json.DeserializeWithSettings<Result<API.NotaryJournalEntry>> (response );

                foreach ( var apiNotaryJournalEntry in apiResponse.Results ) 
                {
                    result.Add( new NotaryJournalEntryConverter( apiNotaryJournalEntry ).ToSDKNotaryJournalEntry() );
                }

                return result;

            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get Journal Entries." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get Journal Entries." + " Exception: " + e.Message, e);
            }
        }

        public DownloadedFile GetJournalEntriesAsCSV(string userId) 
        {
            var path = _template.UrlFor(UrlTemplate.NOTARY_JOURNAL_CSV_PATH)
                    .Replace("{userId}", userId)
                    .Build();

            try
            {
                return _restClient.GetBytes(path);
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get Journal Entries in csv." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get Journal Entries in csv." + " Exception: " + e.Message, e);
            }
        }

        public string GetThankYouDialogContent(PackageId packageId) 
        {
            var path = _template.UrlFor(UrlTemplate.THANK_YOU_DIALOG_PATH)
                    .Replace("{packageId}", packageId.Id)
                    .Build();

            try
            {
                var response = _restClient.Get(path);
                var thankYouDialogContent = Json.DeserializeWithSettings<Dictionary<string, string>>(response);
                return thankYouDialogContent["body"];
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get thank you dialog content." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get thank you dialog content." + " Exception: " + e.Message, e);
            }
        }

        public SupportConfiguration GetConfig(PackageId packageId) 
        {
            var path = _template.UrlFor(UrlTemplate.PACKAGE_INFORMATION_CONFIG_PATH)
                    .Replace("{packageId}", packageId.Id)
                    .Build();

            try
            {
                var response = _restClient.Get(path);
                var apiSupportConfiguration = Json.DeserializeWithSettings<API.SupportConfiguration>(response);
                return new SupportConfigurationConverter(apiSupportConfiguration).ToSDKSupportConfiguration();
            } 
            catch (EslServerException e)
            {
                throw new EslServerException("Could not get support configuration." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not get support configuration." + " Exception: " + e.Message, e);
            }
        }
    }
}