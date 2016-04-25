using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class CustomFieldExampleTest
    {
		[Test]
		public void verify() {
			CustomFieldExample example = new CustomFieldExample();
			example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;
            Assert.IsTrue(example.EslClient.GetCustomFieldService().DoesCustomFieldExist(example.customFieldId1));
            Assert.IsFalse(example.EslClient.GetCustomFieldService().DoesCustomFieldExist(example.customFieldId2));

            Assert.AreEqual(documentPackage.GetDocument(example.DOCUMENT_NAME).Signatures.Count, 1);
            Assert.AreEqual(documentPackage.GetDocument(example.DOCUMENT_NAME).Signatures[0].SignerEmail, example.email1);
            Assert.IsNotNull(documentPackage.GetDocument(example.DOCUMENT_NAME).Signatures[0].Fields[0]);

            // Get first custom field
            CustomField retrievedCustomField = example.retrievedCustomField;
            Assert.AreEqual(retrievedCustomField.Id, example.customFieldId1);
            Assert.AreEqual(retrievedCustomField.Value, example.DEFAULT_VALUE);
            Assert.AreEqual(retrievedCustomField.Translations[0].Name, example.ENGLISH_NAME);
            Assert.AreEqual(retrievedCustomField.Translations[0].Language, example.ENGLISH_LANGUAGE);
            Assert.AreEqual(retrievedCustomField.Translations[0].Description, example.ENGLISH_DESCRIPTION);
            Assert.AreEqual(retrievedCustomField.Translations[1].Name, example.FRENCH_NAME);
            Assert.AreEqual(retrievedCustomField.Translations[1].Language, example.FRENCH_LANGUAGE);
            Assert.AreEqual(retrievedCustomField.Translations[1].Description, example.FRENCH_DESCRIPTION);

            // Get entire list of custom fields
            Assert.Greater(example.retrievedCustomFieldList1.Count, 0);

            // Get first page of custom fields
            Assert.Greater(example.retrievedCustomFieldList2.Count, 0);

            // Get the custom field values for this user
            Assert.GreaterOrEqual(example.retrieveCustomFieldValueList1.Count, 1);
            Assert.AreEqual(example.customFieldId1, example.retrieveCustomFieldValue1.Id);
            Assert.AreEqual(example.customFieldId2, example.retrieveCustomFieldValue2.Id);

            // Get the custom field values for this user after deleting 1 user custom field for this user
            Assert.AreEqual(example.retrieveCustomFieldValueList2.Count, example.retrieveCustomFieldValueList1.Count - 1);

		}
    }
}

