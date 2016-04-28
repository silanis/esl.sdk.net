using System;

namespace Silanis.ESL.SDK.Internal
{
	/// <summary>
	/// For internal use.
	/// </summary>
	public class UrlTemplate
	{
		private String baseUrl;
		private String path;

//		@QueryParam("query") final String query,
//		@QueryParam("search") final String search,
//		@QueryParam("from") int fromRec,
//		@QueryParam("to") int toRec,
//		@QueryParam("sort") String orderBy,
//		@QueryParam("dir") String orderDir


		// Package Service
		public static readonly string PACKAGE_PATH = "/packages";
		public static readonly string PACKAGE_LIST_PATH = "/packages?query={status}&from={from}&to={to}";
        public static readonly string PACKAGE_LIST_STATUS_DATE_RANGE_PATH = "/packages?query={status}&from={from}&to={to}&lastUpdatedStartDate={lastUpdatedStartDate}&lastUpdatedEndDate={lastUpdatedEndDate}";
        public static readonly string TEMPLATE_LIST_PATH = "/packages?type=TEMPLATE&from={from}&to={to}";
		public static readonly string PACKAGE_ID_PATH = "/packages/{packageId}";
		public static readonly string DOCUMENT_PATH = "/packages/{packageId}/documents";
		public static readonly string DOCUMENT_ID_PATH = "/packages/{packageId}/documents/{documentId}";
		public static readonly string ROLE_PATH = "/packages/{packageId}/roles";
        public static readonly string ROLE_ID_PATH = "/packages/{packageId}/roles/{roleId}";
        public static readonly string ROLE_UNLOCK_PATH = "/packages/{packageId}/roles/{roleId}/unlock";
		public static readonly string NOTIFICATIONS_PATH = "/packages/{packageId}/notifications";
		public static readonly string PDF_PATH = "/packages/{packageId}/documents/{documentId}/pdf";
		public static readonly string ORIGINAL_PATH = "/packages/{packageId}/documents/{documentId}/original";
		public static readonly string ZIP_PATH = "/packages/{packageId}/documents/zip";
		public static readonly string EVIDENCE_SUMMARY_PATH = "/packages/{packageId}/evidence/summary";
		public static readonly string SIGNING_STATUS_PATH = "/packages/{packageId}/signingStatus?signer={signerId}&document={documentId}";
		public static readonly string NOTIFY_ROLE_PATH = "/packages/{packageId}/roles/{roleId}/notifications";
        public static readonly string CLONE_PACKAGE_PATH = "/packages/{packageId}/clone";
        public static readonly string THANK_YOU_DIALOG_PATH = "/packages/{packageId}/thank_you_dialog";
        public static readonly string PACKAGE_INFORMATION_CONFIG_PATH = "/package_information/{packageId}/support_information";

        // Report Service
        public static readonly string COMPLETION_REPORT_PATH = "/reports/completion?senderId={senderId}&status={status}&from={from}&to={to}";
        public static readonly string COMPLETION_REPORT_FOR_ALL_SENDERS_PATH = "/reports/completion?status={status}&from={from}&to={to}";
        public static readonly string USAGE_REPORT_PATH = "/reports/usage?from={from}&to={to}";
        public static readonly string DELEGATION_REPORT_PATH = "/reports/delegation";

        // Signer Service
        public static readonly string GET_SIGNER_PATH = "/packages/{packageId}/roles/{roleId}";
        public static readonly string ADD_SIGNER_PATH = "/packages/{packageId}/roles";
        public static readonly string UPDATE_SIGNER_PATH = "/packages/{packageId}/roles/{roleId}";
        public static readonly string REMOVE_SIGNER_PATH = "/packages/{packageId}/roles/{roleId}";
        public static readonly string SIGNER_URL_PATH = "/packages/{packageId}/roles/{roleId}/signingUrl";
        public static readonly string SEND_SMS_TO_SIGNER_PATH = "/packages/{packageId}/roles/{roleId}/sms_notification";

