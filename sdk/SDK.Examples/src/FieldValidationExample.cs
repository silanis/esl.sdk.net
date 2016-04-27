using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class FieldValidationExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new FieldValidationExample().Run();
        }

        public readonly string DocumentName = "My Document";

        public readonly string FieldNumericId = "numeric";
        public readonly int FieldNumericMaxLength = 10;
        public readonly string FieldNumericErrorMessage = "This field is not numeric";

        public readonly string FieldAlphabeticId = "alphabetic";
        public readonly int FieldAlphabeticMinLength = 3;
        public readonly int FieldAlphabeticMaxLength = 10;
        public readonly string FieldAlphabeticErrorMessage = "This field is not alphabetic";

        public readonly string FieldAlphanumericId = "alphanumeric";
        public readonly int FieldAlphanumericMinLength = 5;
        public readonly string FieldAlphanumericErrorMessage = "This field is not alphanumeric";

        public readonly string FieldUrlId = "url";
        public readonly String FieldUrlErrorMessage = "The value in this field is not a valid URL";

        public readonly string FieldEmailId = "email";
        public readonly string FieldEmailErrorMessage = "The value in this field is not an email address";

        public readonly string FieldBasicId = "basic";
        public readonly String FieldBasicOption1 = "one";
        public readonly String FieldBasicOption2 = "two";

        public readonly string FieldRegexId = "regex";
        public readonly string FieldRegex = "^[0-9a-zA-Z]+$";
        public readonly String FieldRegexErrorMessage = "The value in this field does not match the expression";

        public string Email1
        {
            get
            {
                return email1;
            }
        }

        override public void Execute()
        {
            var package = PackageBuilder.NewPackageNamed(PackageName)
					.DescribedAs("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                .FromStream(fileStream1, DocumentType.PDF)
				                .WithSignature(SignatureBuilder.SignatureFor(email1)
					              		.OnPage(0)
					               		.AtPosition(500, 100)
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FieldAlphabeticId)   				
                                            .OnPage(0)
					           				.AtPosition(500, 200)
					           				.WithValidation(FieldValidatorBuilder.Alphabetic()
                                                .MaxLength(FieldAlphabeticMaxLength)
                                                .MinLength(FieldAlphabeticMinLength)
					                			.Required()
                                                .WithErrorMessage(FieldAlphabeticErrorMessage)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FieldNumericId)
					           				.OnPage(0)
					           				.AtPosition(500, 300)
					           				.WithValidation(FieldValidatorBuilder.Numeric()					                			
                                                .WithErrorMessage(FieldNumericErrorMessage)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FieldAlphanumericId)
					           				.OnPage(0)
					           				.AtPosition(500, 400)
					           				.WithValidation(FieldValidatorBuilder.Alphanumeric()					                			
                                                .WithErrorMessage(FieldAlphanumericErrorMessage)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FieldEmailId)
							           		.OnPage(0)
							           		.AtPosition(500, 500)
							           		.WithValidation(FieldValidatorBuilder.Email()					                			
                                                .WithErrorMessage(FieldEmailErrorMessage)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FieldUrlId)
					           				.OnPage(0)
					           				.AtPosition(500, 600)
					           				.WithValidation(FieldValidatorBuilder.URL()
                                                .WithErrorMessage(FieldUrlErrorMessage)))
					               		.WithField(FieldBuilder.TextField()
                                            .WithId(FieldRegexId)
					           				.OnPage(0)
					           				.AtPosition(500, 700)
                                            .WithValidation(FieldValidatorBuilder.Regex(FieldRegex)
                                                .WithErrorMessage(FieldRegexErrorMessage)))))
					.Build();

            packageId = eslClient.CreatePackage(package);

            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}