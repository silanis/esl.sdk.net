
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class DocumentLayoutExampleTest
    {
        private readonly double TOLERANCE = 1.25;

        private DocumentLayoutExample example;

        [TestMethod]
        public void VerifyResult()
        {
            example = new DocumentLayoutExample();
            example.Run();

            // Assert the layout was created correctly.
            var layouts = example.Layouts;
            Assert.IsTrue(layouts.Count > 0);

            foreach (var layout in layouts)
            {
                if (layout.Name.Equals(example.LayoutPackageName))
                {
                    Assert.AreEqual(layout.Id.Id, example.LayoutId);
                    Assert.AreEqual(layout.Description, example.LayoutPackageDescription);
                    Assert.AreEqual(layout.Documents.Count, 1);
                    Assert.AreEqual(layout.Signers.Count, 2);

                    var document = layout.GetDocument(example.LayoutDocumentName);
                    Assert.AreEqual(document.Signatures.Count, 1);

                    // Validate the signature fields of layout were saved correctly.
                    ValidateSignatureFields(document.Signatures);
                }
            }

            // Assert that document layout was applied correctly to document.
            var packageWithLayout = example.PackageWithLayout;

            Assert.AreNotEqual(packageWithLayout.Name, example.LayoutPackageName);
            Assert.AreNotEqual(packageWithLayout.Description, example.LayoutPackageDescription);
            Assert.AreEqual(packageWithLayout.Signers.Count, 2);
            Assert.AreEqual(packageWithLayout.Documents.Count, 2);

            var documentWithLayout = packageWithLayout.GetDocument(example.ApplyLayoutDocumentName);
            Assert.AreEqual(documentWithLayout.Description, example.ApplyLayoutDocumentDescription);
            Assert.AreEqual(documentWithLayout.Id, example.ApplyLayoutDocumentId);
            Assert.AreEqual(documentWithLayout.Signatures.Count, 1);

            // Validate that the signature fields were applied correctly to document.
            ValidateSignatureFields(documentWithLayout.Signatures);
        }

        private void ValidateSignatureFields(IList<Signature> signatures)
        {
            foreach (var signature in signatures)
            {
                Assert.AreEqual(signature.SignerEmail, example.email1);
                Assert.AreEqual(signature.Page, 0);
                Assert.AreEqual(signature.Fields.Count, 2);

                foreach (var field in signature.Fields)
                {
                    if (field.Name.Equals(example.Field1Name))
                    {
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_TITLE);
                        Assert.AreEqual(field.Page, 0);
                        Assert.IsTrue(field.X > 100 - TOLERANCE);
                        Assert.IsTrue(field.X < 100 + TOLERANCE);
                        Assert.IsTrue(field.Y > 200 - TOLERANCE);
                        Assert.IsTrue(field.Y < 200 + TOLERANCE);
                    }

                    if (field.Name.Equals(example.Field2Name))
                    {
                        Assert.AreEqual(field.Style, FieldStyle.BOUND_COMPANY);
                        Assert.AreEqual(field.Page, 0);
                        Assert.IsTrue(field.X > 100 - TOLERANCE);
                        Assert.IsTrue(field.X < 100 + TOLERANCE);
                        Assert.IsTrue(field.Y > 300 - TOLERANCE);
                        Assert.IsTrue(field.Y < 300 + TOLERANCE);
                    }
                }
            }
        }
    }
}

