using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class FieldStyleTest
    {
        [TestMethod]
        public void WhenBuildingFieldStyleWithApiValueLabelThenLabelFieldStyleIsReturned()
        {
            var expectedSDKValue = "LABEL";


            var classUnderTest = FieldStyle.valueOf("LABEL");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithSDKValueBOUND_DATEThenFieldStyleWithAPIValueLABELIsReturned()
        {
            var expectedAPIValue = "LABEL";


            var classUnderTest = FieldStyle.BOUND_DATE;
            var actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithSDKValueBOUND_NAMEThenFieldStyleWithAPIValueLABELIsReturned()
        {
            var expectedAPIValue = "LABEL";


            var classUnderTest = FieldStyle.BOUND_NAME;
            var actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithSDKValueBOUND_TITLEThenFieldStyleWithAPIValueLABELIsReturned()
        {
            var expectedAPIValue = "LABEL";


            var classUnderTest = FieldStyle.BOUND_TITLE;
            var actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithSDKValueBOUND_COMPANYThenFieldStyleWithAPIValueLABELIsReturned()
        {
            var expectedAPIValue = "LABEL";


            var classUnderTest = FieldStyle.BOUND_COMPANY;
            var actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

       

        [TestMethod]
        public void whenBuildingFieldStyleWithAPIValueQRCODEThenBOUND_QRCODEFieldStyleIsReturned()
        {
            var expectedSDKValue = "BOUND_QRCODE";


            var classUnderTest = FieldStyle.valueOf("QRCODE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithAPIValueTEXTFIELDThenUNBOUND_TEXT_FIELDFieldStyleIsReturned()
        {
            var expectedSDKValue = "UNBOUND_TEXT_FIELD";


            var classUnderTest = FieldStyle.valueOf("TEXTFIELD");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithAPIValueCUSTOMFIELDThenUNBOUND_CUSTOM_FIELDFieldStyleIsReturned()
        {
            var expectedSDKValue = "UNBOUND_CUSTOM_FIELD";


            var classUnderTest = FieldStyle.valueOf("CUSTOMFIELD");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithAPIValueCHECKBOXThenUNBOUND_CHECK_BOXFieldStyleIsReturned()
        {
            var expectedSDKValue = "UNBOUND_CHECK_BOX";


            var classUnderTest = FieldStyle.valueOf("CHECKBOX");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithAPIValueRADIOThenUNBOUND_RADIO_BUTTONFieldStyleIsReturned()
        {
            var expectedSDKValue = "UNBOUND_RADIO_BUTTON";


            var classUnderTest = FieldStyle.valueOf("RADIO");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithAPIValueTEXT_AREAThenTEXT_AREAFieldStyleIsReturned()
        {
            var expectedSDKValue = "TEXT_AREA";


            var classUnderTest = FieldStyle.valueOf("TEXTAREA");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithAPIValueLISTThenDROP_LISTFieldStyleIsReturned()
        {
            var expectedSDKValue = "DROP_LIST";


            var classUnderTest = FieldStyle.valueOf("LIST");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithAPIValueSEALThenSEALFieldStyleIsReturned()
        {
            var expectedSDKValue = "SEAL";


            var classUnderTest = FieldStyle.valueOf("SEAL");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingFieldStyleWithUnknownAPIValueThenUNRECOGNIZEDFieldStyleIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = FieldStyle.valueOf("ThisFieldStyleDoesNotExistInSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}

