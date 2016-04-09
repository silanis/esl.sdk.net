using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK.Builder
{
	public class SignatureBuilder
	{
		public static double DEFAULT_HEIGHT = 50d;
		public static double DEFAULT_WIDTH = 200d;
		public static SignatureStyle DEFAULT_STYLE = SignatureStyle.FULL_NAME;

        private SignatureId id;
        private string name;
		private string signerEmail;
		private double width = DEFAULT_WIDTH;
		private double height = DEFAULT_HEIGHT;
		private SignatureStyle style = DEFAULT_STYLE;
		private int page;
		private double x;
		private double y;
		private IList<Field> fields = new List<Field>();
		private bool extract;
        private TextAnchor textAnchor;
        private GroupId groupId;
        private Placeholder roleId;

		private SignatureBuilder (string signerEmail)
		{
			this.signerEmail = signerEmail;
            groupId = null;
            roleId = null;
		}

        private SignatureBuilder (GroupId groupId )
        {
            signerEmail = null;
            this.groupId = groupId;
            roleId = null;
        }
        
        private SignatureBuilder(Placeholder roleId)
        {
            signerEmail = null;
            groupId = null;
            this.roleId = roleId;
        }

        public static SignatureBuilder AcceptanceFor (string signerEmail)
        {
            return new SignatureBuilder(signerEmail)
                .WithStyle(SignatureStyle.ACCEPTANCE)
                    .WithSize(0,0)
                    .AtPosition(0,0)
                    .OnPage(0);
        }

		public static SignatureBuilder AcceptanceFor (GroupId groupId )
		{
			return new SignatureBuilder(groupId)
					.WithStyle(SignatureStyle.ACCEPTANCE)
					.WithSize(0,0)
					.AtPosition(0,0)
					.OnPage(0);
		}
        
        public static SignatureBuilder AcceptanceFor(Placeholder roleId)
        {
            return new SignatureBuilder(roleId)
                    .WithStyle(SignatureStyle.ACCEPTANCE)
                    .WithSize(0, 0)
                    .AtPosition(0, 0)
                    .OnPage(0);
        }

        public static SignatureBuilder SignatureFor( GroupId groupId )
        {
            return new SignatureBuilder(groupId);
        }
        
        public static SignatureBuilder SignatureFor(Placeholder roleId)
        {
            return new SignatureBuilder(roleId);
        }

		public static SignatureBuilder SignatureFor (string signerEmail)
		{
			return new SignatureBuilder (signerEmail);
		}

		public static SignatureBuilder InitialsFor (string signerEmail)
		{
			return new SignatureBuilder (signerEmail).WithStyle (SignatureStyle.INITIALS);
		}

		public static SignatureBuilder InitialsFor ( GroupId groupId )
		{
			return  new SignatureBuilder(groupId).WithStyle(SignatureStyle.INITIALS);
		}
        
        public static SignatureBuilder InitialsFor(Placeholder roleId)
        {
            return new SignatureBuilder(roleId).WithStyle(SignatureStyle.INITIALS);
        }

		public static SignatureBuilder CaptureFor (string signerEmail)
		{
			return new SignatureBuilder (signerEmail).WithStyle (SignatureStyle.HAND_DRAWN);
		}

		public static SignatureBuilder CaptureFor (GroupId groupId)
		{
			return new SignatureBuilder(groupId).WithStyle(SignatureStyle.HAND_DRAWN);
		}
        
        public static SignatureBuilder CaptureFor(Placeholder roleId)
        {
            return new SignatureBuilder(roleId).WithStyle(SignatureStyle.HAND_DRAWN);
        }

        public static SignatureBuilder MobileCaptureFor (string signerEmail)
        {
            return new SignatureBuilder (signerEmail).WithStyle (SignatureStyle.MOBILE_CAPTURE);
        }

        public static SignatureBuilder MobileCaptureFor (GroupId groupId)
        {
            return new SignatureBuilder(groupId).WithStyle(SignatureStyle.MOBILE_CAPTURE);
        }

        public static SignatureBuilder MobileCaptureFor(Placeholder roleId)
        {
            return new SignatureBuilder(roleId).WithStyle(SignatureStyle.MOBILE_CAPTURE);
        }

        public SignatureBuilder WithId (SignatureId id)
        {
            this.id = id;
            return this;
        }

		public SignatureBuilder WithName (string name)
		{
			this.name = name;
			return this;
		}

        [Obsolete("Use WithPositionExtracted() instead")]
		public SignatureBuilder EnableExtraction()
		{
			extract = true;
			return this;
		}

		public SignatureBuilder OnPage (int page)
		{
			this.page = page;
			return this;
		}

		public SignatureBuilder AtPosition (double x, double y)
		{
			this.x = x;
			this.y = y;
			return this;
		}

		public SignatureBuilder WithStyle (SignatureStyle style)
		{
			this.style = style;
			return this;
		}

		public SignatureBuilder WithSize (double width, double height)
		{
			this.width = width;
			this.height = height;
			return this;
		}

		public SignatureBuilder WithField (FieldBuilder builder)
		{
			return WithField (builder.Build());
		}

		public SignatureBuilder WithField (Field field)
		{
			fields.Add (field);
			return this;
		}

        public SignatureBuilder WithPositionExtracted()
        {
            extract = true;
            return this;
        }

        public SignatureBuilder WithPositionAnchor( TextAnchorBuilder builder ) {
            return WithPositionAnchor(builder.Build());
        }

        public SignatureBuilder WithPositionAnchor( TextAnchor textAnchor ) {
            this.textAnchor = textAnchor;
            return this;
        }

		public Signature Build()
        {
            Signature signature;
            if (isForRegularSigner())
            {
                signature = new Signature(signerEmail, page, x, y);
            }
            else if (isForGroup())
            {
                signature = new Signature(groupId, page, x, y);
            }
            else
            {
                signature = new Signature(roleId, page, x, y);
            }

			signature.Height = height;
			signature.Width = width;
			signature.Style = style;
			signature.AddFields (fields);
            signature.Id = id;
			signature.Name = name;
			signature.Extract = extract;
            signature.TextAnchor = textAnchor;

			return signature;
		}
        
        private bool isForPlaceholder() {
            return roleId != null;
        }
        
        private bool isForGroup()
        {
            return groupId != null;
        }
        
        private bool isForRegularSigner()
        {
            return signerEmail != null;
        }

	}
}