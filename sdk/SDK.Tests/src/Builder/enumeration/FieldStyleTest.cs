using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    public class FieldStyleTest
    {
        [Test]
        public void whenBuildingFieldStyleWithAPIValueLABELThenLABELFieldStyleIsReturned()
        {
            string expectedSDKValue = "LABEL";


            FieldStyle classUnderTest = FieldStyle.valueOf("LABEL");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithSDKValueBOUND_DATEThenFieldStyleWithAPIValueLABELIsReturned()
        {
            string expectedAPIValue = "LABEL";


            FieldStyle classUnderTest = FieldStyle.BOUND_DATE;
            string actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithSDKValueBOUND_NAMEThenFieldStyleWithAPIValueLABELIsReturned()
        {
            string expectedAPIValue = "LABEL";


            FieldStyle classUnderTest = FieldStyle.BOUND_NAME;
            string actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithSDKValueBOUND_TITLEThenFieldStyleWithAPIValueLABELIsReturned()
        {
            string expectedAPIValue = "LABEL";


            FieldStyle classUnderTest = FieldStyle.BOUND_TITLE;
            string actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithSDKValueBOUND_COMPANYThenFieldStyleWithAPIValueLABELIsReturned()
        {
            string expectedAPIValue = "LABEL";


            FieldStyle classUnderTest = FieldStyle.BOUND_COMPANY;
            string actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

       

        [Test]
        public void whenBuildingFieldStyleWithAPIValueQRCODEThenBOUND_QRCODEFieldStyleIsReturned()
        {
            string expectedSDKValue = "BOUND_QRCODE";


            FieldStyle classUnderTest = FieldStyle.valueOf("QRCODE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithAPIValueTEXTFIELDThenUNBOUND_TEXT_FIELDFieldStyleIsReturned()
        {
            string expectedSDKValue = "UNBOUND_TEXT_FIELD";


            FieldStyle classUnderTest = FieldStyle.valueOf("TEXTFIELD");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithAPIValueCUSTOMFIELDThenUNBOUND_CUSTOM_FIELDFieldStyleIsReturned()
        {
            string expectedSDKValue = "UNBOUND_CUSTOM_FIELD";


            FieldStyle classUnderTest = FieldStyle.valueOf("CUSTOMFIELD");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithAPIValueCHECKBOXThenUNBOUND_CHECK_BOXFieldStyleIsReturned()
        {
            string expectedSDKValue = "UNBOUND_CHECK_BOX";


            FieldStyle classUnderTest = FieldStyle.valueOf("CHECKBOX");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithAPIValueRADIOThenUNBOUND_RADIO_BUTTONFieldStyleIsReturned()
        {
            string expectedSDKValue = "UNBOUND_RADIO_BUTTON";


            FieldStyle classUnderTest = FieldStyle.valueOf("RADIO");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithAPIValueTEXT_AREAThenTEXT_AREAFieldStyleIsReturned()
        {
            string expectedSDKValue = "TEXT_AREA";


            FieldStyle classUnderTest = FieldStyle.valueOf("TEXTAREA");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithAPIValueLISTThenDROP_LISTFieldStyleIsReturned()
        {
            string expectedSDKValue = "DROP_LIST";


            FieldStyle classUnderTest = FieldStyle.valueOf("LIST");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithAPIValueSEALThenSEALFieldStyleIsReturned()
        {
            string expectedSDKValue = "SEAL";


            FieldStyle classUnderTest = FieldStyle.valueOf("SEAL");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingFieldStyleWithUnknownAPIValueThenUNRECOGNIZEDFieldStyleIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            FieldStyle classUnderTest = FieldStyle.valueOf("ThisFieldStyleDoesNotExistInSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}

