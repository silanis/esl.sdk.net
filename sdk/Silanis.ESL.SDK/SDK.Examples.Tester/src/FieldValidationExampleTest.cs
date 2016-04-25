using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    [TestFixture()]
    public class FieldValidationExampleTest
    {
        private static String ALPHABETIC_REGEX = "^[\\sa-zA-Z]+$";
        private static String NUMERIC_REGEX = "^[-+]?[0-9]*\\.?[0-9]*$";
        private static String ALPHANUMERIC_REGEX = "^[\\s0-9a-zA-Z]+$";
        private static String EMAIL_REGEX = "^([a-z0-9_\\.-]+)@([\\da-z\\.-]+)\\.([a-z\\.]{2,6})$";
        private static String URL_REGEX = "^(https?:\\/\\/)?([\\da-z\\.-]+)\\.([a-z\\.]{2,6})([\\/\\w \\.-]*)*\\/?$";

        [Test()]
        public void VerifyResult()
        {
            FieldValidationExample example = new FieldValidationExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            Document document = documentPackage.GetDocument(example.DOCUMENT_NAME);

            foreach (Signature signature in document.Signatures)
            {
                if (!signature.SignerEmail.Equals(example.Email1))
                {
                    break;
                }

                foreach (Field field in signature.Fields)
                {
                    string fieldId = field.Id;

                    if (fieldId.Equals(example.FIELD_ALPHABETIC_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, ALPHABETIC_REGEX);
                        Assert.AreEqual(field.Validator.MaxLength, example.FIELD_ALPHABETIC_MAX_LENGTH);
                        Assert.AreEqual(field.Validator.MinLength, example.FIELD_ALPHABETIC_MIN_LENGTH);
                        Assert.IsTrue(field.Validator.Required);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_ALPHABETIC_ERROR_MESSAGE);
                    }
                    if (fieldId.Equals(example.FIELD_NUMERIC_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, NUMERIC_REGEX);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_NUMERIC_ERROR_MESSAGE);
                    }
                    if (fieldId.Equals(example.FIELD_ALPHANUMERIC_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, ALPHANUMERIC_REGEX);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_ALPHANUMERIC_ERROR_MESSAGE);
                    }
                    if (fieldId.Equals(example.FIELD_EMAIL_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, EMAIL_REGEX);
                        Assert.AreEqual(field.Validator.Message, example.FIELD_EMAIL_ERROR_MESSAGE);
                    }
                    if (fieldId.Equals(example.FIELD_URL_ID))
                    {
                        Assert.AreEqual(field.Validator.Regex, URL_REGEX);
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

