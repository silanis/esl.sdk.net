using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class CustomFieldExample: SdkSample
    {
        public readonly string DocumentName = "First Document";
        public readonly string DefaultValue = "#12345";
        public readonly string EnglishLanguage = "en";
        public readonly string EnglishName = "Player Number";
        public readonly string EnglishDescription = "The number on your team jersey";
        public readonly string FrenchLanguage = "fr";
        public readonly string FrenchName = "Numero du Joueur";
        public readonly string FrenchDescription = "Le numero dans le dos de votre chandail d'equipe";
        public readonly string FieldValue1 = "11";
        public readonly string FieldValue2 = "22";

        public string CustomFieldId1, CustomFieldId2;
        public CustomField RetrievedCustomField;
        public IList<CustomField> RetrievedCustomFieldList1, RetrievedCustomFieldList2;
        public IList<CustomFieldValue> RetrieveCustomFieldValueList1, RetrieveCustomFieldValueList2;
        public CustomFieldValue RetrieveCustomFieldValue1, RetrieveCustomFieldValue2;

        public static void Main(string[] args)
        {
            new CustomFieldExample().Run();
        }

        override public void Execute()
        {
            // first custom field
            CustomFieldId1 = Guid.NewGuid().ToString().Replace("-", "");
            Console.WriteLine("customer field ID = " + CustomFieldId1);
            var customField1 = eslClient.GetCustomFieldService()
                .CreateCustomField(CustomFieldBuilder.CustomFieldWithId(CustomFieldId1)
                    .WithDefaultValue(DefaultValue)
                    .WithTranslation(TranslationBuilder.NewTranslation(EnglishLanguage)
                        .WithName(EnglishName)
                        .WithDescription(EnglishDescription))
                    .WithTranslation(TranslationBuilder.NewTranslation(FrenchLanguage)
                        .WithName(FrenchName)
                        .WithDescription(FrenchDescription))
                        .Build());

            var customFieldValue = eslClient.GetCustomFieldService()
                .SubmitCustomFieldValue(CustomFieldValueBuilder.CustomFieldValueWithId(customField1.Id)
                        .WithValue(FieldValue1)
                        .build());

            // Second custom field
            CustomFieldId2 = Guid.NewGuid().ToString().Replace("-", "");
            Console.WriteLine("customer field ID = " + CustomFieldId1);
            var customField2 = eslClient.GetCustomFieldService()
				.CreateCustomField(CustomFieldBuilder.CustomFieldWithId(CustomFieldId2)
					.WithDefaultValue("Red")
					.WithTranslation(TranslationBuilder.NewTranslation("en").
						WithName("Jersey color").
						WithDescription("The color of your team jersey"))
					.Build());

            var customFieldValue2 = eslClient.GetCustomFieldService()
                .SubmitCustomFieldValue(CustomFieldValueBuilder.CustomFieldValueWithId(customField2.Id)
                                        .WithValue(FieldValue2)
                                        .build());

            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                        .WithFirstName("John")
                        .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                        .FromStream(fileStream1, DocumentType.PDF)
                        .WithSignature(SignatureBuilder.SignatureFor(email1)
                                .OnPage(0)
                                .AtPosition(100, 100)
							.WithField(FieldBuilder.CustomField(customFieldValue.Id)
                                        .OnPage(0)
                                        .AtPosition(400, 200))
                            .WithField(FieldBuilder.CustomField(customFieldValue2.Id)
							.OnPage(0)
							.AtPosition(400, 400))))
                .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            eslClient.SendPackage(packageId);
            retrievedPackage = eslClient.GetPackage(packageId);

            // Get the entire list of custom field from account
            RetrievedCustomFieldList1 = eslClient.GetCustomFieldService().GetCustomFields(Direction.ASCENDING);

            // Get a list of custom fields on page 1 sorted in ascending order by its id
            RetrievedCustomFieldList2 = eslClient.GetCustomFieldService().GetCustomFields(Direction.ASCENDING, new PageRequest(1));

            // Get the first custom field from account
            RetrievedCustomField = eslClient.GetCustomFieldService().GetCustomField(CustomFieldId1);

            // Delete the second custom field from account
            eslClient.GetCustomFieldService().DeleteCustomField(CustomFieldId2);

            // Get the entire list of user custom field from the user
            RetrieveCustomFieldValueList1 = eslClient.GetCustomFieldService().GetCustomFieldValues();
            RetrieveCustomFieldValue1 = eslClient.GetCustomFieldService().GetCustomFieldValue(CustomFieldId1);
            RetrieveCustomFieldValue2 = eslClient.GetCustomFieldService().GetCustomFieldValue(CustomFieldId2);

            // Delete the second custom field from the user
            eslClient.GetCustomFieldService().DeleteCustomFieldValue(RetrieveCustomFieldValueList1[1].Id);

            // Get the entire list of user custom field from the user
            RetrieveCustomFieldValueList2 = eslClient.GetCustomFieldService().GetCustomFieldValues();

        }
    }
}

