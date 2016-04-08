using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class FieldValidationExampleTest
    {
        private const String AlphabeticRegex = "^[\\sa-zA-Z]+$";
        private const String NumericRegex = "^[-+]?[0-9]*\\.?[0-9]*$";
        private const String AlphanumericRegex = "^[\\s0-9a-zA-Z]+$";
        private const String EmailRegex = "^([a-z0-9_\\.-]+)@([\\da-z\\.-]+)\\.([a-z\\.]{2,6})$";
        private const String UrlRegex = "^(https?:\\/\\/)?([\\da-z\\.-]+)\\.([a-z\\.]{2,6})([\\/\\w \\.-]*)*\\/?$";

        [TestMethod]
        public void VerifyResult()
        {
            var example = new FieldValidationExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            var document = documentPackage.GetDocument(example.DOCUMENT_NAME);

            foreach (var signature in document.Signatures)
            {
                if (!signature.SignerEmail.Equals(example.Email1))
                {
                    break;
                }

                foreach (var field in signature.Fields)
                {
                    var fieldId = field.Id;

                    if (fieldId.Equals(example.FIELD_ALPHABETIC_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, AlphabeticRegex);
                        Assert.AreEqual(field.Validator.MaxLength, example.FIELD_ALPHABETIC_MAX_LENGTH);
                        Assert.AreEqual(field.Validator.MinLength, example.FIELD_ALPHABETIC_MIN_LENGTH);
                        Assert.IsTrue(field.Validator.Required);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_ALPHABETIC_ERROR_MESSAGE);
                    }
                    if (fieldId.Equals(example.FIELD_NUMERIC_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, NumericRegex);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_NUMERIC_ERROR_MESSAGE);
                    }
                    if (fieldId.Equals(example.FIELD_ALPHANUMERIC_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, AlphanumericRegex);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_ALPHANUMERIC_ERROR_MESSAGE);
                    }
                    if (fieldId.Equals(example.FIELD_EMAIL_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, EmailRegex);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_EMAIL_ERROR_MESSAGE);
                    }
                    if (fieldId.Equals(example.FIELD_URL_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, UrlRegex);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_URL_ERROR_MESSAGE);

                    }
                    if (fieldId.Equals(example.FIELD_REGEX_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, example.FIELD_REGEX);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_REGEX_ERROR_MESSAGE);
                    }
                }
            }
        }
    }
}

