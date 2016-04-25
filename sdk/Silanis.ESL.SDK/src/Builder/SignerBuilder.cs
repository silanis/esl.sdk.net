using System;
using Silanis.ESL.SDK.Internal;
using System.Collections.Generic;

namespace Silanis.ESL.SDK.Builder
{
	public class SignerBuilder
	{
		private string signerEmail;
		private string firstName;
		private string lastName;
		private string title;
		private string company;
		private AuthenticationBuilder authenticationBuilder = new AuthenticationBuilder();
        private Authentication authentication;
		private bool deliverSignedDocumentsByEmail;
		private int signingOrder;
		private string message;
		private string id;
        private string placeholderName;
		private bool canChangeSigner;
        private GroupId groupId;
		private IList<AttachmentRequirement> attachments = new List<AttachmentRequirement>();
        private KnowledgeBasedAuthentication knowledgeBasedAuthentication;

        private SignerBuilder(string signerEmail)
		{
			this.signerEmail = signerEmail;
            this.groupId = null;
		}

        private SignerBuilder(GroupId groupId)
        {
            this.signerEmail = null;
            this.groupId = groupId;
        }
        
        private SignerBuilder(Placeholder placeholder)
        {
            this.signerEmail = null;
            this.groupId = null;
            this.id = placeholder.Id;
            this.placeholderName = placeholder.Name;
        }

        public static SignerBuilder NewSignerPlaceholder(Placeholder placeholder)
        {
            return new SignerBuilder(placeholder);
        }

		public static SignerBuilder NewSignerWithEmail (string signerEmail)
		{
			Asserts.NotEmptyOrNull (signerEmail, "signerEmail");
			return new SignerBuilder (signerEmail);
		}

		public static SignerBuilder NewSignerFromGroup(GroupId groupId)
        {
			return new SignerBuilder(groupId);
        }

		public SignerBuilder WithCustomId (string id)
		{
			this.id = id;
			return this;
		}

		public SignerBuilder WithFirstName (string firstName)
		{
			this.firstName = firstName;
			return this;
		}

		public SignerBuilder WithLastName (string lastName)
		{
			this.lastName = lastName;
			return this;
		}

		public SignerBuilder WithTitle (string title)
		{
			this.title = title;
			return this;
		}

		public SignerBuilder WithCompany (string company)
		{
			this.company = company;
			return this;
		}

        [Obsolete("Please use Replacing() instead")]
        public SignerBuilder WithRoleId(string roleId)
        {
            return Replacing(new Placeholder(roleId));
        }

        public SignerBuilder Replacing(Placeholder placeholder)
        {
            this.id = placeholder.Id;
            return this;
        }

        [Obsolete("Please use Replacing() instead")]
        public SignerBuilder WithRoleId ( Placeholder placeholder )
        {
            return Replacing( placeholder );
        }

		[Obsolete("Please use WithCustomId() instead")]
		public SignerBuilder WithId ( string id )
		{
			return WithCustomId(id);
		}

		public SignerBuilder ChallengedWithQuestions (ChallengeBuilder challengeBuilder)
		{
			this.authenticationBuilder = challengeBuilder;
			return this;
		}

		public SignerBuilder WithSMSSentTo (string phoneNumber)
		{
			this.authenticationBuilder = new SMSAuthenticationBuilder (phoneNumber);
			return this;
		}

        public SignerBuilder WithAuthentication(Authentication authentication)
        {
            this.authentication = authentication;
            return this;
        }

		public SignerBuilder DeliverSignedDocumentsByEmail ()
		{
			deliverSignedDocumentsByEmail = true;
			return this;
		}

		public SignerBuilder SigningOrder (int signingOrder)
		{
			this.signingOrder = signingOrder;
			return this;
		}

		public SignerBuilder WithEmailMessage (string message)
		{
			this.message = message;
			return this;
		}

		public SignerBuilder CanChangeSigner ()
		{
			canChangeSigner = true;
			return this;
		}

		public SignerBuilder WithAttachmentRequirement (AttachmentRequirementBuilder builder)
		{
			return WithAttachmentRequirement(builder.Build());
		}

