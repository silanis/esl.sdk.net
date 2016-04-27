using System;
using Silanis.ESL.API;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	public class DocumentPackageSettings
	{
        private Nullable<bool> showLanguageDropDown = null;
        public Nullable<bool> ShowLanguageDropDown
        {
            get { return showLanguageDropDown; }
            set { showLanguageDropDown = value; }
        }
        
        private Nullable<bool> enableFirstAffidavit = null;
        public Nullable<bool> EnableFirstAffidavit
        {
            get { return enableFirstAffidavit; }
            set { enableFirstAffidavit = value; }
        }
        
        private Nullable<bool> enableSecondAffidavit = null;
        public Nullable<bool> EnableSecondAffidavit
        {
            get { return enableSecondAffidavit; }
            set { enableSecondAffidavit = value; }
        }

        private Nullable<bool> showOwnerInPersonDropDown = null;
        public Nullable<bool> ShowOwnerInPersonDropDown
        {
            get { return showOwnerInPersonDropDown; }
            set { showOwnerInPersonDropDown = value; }
        }
        
		private Nullable<bool> enableInPerson = null;

		public Nullable<bool> EnableInPerson {
			get {
				return enableInPerson;
			}
			set {
				enableInPerson = value;
			}
		}

		private Nullable<bool> enableOptOut = null;

		public Nullable<bool> EnableOptOut {
			get {
				return enableOptOut;
			}
			set {
				enableOptOut = value;
			}
		}

        private Nullable<bool> disableOptOutOther = null;

        public Nullable<bool> DisableOptOutOther {
            get {
                return disableOptOutOther;
            }
            set {
                disableOptOutOther = value;
            }
        }

		private Nullable<bool> enableDecline = null;

		public Nullable<bool> EnableDecline {
			get {
				return enableDecline;
			}
			set {
				enableDecline = value;
			}
		}

        private Nullable<bool> disableDeclineOther = null;

        public Nullable<bool> DisableDeclineOther {
            get {
                return disableDeclineOther;
            }
            set {
                disableDeclineOther = value;
            }
        }

		private Nullable<bool> hideWatermark = null;

		public Nullable<bool> HideWatermark {
			get {
				return hideWatermark;
			}
			set {
				hideWatermark = value;
			}
		}

		private Nullable<bool> hideCaptureText = null;

		public Nullable<bool> HideCaptureText {
			get {
				return hideCaptureText;
			}
			set {
				hideCaptureText = value;
			}
		}

        private List<string> declineReasons = new List<string>();

        public List<string> DeclineReasons {
            get {
                return declineReasons;
            }
            set {
                declineReasons = value;
            }
        }

		private List<string> optOutReasons = new List<string>();

		public List<string> OptOutReasons {
			get {
				return optOutReasons;
			}
			set {
				optOutReasons = value;
			}
		}

		private Nullable<int> maxAuthAttempts = null;

		public Nullable<int> MaxAuthAttempts {
			get {
				return maxAuthAttempts;
			}
			set {
				maxAuthAttempts = value;
			}
		}

		private Nullable<bool> showDownloadButton = true;

		public Nullable<bool> ShowDownloadButton {
			get {
				return showDownloadButton;
			}
			set {
				showDownloadButton = value;
			}
		}

		private Nullable<bool> showDialogOnComplete = null;

		public Nullable<bool> ShowDialogOnComplete {
			get {
				return showDialogOnComplete;
			}
			set {
				showDialogOnComplete = value;
			}
		}

		private string linkText;

		public string LinkText {
			get {
				return linkText;
			}
			set {
				linkText = value;
			}
		}

		private string linkTooltip;

		public string LinkTooltip {
			get {
				return linkTooltip;
			}
			set {
				linkTooltip = value;
			}
		}

		private string linkHref;

		public string LinkHref {
			get {
				return linkHref;
			}
			set {
				linkHref = value;
			}
		}

		private CeremonyLayoutSettings ceremonyLayoutSettings = null;

		public CeremonyLayoutSettings CeremonyLayoutSettings {
			get {
				return ceremonyLayoutSettings;
			}
			set {
				ceremonyLayoutSettings = value;
			}
		}

		internal PackageSettings toAPIPackageSettings() {

			var ceremonySettings = new CeremonySettings();

			if ( enableInPerson != null )
				ceremonySettings.InPerson = enableInPerson.Value;

			if ( enableOptOut != null )
				ceremonySettings.OptOutButton = enableOptOut.Value;	

			if ( enableDecline != null )
			    ceremonySettings.DeclineButton = enableDecline.Value;

            if ( disableOptOutOther != null )
                ceremonySettings.DisableOptOutOther = disableOptOutOther.Value; 

            if ( disableDeclineOther != null )
                ceremonySettings.DisableDeclineOther = disableDeclineOther.Value;

            if ( hideWatermark != null )
			    ceremonySettings.HideWatermark = hideWatermark.Value;

            if ( hideCaptureText != null )
			    ceremonySettings.HideCaptureText = hideCaptureText.Value;

            if ( enableFirstAffidavit != null )
                ceremonySettings.DisableFirstInPersonAffidavit = !enableFirstAffidavit.Value;
                
            if ( enableSecondAffidavit != null )
                ceremonySettings.DisableSecondInPersonAffidavit = !enableSecondAffidavit.Value;
                
            if ( showOwnerInPersonDropDown != null )
                ceremonySettings.HidePackageOwnerInPerson = !showOwnerInPersonDropDown.Value;
                
            if ( showLanguageDropDown != null )
                ceremonySettings.HideLanguageDropdown = !showLanguageDropDown.Value;

            foreach ( var declineReason in declineReasons )
                ceremonySettings.DeclineReasons.Add( declineReason );

            foreach ( var optOutReason in optOutReasons )
                ceremonySettings.OptOutReasons.Add( optOutReason );

            if ( maxAuthAttempts != null )
			    ceremonySettings.MaxAuthFailsAllowed = maxAuthAttempts.Value;

			if ( linkHref != null ) {
				var link = new Link();
				link.Href = linkHref;
				link.Text = ( linkText == null ? linkHref : linkText );
				link.Title = ( linkTooltip == null ? linkHref : linkTooltip );
				ceremonySettings.HandOver = link;
			}

			if ( showDialogOnComplete != null ) {
				var ceremonyEvents = new CeremonyEvents();
				var ceremonyEventComplete = new CeremonyEventComplete();
				if ( showDialogOnComplete != null )
					ceremonyEventComplete.Dialog = showDialogOnComplete.Value;

				ceremonyEvents.Complete = ceremonyEventComplete;
                ceremonySettings.Events = ceremonyEvents;
			}

			if ( showDownloadButton != null ) {
				var documentToolbarOptions = new DocumentToolbarOptions();
			    if ( showDownloadButton != null ) 
					documentToolbarOptions.DownloadButton = showDownloadButton.Value;
				ceremonySettings.DocumentToolbarOptions = documentToolbarOptions;
			}

			if ( ceremonyLayoutSettings != null ) {
				ceremonySettings.Layout = new CeremonyLayoutSettingsConverter(ceremonyLayoutSettings).ToAPILayoutOptions();
			}

			var result = new PackageSettings();
			result.Ceremony = ceremonySettings;

			return result;
		}
	}
}

