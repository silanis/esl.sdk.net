using System;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
	public class DocumentPackageSettingsBuilder
	{
		private Nullable<bool> enableInPerson = null;
		private Nullable<bool> enableOptOut = null;
		private Nullable<bool> enableDecline = null;
		private Nullable<bool> hideWatermark = null;
		private Nullable<bool> hideCaptureText = null;
        private List<string> declineReasons = new List<string>();
		private List<string> optOutReasons = new List<string>();
		private Nullable<int> maxAuthAttempts = null;
		private Nullable<bool> showDocumentToolbarDownloadButton = true;
		private Nullable<bool> showDialogOnComplete = null;
        private Nullable<bool> showLanguageDropDown = null;
        private Nullable<bool> enableFirstAffidavit = null;
        private Nullable<bool> enableSecondAffidavit = null;
        private Nullable<bool> showOwnerInPersonDropDown = null;
        private Nullable<bool> disableDeclineOther = null;
        private Nullable<bool> disableOptOutOther = null;

		private string linkText = null;
		private string linkTooltip = null;
		private string linkHref = null;

		private CeremonyLayoutSettings ceremonyLayoutSettings = null;

		private DocumentPackageSettingsBuilder ()
		{
		}

        public DocumentPackageSettingsBuilder ShowOwnerInPersonDropDown()
        {
            showOwnerInPersonDropDown = true;
            return this;
        }
        
        public DocumentPackageSettingsBuilder HideOwnerInPersonDropDown()
        {
            showOwnerInPersonDropDown = false;
            return this;
        }
        
        public DocumentPackageSettingsBuilder EnableFirstAffidavit()
        {
            enableFirstAffidavit = true;
            return this;
        }
        
        public DocumentPackageSettingsBuilder DisableFirstAffidavit()
        {
            enableFirstAffidavit = false;
            return this;
        }

        public DocumentPackageSettingsBuilder EnableSecondAffidavit()
        {
            enableSecondAffidavit = true;
            return this;
        }
        
        public DocumentPackageSettingsBuilder DisableSecondAffidavit()
        {
            enableSecondAffidavit = false;
            return this;
        }

        public DocumentPackageSettingsBuilder WithLanguageDropDown()
        {
            showLanguageDropDown = true;
            return this;
        }

        public DocumentPackageSettingsBuilder WithoutLanguageDropDown()
        {
            showLanguageDropDown = false;
            return this;
        }

        public DocumentPackageSettingsBuilder WithoutDocumentToolbarDownloadButton()
        {
            showDocumentToolbarDownloadButton = false;
            return this;
        }

        public DocumentPackageSettingsBuilder WithDocumentToolbarDownloadButton()
        {
            showDocumentToolbarDownloadButton = true;
            return this;
        }

        public DocumentPackageSettingsBuilder WithDialogOnComplete()
        {
            showDialogOnComplete = true;
            return this;
        }

		public DocumentPackageSettingsBuilder WithoutDialogOnComplete()
		{
			showDialogOnComplete = false;
			return this;
		}

		public DocumentPackageSettingsBuilder WithInPerson()
		{
			enableInPerson = true;
			return this;
		}

		public DocumentPackageSettingsBuilder WithoutInPerson()
		{
			enableInPerson = false;
			return this;
		}

		public DocumentPackageSettingsBuilder WithOptOut()
		{
			enableOptOut = true;
			return this;
		}

		public DocumentPackageSettingsBuilder WithoutOptOut()
		{
			enableOptOut = false;
			return this;
		}

		public DocumentPackageSettingsBuilder WithDecline()
		{
			enableDecline = true;
			return this;
		}

		public DocumentPackageSettingsBuilder WithoutDecline() {
			enableDecline = false;
			return this;
		}

        public DocumentPackageSettingsBuilder WithWatermark() {
            hideWatermark = false;
            return this;
        }

		public DocumentPackageSettingsBuilder WithoutWatermark() {
			hideWatermark = true;
			return this;
		}

        public DocumentPackageSettingsBuilder WithCaptureText() {
            hideCaptureText = false;
            return this;
        }

		public DocumentPackageSettingsBuilder WithoutCaptureText() {
			hideCaptureText = true;
			return this;
		}

		public DocumentPackageSettingsBuilder WithHandOverLinkHref( String href )
		{
            Asserts.NotEmptyOrNull(href, "href");

			linkHref = href;

            //If no protocol was specified, we assume https
            if (!linkHref.StartsWith("http://") && !linkHref.StartsWith("https://"))
            {
                linkHref = "https://" + linkHref;
            }

			return this;
		}

		public DocumentPackageSettingsBuilder WithHandOverLinkText( String text )
		{
			linkText = text;
			return this;
		}

		public DocumentPackageSettingsBuilder WithHandOverLinkTooltip( String tooltip )
		{
			linkTooltip = tooltip;
			return this;
		}

        public DocumentPackageSettingsBuilder WithDeclineReason( String reason )
        {
            declineReasons.Add( reason );
            return this;
        }

		public DocumentPackageSettingsBuilder WithOptOutReason( String reason )
		{
			optOutReasons.Add( reason );
			return this;
		}

		public DocumentPackageSettingsBuilder WithCeremonyLayoutSettings( CeremonyLayoutSettingsBuilder builder )
		{
			return WithCeremonyLayoutSettings (builder.Build ());
		}

		public DocumentPackageSettingsBuilder WithCeremonyLayoutSettings( CeremonyLayoutSettings ceremonyLayoutSettings )
		{
			this.ceremonyLayoutSettings = ceremonyLayoutSettings;
			return this;
		}

        public DocumentPackageSettingsBuilder WithMaxAuthAttempts(int maxAuthAttempts)
        {
            this.maxAuthAttempts = maxAuthAttempts;
            return this;
        }

        public DocumentPackageSettingsBuilder WithDeclineOther()
        {
            disableDeclineOther = false;
            return this;
        }

        public DocumentPackageSettingsBuilder WithoutDeclineOther()
        {
            disableDeclineOther = true;
            return this;
        }

        public DocumentPackageSettingsBuilder WithOptOutOther()
        {
            disableOptOutOther = false;
            return this;
        }

        public DocumentPackageSettingsBuilder WithoutOptOutOther()
        {
            disableOptOutOther = true;
            return this;
        }

        public DocumentPackageSettings build()
        {
            return Build();
        }

		public DocumentPackageSettings Build()
		{
			var result = new DocumentPackageSettings ();

			result.EnableInPerson = enableInPerson;
			result.EnableOptOut = enableOptOut;
			result.EnableDecline = enableDecline;
			result.HideWatermark = hideWatermark;
			result.HideCaptureText = hideCaptureText;
            foreach ( var declineReason in declineReasons )
                result.DeclineReasons.Add( declineReason );
            foreach ( var optOutReason in optOutReasons )
                result.OptOutReasons.Add( optOutReason );
			result.MaxAuthAttempts = maxAuthAttempts;
			result.ShowDownloadButton = showDocumentToolbarDownloadButton;
			result.ShowDialogOnComplete = showDialogOnComplete;
            result.ShowLanguageDropDown = showLanguageDropDown;
            result.EnableFirstAffidavit = enableFirstAffidavit;
            result.EnableSecondAffidavit = enableSecondAffidavit;
            result.ShowOwnerInPersonDropDown = showOwnerInPersonDropDown;
            result.DisableDeclineOther = disableDeclineOther;
            result.DisableOptOutOther = disableOptOutOther;
			result.LinkHref = linkHref;
			result.LinkText = linkText;
			result.LinkTooltip = linkTooltip;

			result.CeremonyLayoutSettings = ceremonyLayoutSettings;

			return result;
		}

        public static DocumentPackageSettingsBuilder NewDocumentPackageSettings()
        {
            return new DocumentPackageSettingsBuilder();
        }

        internal DocumentPackageSettingsBuilder( PackageSettings apiPackageSettings )
        {
            enableInPerson = apiPackageSettings.Ceremony.InPerson;
            enableOptOut = apiPackageSettings.Ceremony.OptOutButton;
            enableDecline = apiPackageSettings.Ceremony.DeclineButton;
            hideWatermark = apiPackageSettings.Ceremony.HideWatermark;
            hideCaptureText = apiPackageSettings.Ceremony.HideCaptureText;
            enableFirstAffidavit = !apiPackageSettings.Ceremony.DisableFirstInPersonAffidavit;
            enableSecondAffidavit = !apiPackageSettings.Ceremony.DisableSecondInPersonAffidavit;
            showOwnerInPersonDropDown = !apiPackageSettings.Ceremony.HidePackageOwnerInPerson;
            showLanguageDropDown = !apiPackageSettings.Ceremony.HideLanguageDropdown;
            disableDeclineOther = apiPackageSettings.Ceremony.DisableDeclineOther;
            disableOptOutOther = apiPackageSettings.Ceremony.DisableOptOutOther;

            foreach (var declineReason in apiPackageSettings.Ceremony.DeclineReasons)
            {
                declineReasons.Add(declineReason);
            }

            foreach (var optOutReason in apiPackageSettings.Ceremony.OptOutReasons)
            {
                optOutReasons.Add(optOutReason);
            }

            maxAuthAttempts = apiPackageSettings.Ceremony.MaxAuthFailsAllowed;

            if (apiPackageSettings.Ceremony.DocumentToolbarOptions != null)
            {
                showDocumentToolbarDownloadButton = apiPackageSettings.Ceremony.DocumentToolbarOptions.DownloadButton;
            }

            if (apiPackageSettings.Ceremony.Events != null && apiPackageSettings.Ceremony.Events.Complete != null)
            {
                showDialogOnComplete = apiPackageSettings.Ceremony.Events.Complete.Dialog;
            }

            if (apiPackageSettings.Ceremony.HandOver != null)
            {
                linkHref = apiPackageSettings.Ceremony.HandOver.Href;
                linkText = apiPackageSettings.Ceremony.HandOver.Text;
                linkTooltip = apiPackageSettings.Ceremony.HandOver.Title;
            }
        }

	}
}

