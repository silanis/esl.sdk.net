using System;
using System.Collections.Generic;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
	public class Signer
	{
		private readonly Authentication authentication;

        public Signer (string signerEmail, string firstName, string lastName, Authentication authentication)
		{
			Email = signerEmail;
			FirstName = firstName;
			LastName = lastName;
			this.authentication = authentication;
			this.GroupId = null;
            this.KnowledgeBasedAuthentication = null;
		}

		public Signer( GroupId groupId )
		{
			GroupId = groupId;
			Email = null;
			FirstName = null;
			LastName = null;
			authentication = new Authentication(AuthenticationMethod.EMAIL);
            this.KnowledgeBasedAuthentication = null;
		}
        
        public Signer(string id)
        {
            GroupId = null;
            FirstName = null;
            LastName = null;
            Email = null;
            authentication = null;
            this.Id = id;
            authentication = new Authentication(Silanis.ESL.SDK.AuthenticationMethod.EMAIL);
            this.KnowledgeBasedAuthentication = null;
        }

		public string Id {
			get;
			set;
		}

        public string PlaceholderName {
            get;
            set;
        }

		public GroupId GroupId
		{
			get;
			private set;
		}

        public KnowledgeBasedAuthentication KnowledgeBasedAuthentication
        {
            get; set;
        }

        private string email;
		public string Email
        {
            get{ return email; }
            private set
            { 
                if (value != null)
                {
                    email = value.ToLower();
                }
                else
                {
                    email = null;
                }
            }
		}

		public string FirstName {
			get;
			private set;
		}

		public string LastName {
			get;
			private set;
		}

		public string Title {
			get;
			set;
		}

		public string Company {
			get;
			set;
		}

		public bool CanChangeSigner {
			get;
			set;
		}

		public Authentication Authentication
		{
			get
			{
				return authentication;
			}
		}

		public AuthenticationMethod AuthenticationMethod {
			get
			{
				return authentication.Method;
			}
		}

		public IList<Challenge> ChallengeQuestion {
			get
			{
				return authentication.Challenges;
			}
		}

		public string PhoneNumber {
			get
			{
				return authentication.PhoneNumber;
			}
		}

		public bool DeliverSignedDocumentsByEmail {
			get;
			set;
		}

		public int SigningOrder {
			get;
			set;
		}

		public string Message {
			get;
			set;
		}

		public bool Locked {
			get;
			set;
		}

		public IList<AttachmentRequirement> Attachments
		{
			get;
			set;
		}

        public AttachmentRequirement GetAttachmentRequirement(string attachmentName) 
        {
            foreach(var attachment in Attachments) 
            {
                if(attachment.Name.Equals(attachmentName)) 
                {
                    return attachment;
                }
            }
            return null;
        }

        public bool IsPlaceholderSigner()
        {
            return GroupId == null && Email == null;
        }

		public bool IsGroupSigner()
		{
			return GroupId != null;
		}
	}
}