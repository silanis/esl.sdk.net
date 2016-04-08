using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK.src.Internal.Conversion;
using Field = Silanis.ESL.SDK.Field;

namespace SDK.Tests
{
    [TestClass]
    public class FieldConverterTest
    {
        private Field sdkField1;
        private Field sdkField2;
        private Silanis.ESL.API.Field apiField1;
        private Silanis.ESL.API.Field apiField2;
        private FieldConverter converter;

        [TestMethod]
        public void ConvertNullSDKToAPI()
        {
            sdkField1 = null;
            converter = new FieldConverter(sdkField1);
            Assert.IsNull(converter.ToAPIField());
        }

        [TestMethod]
        public void ConvertNullAPIToSDK()
        {
            apiField1 = null;
            converter = new FieldConverter(apiField1);
            Assert.IsNull(converter.ToSDKField());
        }

        [TestMethod]
        public void ConvertNullSDKToSDK()
        {
            sdkField1 = null;
            converter = new FieldConverter(sdkField1);
            Assert.IsNull(converter.ToSDKField());
        }

        [TestMethod]
        public void ConvertNullAPIToAPI()
        {
            apiField1 = null;
            converter = new FieldConverter(apiField1);
            Assert.IsNull(converter.ToAPIField());
        }

        [TestMethod]
        public void ConvertSDKToSDK()
        {
            sdkField1 = CreateTypicalSDKField();
            converter = new FieldConverter(sdkField1);
            sdkField2 = converter.ToSDKField();
            Assert.IsNotNull(sdkField2);
            Assert.AreEqual(sdkField2, sdkField1);
        }

        [TestMethod]
        public void ConvertAPIToAPI()
        {
            apiField1 = CreateTypicalAPIField();
            converter = new FieldConverter(apiField1);
            apiField2 = converter.ToAPIField();
            Assert.IsNotNull(apiField2);
            Assert.AreEqual(apiField2, apiField1);
        }

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            apiField1 = CreateTypicalAPIField();
            sdkField1 = new FieldConverter(apiField1).ToSDKField();

            Assert.IsNotNull(sdkField1);
            Assert.AreEqual(sdkField1.Validator, new FieldValidatorConverter(apiField1.Validation).ToSDKFieldValidator());
            Assert.AreEqual(sdkField1.Id, apiField1.Id);
            Assert.AreEqual(sdkField1.Name, apiField1.Name);
            Assert.AreEqual(sdkField1.Page, apiField1.Page);
            Assert.AreEqual(sdkField1.Style, new FieldStyleAndSubTypeConverter(apiField1.Subtype, apiField1.Binding).ToSDKFieldStyle());
            Assert.AreEqual(sdkField1.TextAnchor, new TextAnchorConverter(apiField1.ExtractAnchor).ToSDKTextAnchor());
            Assert.AreEqual(sdkField1.Value, apiField1.Value);
            Assert.AreEqual(sdkField1.X, apiField1.Left);
            Assert.AreEqual(sdkField1.Y, apiField1.Top);
            Assert.AreEqual(sdkField1.Width, apiField1.Width);
            Assert.AreEqual(sdkField1.Height, apiField1.Height);
        }

        [TestMethod]
        public void ConvertSDKToAPI()
        {
            sdkField1 = CreateTypicalSDKField();
            apiField1 = new FieldConverter(sdkField1).ToAPIField();

            Assert.IsNotNull(apiField1);
            Assert.AreEqual(sdkField1.Value, apiField1.Value);
            Assert.AreEqual(sdkField1.X, apiField1.Left);
            Assert.AreEqual(sdkField1.Y, apiField1.Top);
            Assert.AreEqual(sdkField1.Width, apiField1.Width);
            Assert.AreEqual(sdkField1.Height, apiField1.Height);
            Assert.AreEqual(sdkField1.Id, apiField1.Id);
            Assert.AreEqual(sdkField1.Name, apiField1.Name);
            Assert.AreEqual(sdkField1.Page, apiField1.Page);
        }

        private Field CreateTypicalSDKField()
        {
            double x = 1;
            double y = 1;
            var page = 3;
            double width = 4;
            double height = 5;

            var sdkField = FieldBuilder.NewField()
                .WithId("99")
                    .AtPosition(x, y)
                    .OnPage(page)
                    .WithSize(width, height)
                    .WithStyle(FieldStyle.BOUND_DATE)
                    .WithName("Field name")
                    .WithPositionAnchor(TextAnchorBuilder.NewTextAnchor("Anchor Text")
                                        .AtPosition(TextAnchorPosition.BOTTOMLEFT)
                                        .WithCharacter(65)
                                        .WithOccurrence(2)
                                        .WithOffset(101, 102) //xOffset, yOffset
                                        .WithSize(201, 202)   // width, height
                                        .Build())
                    .WithValidation(FieldValidatorBuilder.Alphabetic()
                                    .MaxLength(15)
                                    .MinLength(5)
                                    .Required()
                                    .WithErrorMessage("Error message for validation.")
                                    .Build())
                    .WithValue("value")
                    .Build();

            return sdkField;
        }

        private Silanis.ESL.API.Field CreateTypicalAPIField()
        {
            var apiField = new Silanis.ESL.API.Field();

            apiField.Extract = false;
            apiField.Height = 100.0;
            apiField.Left = 10.0;
            apiField.Id = "3";
            apiField.Name = "Field Name";
            apiField.Page = 1;
            apiField.Subtype = FieldStyle.UNBOUND_TEXT_FIELD.getApiValue();
            apiField.Top = 101.0;
            apiField.Type = "INPUT";
            apiField.Value = "field value";
            apiField.Width = 102.0;

            return apiField;
        }

    }
}