        // Fast Track Service
        public static readonly string FAST_TRACK_URL_PATH = "/fastTrack/{packageId}/url?signing={signing}";
        public static readonly string START_FAST_TRACK_PATH = "/fastTrack?token={token}";

        // System Service
        public static readonly string SYSTEM_PATH = "/sysinfo";

        // Event Notification Service
        public static readonly string CALLBACK_PATH = "/callback";
        public static readonly string CONNECTORS_CALLBACK_PATH = "/callback/connectors/{origin}";

		// Audit Service
		public static readonly string AUDIT_PATH = "/packages/{packageId}/audit";

		// Field Summary Service
		public static readonly string FIELD_SUMMARY_PATH = "/packages/{packageId}/fieldSummary";

		// Session Service
		public static readonly string SESSION_PATH = "/sessions?package={packageId}&signer={signerId}";
		public static readonly string SENDER_SESSION_PATH = "/sessions";

        // Custom Field Service
        public static readonly string ACCOUNT_CUSTOMFIELD_PATH = "/account/customfields";
        public static readonly string ACCOUNT_CUSTOMFIELD_LIST_PATH = "/account/customfields?dir={dir}&from={from}&to={to}";
		public static readonly string ACCOUNT_CUSTOMFIELD_ID_PATH = "/account/customfields/{customFieldId}";
        public static readonly string USER_CUSTOMFIELD_PATH = "/user/customfields";
		public static readonly string USER_CUSTOMFIELD_ID_PATH = "/user/customfields/{customFieldId}";

        // Groups Service
        public static readonly string GROUPS_PATH = "/groups";
        public static readonly string GROUPS_SUMMARY_PATH = "/groups/summary";
        public static readonly string GROUPS_ID_PATH = "/groups/{groupId}";
        public static readonly string GROUPS_MEMBER_PATH = "/groups/{groupId}/members";
        public static readonly string GROUPS_INVITE_PATH = "/groups/{groupId}/invite";

        // Account Service
        public static readonly string ACCOUNT_MEMBER_PATH = "/account/senders";
        public static readonly string ACCOUNT_MEMBER_ID_PATH = "/account/senders/{senderUid}";
        public static readonly string ACCOUNT_MEMBER_INVITE_PATH = "/account/senders/{senderUid}/invite";
        public static readonly string ACCOUNT_MEMBER_LIST_PATH = "/account/senders?to={to}&from={from}&dir={dir}";
        public static readonly string ACCOUNT_CONTACTS_PATH = "/users";

        // Approval Service
        public static readonly string APPROVAL_PATH = "/packages/{packageId}/documents/{documentId}/approvals";
        public static readonly string APPROVAL_ID_PATH = "/packages/{packageId}/documents/{documentId}/approvals/{approvalId}";
        public static readonly string FIELD_PATH = "/packages/{packageId}/documents/{documentId}/approvals/{approvalId}/fields";
        public static readonly string FIELD_ID_PATH = "/packages/{packageId}/documents/{documentId}/approvals/{approvalId}/fields/{fieldId}";
        public static readonly string SIGNABLE_APPROVAL_PATH = "/packages/{packageId}/documents/{documentId}/signers/{signerId}/approvals";

        // Provider Document Resource
        public static readonly string PROVIDER_DOCUMENTS = "/documents";

		// Reminder Service
		public static readonly string REMINDER_PATH = "/packages/{packageId}/reminders";

        // Signing Service
        public static readonly string SIGN_DOCUMENT_PATH = "/packages/{packageId}/documents/signConfirm";
        public static readonly string SIGN_DOCUMENTS_PATH = "/packages/{packageId}/documents/signed_documents";

        // NotaryJournal Service
        public static readonly string NOTARY_JOURNAL_PATH = "/user/{userId}/journal";
        public static readonly string NOTARY_JOURNAL_CSV_PATH = "/user/{userId}/journal/download";
        public static readonly string NOTARY_JOURNAL_LIST_PATH = "/user/{userId}/journal?to={to}&from={from}&dir={dir}";

