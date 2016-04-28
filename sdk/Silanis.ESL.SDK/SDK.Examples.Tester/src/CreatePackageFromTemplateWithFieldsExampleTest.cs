using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    [TestClass]
    public class CreatePackageFromTemplateWithFieldsExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new CreatePackageFromTemplateWithFieldsExample();
            example.Run();

            var documentPackage = example.RetrievedPackage;

            foreach (var signature in documentPackage.GetDocument(example.DocumentName).Signatures)
            {
                foreach (var field in signature.Fields)
                {
                    // Textfield
                    if (field.Id == example.TextfieldId)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_TEXT_FIELD, field.Style);
                        Assert.AreEqual(example.TextfieldPage, field.Page);
                    }
                    // Checkbox
                    if (field.Id == example.Checkbox1Id)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_CHECK_BOX, field.Style);
                        Assert.IsNotNull(field.Value);
                        Assert.AreEqual(example.Checkbox1Page, field.Page);
                    }
                    if (field.Id == example.Checkbox2Id)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_CHECK_BOX, field.Style);
                        Assert.AreEqual(FieldBuilder.CHECKBOX_CHECKED, field.Value);
                        Assert.AreEqual(example.Checkbox2Page, field.Page);
                    }
                    // Radio Button 1
                    if (field.Id == example.Radio1Id)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(example.Radio1Page,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(example.Radio1Group, field.Validator.Options[0]);
                        Assert.AreEqual("", field.Value);
                    }
                    // Radio Button 2
                    if (field.Id == example.Radio2Id)
                    {
                        Assert.AreEqual(FieldStyle.UNBOUND_RADIO_BUTTON, field.Style);
                        Assert.AreEqual(example.Radio2Page,field.Page);
                        Assert.IsNotNull(field.Validator);
                        Assert.AreEqual(example.Radio2Group, field.Validator.Options[0]);
                        Assert.AreEqual(FieldBuilder.RADIO_SELECTED, field.Value);
                    }
                    // Drop List
                    if (field.Id == example.DropListId) 
                    {
                        Assert.AreEqual(example.DropListPage, field.Page);
                        Assert.AreEqual(FieldStyle.DROP_LIST, field.Style);
                        Assert.AreEqual(example.DropListOption1, field.Validator.Options[0]);
                        Assert.AreEqual(example.DropListOption2, field.Validator.Options[1]);
                        Assert.AreEqual(example.DropListOption3, field.Validator.Options[2]);
                        Assert.AreEqual(example.DropListOption2, field.Value);
                    }
                    // Text Area
                    if (field.Id == example.TextAreaId) 
                    {
                        Assert.AreEqual(example.TextAreaPage, field.Page);
                        Assert.AreEqual(FieldStyle.TEXT_AREA, field.Style);
                        Assert.AreEqual(example.TextAreaValue, field.Value);
                    }
                    // Label Field
                    if (field.Id == example.LabelId) 
                    {
                        Assert.AreEqual(example.LabelPage, field.Page);
                        Assert.AreEqual(FieldStyle.LABEL, field.Style);
                        Assert.AreEqual(example.LabelValue, field.Value);
                    }
                }
            }
        }
    }
}

