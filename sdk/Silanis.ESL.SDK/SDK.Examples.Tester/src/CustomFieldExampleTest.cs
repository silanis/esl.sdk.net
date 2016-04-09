using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    public class CustomFieldExampleTest
    {
		[TestMethod]
		public void Verify() {
			var example = new CustomFieldExample();
			example.Run();

            var documentPackage = example.RetrievedPackage;
            Assert.IsTrue(example.EslClient.GetCustomFieldService().DoesCustomFieldExist(example.CustomFieldId1));
            Assert.IsFalse(example.EslClient.GetCustomFieldService().DoesCustomFieldExist(example.CustomFieldId2));

            Assert.AreEqual(documentPackage.GetDocument(example.DocumentName).Signatures.Count, 1);
            Assert.AreEqual(documentPackage.GetDocument(example.DocumentName).Signatures[0].SignerEmail, example.email1);
            Assert.IsNotNull(documentPackage.GetDocument(example.DocumentName).Signatures[0].Fields[0]);

            // Get first custom field
            var retrievedCustomField = example.RetrievedCustomField;
            Assert.AreEqual(retrievedCustomField.Id, example.CustomFieldId1);
            Assert.AreEqual(retrievedCustomField.Value, example.DefaultValue);
            Assert.AreEqual(retrievedCustomField.Translations[0].Name, example.EnglishName);
            Assert.AreEqual(retrievedCustomField.Translations[0].Language, example.EnglishLanguage);
            Assert.AreEqual(retrievedCustomField.Translations[0].Description, example.EnglishDescription);
            Assert.AreEqual(retrievedCustomField.Translations[1].Name, example.FrenchName);
            Assert.AreEqual(retrievedCustomField.Translations[1].Language, example.FrenchLanguage);
            Assert.AreEqual(retrievedCustomField.Translations[1].Description, example.FrenchDescription);

            // Get entire list of custom fields
            Assert.IsTrue(example.RetrievedCustomFieldList1.Count > 0);

            // Get first page of custom fields
            Assert.IsTrue(example.RetrievedCustomFieldList2.Count > 0);

            // Get the custom field values for this user
            Assert.IsTrue(example.RetrieveCustomFieldValueList1.Count >= 1);
            Assert.AreEqual(example.CustomFieldId1, example.RetrieveCustomFieldValue1.Id);
            Assert.AreEqual(example.CustomFieldId2, example.RetrieveCustomFieldValue2.Id);

            // Get the custom field values for this user after deleting 1 user custom field for this user
            Assert.AreEqual(example.RetrieveCustomFieldValueList2.Count, example.RetrieveCustomFieldValueList1.Count - 1);

		}
    }
}

