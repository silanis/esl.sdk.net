using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    [TestFixture()]
    public class CreatePackageFromTemplateWithFieldsExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            CreatePackageFromTemplateWithFieldsExample example = new CreatePackageFromTemplateWithFieldsExample();
            example.Run();

            DocumentPackage documentPackage = example.RetrievedPackage;

            foreach (Signature signature in documentPackage.GetDocument(example.DOCUMENT_NAME).Signatures)
            {
                foreach (Field field in signature.Fields)
                {
                    // Textfield
                    if (field.Id == example.TEXTFIELD_ID)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_TEXT_FIELD, field.Style);
                        Assert.AreEqual(example.TEXTFIELD_PAGE, field.Page);
                    }
                    // Checkbox
                    if (field.Id == example.CHECKBOX_1_ID)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_CHECK_BOX, field.Style);
                        Assert.IsNotNull(field.Value);
                        Assert.AreEqual(example.CHECKBOX_1_PAGE, field.Page);
                    }
                    if (field.Id == example.CHECKBOX_2_ID)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_CHECK_BOX, field.Style);
                        Assert.AreEqual(FieldBuilder.CHECKBOX_CHECKED, field.Value);
                        Assert.AreEqual(example.CHECKBOX_2_PAGE, field.Page);
                    }
                    // Radio Button 1
                    if (field.Id == example.RADIO_1_ID)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(example.RADIO_1_PAGE,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(example.RADIO_1_GROUP, field.Validator.Options[0]);
                        Assert.AreEqual("", field.Value);
                    }
                    // Radio Button 2
                    if (field.Id == example.RADIO_2_ID)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(example.RADIO_2_PAGE,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(example.RADIO_2_GROUP, field.Validator.Options[0]);
                        Assert.AreEqual(FieldBuilder.RADIO_SELECTED, field.Value);
                    }
                    // Drop List
                    if (field.Id == example.DROP_LIST_ID) 
                    {
                        Assert.AreEqual(example.DROP_LIST_PAGE, field.Page);
                        Assert.AreEqual(FieldStyle.DROP_LIST, field.Style);
                        Assert.AreEqual(example.DROP_LIST_OPTION1, field.Validator.Options[0]);
                        Assert.AreEqual(example.DROP_LIST_OPTION2, field.Validator.Options[1]);
                        Assert.AreEqual(example.DROP_LIST_OPTION3, field.Validator.Options[2]);
                        Assert.AreEqual(example.DROP_LIST_OPTION2, field.Value);
                    }
                    // Text Area
                    if (field.Id == example.TEXT_AREA_ID) 
                    {
                        Assert.AreEqual(example.TEXT_AREA_PAGE, field.Page);
                        Assert.AreEqual(FieldStyle.TEXT_AREA, field.Style);
                        Assert.AreEqual(example.TEXT_AREA_VALUE, field.Value);
                    }
                    // Label Field
                    if (field.Id == example.LABEL_ID) 
                    {
                        Assert.AreEqual(example.LABEL_PAGE, field.Page);
                        Assert.AreEqual(FieldStyle.LABEL, field.Style);
                        Assert.AreEqual(example.LABEL_VALUE, field.Value);
                    }
                }
            }
        }
    }
}

