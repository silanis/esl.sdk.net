using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class FieldValidationExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new FieldValidationExample().Run();
        }

        public readonly string DOCUMENT_NAME = "My Document";

        public readonly string FIELD_NUMERIC_ID = "numeric";
        public readonly int FIELD_NUMERIC_MAX_LENGTH = 10;
        public readonly string FIELD_NUMERIC_ERROR_MESSAGE = "This field is not numeric";

        public readonly string FIELD_ALPHABETIC_ID = "alphabetic";
        public readonly int FIELD_ALPHABETIC_MIN_LENGTH = 3;
        public readonly int FIELD_ALPHABETIC_MAX_LENGTH = 10;
        public readonly string FIELD_ALPHABETIC_ERROR_MESSAGE = "This field is not alphabetic";

        public readonly string FIELD_ALPHANUMERIC_ID = "alphanumeric";
        public readonly int FIELD_ALPHANUMERIC_MIN_LENGTH = 5;
        public readonly string FIELD_ALPHANUMERIC_ERROR_MESSAGE = "This field is not alphanumeric";

        public readonly string FIELD_URL_ID = "url";
        public readonly String FIELD_URL_ERROR_MESSAGE = "The value in this field is not a valid URL";

        public readonly string FIELD_EMAIL_ID = "email";
        public readonly string FIELD_EMAIL_ERROR_MESSAGE = "The value in this field is not an email address";

        public readonly string FIELD_BASIC_ID = "basic";
        public readonly String FIELD_BASIC_OPTION_1 = "one";
        public readonly String FIELD_BASIC_OPTION_2 = "two";

        public readonly string FIELD_REGEX_ID = "regex";
        public readonly string FIELD_REGEX = "^[0-9a-zA-Z]+$";
        public readonly String FIELD_REGEX_ERROR_MESSAGE = "The value in this field does not match the expression";

        public string Email1
        {
            get
            {
                return email1;
            }
        }

        override public void Execute()
        {
            DocumentPackage package = PackageBuilder.NewPackageNamed(PackageName)
					.DescribedAs("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                .FromStream(fileStream1, DocumentType.PDF)
				                .WithSignature(SignatureBuilder.SignatureFor(email1)
					              		.OnPage(0)
					               		.AtPosition(500, 100)
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FIELD_ALPHABETIC_ID)   				
                                            .OnPage(0)
					           				.AtPosition(500, 200)
					           				.WithValidation(FieldValidatorBuilder.Alphabetic()
                                                .MaxLength(FIELD_ALPHABETIC_MAX_LENGTH)
                                                .MinLength(FIELD_ALPHABETIC_MIN_LENGTH)
					                			.Required()
                                                .WithErrorMessage(FIELD_ALPHABETIC_ERROR_MESSAGE)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FIELD_NUMERIC_ID)
					           				.OnPage(0)
					           				.AtPosition(500, 300)
					           				.WithValidation(FieldValidatorBuilder.Numeric()					                			
                                                .WithErrorMessage(FIELD_NUMERIC_ERROR_MESSAGE)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FIELD_ALPHANUMERIC_ID)
					           				.OnPage(0)
					           				.AtPosition(500, 400)
					           				.WithValidation(FieldValidatorBuilder.Alphanumeric()					                			
                                                .WithErrorMessage(FIELD_ALPHANUMERIC_ERROR_MESSAGE)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FIELD_EMAIL_ID)
							           		.OnPage(0)
							           		.AtPosition(500, 500)
							           		.WithValidation(FieldValidatorBuilder.Email()					                			
                                                .WithErrorMessage(FIELD_EMAIL_ERROR_MESSAGE)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FIELD_URL_ID)
					           				.OnPage(0)
					           				.AtPosition(500, 600)
					           				.WithValidation(FieldValidatorBuilder.URL()
                                                .WithErrorMessage(FIELD_URL_ERROR_MESSAGE)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FIELD_REGEX_ID)
					           				.OnPage(0)
					           				.AtPosition(500, 700)
                                            .WithValidation(FieldValidatorBuilder.Regex(FIELD_REGEX)
                                                .WithErrorMessage(FIELD_REGEX_ERROR_MESSAGE)))))
					.Build();

            packageId = eslClient.CreatePackage(package);

            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}