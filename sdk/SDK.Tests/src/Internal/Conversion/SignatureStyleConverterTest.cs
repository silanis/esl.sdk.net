using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture]
    public class SignatureStyleConverterTest
    {
        public SignatureStyleConverterTest()
        {
        }
        
        [Test]
        public void ToSDKFromCapture()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(SignatureStyle.HAND_DRAWN.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.IsNotNull(sdk);
            Assert.AreEqual(SignatureStyle.HAND_DRAWN,sdk);            
        }
        
        [Test]
        public void ToSDKFromFullName()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(SignatureStyle.FULL_NAME.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.IsNotNull(sdk);
            Assert.AreEqual(SignatureStyle.FULL_NAME,sdk);            
        }
        
        [Test]
        public void ToSDKFromInitials()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(SignatureStyle.INITIALS.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.IsNotNull(sdk);
            Assert.AreEqual(SignatureStyle.INITIALS,sdk);            
        }
        
        [Test]

        public void ToSDKFromCheckbox()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(FieldStyle.UNBOUND_CHECK_BOX.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.UNBOUND_CHECK_BOX.getApiValue());
        }

        [Test]

        public void ToSDKFromCustomField()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(FieldStyle.UNBOUND_CUSTOM_FIELD.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.UNBOUND_CUSTOM_FIELD.getApiValue());
        }

        [Test]

        public void ToSDKFromDate()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter("DATE");
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), "DATE");
        }

        [Test]

        public void ToSDKFromLabel()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(FieldStyle.LABEL.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.LABEL.getApiValue());
        }

        [Test]

        public void ToSDKFromList()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(FieldStyle.DROP_LIST.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.DROP_LIST.getApiValue());
        }

        [Test]

        public void ToSDKFromNotarize()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(FieldStyle.SEAL.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.SEAL.getApiValue());
        }

        [Test]

        public void ToSDKFromQRCode()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(FieldStyle.BOUND_QRCODE.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.BOUND_QRCODE.getApiValue());
        }

        [Test]

        public void ToSDKFromRadio()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(FieldStyle.UNBOUND_RADIO_BUTTON.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.UNBOUND_RADIO_BUTTON.getApiValue());
        }

        [Test]

        public void ToSDKFromTextArea()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(FieldStyle.TEXT_AREA.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.TEXT_AREA.getApiValue());
        }

        [Test]

        public void ToSDKFromTextField()
        {
            SignatureStyleConverter converter = new SignatureStyleConverter(FieldStyle.UNBOUND_TEXT_FIELD.getApiValue());
            SignatureStyle sdk = converter.ToSDKSignatureStyle();

            Assert.AreEqual(sdk.getApiValue(), FieldStyle.UNBOUND_TEXT_FIELD.getApiValue());
        }
    }
}

