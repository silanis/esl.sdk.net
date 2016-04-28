using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	public class Signature
	{
		private List<Field> fields = new List<Field>();

		public Signature (string signerEmail, int page, double x, double y)
		{
			SignerEmail = signerEmail;
            GroupId = null;
            RoleId = null;
			Page = page;
			X = x;
			Y = y;
            Style = SignatureStyle.HAND_DRAWN;
		}

        public Signature( GroupId groupId, int page, double x, double y)
        {
            SignerEmail = null;
            GroupId = groupId;
            RoleId = null;
            Page = page;
            X = x;
            Y = y;
            Style = SignatureStyle.HAND_DRAWN;
        }
        
        public Signature(Placeholder roleId, int page, double x, double y)
        {
            SignerEmail = null;
            GroupId = null;
            RoleId = roleId;
            Page = page;
            X = x;
            Y = y;
            Style = SignatureStyle.HAND_DRAWN;
        }

        public GroupId GroupId
        {
            get;
            private set;
        }

        private string signerEmail;
		public string SignerEmail
        {
            get { return signerEmail; }
            private set
            { 
                if (value != null)
                {
                    signerEmail = value.ToLower(); 
                }
                else
                {
                    signerEmail = null;
                }
            }
		}

        public Placeholder RoleId
        {
            get;
            private set;
        }

        public Nullable<DateTime> Accepted 
        {
            get;
            internal set;
        }

		public int Page 
		{
			get;
			private set;
		}

		public double X 
		{
			get;
			private set;
		}

		public double Y
		{
			get;
			private set;
		}

		public double Height {
			get;
			set;
		}

		public double Width {
			get;
			set;
		}

		public SignatureStyle Style {
			get;
			set;
		}

		public void AddFields (IList<Field> fields)
		{
			this.fields.AddRange (fields);
		}

		public List<Field> Fields
		{
			get
			{
				return fields;
			}
		}

        public SignatureId Id
        {
            get;
            set;
        }

		public string Name {
			get;
			set;
		}

		public bool Extract {
			get;
			set;
		}

        public TextAnchor TextAnchor
        {
            get;
            set;
        }

		public bool IsGroupSignature()
		{
			return GroupId != null;
		}
        
        public bool IsPlaceholderSignature()
        {
            return RoleId != null;
        }
	}
}