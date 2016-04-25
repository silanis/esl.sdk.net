using System;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    internal class SignerConverter
    {
		private Signer sdkSigner = null;
		private Silanis.ESL.API.Signer apiSigner = null;
		private Silanis.ESL.API.Role apiRole = null;
    
        public SignerConverter( Signer signer )
        {
            this.sdkSigner = signer;
        }

        public SignerConverter( Placeholder placeholder )
        {
            this.sdkSigner = new Signer(placeholder.Id);
        }

		public SignerConverter (Silanis.ESL.API.Role apiRole)
		{
			this.apiRole = apiRole;

			if (apiRole != null)
			{
				this.apiSigner = apiRole.Signers[0];
			}
		}

        public Silanis.ESL.API.Role ToAPIRole(string roleIdName)
        {
            Silanis.ESL.API.Role role = new Silanis.ESL.API.Role();

            if ( !sdkSigner.IsPlaceholderSigner() ) {
				role.AddSigner(new SignerConverter(sdkSigner).ToAPISigner());
            }
            role.Index = sdkSigner.SigningOrder;
            role.Reassign = sdkSigner.CanChangeSigner;
            role.Locked = sdkSigner.Locked;

			foreach (AttachmentRequirement attachmentRequirement in sdkSigner.Attachments)
			{
				role.AddAttachmentRequirement(new AttachmentRequirementConverter(attachmentRequirement).ToAPIAttachmentRequirement());
			}

            if (!String.IsNullOrEmpty(sdkSigner.Id))
            {
                role.Id = sdkSigner.Id;
                role.Name = sdkSigner.Id;
            }
            else if (sdkSigner.IsGroupSigner())
            {
                role.Id = role.Name = sdkSigner.GroupId.Id;
            }
            else
            {
                role.Id = role.Name = roleIdName;
            }

            if (!String.IsNullOrEmpty(sdkSigner.Message))
            {
                Silanis.ESL.API.BaseMessage message = new Silanis.ESL.API.BaseMessage();

                message.Content = sdkSigner.Message;
                role.EmailMessage = message;
            }

            return role;
        }

        public Silanis.ESL.API.Role ToAPIRole(string id, string name)
        {
            Silanis.ESL.API.Role role = new Silanis.ESL.API.Role();

            if ( !sdkSigner.IsPlaceholderSigner() ) {
                role.AddSigner(new SignerConverter(sdkSigner).ToAPISigner());
            }
            role.Index = sdkSigner.SigningOrder;
            role.Reassign = sdkSigner.CanChangeSigner;
            role.Locked = sdkSigner.Locked;

            foreach (AttachmentRequirement attachmentRequirement in sdkSigner.Attachments)
            {
                role.AddAttachmentRequirement(new AttachmentRequirementConverter(attachmentRequirement).ToAPIAttachmentRequirement());
            }

            if (!String.IsNullOrEmpty(sdkSigner.Id))
            {
                role.Id = sdkSigner.Id;
            }
            else if (sdkSigner.IsGroupSigner())
            {
                role.Id = sdkSigner.GroupId.Id;
            }
            else
            {
                role.Id = id;
            }

            if (!String.IsNullOrEmpty(sdkSigner.PlaceholderName))
            {
                role.Name = sdkSigner.PlaceholderName;
            }
            else
            {
                role.Name = name;
            }

            if (!String.IsNullOrEmpty(sdkSigner.Message))
            {
                Silanis.ESL.API.BaseMessage message = new Silanis.ESL.API.BaseMessage();

                message.Content = sdkSigner.Message;
                role.EmailMessage = message;
            }

            return role;
        }

		internal Silanis.ESL.API.Signer ToAPISigner()
		{
			if (sdkSigner == null)
			{
				return apiSigner;
			}

			if (sdkSigner.IsPlaceholderSigner())
			{
				return null;
			}

			Silanis.ESL.API.Signer signer = new Silanis.ESL.API.Signer ();

			if (!sdkSigner.IsGroupSigner())
			{
				signer.Email = sdkSigner.Email;
				signer.FirstName = sdkSigner.FirstName;
				signer.LastName = sdkSigner.LastName;
				signer.Title = sdkSigner.Title;
				signer.Company = sdkSigner.Company;
				if (sdkSigner.DeliverSignedDocumentsByEmail)
				{
					signer.Delivery = new Silanis.ESL.API.Delivery();
					signer.Delivery.Email = sdkSigner.DeliverSignedDocumentsByEmail;
				}
                signer.KnowledgeBasedAuthentication = new KnowledgeBasedAuthenticationConverter(sdkSigner.KnowledgeBasedAuthentication).ToAPIKnowledgeBasedAuthentication();
			}
			else
			{
				signer.Group = new Silanis.ESL.API.Group();
				signer.Group.Id = sdkSigner.GroupId.Id;
			}

			if (!String.IsNullOrEmpty(sdkSigner.Id))
			{
				signer.Id = sdkSigner.Id;
			}

			signer.Auth = new AuthenticationConverter(sdkSigner.Authentication).ToAPIAuthentication();

			return signer;
		}

        public Silanis.ESL.SDK.Signer ToSDKSigner()
        {
            if (apiRole == null)
            {
                return sdkSigner;
            }

            if (apiRole.Signers == null || apiRole.Signers.Count == 0)
            {
                return NewSignerPlaceholderFromAPIRole();
            }
            else
            {
                return NewRegularSignerFromAPIRole();
            }

        }

        private Silanis.ESL.SDK.Signer NewSignerPlaceholderFromAPIRole()
        {
            Asserts.NotEmptyOrNull(apiRole.Id, "role.id");

            SignerBuilder builder = SignerBuilder.NewSignerPlaceholder(new Placeholder(apiRole.Id))
                .SigningOrder(apiRole.Index.Value);

            if ( apiRole.Reassign.Value ) {
                builder.CanChangeSigner ();
            }

            if ( apiRole.EmailMessage != null ) {
                builder.WithEmailMessage( apiRole.EmailMessage.Content );
            }

            Signer signer = builder.Build();

            if ( apiRole.Locked.Value ) {
                signer.Locked = true;
            }

            return builder.Build();
        }

        private Silanis.ESL.SDK.Signer NewRegularSignerFromAPIRole()
        {
            Silanis.ESL.API.Signer eslSigner = apiRole.Signers[0];

            SignerBuilder builder = SignerBuilder.NewSignerWithEmail(eslSigner.Email)
                .WithCustomId(eslSigner.Id)   
                .WithFirstName(eslSigner.FirstName)
                .WithLastName(eslSigner.LastName)
                .WithCompany(eslSigner.Company)
                .WithTitle(eslSigner.Title)
                .ChallengedWithKnowledgeBasedAuthentication(new KnowledgeBasedAuthenticationConverter(eslSigner.KnowledgeBasedAuthentication).ToSDKKnowledgeBasedAuthentication());
                
            if (apiRole.Index.HasValue)
                builder.SigningOrder(apiRole.Index.Value);

            foreach (Silanis.ESL.API.AttachmentRequirement attachmentRequirement in apiRole.AttachmentRequirements)
            {
                builder.WithAttachmentRequirement(new AttachmentRequirementConverter(attachmentRequirement).ToSDKAttachmentRequirement());
            }

            if (apiRole.Id != null) {
                builder.WithCustomId(apiRole.Id);
            }

            if ( apiRole.Reassign.Value ) {
                builder.CanChangeSigner ();
            }

            if ( apiRole.EmailMessage != null ) {
                builder.WithEmailMessage( apiRole.EmailMessage.Content );
            }

            if (eslSigner.Delivery != null && eslSigner.Delivery.Email.Value) {
                builder.DeliverSignedDocumentsByEmail();
            }

            builder.WithAuthentication(new AuthenticationConverter(eslSigner.Auth).ToSDKAuthentication());

            Signer signer = builder.Build();
            if ( apiRole.Locked.Value ) {
                signer.Locked = true;
            }

            return signer;
        }
    }
}