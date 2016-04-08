using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;
using System.Globalization;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Utilities.LinqBridge;
using System.Collections.Specialized;

namespace Silanis.ESL.SDK.Services
{
    /// <summary>
    /// The PackageService class provides methods to help create packages and download documents after 
    /// the package is complete.
    /// </summary>
    public class PackageService
    {
        private UrlTemplate template;
        private JsonSerializerSettings settings;
        private RestClient restClient;
        private ReportService reportService;

        private static readonly object syncLock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="Silanis.ESL.SDK.PackageService"/> class.
        /// </summary>
        /// <param name="apiToken">API token.</param>
        /// <param name="baseUrl">Base URL.</param>
        public PackageService(RestClient restClient, string baseUrl, JsonSerializerSettings settings)
        {
            this.restClient = restClient;
            template = new UrlTemplate(baseUrl);
            this.settings = settings;
            reportService = new ReportService(restClient, baseUrl, settings);
        }

        /// <summary>
        /// Creates a package based on the settings of the pacakge parameter.
        /// </summary>
        /// <returns>The package id.</returns>
        /// <param name="package">The package to create.</param>
        internal PackageId CreatePackage(Silanis.ESL.API.Package package)
        {
            var path = template.UrlFor(UrlTemplate.PACKAGE_PATH)
				.Build();
            try
            {
                var json = JsonConvert.SerializeObject(package, settings);
                var response = restClient.Post(path, json);				
                var result = JsonConvert.DeserializeObject<PackageId>(response);

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
        internal PackageId CreatePackageOneStep(Silanis.ESL.API.Package package, ICollection<Silanis.ESL.SDK.Document> documents)
        {
            lock (syncLock)
            {
                var path = template.UrlFor(UrlTemplate.PACKAGE_PATH)
                .Build();
                try
                {
                    var json = JsonConvert.SerializeObject(package, settings);
                    var payloadBytes = Converter.ToBytes(json);

                    var boundary = GenerateBoundary();
                    var content = CreateMultipartPackage(documents, payloadBytes, boundary);

                    var response = restClient.PostMultipartPackage(path, content, boundary, json); 

                    var result = JsonConvert.DeserializeObject<PackageId>(response);

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
        /// Updates the package's fields and roles.
        /// </summary>
        /// <param name="packageId">The package id.</param>
        /// <param name="package">The updated package.</param>
        //		internal void UpdatePackage (PackageId packageId, Silanis.ESL.API.Package package)
        //		{
        //			string path = template.UrlFor (UrlTemplate.PACKAGE_ID_PATH)
        //				.Replace ("{packageId}", packageId.Id)
        //				.Build ();
        //
        //			try {
        //				string json = JsonConvert.SerializeObject (package, settings);
        //                string response = restClient.Put(path, json);
        //			} catch (Exception e) {
        //				throw new EslException ("Could not update the package." + " Exception: " + e.Message);
        //			}
        //		}

        /// <summary>
        /// Gets the package.
        /// </summary>
        /// <returns>The package.</returns>
        /// <param name="packageId">The package id.</param>
        internal Silanis.ESL.API.Package GetPackage(PackageId packageId)
        {
            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
				.Replace("{packageId}", packageId.Id)
				.Build();

            try
            {
                var response = restClient.Get(path);
                return JsonConvert.DeserializeObject<Silanis.ESL.API.Package>(response, settings);
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
            var path = template.UrlFor(UrlTemplate.DOCUMENT_ID_PATH)
							.Replace("{packageId}", packageId.Id)
							.Replace("{documentId}", documentId)
							.Build();

            try
            {
                restClient.Delete(path);
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
        public Silanis.ESL.SDK.Document GetDocumentMetadata(DocumentPackage package, string documentId)
        {
            var path = template.UrlFor(UrlTemplate.DOCUMENT_ID_PATH)
                .Replace("{packageId}", package.Id.Id)
                .Replace("{documentId}", documentId)
                .Build();

            try
            {
                var response = restClient.Get(path);
                var apiDocument = JsonConvert.DeserializeObject<Silanis.ESL.API.Document>(response, settings);

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
            var path = template.UrlFor(UrlTemplate.DOCUMENT_ID_PATH)
                .Replace("{packageId}", package.Id.Id)
                    .Replace("{documentId}", document.Id)
                    .Build();

            var internalDoc = new DocumentConverter(document).ToAPIDocument();

            // Wipe out the members not related to the metadata
            internalDoc.Approvals = null;
            internalDoc.Fields = null;
            internalDoc.Pages = null;

            try
            {
                var json = JsonConvert.SerializeObject(internalDoc, settings);
                restClient.Put(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not update the document's metadata." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not update the document's metadata." + " Exception: " + e.Message, e);
            }

            var prevContractResolver = settings.ContractResolver;
            settings.ContractResolver = DocumentMetadataContractResolver.Instance;            

            try
            {
                var json = JsonConvert.SerializeObject(internalDoc, settings);
                restClient.Put(path, json);
            }
            catch (EslServerException e)
            {
                throw new EslServerException("Could not update the document's metadata." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e)
            {
                throw new EslException("Could not update the document's metadata." + " Exception: " + e.Message, e);
            }
            finally
            {
                settings.ContractResolver = prevContractResolver;
            }
        }

        public void OrderDocuments(DocumentPackage package)
        {
            var path = template.UrlFor(UrlTemplate.DOCUMENT_PATH)
				.Replace("{packageId}", package.Id.Id)
				.Build();

            var documents = new List<Silanis.ESL.API.Document>();
            foreach (var doc in package.Documents)
            {
                documents.Add(new DocumentConverter(doc).ToAPIDocument());
            }

            try
            {
                var json = JsonConvert.SerializeObject(documents, settings);
                restClient.Put(path, json);
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
        /// <param name="document">The documents to be uploaded</param>
        /// 
        public void AddDocumentWithExternalContent(string packageId, IList<Document> providerDocuments)
        {
            var path = template.UrlFor(UrlTemplate.DOCUMENT_PATH)
                .Replace("{packageId}", packageId)
                    .Build();

            IList<Silanis.ESL.API.Document> apiDocuments = new List<Silanis.ESL.API.Document>();
            foreach (var document in providerDocuments)
            {
                apiDocuments.Add(new DocumentConverter(document).ToAPIDocument());
            }
            try
            {
                var json = JsonConvert.SerializeObject(apiDocuments, settings);

                var response = restClient.Post(path, json);
                //Silanis.ESL.API.Document uploadedDoc = JsonConvert.DeserializeObject<Silanis.ESL.API.Document>(response);
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
            var path = template.UrlFor(UrlTemplate.PROVIDER_DOCUMENTS).Build();

            try
            {
                var response = restClient.Get(path);
                var apiResponse = 
                    JsonConvert.DeserializeObject<IList<Silanis.ESL.API.Document>>(response, settings);
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
            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                .Build();

            try
            {			
                restClient.Post(path, "{\"status\":\"SENT\"}");
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
            var path = template.UrlFor(UrlTemplate.PDF_PATH)
				.Replace("{packageId}", packageId.Id)
					.Replace("{documentId}", documentId)
					.Build();

            try
            {
                return restClient.GetHttpAsOctetStream(path).Contents;
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
            var path = template.UrlFor(UrlTemplate.ORIGINAL_PATH)
                .Replace("{packageId}", packageId.Id)
                .Replace("{documentId}", documentId)
                .Build();

            try
            {
                return restClient.GetHttpAsOctetStream(path).Contents;
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
            var path = template.UrlFor(UrlTemplate.ZIP_PATH)
            .Replace("{packageId}", packageId.Id)
            .Build();

            try
            {
                return restClient.GetBytes(path).Contents;
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
            var path = template.UrlFor(UrlTemplate.EVIDENCE_SUMMARY_PATH)
                .Replace("{packageId}", packageId.Id)
                .Build();

            try
            {
                return restClient.GetBytes(path).Contents;
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
            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                .Build();
                
            try
            {
                restClient.Put(path, JsonConvert.SerializeObject(package, settings));
                restClient.GetBytes(path);
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
            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH)
                .Replace("{packageId}", packageId.Id)
                .Build();

            try
            {
                restClient.Put(path, "{\"status\":\"DRAFT\"}");
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
        /// <param name="packageId">The package id.</param>
        /// <param name="fileName">The name of the document.</param>
        /// <param name="fileBytes">The file to upload in bytes.</param>
        /// <param name="document">The document object that has field settings.</param>
        internal Document UploadDocument(DocumentPackage package, string fileName, byte[] fileBytes, Document document)
        {
            lock (syncLock)
            {
                var path = template.UrlFor(UrlTemplate.DOCUMENT_PATH)
				.Replace("{packageId}", package.Id.Id)
					.Build();

                var internalPackage = new DocumentPackageConverter(package).ToAPIPackage();
                var internalDoc = new DocumentConverter(document).ToAPIDocument(internalPackage);

                try
                {
                    var json = JsonConvert.SerializeObject(internalDoc, settings);
                    var payloadBytes = Converter.ToBytes(json);

                    var boundary = GenerateBoundary();
                    var content = CreateMultipartContent(fileName, fileBytes, payloadBytes, boundary);

                    var response = restClient.PostMultipartFile(path, content, boundary, json);

                    var uploadedDoc = JsonConvert.DeserializeObject<Silanis.ESL.API.Document>(response);
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

        private byte[] CreateMultipartPackage(ICollection<Silanis.ESL.SDK.Document> documents, byte[] payloadBytes, string boundary)
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
            var path = template.UrlFor(UrlTemplate.SIGNING_STATUS_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{signerId}", !String.IsNullOrEmpty(signerId) ? signerId : "")
				.Replace("{documentId}", !String.IsNullOrEmpty(documentId) ? documentId : "")
				.Build();

            try
            {
                var response = restClient.Get(path);
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
            var path = template.UrlFor(UrlTemplate.ROLE_PATH)
				.Replace("{packageId}", packageId.Id)
				.Build();

            Result<Role> response = null;
            try
            {
                var stringResponse = restClient.Get(path);
                response = JsonConvert.DeserializeObject<Result<Role>>(stringResponse, settings);
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
            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                restClient.Delete(path);
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

            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                restClient.Post(path, "{\"trashed\":false}");
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

            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                restClient.Post(path, "{\"trashed\":true}");
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

            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                restClient.Put(path, "{\"status\":\"ARCHIVED\"}");
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

            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                restClient.Put(path, "{\"status\":\"COMPLETED\"}");
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

            var path = template.UrlFor(UrlTemplate.PACKAGE_ID_PATH).Replace("{packageId}", id.Id).Build();

            try
            {
                restClient.Put(path, "{\"status\":\"DRAFT\"}");
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

            var path = template.UrlFor(UrlTemplate.NOTIFY_ROLE_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{roleId}", roleId)
				.Build();

            try
            {
                restClient.Post(path, "");
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
            var path = template.UrlFor(UrlTemplate.NOTIFICATIONS_PATH).Replace("{packageId}", packageId.Id).Build();
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
                restClient.Post(path, sw.ToString());
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
            var path = template.UrlFor(UrlTemplate.PACKAGE_LIST_PATH)
                .Replace("{status}", new PackageStatusConverter(status).ToAPIPackageStatus())
				.Replace("{from}", request.From.ToString())
				.Replace("{to}", request.To.ToString())
				.Build();

            try
            {
                var response = restClient.Get(path);
                var results = JsonConvert.DeserializeObject<Silanis.ESL.API.Result<Silanis.ESL.API.Package>>(response, settings);

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

            var path = template.UrlFor(UrlTemplate.PACKAGE_LIST_STATUS_DATE_RANGE_PATH)
                    .Replace("{status}", new PackageStatusConverter(status).ToAPIPackageStatus())
                    .Replace("{from}", request.From.ToString())
                    .Replace("{to}", request.To.ToString())
                    .Replace("{lastUpdatedStartDate}", fromDate)
                    .Replace("{lastUpdatedEndDate}", toDate)
                    .Build();

            try
            {
                var response = restClient.Get(path);
                var results = JsonConvert.DeserializeObject<Silanis.ESL.API.Result<Silanis.ESL.API.Package>>(response, settings);

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
            var path = template.UrlFor(UrlTemplate.TEMPLATE_LIST_PATH)
                    .Replace("{from}", request.From.ToString())
                    .Replace("{to}", request.To.ToString())
                    .Build();

            try
            {
                var response = restClient.Get(path);
                var results = JsonConvert.DeserializeObject<Silanis.ESL.API.Result<Silanis.ESL.API.Package>>(response, settings);

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

        private Page<DocumentPackage> ConvertToPage(Silanis.ESL.API.Result<Silanis.ESL.API.Package> results, PageRequest request)
        {
            IList<DocumentPackage> converted = new List<DocumentPackage>();

            foreach (var package in results.Results)
            {
                var dp = new DocumentPackageConverter(package).ToSDKPackage();

                converted.Add(dp);
            }

            return new Page<DocumentPackage>(converted, results.Count.Value, request);
        }

        private string GenerateBoundary()
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
            var apiPayload = new SignerConverter(signer).ToAPIRole(System.Guid.NewGuid().ToString());

            var path = template.UrlFor(UrlTemplate.ADD_SIGNER_PATH)
				.Replace("{packageId}", packageId.Id)
				.Build();
            try
            {
                var json = JsonConvert.SerializeObject(apiPayload, settings);
                var response = restClient.Post(path, json);              
                var apiRole = JsonConvert.DeserializeObject<Role>(response);

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
            var path = template.UrlFor(UrlTemplate.GET_SIGNER_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{roleId}", signerId)
				.Build();

            try
            {
                var response = restClient.Get(path);
                var apiRole = JsonConvert.DeserializeObject<Silanis.ESL.API.Role>(response, settings);
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
            var apiPayload = new SignerConverter(signer).ToAPIRole(System.Guid.NewGuid().ToString());

            var path = template.UrlFor(UrlTemplate.UPDATE_SIGNER_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{roleId}", signer.Id)
				.Build();
            try
            {
                var json = JsonConvert.SerializeObject(apiPayload, settings);
                restClient.Put(path, json);              
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
            var path = template.UrlFor(UrlTemplate.REMOVE_SIGNER_PATH)
				.Replace("{packageId}", packageId.Id)
				.Replace("{roleId}", signerId)
				.Build();

            try
            {
                restClient.Delete(path);
                return;
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
            var path = template.UrlFor(UrlTemplate.ROLE_PATH)
				.Replace("{packageId}", package.Id.Id)
				.Build();

            var roles = new List<Silanis.ESL.API.Role>();
            foreach (var signer in package.Signers)
            {
                roles.Add(new SignerConverter(signer).ToAPIRole(signer.Id));
            }

            try
            {
                var json = JsonConvert.SerializeObject(roles, settings);
                restClient.Put(path, json);
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
            var path = template.UrlFor(UrlTemplate.ROLE_UNLOCK_PATH)
                .Replace("{packageId}", packageId.Id)
                    .Replace("{roleId}", senderId)
                    .Build();

            try
            {
                restClient.Post(path, null);
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
        public string DownloadCompletionReportAsCSV(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            return reportService.DownloadCompletionReportAsCSV(packageStatus, senderId, from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadCompletionReport")]
        public Silanis.ESL.SDK.CompletionReport DownloadCompletionReport(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, String senderId, DateTime from, DateTime to)
        {
            return reportService.DownloadCompletionReport(packageStatus, senderId, from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadCompletionReportAsCSV")]
        public string DownloadCompletionReportAsCSV(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            return reportService.DownloadCompletionReportAsCSV(packageStatus, from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadCompletionReport")]
        public Silanis.ESL.SDK.CompletionReport DownloadCompletionReport(Silanis.ESL.SDK.DocumentPackageStatus packageStatus, DateTime from, DateTime to)
        {
            return reportService.DownloadCompletionReport(packageStatus, from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadUsageReportAsCSV")]
        public string DownloadUsageReportAsCSV(DateTime from, DateTime to)
        {
            return reportService.DownloadUsageReportAsCSV(from, to);
        }

        [Obsolete("Use Silanis.ESL.SDK.Services.ReportService.DownloadUsageReport")]
        public Silanis.ESL.SDK.UsageReport DownloadUsageReport(DateTime from, DateTime to)
        {
            return reportService.DownloadUsageReport(from, to);
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

            var path = template.UrlFor(UrlTemplate.SIGNER_URL_PATH)
                         .Replace("{packageId}", packageId.Id)
                         .Replace("{roleId}", role.Id)
                         .Build();

            try 
            {
                var response = restClient.Get(path);
                var signingUrl = JsonConvert.DeserializeObject<Silanis.ESL.API.SigningUrl>(response, settings);
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
            var path = template.UrlFor(UrlTemplate.START_FAST_TRACK_PATH)
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

            var json = JsonConvert.SerializeObject(roles, settings);

            try
            {
                var response = restClient.Post(path, json);
                var signingUrl = JsonConvert.DeserializeObject<Silanis.ESL.API.SigningUrl>(response, settings);
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
            var path = template.UrlFor(UrlTemplate.FAST_TRACK_URL_PATH)
                                  .Replace("{packageId}", packageId.Id)
                                  .Replace("{signing}", signing.ToString())
                                  .Build();

            try 
            {
                var response = restClient.Get(path);
                var signingUrl = JsonConvert.DeserializeObject<Silanis.ESL.API.SigningUrl>(response, settings);
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
            var role = new SignerConverter(signer).ToAPIRole(System.Guid.NewGuid().ToString());
            SendSmsToSigner(packageId, role);
        }

        private void SendSmsToSigner(PackageId packageId, Role role) 
        {
            var path = template.UrlFor(UrlTemplate.SEND_SMS_TO_SIGNER_PATH)
                                  .Replace("{packageId}", packageId.Id)
                                  .Replace("{roleId}", role.Id)
                                  .Build();

            try
            {
                restClient.Post(path, null);
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

        public List<Silanis.ESL.SDK.NotaryJournalEntry> GetJournalEntries(string userId) 
        {
            var result = new List<Silanis.ESL.SDK.NotaryJournalEntry>();

            var path = template.UrlFor(UrlTemplate.NOTARY_JOURNAL_PATH)
                    .Replace("{userId}", userId)
                    .Build();

            try
            {
                var response = restClient.Get(path);
                var apiResponse = JsonConvert.DeserializeObject<Silanis.ESL.API.Result<Silanis.ESL.API.NotaryJournalEntry>> (response, settings );

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
            var path = template.UrlFor(UrlTemplate.NOTARY_JOURNAL_CSV_PATH)
                    .Replace("{userId}", userId)
                    .Build();

            try
            {
                return restClient.GetBytes(path);
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
            var path = template.UrlFor(UrlTemplate.THANK_YOU_DIALOG_PATH)
                    .Replace("{packageId}", packageId.Id)
                    .Build();

            try
            {
                var response = restClient.Get(path);
                var thankYouDialogContent = JsonConvert.DeserializeObject<Dictionary<string, string>>(response, settings);
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
            var path = template.UrlFor(UrlTemplate.PACKAGE_INFORMATION_CONFIG_PATH)
                    .Replace("{packageId}", packageId.Id)
                    .Build();

            try
            {
                var response = restClient.Get(path);
                var apiSupportConfiguration = JsonConvert.DeserializeObject<Silanis.ESL.API.SupportConfiguration>(response, settings);
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