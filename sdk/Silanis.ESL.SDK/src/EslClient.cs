using System;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.SDK.Services;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    /// <summary>
    /// The EslClient acts as a E-SignLive client.
    /// The EslClient has access to service classes that help create packages and retrieve resources from the client's account.
    /// </summary>
	public class EslClient
	{

		private string _baseUrl;
        private string _webpageUrl;
		private PackageService _packageService;
        private ReportService _reportService;
		private SessionService _sessionService;
		private FieldSummaryService _fieldSummaryService;
		private AuditService _auditService;
        private EventNotificationService _eventNotificationService;
        private CustomFieldService _customFieldService;
        private GroupService _groupService;
		private AccountService _accountService;
        private ApprovalService _approvalService;
		private ReminderService _reminderService;
        private TemplateService _templateService;
		private AuthenticationTokenService _authenticationTokenService;    
		private AttachmentRequirementService _attachmentRequirementService;
        private LayoutService _layoutService;
        private QRCodeService _qrCodeService;
        private AuthenticationService _authenticationService;
        private SystemService _systemService;
        private SignatureImageService _signatureImageService;
        private SigningService _signingService;
        
        /// <summary>
        /// EslClient constructor.
        /// Initiates service classes that can be used by the client.
        /// </summary>
        /// <param name="apiKey">The client's api key.</param>
        /// <param name="baseUrl">The staging or production url.</param>
		public EslClient (string apiKey, string baseUrl)
		{
			Asserts.NotEmptyOrNull (apiKey, "apiKey");
			Asserts.NotEmptyOrNull (baseUrl, "baseUrl");
            SetBaseUrl (baseUrl);
            SetWebpageUrl (baseUrl);

            var restClient = new RestClient(apiKey);
            Init(restClient, apiKey);
        }

        /// <summary>
        /// EslClient constructor.
        /// Initiates service classes that can be used by the client.
        /// </summary>
        /// <param name="apiKey">The client's api key.</param>
        /// <param name="baseUrl">The staging or production url.</param>
        /// <param name="webpageUrl"></param>
        public EslClient (string apiKey, string baseUrl, string webpageUrl)
        {
            Asserts.NotEmptyOrNull (apiKey, "apiKey");
            Asserts.NotEmptyOrNull (baseUrl, "baseUrl");
            Asserts.NotEmptyOrNull (webpageUrl, "webpageUrl");
            SetBaseUrl (baseUrl);
            _webpageUrl = AppendServicePath (webpageUrl);

            var restClient = new RestClient(apiKey);
            Init(restClient, apiKey);
        }

        public EslClient (string apiKey, string baseUrl, Boolean allowAllSslCertificates)
        {
            Asserts.NotEmptyOrNull (apiKey, "apiKey");
            Asserts.NotEmptyOrNull (baseUrl, "baseUrl");
            SetBaseUrl (baseUrl);
            SetWebpageUrl (baseUrl);

            var restClient = new RestClient(apiKey, allowAllSslCertificates);
            Init(restClient, apiKey);
        }

        public EslClient (string apiKey, string baseUrl, ProxyConfiguration proxyConfiguration)
        {
            Asserts.NotEmptyOrNull (apiKey, "apiKey");
            Asserts.NotEmptyOrNull (baseUrl, "baseUrl");
            SetBaseUrl (baseUrl);
            SetWebpageUrl (baseUrl);

            var restClient = new RestClient(apiKey, proxyConfiguration);
            Init(restClient, apiKey);
        }

        public EslClient (string apiKey, string baseUrl, bool allowAllSslCertificates, ProxyConfiguration proxyConfiguration)
        {
            Asserts.NotEmptyOrNull (apiKey, "apiKey");
            Asserts.NotEmptyOrNull (baseUrl, "baseUrl");
            SetBaseUrl (baseUrl);
            SetWebpageUrl (baseUrl);

            var restClient = new RestClient(apiKey, allowAllSslCertificates, proxyConfiguration);
            Init(restClient, apiKey);
        }

        private void Init(RestClient restClient, String apiKey)
        {
            _packageService = new PackageService(restClient, _baseUrl);
            _reportService = new ReportService(restClient, _baseUrl);
            _systemService = new SystemService(restClient, _baseUrl);
            _signingService = new SigningService(restClient, _baseUrl);
            _signatureImageService = new SignatureImageService(restClient, _baseUrl);
            _sessionService = new SessionService(apiKey, _baseUrl);
            _fieldSummaryService = new FieldSummaryService(new FieldSummaryApiClient(apiKey, _baseUrl));
            _auditService = new AuditService(apiKey, _baseUrl);
            _eventNotificationService = new EventNotificationService(new EventNotificationApiClient(restClient, _baseUrl));
            _customFieldService = new CustomFieldService(new CustomFieldApiClient(restClient, _baseUrl));
            _groupService = new GroupService(new GroupApiClient(restClient, _baseUrl));
            _accountService = new AccountService(new AccountApiClient(restClient, _baseUrl));
            _approvalService = new ApprovalService(new ApprovalApiClient(restClient, _baseUrl));
            _reminderService = new ReminderService(new ReminderApiClient(restClient, _baseUrl));
            _templateService = new TemplateService(new TemplateApiClient(restClient, _baseUrl), _packageService);
            _authenticationTokenService = new AuthenticationTokenService(restClient, _baseUrl);
            _attachmentRequirementService = new AttachmentRequirementService(restClient, _baseUrl);
            _layoutService = new LayoutService(new LayoutApiClient(restClient, _baseUrl));
            _qrCodeService = new QRCodeService(new QRCodeApiClient(restClient, _baseUrl));
            _authenticationService = new AuthenticationService(_webpageUrl);
        }

        private void SetBaseUrl(string baseUrl) 
        {
            _baseUrl = baseUrl;
            _baseUrl = AppendServicePath (_baseUrl);
        }

        private void SetWebpageUrl(string baseUrl) 
        {
            _webpageUrl = baseUrl;
            if (_webpageUrl.EndsWith("/api")) 
            {
                _webpageUrl = _webpageUrl.Replace("/api", "");
            }
            _webpageUrl = AppendServicePath (_webpageUrl);
        }
            
		private string AppendServicePath(string baseUrl)
		{
			if (baseUrl.EndsWith ("/")) 
			{
				baseUrl = baseUrl.Remove (baseUrl.Length - 1);
			}

			return baseUrl;
		}

        /**
         * Facilitates access to the service that could be used to add custom field
         *
         * @return  the custom field service
         */
        public CustomFieldService GetCustomFieldService() {
            return _customFieldService;
        }

        internal bool IsSdkVersionSetInPackageData(DocumentPackage package)
        {
            if (package.Attributes != null && package.Attributes.Contents.ContainsKey("sdk"))
            {
                return true;
            }            
            return false;
        }

        internal void SetSdkVersionInPackageData(DocumentPackage package)
        {
            if (package.Attributes == null)
            {
                package.Attributes = new DocumentPackageAttributes();
            }
            package.Attributes.Append( "sdk", ".NET v" + CurrentVersion );
        }

		public PackageId CreatePackage(DocumentPackage package)
        {
            ValidateSignatures(package);
            if (!IsSdkVersionSetInPackageData(package))
            {
                SetSdkVersionInPackageData(package);
            }
        
			var packageToCreate = new DocumentPackageConverter(package).ToAPIPackage();
			var id = _packageService.CreatePackage (packageToCreate);
            var retrievedPackage = GetPackage(id);

			foreach (var document in package.Documents)
			{
                UploadDocument(document, retrievedPackage);
			}

			return id;
		}

        public PackageId CreatePackageOneStep(DocumentPackage package)
        {
            ValidateSignatures(package);
            if (!IsSdkVersionSetInPackageData(package))
            {
                SetSdkVersionInPackageData(package);
            }

            var packageToCreate = new DocumentPackageConverter(package).ToAPIPackage();
            foreach(var document in package.Documents){
                packageToCreate.AddDocument(new DocumentConverter(document).ToAPIDocument(packageToCreate));
            }
            var id = _packageService.CreatePackageOneStep (packageToCreate, package.Documents);
            return id;
        }

        public void SignDocument(PackageId packageId, string documentName) 
        {
            var package = _packageService.GetPackage(packageId);
            foreach(var document in package.Documents) 
            {
                if(document.Name.Equals(documentName)) 
                {
                    document.Approvals.Clear();
                    _signingService.SignDocument(packageId, document);
                }
            }
        }

        public void SignDocuments(PackageId packageId) 
        {
            var signedDocuments = new SignedDocuments();
            var package = _packageService.GetPackage(packageId);
            foreach(var document in package.Documents) 
            {
                document.Approvals.Clear();
                signedDocuments.AddDocument(document);
            }
            _signingService.SignDocuments(packageId, signedDocuments);
        }

        public void SignDocuments(PackageId packageId, string signerId) 
        {
            var bulkSigningKey = "Bulk Signing on behalf of";

            IDictionary<string, string> signerSessionFields = new Dictionary<string, string>();
            signerSessionFields.Add(bulkSigningKey, signerId);
            var signerAuthenticationToken = _authenticationTokenService.CreateSignerAuthenticationToken(packageId, signerId, signerSessionFields);

            var signerSessionId = _authenticationService.GetSessionIdForSignerAuthenticationToken(signerAuthenticationToken);

            var signedDocuments = new SignedDocuments();
            var package = _packageService.GetPackage(packageId);
            foreach(var document in package.Documents) 
            {
                document.Approvals.Clear();
                signedDocuments.AddDocument(document);
            }
            _signingService.SignDocuments(packageId, signedDocuments, signerSessionId);
        }

		public PackageId CreateAndSendPackage( DocumentPackage package ) 
		{
			var packageId = CreatePackage (package);
			SendPackage (packageId);
			return packageId;
		}

		public void SendPackage (PackageId id)
		{
			_packageService.SendPackage (id);
		}

        public PackageId CreateTemplateFromPackage(PackageId originalPackageId, DocumentPackage delta)
        {
			return _templateService.CreateTemplateFromPackage( originalPackageId, new DocumentPackageConverter(delta).ToAPIPackage() );
        }

        public PackageId CreateTemplateFromPackage(PackageId originalPackageId, string templateName)
        {
            var sdkPackage = PackageBuilder.NewPackageNamed( templateName ).Build();
            return CreateTemplateFromPackage( originalPackageId, sdkPackage );
        }
        
        public PackageId CreatePackageFromTemplate(PackageId templateId, string packageName)
        {
            var sdkPackage = PackageBuilder.NewPackageNamed( packageName ).Build();
            return CreatePackageFromTemplate( templateId, sdkPackage );
        }
        
        public PackageId CreatePackageFromTemplate(PackageId templateId, DocumentPackage delta)
        {
            ValidateSignatures(delta);
            SetNewSignersIndexIfRoleWorkflowEnabled(templateId, delta);
			return _templateService.CreatePackageFromTemplate( templateId, new DocumentPackageConverter(delta).ToAPIPackage() );
        }

        private void SetNewSignersIndexIfRoleWorkflowEnabled (PackageId templateId, DocumentPackage documentPackage) 
        {
            var template = new DocumentPackageConverter(_packageService.GetPackage(templateId)).ToSDKPackage();
            if (CheckSignerOrdering(template)) {
                var firstSignerIndex = template.Signers.Count;
                foreach(var signer in documentPackage.Signers)
                {
                    signer.SigningOrder = firstSignerIndex;
                    firstSignerIndex++;
                }
            }
        }

        private void ValidateSignatures(DocumentPackage documentPackage) {
            foreach(var document in documentPackage.Documents) {
                ValidateMixingSignatureAndAcceptance(document);
            }
        }

        private void ValidateMixingSignatureAndAcceptance(Document document) {
            if(CheckAcceptanceSignatureStyle(document)) {
                foreach(var signature in document.Signatures) {
                    if (signature.Style != SignatureStyle.ACCEPTANCE )
                        throw new EslException("It is not allowed to use acceptance signature styles and other signature styles together in one document.", null);
                }
            }
        }

        private bool CheckAcceptanceSignatureStyle(Document document) {
            foreach (var signature in document.Signatures) {
                if (signature.Style == SignatureStyle.ACCEPTANCE)
                    return true;
            }
            return false;
        }

        private bool CheckSignerOrdering(DocumentPackage template) {
            foreach(var signer in template.Signers)
            {
                if (signer.SigningOrder > 0) 
                {
                    return true;
                }
            }
            return false;
        }

		public PackageId CreateTemplate(DocumentPackage template)
		{
			var templateId = _templateService.CreateTemplate(new DocumentPackageConverter(template).ToAPIPackage());
			var createdTemplate = GetPackage(templateId);

			foreach (var document in template.Documents)
			{
				UploadDocument(document, createdTemplate);
			}

			return templateId;
		}

		[Obsolete("Call AuthenticationTokenService.CreateSenderAuthenticationToken() instead.")]
		public SessionToken CreateSenderSessionToken()
		{
			return _sessionService.CreateSenderSessionToken();
		}

		[Obsolete("Call AuthenticationTokenService.CreateSignerAuthenticationToken() instead.")]
		public SessionToken CreateSessionToken(PackageId packageId, string signerId)
		{
			return CreateSignerSessionToken(packageId, signerId); 
		}

		public SessionToken CreateSignerSessionToken(PackageId packageId, string signerId)
		{
			return _sessionService.CreateSignerSessionToken (packageId, signerId);
		}

        //use createUserAuthenticationToken which returns a string for the token
        [Obsolete("Call AuthenticationTokenService.CreateUserAuthenticationToken() instead.")]
		public AuthenticationToken CreateAuthenticationToken()
		{
			return _authenticationTokenService.CreateAuthenticationToken();
		}

        public byte[] DownloadDocument (PackageId packageId, string documentId)
		{
			return _packageService.DownloadDocument (packageId, documentId);
		}

        public byte[] DownloadOriginalDocument(PackageId packageId, string documentId)
        {
            return _packageService.DownloadOriginalDocument(packageId, documentId);
        }

        public byte[] DownloadEvidenceSummary (PackageId packageId)
		{
			return _packageService.DownloadEvidenceSummary (packageId);
		}

        public byte[] DownloadZippedDocuments (PackageId packageId)
		{
			return _packageService.DownloadZippedDocuments (packageId);
		}

		public DocumentPackage GetPackage (PackageId id)
		{
			var package = _packageService.GetPackage (id);

            return new DocumentPackageConverter(package).ToSDKPackage();
		}

        public void UpdatePackage(PackageId packageId, DocumentPackage sentSettings)
        {
			_packageService.UpdatePackage( packageId, new DocumentPackageConverter(sentSettings).ToAPIPackage() );
        }

        public void ChangePackageStatusToDraft(PackageId packageId) {
            _packageService.ChangePackageStatusToDraft(packageId);
        }
        
		public SigningStatus GetSigningStatus (PackageId packageId, string signerId, string documentId)
		{
			return _packageService.GetSigningStatus (packageId, signerId, documentId);
		}

		public Document UploadDocument(Document document, DocumentPackage documentPackage ) {
			return UploadDocument( document.FileName, document.Content, document, documentPackage );
		}

		public Document UploadDocument(String fileName, byte[] fileContent, Document document, DocumentPackage documentPackage)
        {
			var uploaded = _packageService.UploadDocument(documentPackage, fileName, fileContent, document);

			documentPackage.Documents.Add(uploaded);
			return uploaded;
        }

		public Document UploadDocument( Document document, PackageId packageId ) {
			var documentPackage = GetPackage(packageId);

			return UploadDocument(document, documentPackage);
		}

        public void UploadAttachment(PackageId packageId, string attachmentId, string filename, byte[] fileBytes, string signerId) {
            var signerSessionFieldKey = "Upload Attachment on behalf of";

            IDictionary<string, string> signerSessionFields = new Dictionary<string, string>();
            signerSessionFields.Add(signerSessionFieldKey, signerId);
            var signerAuthenticationToken = _authenticationTokenService.CreateSignerAuthenticationToken(packageId, signerId, signerSessionFields);
            var signerSessionId = _authenticationService.GetSessionIdForSignerAuthenticationToken(signerAuthenticationToken);

            _attachmentRequirementService.UploadAttachment(packageId, attachmentId, filename, fileBytes, signerSessionId);
        }
        
        /// <summary>
        /// BaseUrl property
        /// </summary>
		public string BaseUrl {
			get {
				return _baseUrl;
			}
		}

        /// <summary>
        /// PackageService property
        /// </summary>
		public PackageService PackageService {
			get {
				return _packageService;
			}
		}

        public ReportService ReportService {
            get {
                return _reportService;
            }
        }

        public SignatureImageService SignatureImageService {
            get {
                return _signatureImageService;
            }
        }
		        
        public TemplateService TemplateService
		{
			get
			{
				return _templateService;
			}
		}

        /// <summary>
        /// SessionService property
        /// </summary>
		public SessionService SessionService {
			get {
				return _sessionService;
			}
		}

        /// <summary>
        /// FieldSummaryService property
        /// </summary>
		public FieldSummaryService FieldSummaryService {
			get {
				return _fieldSummaryService;
			}
		}

        /// <summary>
        /// AuditService property
        /// </summary>
		public AuditService AuditService {
			get {
				return _auditService;
			}
		}

        public EventNotificationService EventNotificationService
        {
            get
            {
                return _eventNotificationService;
            }
        }

        public GroupService GroupService
        {
            get
            {
                return _groupService;
            }
        }

		public AccountService AccountService
		{
			get
			{
				return _accountService;
			}
		}

        public ApprovalService ApprovalService
        {
            get
            {
                return _approvalService;
            }
        }

		public ReminderService ReminderService
		{
			get
			{
				return _reminderService;
			}
		}
        
        public AuthenticationTokenService AuthenticationTokenService
        {
            get
            {
                return _authenticationTokenService;
            }
        }
        
        public string CurrentVersion
        {
            get
            {
                return VersionUtil.getVersion();
            }
        }   

		public AttachmentRequirementService AttachmentRequirementService
		{
			get
			{
				return _attachmentRequirementService;
			}
		}

        public LayoutService LayoutService
        {
            get
            {
                return _layoutService;
            }
        }

        public QRCodeService QrCodeService
        {
            get
            {
                return _qrCodeService;
            }
        }

        public SystemService SystemService
        {
            get
            {
                return _systemService;
            }
        }

        public SigningService SigningService
        {
            get
            {
                return _signingService;
            }
        }
	}
}	