        // Delegation Service
        public static readonly string DELEGATES_PATH = "/account/senders/{senderId}/delegates";
        public static readonly string DELEGATE_ID_PATH = "/account/senders/{senderId}/delegates/{delegateId}";

        //Authentication Token Services
        public static readonly string ESL_AUTHENTICATION_PATH = "/auth";
        public static readonly string USER_AUTHENTICATION_TOKEN_PATH = "/authenticationTokens";
        public static readonly string AUTHENTICATION_PATH_FOR_USER_AUTHENTICATION_TOKEN = "?authenticationToken={authenticationToken}";
        public static readonly string AUTHENTICATION_PATH_FOR_USER_AUTHENTICATION_TOKEN_WITH_REDIRECT = "?authenticationToken={authenticationToken}&target={redirectUrl}";
        public static readonly string SENDER_AUTHENTICATION_TOKEN_PATH = "/senderAuthenticationTokens";
        public static readonly string AUTHENTICATION_PATH_FOR_SENDER_AUTHENTICATION_TOKEN = "?senderAuthenticationToken={senderAuthenticationToken}";
        public static readonly string AUTHENTICATION_PATH_FOR_SENDER_AUTHENTICATION_TOKEN_WITH_REDIRECT = "?senderAuthenticationToken={senderAuthenticationToken}&target={redirectUrl}";
        public static readonly string SIGNER_AUTHENTICATION_TOKEN_PATH = "/signerAuthenticationTokens";
        public static readonly string AUTHENTICATION_PATH_FOR_SIGNER_AUTHENTICATION_TOKEN = "?signerAuthenticationToken={signerAuthenticationToken}";
        public static readonly string AUTHENTICATION_PATH_FOR_SIGNER_AUTHENTICATION_TOKEN_WITH_REDIRECT = "?signerAuthenticationToken={signerAuthenticationToken}&target={redirectUrl}";

        // Webpage redirect urls
        public static readonly string DESIGNER_REDIRECT_PATH = "/designer/{packageId}";
        public static readonly string PACKAGE_VIEW_REDIRECT_PATH = "/packages/{packageId}";
        public static readonly string SIGNING_REDIRECT_PATH = "/packages/{packageId}/sign";  

		// AttachmentRequirement Service
		public static readonly string ATTACHMENT_REQUIREMENT_PATH = "/packages/{packageId}/attachment/{attachmentId}";
        public static readonly string ALL_ATTACHMENTS_PATH = "/packages/{packageId}/attachment/zip";
        public static readonly string ALL_ATTACHMENTS_FOR_ROLE_PATH = "/packages/{packageId}/attachment/zip/{roleId}";

        // Layout Service
        public static readonly string LAYOUT_PATH = "/layouts";
        public static readonly string LAYOUT_LIST_PATH = "/layouts?to={to}&from={from}&dir={dir}";
        public static readonly string APPLY_LAYOUT_PATH = "/packages/{packageId}/documents/{documentId}/layout?layoutId={layoutId}";

        // QR Code Service
        public static readonly string QRCODE_PATH = "/packages/{packageId}/documents/{documentId}/fields";
        public static readonly string QRCODE_ID_PATH = "/packages/{packageId}/documents/{documentId}/fields/{fieldId}";

        // Signature Image Service
        public static readonly string SIGNATURE_IMAGE_FOR_SENDER_PATH = "/account/senders/{senderId}/signatureImage";
        public static readonly string SIGNATURE_IMAGE_FOR_PACKAGE_ROLE_PATH = "/packages/{packageId}/roles/{roleId}/signatureImage";


		public UrlTemplate (string baseUrl)
		{
			this.baseUrl = baseUrl;
		}

		public UrlTemplate UrlFor (string path)
		{
			this.path = path;
			return this;
		}

		public UrlTemplate Replace (string pathParams, string value)
		{
			path = path.Replace (pathParams, value);
			return this;
		}

		public string Build ()
		{
			return baseUrl + path;
		}
	}
}

