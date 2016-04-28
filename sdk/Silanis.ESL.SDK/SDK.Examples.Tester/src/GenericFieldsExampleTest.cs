using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    [TestClass]
    public class GenericFieldsExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new GenericFieldsExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            foreach (var signature in documentPackage.GetDocument(GenericFieldsExample.DocumentName).Signatures)
            {
                foreach (var field in signature.Fields)
                {
                    // Textfield
                    if (field.Id == GenericFieldsExample.TextfieldId)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_TEXT_FIELD, field.Style);
                        Assert.AreEqual(GenericFieldsExample.TextfieldPage, field.Page);
                    }
                    // Checkbox
                    if (field.Id == GenericFieldsExample.CheckboxId)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_CHECK_BOX, field.Style);
                        Assert.AreEqual(FieldBuilder.CHECKBOX_CHECKED, field.Value);
                        Assert.AreEqual(GenericFieldsExample.CheckboxPage, field.Page);
                    }
                    // Radio Button 1
                    if (field.Id == GenericFieldsExample.RadioId1)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(GenericFieldsExample.RadioPage,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(GenericFieldsExample.RadioGroup1, field.Validator.Options[0]);
                        Assert.AreEqual("", field.Value);
                    }
                    // Radio Button 2
                    if (field.Id == GenericFieldsExample.RadioId2)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(GenericFieldsExample.RadioPage,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(GenericFieldsExample.RadioGroup1, field.Validator.Options[0]);
                        Assert.AreEqual(FieldBuilder.RADIO_SELECTED, field.Value);
                    }
                    // Radio Button 3
                    if (field.Id == GenericFieldsExample.RadioId3)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(GenericFieldsExample.RadioPage,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(GenericFieldsExample.RadioGroup2, field.Validator.Options[0]);
                        Assert.AreEqual(FieldBuilder.RADIO_SELECTED, field.Value);
                    }
                    // Radio Button 4
                    if (field.Id == GenericFieldsExample.RadioId4)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(GenericFieldsExample.RadioPage,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(GenericFieldsExample.RadioGroup2, field.Validator.Options[0]);
                        Assert.AreEqual("", field.Value);
                    }
                    // Drop List
                    if (field.Id == GenericFieldsExample.DropListId) 
                    {
                        Assert.AreEqual(GenericFieldsExample.DropListPage, field.Page);
                        Assert.AreEqual(FieldStyle.DROP_LIST, field.Style);
                        Assert.AreEqual(GenericFieldsExample.DropListOption1, field.Validator.Options[0]);
                        Assert.AreEqual(GenericFieldsExample.DropListOption2, field.Validator.Options[1]);
                        Assert.AreEqual(GenericFieldsExample.DropListOption3, field.Validator.Options[2]);
                        Assert.AreEqual(GenericFieldsExample.DropListOption2, field.Value);
                    }
                    // Text Area
                    if (field.Id == GenericFieldsExample.TextAreaId) 
                    {
                        Assert.AreEqual(GenericFieldsExample.TextAreaPage, field.Page);
                        Assert.AreEqual(FieldStyle.TEXT_AREA, field.Style);
                        Assert.AreEqual(GenericFieldsExample.TextAreaValue, field.Value);
                    }
                    // Label Field
                    if (field.Id == GenericFieldsExample.LabelId) 
                    {
                        Assert.AreEqual(GenericFieldsExample.LabelPage, field.Page);
                        Assert.AreEqual(FieldStyle.LABEL, field.Style);
                        Assert.AreEqual(GenericFieldsExample.LabelValue, field.Value);
                    }
                }
            }
        }
    }
}