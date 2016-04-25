using System;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK.Builder
{
	public class FieldBuilder
	{
        public static string SELECTED_VALUE = "X";
        public static string CHECKBOX_CHECKED = SELECTED_VALUE;
        public static string RADIO_SELECTED = SELECTED_VALUE;

		public static double DEFAULT_WIDTH = 200;
		public static double DEFAULT_HEIGHT = 50;
		public static FieldStyle DEFAULT_STYLE = FieldStyle.UNBOUND_TEXT_FIELD;

		private int page;
		private double x;
		private double y;
		private double width = DEFAULT_WIDTH;
		private double height = DEFAULT_HEIGHT;
		private FieldStyle style = DEFAULT_STYLE;
		private FieldValidator validator;
		private bool extract;
		private string name;
		private string value;
		private string id;
        private TextAnchor textAnchor;

		private FieldBuilder ()
		{
		}

		public static FieldBuilder SignerCompany ()
		{
			return new FieldBuilder ().WithStyle (FieldStyle.BOUND_COMPANY);
		}

		public static FieldBuilder SignerTitle ()
		{
			return new FieldBuilder ().WithStyle (FieldStyle.BOUND_TITLE);
		}

		public static FieldBuilder SignerName ()
		{
			return new FieldBuilder ().WithStyle (FieldStyle.BOUND_NAME);
		}

		public static FieldBuilder SignatureDate ()
		{
			return new FieldBuilder ().WithStyle (FieldStyle.BOUND_DATE);
		}

		public static FieldBuilder NewField ()
		{
			return new FieldBuilder ();
		}

		public static FieldBuilder TextField ()
		{
			return new FieldBuilder ().WithStyle (FieldStyle.UNBOUND_TEXT_FIELD);
		}

		public static FieldBuilder Label ()
		{
			return new FieldBuilder ().WithStyle (FieldStyle.LABEL);
		}

		public static FieldBuilder CheckBox ()
		{
			return new FieldBuilder ().WithStyle (FieldStyle.UNBOUND_CHECK_BOX);
		}

        public static FieldBuilder TextArea ()
        {
            return new FieldBuilder ().WithStyle (FieldStyle.TEXT_AREA);
        }

        public static FieldBuilder DropList ()
        {
            return new FieldBuilder ().WithStyle (FieldStyle.DROP_LIST);
        }

        public static FieldBuilder RadioButton ( string group )
        {
            return new FieldBuilder ().WithStyle(FieldStyle.UNBOUND_RADIO_BUTTON)
                .WithValidation(FieldValidatorBuilder.Alphanumeric().WithOption(group));
        }

		public static FieldBuilder CustomField( String name )
		{
			return new FieldBuilder().WithStyle(FieldStyle.UNBOUND_CUSTOM_FIELD).WithName(name);
		}

        public static FieldBuilder QRCode()
        {
            return new FieldBuilder().WithStyle(FieldStyle.BOUND_QRCODE)
                .WithSize(77.0, 77.0);
        }

		public FieldBuilder WithId (string id)
		{
			this.id = id;
			return this;
		}

		public FieldBuilder WithName (string name)
		{
			this.name = name;
			return this;
		}

		public FieldBuilder WithPositionExtracted ()
		{
			extract = true;
			return this;
		}

		public FieldBuilder OnPage (int page)
		{
			this.page = page;
			return this;
		}

		public FieldBuilder AtPosition (double x, double y)
		{
			this.x = x;
			this.y = y;
			return this;
		}

		public FieldBuilder WithSize (double width, double height)
		{
			this.width = width;
			this.height = height;
			return this;
		}

		public FieldBuilder WithStyle (FieldStyle style)
		{
			this.style = style;
			return this;
		}

		public FieldBuilder WithValidation (FieldValidatorBuilder builder)
		{
			return WithValidation(builder.Build ());
		}

		public FieldBuilder WithValidation (FieldValidator validator)
		{
            MergeValidation(validator);
			return this;
		}

        private void MergeValidation(FieldValidator validator) 
        {
            if (null != this.validator) 
            {
                this.validator.ErrorCode = validator.ErrorCode;
                this.validator.MaxLength = validator.MaxLength;
                this.validator.MinLength = validator.MinLength;

                if(null != validator.Regex)
                    this.validator.Regex = validator.Regex;
                if(null != validator.Options && validator.Options.Count > 0)
                    this.validator.Options = validator.Options;

                this.validator.Required = validator.Required;
            } 
            else 
            {
                this.validator = validator;
            }
        }

        public FieldBuilder WithValue (bool value)
        {
            if (this.style == FieldStyle.UNBOUND_CHECK_BOX || this.style == FieldStyle.UNBOUND_RADIO_BUTTON)
            {
                this.value = value ? SELECTED_VALUE : "";
            }
            return this;
        }

		public FieldBuilder WithValue (string value)
		{
			this.value = value;
			return this;
		}

        public FieldBuilder WithPositionAnchor( TextAnchorBuilder builder ) {
            return WithPositionAnchor( builder.Build() );
        }

        public FieldBuilder WithPositionAnchor( TextAnchor textAnchor ) {
            this.textAnchor = textAnchor;
            return this;
        }

		public Field Build ()
		{
			Field field = new Field ();
			field.Width = width;
			field.Height = height;
			field.Style = style;
			field.Page = page;
			field.X = x;
			field.Y = y;
			field.Validator = validator;
			field.Name = name;
			field.Extract = extract;
			field.Value = value;
			field.Id = id;
            field.TextAnchor = textAnchor;

			return field;
		}
	}
}