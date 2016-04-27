using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK.Builder
{
	public class FieldValidatorBuilder
	{
		private static String ALPHABETIC_REGEX = "^[\\sa-zA-Z]+$";
		private static String NUMERIC_REGEX = "^[-+]?[0-9]*\\.?[0-9]*$";
		private static String ALPHANUMERIC_REGEX = "^[\\s0-9a-zA-Z]+$";
		private static String EMAIL_REGEX = "^([a-z0-9_\\.-]+)@([\\da-z\\.-]+)\\.([a-z\\.]{2,6})$";
		private static String URL_REGEX = "^(https?:\\/\\/)?([\\da-z\\.-]+)\\.([a-z\\.]{2,6})([\\/\\w \\.-]*)*\\/?$";
        private static String DEFAULT_REGEX = null;

		private static int DEFAULT_MAX_LENGTH = Int32.MaxValue;

		private String regex;
		private int maxLength = DEFAULT_MAX_LENGTH;
		private int minLength = 0;
        private int errorCode;
		private string message;
		private bool required;
        private IList<string> options = new List<string>();

		private FieldValidatorBuilder (String regex)
		{
			this.regex = regex;
		}

		public static FieldValidatorBuilder Alphabetic ()
		{
			return new FieldValidatorBuilder (ALPHABETIC_REGEX);
		}

		public static FieldValidatorBuilder Numeric ()
		{
			return new FieldValidatorBuilder (NUMERIC_REGEX);
		}

		public static FieldValidatorBuilder Alphanumeric ()
		{
			return new FieldValidatorBuilder (ALPHANUMERIC_REGEX);
		}

		public static FieldValidatorBuilder Email ()
		{
			return new FieldValidatorBuilder (EMAIL_REGEX);
		}

		public static FieldValidatorBuilder URL ()
		{
			return new FieldValidatorBuilder (URL_REGEX);
		}

		public static FieldValidatorBuilder Regex (string regex)
		{
			return new FieldValidatorBuilder (regex);
		}

		public FieldValidatorBuilder MaxLength (int maxLength)
		{
			this.maxLength = maxLength;
			return this;
		}

		public FieldValidatorBuilder MinLength (int minLength)
		{
			this.minLength = minLength;
			return this;
		}

		public FieldValidatorBuilder Required ()
		{
			required = true;
			return this;
		}

        public static FieldValidatorBuilder Basic() 
        {
            return new FieldValidatorBuilder( DEFAULT_REGEX );
        }

		public FieldValidatorBuilder WithErrorMessage (string message)
		{
			this.message = message;
			return this;
		}

        public FieldValidatorBuilder WithOption( string option )
        {
            options.Add(option);
            return this;
        }

        public FieldValidatorBuilder WithErrorCode(int errorCode)
        {
            this.errorCode = errorCode;
            return this;
        }

		public FieldValidator Build ()
		{
			var validator = new FieldValidator ();

			validator.Regex = regex;
			validator.MaxLength = maxLength;
			validator.MinLength = minLength;
			validator.Required = required;
			validator.Message = message;
            validator.AddOptions(options);
            validator.ErrorCode = errorCode;

			return validator;
		}
	}
}