		public SignerBuilder WithAttachmentRequirement (AttachmentRequirement attachmentRequirement)
		{
			AddAttachmentRequirement(attachmentRequirement);
			return this;
		}

		private void AddAttachmentRequirement (AttachmentRequirement attachmentRequirement)
		{
			attachments.Add(attachmentRequirement);
		}

        public SignerBuilder ChallengedWithKnowledgeBasedAuthentication (KnowledgeBasedAuthentication knowledgeBasedAuthentication)
        {
            if (this.knowledgeBasedAuthentication == null) {
                this.knowledgeBasedAuthentication = new KnowledgeBasedAuthentication();
            }
            this.knowledgeBasedAuthentication = knowledgeBasedAuthentication;
            return this;
        }

        public SignerBuilder ChallengedWithKnowledgeBasedAuthentication(SignerInformationForEquifaxCanadaBuilder signerInformationForEquifaxCanadaBuilder) {
            return ChallengedWithKnowledgeBasedAuthentication(signerInformationForEquifaxCanadaBuilder.Build());
        }

        public SignerBuilder ChallengedWithKnowledgeBasedAuthentication(SignerInformationForEquifaxCanada signerInformationForEquifaxCanada) {

            if (this.knowledgeBasedAuthentication == null) {
                this.knowledgeBasedAuthentication = new KnowledgeBasedAuthentication();
            }
            this.knowledgeBasedAuthentication.SignerInformationForEquifaxCanada = signerInformationForEquifaxCanada;
            return this;
        }

        public SignerBuilder ChallengedWithKnowledgeBasedAuthentication(SignerInformationForEquifaxUSABuilder signerInformationForEquifaxUSABuilder) {
            return ChallengedWithKnowledgeBasedAuthentication(signerInformationForEquifaxUSABuilder.Build());
        }

        public SignerBuilder ChallengedWithKnowledgeBasedAuthentication(SignerInformationForEquifaxUSA signerInformationForEquifaxUSA) {
            if (this.knowledgeBasedAuthentication == null) {
                this.knowledgeBasedAuthentication = new KnowledgeBasedAuthentication();
            }
            this.knowledgeBasedAuthentication.SignerInformationForEquifaxUSA = signerInformationForEquifaxUSA;
            return this;
        }

        private Signer BuildGroupSigner()
        {            
            Signer result = new Signer(groupId);
            result.SigningOrder = signingOrder;
            result.CanChangeSigner = canChangeSigner;
            result.Message = message;
            result.Id = id;
			result.Attachments = attachments;
            
            return result;
        }
        
        private Signer BuildPlaceholderSigner()
        {    
            Asserts.NotEmptyOrNull( id, "No placeholder set for this signer!" );
                    
            Signer result = new Signer(id);
            result.PlaceholderName = placeholderName;
            result.SigningOrder = signingOrder;
            result.CanChangeSigner = canChangeSigner;
            result.Message = message;
			result.Attachments = attachments;
			            
            return result;
        }
        
        private Signer BuildRegularSigner()
        {            
            Asserts.NotEmptyOrNull (firstName, "firstName");
            Asserts.NotEmptyOrNull (lastName, "lastName");
                        
            if (authentication == null)
            {
                authentication = authenticationBuilder.Build();
            }

            Signer result = new Signer (signerEmail, firstName, lastName, authentication);
            result.Title = title;
            result.Company = company;
            result.DeliverSignedDocumentsByEmail = deliverSignedDocumentsByEmail;

            result.SigningOrder = signingOrder;
            result.CanChangeSigner = canChangeSigner;
            result.Message = message;
            result.Id = id;
			result.Attachments = attachments;
            result.KnowledgeBasedAuthentication = knowledgeBasedAuthentication;
			            
            return result;
        }


		public Signer Build()
        {
            Signer result = null;
            if (isGroupSigner())
            {
                result = BuildGroupSigner();
            }
            else if (isPlaceholder())
            {
                result = BuildPlaceholderSigner();
            }
            else
            {
                result = BuildRegularSigner();
            }

            return result;
		}

        private bool isGroupSigner() {
            return groupId != null;
        }
        
        private bool isPlaceholder()
        {
            return groupId == null && signerEmail == null;
        }
	}
}