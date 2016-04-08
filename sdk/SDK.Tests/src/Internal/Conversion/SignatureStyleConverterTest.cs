using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class SignatureStyleConverterTest
    {
        public SignatureStyleConverterTest()
        {
        }
        
        [TestMethod]
        public void ToSDKFromCapture()
        {
            var converter = new SignatureStyleConverter(SignatureStyle.HAND_DRAWN.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.IsNotNull(sdk);
            Assert.AreEqual(SignatureStyle.HAND_DRAWN,sdk);            
        }
        
        [TestMethod]
        public void ToSDKFromFullName()
        {
            var converter = new SignatureStyleConverter(SignatureStyle.FULL_NAME.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.IsNotNull(sdk);
            Assert.AreEqual(SignatureStyle.FULL_NAME,sdk);            
        }
        
        [TestMethod]
        public void ToSDKFromInitials()
        {
            var converter = new SignatureStyleConverter(SignatureStyle.INITIALS.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.IsNotNull(sdk);
            Assert.AreEqual(SignatureStyle.INITIALS,sdk);            
        }
        
        [TestMethod]

        public void ToSDKFromCheckbox()
        {
            var converter = new SignatureStyleConverter(FieldStyle.UNBOUND_CHECK_BOX.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.UNBOUND_CHECK_BOX.getApiValue());
        }

        [TestMethod]

        public void ToSDKFromCustomField()
        {
            var converter = new SignatureStyleConverter(FieldStyle.UNBOUND_CUSTOM_FIELD.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.UNBOUND_CUSTOM_FIELD.getApiValue());
        }

        [TestMethod]

        public void ToSDKFromDate()
        {
            var converter = new SignatureStyleConverter("DATE");
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), "DATE");
        }

        [TestMethod]

        public void ToSDKFromLabel()
        {
            var converter = new SignatureStyleConverter(FieldStyle.LABEL.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.LABEL.getApiValue());
        }

        [TestMethod]

        public void ToSDKFromList()
        {
            var converter = new SignatureStyleConverter(FieldStyle.DROP_LIST.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.DROP_LIST.getApiValue());
        }

        [TestMethod]

        public void ToSDKFromNotarize()
        {
            var converter = new SignatureStyleConverter(FieldStyle.SEAL.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.SEAL.getApiValue());
        }

        [TestMethod]

        public void ToSDKFromQRCode()
        {
            var converter = new SignatureStyleConverter(FieldStyle.BOUND_QRCODE.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.BOUND_QRCODE.getApiValue());
        }

        [TestMethod]

        public void ToSDKFromRadio()
        {
            var converter = new SignatureStyleConverter(FieldStyle.UNBOUND_RADIO_BUTTON.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.UNBOUND_RADIO_BUTTON.getApiValue());
        }

        [TestMethod]

        public void ToSDKFromTextArea()
        {
            var converter = new SignatureStyleConverter(FieldStyle.TEXT_AREA.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.TEXT_AREA.getApiValue());
        }

        [TestMethod]

        public void ToSDKFromTextField()
        {
            var converter = new SignatureStyleConverter(FieldStyle.UNBOUND_TEXT_FIELD.getApiValue());
            var sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.UNBOUND_TEXT_FIELD.getApiValue());
        }
    }
}

