using Silanis.ESL.API;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;
using System.Globalization;

namespace Silanis.ESL.SDK
{
	internal class DocumentPackageConverter
    {
		private Package apiPackage = null;
		private DocumentPackage sdkPackage = null;

		/// <summary>
		/// Construct with API object involved in conversion.
		/// </summary>
		/// <param name="apiPackage">API Package.</param>
		public DocumentPackageConverter(Package apiPackage)
        {
			this.apiPackage = apiPackage;
        }

		/// <summary>
		/// Construct with SDK object involved in conversion.
		/// </summary>
		/// <param name="sdkPackage">SDK DocumentPackage.</param>
		public DocumentPackageConverter(DocumentPackage sdkPackage)
		{
			this.sdkPackage = sdkPackage;
		}

		internal Package ToAPIPackage()
		{
			if (sdkPackage == null)
			{
				return apiPackage;
			}

			var package = new Package();

			package.Name = sdkPackage.Name;
			package.Due = sdkPackage.ExpiryDate;
			package.Autocomplete = sdkPackage.Autocomplete;

            if (sdkPackage.Id != null)
            {
                package.Id = sdkPackage.Id.ToString();
            }

            if (sdkPackage.Status != null)
            {
                package.Status = sdkPackage.Status;
            }

			if (sdkPackage.Description != null)
			{
				package.Description = sdkPackage.Description;
			}

			if (sdkPackage.EmailMessage != null)
			{
				package.EmailMessage = sdkPackage.EmailMessage;
			}

			if (sdkPackage.Language != null)
			{
				package.Language = sdkPackage.Language.TwoLetterISOLanguageName;
			}

			if (sdkPackage.Settings != null)
			{
				package.Settings = sdkPackage.Settings.toAPIPackageSettings();
			}

			if (sdkPackage.SenderInfo != null)
			{
				package.Sender = new SenderConverter(sdkPackage.SenderInfo).ToAPISender();
			}

			if (sdkPackage.Attributes != null)
			{
				package.Data = sdkPackage.Attributes.Contents;
			}

            if ( sdkPackage.Notarized != null ) {
                package.Notarized = sdkPackage.Notarized;
            }

            if ( sdkPackage.Trashed != null ) {
                package.Trashed = sdkPackage.Trashed;
            }

            if ( sdkPackage.Visibility != null ) {
                package.Visibility = sdkPackage.Visibility;
            }

			var signerCount = 1;
			foreach (var signer in sdkPackage.Signers)
			{
                var role = new SignerConverter(signer).ToAPIRole("signer" + signerCount);
				package.AddRole(role);
				signerCount++;
			}
			foreach (var signer in sdkPackage.Placeholders)
			{
                var role = new SignerConverter(signer).ToAPIRole(signer.Id, signer.PlaceholderName);
				package.AddRole(role);
				signerCount++;
			}

			return package;
		}

        internal DocumentPackage ToSDKPackage()
        {
            if (apiPackage == null)
            {
                return sdkPackage;
            }

            var packageBuilder = PackageBuilder.NewPackageNamed(apiPackage.Name);

            packageBuilder.WithID(new PackageId(apiPackage.Id));

            if (apiPackage.Autocomplete.Value)
            {
                packageBuilder.WithAutomaticCompletion();
            }
            else
            {
                packageBuilder.WithoutAutomaticCompletion();
            }

            packageBuilder.ExpiresOn(apiPackage.Due);
            packageBuilder.WithStatus(new PackageStatusConverter(apiPackage.Status).ToSDKPackageStatus());


            if (apiPackage.Description != null)
            {
                packageBuilder.DescribedAs(apiPackage.Description);
            }

            if (apiPackage.EmailMessage != null)
            {
                packageBuilder.WithEmailMessage(apiPackage.EmailMessage);
            }

            if (apiPackage.Language != null)
            {
                packageBuilder.WithLanguage(new CultureInfo(apiPackage.Language));
            }

            if (apiPackage.Settings != null)
            {
                packageBuilder.WithSettings(new DocumentPackageSettingsConverter(apiPackage.Settings).toSDKDocumentPackageSettings());
            }

            if (apiPackage.Sender != null)
            {
                packageBuilder.WithSenderInfo(new SenderConverter(apiPackage.Sender).ToSDKSenderInfo());
            }

            if (apiPackage.Notarized != null) {
                packageBuilder.WithNotarized(apiPackage.Notarized);
            }

            if (apiPackage.Trashed != null) {
                packageBuilder.WithTrashed(apiPackage.Trashed.Value);
            }

            if (apiPackage.Visibility != null) {
                packageBuilder.WithVisibility(new VisibilityConverter(apiPackage.Visibility).ToSDKVisibility());
            }

            packageBuilder.WithAttributes(new DocumentPackageAttributesBuilder(apiPackage.Data).Build());

            foreach (var role in apiPackage.Roles)
            {
                if (role.Signers.Count == 0)
                {
                    packageBuilder.WithSigner(SignerBuilder.NewSignerPlaceholder(new Placeholder(role.Id, role.Name)));
                }
                else if (role.Signers[0].Group != null)
                {
                    packageBuilder.WithSigner(SignerBuilder.NewSignerFromGroup(new GroupId(role.Signers[0].Group.Id)));
                }
                else
                {
                    packageBuilder.WithSigner(new SignerConverter(role).ToSDKSigner());

                    // The custom sender information is stored in the role.signer object.
                    if ("SENDER".Equals(role.Type))
                    {
                        // Override sender info with the customized ones.
                        var senderInfo = new SenderInfo();

                        var signer = role.Signers[0];
                        senderInfo.FirstName = signer.FirstName;
                        senderInfo.LastName = signer.LastName;
                        senderInfo.Title = signer.Title;
                        senderInfo.Company = signer.Company;
                        senderInfo.Email = signer.Email;

                        packageBuilder.WithSenderInfo(senderInfo);
                    }
                }
            }

            foreach (var apiDocument in apiPackage.Documents)
            {
                var document = new DocumentConverter(apiDocument, apiPackage).ToSDKDocument();
                packageBuilder.WithDocument(document);
            }

            var documentPackage = packageBuilder.Build();

            IList<Message> messages = new List<Message>();
            foreach (var apiMessage in apiPackage.Messages)
            {
                messages.Add(new MessageConverter(apiMessage).ToSDKMessage());
            }
            documentPackage.Messages = messages;
            if (apiPackage.Updated != null) {
                documentPackage.UpdatedDate = apiPackage.Updated;
            }

            return documentPackage;
        }
    }
}

