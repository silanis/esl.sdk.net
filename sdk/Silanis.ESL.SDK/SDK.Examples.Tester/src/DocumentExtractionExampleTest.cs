
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using System.Collections.Generic;

namespace SDK.Examples
{
    [TestClass]
    public class DocumentExtractionExampleTest
    {
        /* The test is written based on scaling factor 1.3 but it should work with 1.33333 */
        private readonly double SCALING_FACTOR = 1.3d;
        private readonly double SCALING_FACTOR_TOLERANCE = 0.1d;

        [TestMethod]
        public void VerifyResult()
        {
            var example = new DocumentExtractionExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            // Verify if the required information is correctly extracted.
            var document = documentPackage.GetDocument(example.DocumentName);

            var actualSignatures = document.Signatures;

            Assert.AreEqual(6, actualSignatures.Count, "The number of signatures in extracted document is wrong");

            var signature0 = signatureForTopLeft(actualSignatures, 224, 90);
            Assert.IsNotNull(signature0);
            AssertSignature(signature0, 3);
            var fields0 = signature0.Fields;

            AssertField(fields0, FieldStyle.BOUND_NAME, "{signer.name}", 225, 303, 195, 28, 0);
            AssertField(fields0, FieldStyle.UNBOUND_CHECK_BOX, null, 283, 94, 85, 28, 0);
            AssertField(fields0, FieldStyle.BOUND_NAME, "{signer.name}", 222, 537, 195, 28, 0);
            AssertSignature(signature0, SignatureStyle.HAND_DRAWN, 224, 90, 195, 28, 0);

            var signature1 = signatureForTopLeft(actualSignatures, 345, 93);
            Assert.IsNotNull(signature1);
            AssertSignature(signature1, 2);
            var fields1 = signature1.Fields;
            AssertField(fields1, FieldStyle.UNBOUND_TEXT_FIELD, null, 343, 315, 195, 28, 0);
            AssertField(fields1, FieldStyle.BOUND_TITLE, "{signer.title}", 342, 527, 195, 28, 0);
            AssertSignature(signature1, SignatureStyle.HAND_DRAWN, 345, 93, 195, 28, 0);

            var signature2 = signatureForTopLeft(actualSignatures, 81, 89);
            Assert.IsNotNull(signature2);
            AssertSignature(signature2, 0);
            AssertSignature(signature2, SignatureStyle.INITIALS, 81, 89, 195, 28, 0);

            var signature3 = signatureForTopLeft(actualSignatures, 131, 541);
            Assert.IsNotNull(signature3);
            AssertSignature(signature3, 1);
            var fields3 = signature3.Fields;
            AssertField(fields3, FieldStyle.BOUND_COMPANY, "{signer.company}", 170, 542, 195, 28, 0);
            AssertSignature(signature3, SignatureStyle.FULL_NAME, 131, 541, 195, 28, 0);

            var signature4 = signatureForTopLeft(actualSignatures, 726, 91);
            Assert.IsNotNull(signature4);
            AssertSignature(signature4, 2);
            var fields4 = signature4.Fields;
            AssertField(fields4, FieldStyle.BOUND_NAME, "{signer.name}", 724, 299, 195, 28, 0);
            AssertField(fields4, FieldStyle.BOUND_DATE, "{approval.signed}", 724, 509, 195, 28, 0);
            AssertSignature(signature4, SignatureStyle.HAND_DRAWN, 726, 91, 195, 28, 0);

            var signature5 = signatureForTopLeft(actualSignatures, 43, 54);
            Assert.IsNotNull(signature5);
            AssertSignature(signature5, 2);
            var fields5 = signature5.Fields;
            AssertField(fields5, FieldStyle.BOUND_NAME, "{signer.name}", 42, 262, 195, 28, 1);
            AssertField(fields5, FieldStyle.BOUND_DATE, "{approval.signed}", 41, 471, 195, 28, 1);
            AssertSignature(signature5, SignatureStyle.HAND_DRAWN, 43, 54, 195, 28, 1);
        }

        private Signature signatureForTopLeft(List<Signature> signatures, double top, double left) 
        {
            if (signatures != null) {
                foreach (var signature in signatures) {
                    if (AreClose(signature.X, left) && AreClose(signature.Y, top)) {
                        return signature;
                    }
                }
            }
            return null;
        }

        private void AssertField(List<Field> fields, FieldStyle subtype, string binding,
                                 int top, int left, int width, int height, int pageIndex) 
        {
            var matches = false;
            foreach (var field in fields) 
            {
                if (equals(field.Binding, binding) &&
                    equals(field.Style, subtype) &&
                    AreClose(field.Y, top) &&
                    AreClose(field.X, left) &&
                    AreClose(field.Width, width) &&
                    AreClose(field.Height, height) &&
                    equals(field.Page, pageIndex)) 
                {
                    matches = true;
                    break;
                }
            }
            Assert.IsTrue(matches);
        }

        private void AssertSignature(Signature signature, SignatureStyle style,
                                     int top, int left, int width, int height, int pageIndex) 
        {

            var matches = false;
            if (equals(signature.Style, style) &&
                AreClose(signature.Y, top) &&
                AreClose(signature.X, left) &&
                AreClose(signature.Width, width) &&
                AreClose(signature.Height, height) &&
                equals(signature.Page, pageIndex)) 
            {
                matches = true;
            }
            Assert.IsTrue(matches);
        }

        /**
        * Compares values considering the scaling factor and scaling factor tolerance.
        */
        private bool AreClose(double number, double other) {
            var minValue = (other / SCALING_FACTOR) * (SCALING_FACTOR - SCALING_FACTOR_TOLERANCE);
            var maxValue = (other / SCALING_FACTOR) * (SCALING_FACTOR + SCALING_FACTOR_TOLERANCE);
            return number > minValue && number < maxValue;
        }

        private void AssertSignature(Signature signature, int numbOfFields) 
        {
            Assert.AreEqual(numbOfFields, signature.Fields.Count);
        }

        private bool equals(Object object1, Object object2) 
        {
            if (object1 == object2) 
            {
                return true;
            }
            if (object1 == null || object2 == null) 
            {
                return false;
            }
            return (object1 == object2);
        }

        private bool equals(double number1, double number2) 
        {
            if (number1 == number2) 
            {
                return true;
            }
            var interval = number1 - number2;
            if (interval < 1 && interval > -1 ) 
            {
                return true;
            }
            return false;
        }
    }
}

