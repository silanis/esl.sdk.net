using System;
using System.Collections.Generic;
using System.Globalization;

namespace Silanis.ESL.SDK.Builder
{
	public class PackageBuilder
	{
		private readonly string packageName;
		private string description = String.Empty;
		private bool autocomplete = true;
		private Nullable<DateTime> expiryDate;
		private string emailMessage = String.Empty;
        private IList<Signer> signers = new List<Signer>();
        private IList<Signer> placeholders = new List<Signer> ();
        private IList<Document> documents = new List<Document>();
		private PackageId id;
		private DocumentPackageStatus status;
		private CultureInfo language;
        private DocumentPackageSettings settings;
        private SenderInfo senderInfo;
        private DocumentPackageAttributes attributes;
        private IList<Message> messages = new List<Message>();
        private Nullable<Boolean> notarized;
        private bool trashed;
        private Visibility visibility;

        private const string ORIGIN_KEY = "origin";

		private PackageBuilder(string packageName)
		{
			this.packageName = packageName;
		}

		public static PackageBuilder NewPackageNamed (string name)
		{
			return new PackageBuilder (name);
		}

        [Obsolete("Please do not use WithID() from now on. Will get deleted in a future release.")]
		public PackageBuilder WithID(PackageId id)
		{
			this.id = id;
			return this;
		}


        public PackageBuilder WithAutomaticCompletion()
        {
            autocomplete = true;
            return this;
        }
        
        public PackageBuilder WithoutAutomaticCompletion()
        {
            autocomplete = false;
            return this;
        }

		public PackageBuilder DescribedAs(string description)
		{
			this.description = description;
			return this;
		}

        public PackageBuilder ExpiresOn (Nullable<DateTime> expiryDate)
		{
			this.expiryDate = expiryDate;
			return this;
		}

		public PackageBuilder WithLanguage (CultureInfo language)
		{
			this.language = language;
			return this;
		}

		public PackageBuilder WithEmailMessage (string emailMessage)
		{
			this.emailMessage = emailMessage;
			return this;
		}

		public PackageBuilder WithSigner (SignerBuilder builder)
		{
			return WithSigner (builder.Build());
		}

		public PackageBuilder WithSigner(Signer signer)
        {
            if (signer.IsPlaceholderSigner())
            {
                placeholders.Add(signer);
            }
			else
			{
				signers.Add(signer);
			}
			return this;
		}

		public PackageBuilder WithDocument (DocumentBuilder builder)
		{
			return WithDocument (builder.Build());
		}

		public PackageBuilder WithDocument (Document document)
		{
			documents.Add(document);
			return this;
		}

        public PackageBuilder WithSettings (DocumentPackageSettings settings)
        {
            this.settings = settings;
            return this;
        }

        public PackageBuilder WithSettings (DocumentPackageSettingsBuilder builder)
        {
            return WithSettings(builder.build());
        }

        public PackageBuilder WithSenderInfo( SenderInfoBuilder builder ) {
            return WithSenderInfo(builder.Build());
        }

        public PackageBuilder WithSenderInfo( SenderInfo senderInfo ) {
            this.senderInfo = senderInfo;
            return this;
        }
        
		public PackageBuilder WithStatus (DocumentPackageStatus status) {
			this.status = status;
			return this;
		}

        public PackageBuilder WithAttributes(DocumentPackageAttributes attributes)
        {
            if(null == this.attributes) 
            {
                this.attributes = new DocumentPackageAttributes();
            }
            this.attributes.Append(attributes);
            return this;
        }

        public PackageBuilder WithAttributes(DocumentPackageAttributesBuilder attributesBuilder)
        {
            return WithAttributes( attributesBuilder.Build() );
        }

        public PackageBuilder WithOrigin(string origin)
        {

            if(null == attributes) 
            {
                attributes = new DocumentPackageAttributes();
            }
            attributes.Append(ORIGIN_KEY, origin);
            return this;
        }

        [Obsolete("Use WithAttributes() instead.  Notice the uppercase W.")]
        public PackageBuilder withAttributes( DocumentPackageAttributes attributes) {
            return WithAttributes( attributes );
        } 

        public PackageBuilder WithNotarized(Nullable<Boolean> notarized) {
            this.notarized = notarized;
            return this;
        }

        public PackageBuilder WithTrashed(bool trashed) {
            this.trashed = trashed;
            return this;
        }

        public PackageBuilder WithVisibility(Visibility visibility) {
            this.visibility = visibility;
            return this;
        }


		public DocumentPackage Build()
        {
            var package = new DocumentPackage(id, packageName, autocomplete, signers, placeholders, documents);
            package.Description = description;
            package.ExpiryDate = expiryDate;
            package.EmailMessage = emailMessage;
            package.Status = status;
            package.Language = language;
            package.Settings = settings;
            package.SenderInfo = senderInfo;
            package.Attributes = attributes;
            package.Messages = messages;
            package.Notarized = notarized;
            package.Trashed = trashed;

            if ( visibility != null ) {
                package.Visibility = visibility;
            }

			return package;
		}
    }
}