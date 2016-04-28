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

            var document = documentPackage.GetDocument(example.DocumentName);

            foreach (var signature in document.Signatures)
            {
                if (!signature.SignerEmail.Equals(example.Email1))
                {
                    break;
                }

                foreach (var field in signature.Fields)
                {
                    var fieldId = field.Id;

                    if (fieldId.Equals(example.FieldAlphabeticId))
                    {
                        Assert.AreEqual(field.Validator.Regex, AlphabeticRegex);
                        Assert.AreEqual(field.Validator.MaxLength, example.FieldAlphabeticMaxLength);
                        Assert.AreEqual(field.Validator.MinLength, example.FieldAlphabeticMinLength);
                        Assert.IsTrue(field.Validator.Required);
                        Assert.AreEqual(field.Validator.Message, example.FieldAlphabeticErrorMessage);
                    }
                    if (fieldId.Equals(example.FieldNumericId))
                    {
                        Assert.AreEqual(field.Validator.Regex, NumericRegex);
                        Assert.AreEqual(field.Validator.Message, example.FieldNumericErrorMessage);
                    }
                    if (fieldId.Equals(example.FieldAlphanumericId))
                    {
                        Assert.AreEqual(field.Validator.Regex, AlphanumericRegex);
                        Assert.AreEqual(field.Validator.Message, example.FieldAlphanumericErrorMessage);
                    }
                    if (fieldId.Equals(example.FieldEmailId))
                    {
                        Assert.AreEqual(field.Validator.Regex, EmailRegex);
                        Assert.AreEqual(field.Validator.Message, example.FieldEmailErrorMessage);
                    }
                    if (fieldId.Equals(example.FieldUrlId))
                    {
                        Assert.AreEqual(field.Validator.Regex, UrlRegex);
                        Assert.AreEqual(field.Validator.Message, example.FieldUrlErrorMessage);

                    }
                    if (fieldId.Equals(example.FieldRegexId))
                    {
                        Assert.AreEqual(field.Validator.Regex, example.FieldRegex);
                        Assert.AreEqual(field.Validator.Message, example.FieldRegexErrorMessage);
                    }
                }
            }
        }
    }
}

