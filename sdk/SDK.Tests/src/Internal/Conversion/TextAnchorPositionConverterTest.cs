using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.src.Internal.Conversion;

namespace SDK.Tests
{
    [TestClass]
    public class TextAnchorPositionConverterTest
    {
        private TextAnchorPosition sdkTextAnchorPosition1;
        private string apiTextAnchorPosition1;

        [TestMethod]
        public void ConvertAPITOPLEFTToTOPLEFTTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "TOPLEFT";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(apiTextAnchorPosition1, sdkTextAnchorPosition1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPITOPRIGHTToTOPRIGHTTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "TOPRIGHT";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(apiTextAnchorPosition1, sdkTextAnchorPosition1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIBOTTOMLEFTToBOTTOMLEFTTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "BOTTOMLEFT";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(apiTextAnchorPosition1, sdkTextAnchorPosition1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIBOTTOMRIGHTToBOTTOMRIGHTTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "BOTTOMRIGHT";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(apiTextAnchorPosition1, sdkTextAnchorPosition1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIUnknonwnValueToUnrecognizedTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "NEWLY_ADDED_TEXT ANCHOR POSITION";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(sdkTextAnchorPosition1.getApiValue(), apiTextAnchorPosition1);
        }

        [TestMethod]
        public void ConvertSDKTOPLEFTToAPITOPLEFTT()
        {
            sdkTextAnchorPosition1 = TextAnchorPosition.TOPLEFT;
            apiTextAnchorPosition1 = new TextAnchorPositionConverter(sdkTextAnchorPosition1).ToAPIAnchorPoint();

            Assert.AreEqual("TOPLEFT", apiTextAnchorPosition1);
        }

        [TestMethod]
        public void ConvertSDKTOPRIGHTToAPITOPRIGHT()
        {
            sdkTextAnchorPosition1 = TextAnchorPosition.TOPRIGHT;
            apiTextAnchorPosition1 = new TextAnchorPositionConverter(sdkTextAnchorPosition1).ToAPIAnchorPoint();

            Assert.AreEqual("TOPRIGHT", apiTextAnchorPosition1);
        }

        [TestMethod]
        public void ConvertSDKBOTTOMLEFTToAPIBOTTOMLEFT()
        {
            sdkTextAnchorPosition1 = TextAnchorPosition.BOTTOMLEFT;
            apiTextAnchorPosition1 = new TextAnchorPositionConverter(sdkTextAnchorPosition1).ToAPIAnchorPoint();

            Assert.AreEqual("BOTTOMLEFT", apiTextAnchorPosition1);
        }

        [TestMethod]
        public void ConvertSDKBOTTOMRIGHTToAPIBOTTOMRIGHT()
        {
            sdkTextAnchorPosition1 = TextAnchorPosition.BOTTOMRIGHT;
            apiTextAnchorPosition1 = new TextAnchorPositionConverter(sdkTextAnchorPosition1).ToAPIAnchorPoint();

            Assert.AreEqual("BOTTOMRIGHT", apiTextAnchorPosition1);
        }

        [TestMethod]
        public void ConvertSDKUnrecognizedTextAnchorPositionToAPIUnknownValue()
        {
            apiTextAnchorPosition1 = "NEWLY_ADDED_TEXT ANCHOR POSITION";
            var unrecognizedTextAnchorPosition = TextAnchorPosition.valueOf(apiTextAnchorPosition1);
            var acutalApiScheme = new TextAnchorPositionConverter(unrecognizedTextAnchorPosition).ToAPIAnchorPoint();

            Assert.AreEqual(apiTextAnchorPosition1, acutalApiScheme);
        }

    }
}

