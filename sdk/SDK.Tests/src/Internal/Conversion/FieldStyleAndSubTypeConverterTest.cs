using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{

    [TestClass]
    public class FieldStyleAndSubTypeConverterTest
    {
        private string apiFieldSubtype1;
        private string apiFieldSubtype2;
        private FieldStyle sdkFieldStyle1;
        private FieldStyle sdkFieldStyle2;

        [TestMethod]
        public void ConvertSDKToSDK()
        {
            sdkFieldStyle1 = FieldStyle.UNBOUND_CUSTOM_FIELD;
            sdkFieldStyle2 = new FieldStyleAndSubTypeConverter(sdkFieldStyle1).ToSDKFieldStyle();
            Assert.IsNotNull(sdkFieldStyle2);
            Assert.AreEqual(sdkFieldStyle2, sdkFieldStyle1);
        }

        [TestMethod]
        public void ConvertAPIToAPI()
        {
            string binding = null;
            apiFieldSubtype1 = FieldStyle.UNBOUND_CUSTOM_FIELD.getApiValue();
            apiFieldSubtype2 = new FieldStyleAndSubTypeConverter(apiFieldSubtype1, binding).ToAPIFieldSubtype();

            Assert.IsNotNull(apiFieldSubtype2);
            Assert.AreEqual(apiFieldSubtype2, apiFieldSubtype1);
        }

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            var BINDING_DATE = "{approval.signed}";
            var BINDING_TITLE = "{signer.title}";
            var BINDING_NAME = "{signer.name}";
            var BINDING_COMPANY = "{signer.company}";

            // Where the conversion is based on subtype.
            string binding;
            string fieldSubtype;
            FieldStyle fieldStyle;

            fieldSubtype = FieldStyle.UNBOUND_CUSTOM_FIELD.getApiValue();
            binding = null;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.UNBOUND_CUSTOM_FIELD);

            fieldSubtype = FieldStyle.UNBOUND_TEXT_FIELD.getApiValue();
            binding = null;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.UNBOUND_TEXT_FIELD);

            fieldSubtype = FieldStyle.UNBOUND_CHECK_BOX.getApiValue();
            binding = null;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.UNBOUND_CHECK_BOX);

            fieldSubtype = FieldStyle.UNBOUND_RADIO_BUTTON.getApiValue();
            binding = null;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.UNBOUND_RADIO_BUTTON);

            fieldSubtype = FieldStyle.TEXT_AREA.getApiValue();
            binding = null;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.TEXT_AREA);

            fieldSubtype = FieldStyle.DROP_LIST.getApiValue();
            binding = null;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.DROP_LIST);

            fieldSubtype = FieldStyle.BOUND_QRCODE.getApiValue();
            binding = null;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.BOUND_QRCODE);

            fieldSubtype = FieldStyle.SEAL.getApiValue();
            binding = null;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.SEAL);

            fieldSubtype = "THIS_IS_A_NEW_FIELD_ADDED";
            binding = null;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle.getApiValue(), "THIS_IS_A_NEW_FIELD_ADDED");

            // Where the conversion is based on binding.
            fieldSubtype = "";
            binding = BINDING_DATE;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.BOUND_DATE);

            fieldSubtype = "";
            binding = BINDING_TITLE;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.BOUND_TITLE);

            fieldSubtype = "";
            binding = BINDING_NAME;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.BOUND_NAME);

            fieldSubtype = "";
            binding = BINDING_COMPANY;
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle, FieldStyle.BOUND_COMPANY);

            fieldSubtype = "";
            binding = "";
            fieldStyle = new FieldStyleAndSubTypeConverter(fieldSubtype, binding).ToSDKFieldStyle();
            Assert.AreEqual(fieldStyle.getApiValue(), FieldStyle.valueOf("").getApiValue());
        }

        [TestMethod]
        public void ConvertSDKToAPI()
        {
            var fieldStyle = FieldStyle.UNBOUND_CUSTOM_FIELD;
            var fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.UNBOUND_CUSTOM_FIELD.getApiValue());

            fieldStyle = FieldStyle.UNBOUND_TEXT_FIELD;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.UNBOUND_TEXT_FIELD.getApiValue());

            fieldStyle = FieldStyle.LABEL;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.LABEL.getApiValue());

            fieldStyle = FieldStyle.UNBOUND_CHECK_BOX;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.UNBOUND_CHECK_BOX.getApiValue());

            fieldStyle = FieldStyle.UNBOUND_RADIO_BUTTON;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.UNBOUND_RADIO_BUTTON.getApiValue());

            fieldStyle = FieldStyle.DROP_LIST;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.DROP_LIST.getApiValue());

            fieldStyle = FieldStyle.TEXT_AREA;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.TEXT_AREA.getApiValue());

            fieldStyle = FieldStyle.BOUND_QRCODE;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.BOUND_QRCODE.getApiValue());

            fieldStyle = FieldStyle.SEAL;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.SEAL.getApiValue());

            fieldStyle = FieldStyle.BOUND_DATE;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.LABEL.getApiValue());

            fieldStyle = FieldStyle.BOUND_NAME;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.LABEL.getApiValue());

            fieldStyle = FieldStyle.BOUND_TITLE;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.LABEL.getApiValue());

            fieldStyle = FieldStyle.BOUND_COMPANY;
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual(fieldSubtype, FieldStyle.LABEL.getApiValue());

            fieldStyle = FieldStyle.valueOf("unknownvalue");
            fieldSubtype = new FieldStyleAndSubTypeConverter(fieldStyle).ToAPIFieldSubtype();
            Assert.AreEqual("unknownvalue", fieldSubtype);
        }

    }
}

