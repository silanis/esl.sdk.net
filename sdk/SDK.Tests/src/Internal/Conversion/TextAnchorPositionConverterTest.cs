using NUnit.Framework;
using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.src.Internal.Conversion;

namespace SDK.Tests
{
    [TestFixture()]
    public class TextAnchorPositionConverterTest
    {
        private Silanis.ESL.SDK.TextAnchorPosition sdkTextAnchorPosition1;
        private string apiTextAnchorPosition1;

        [Test]
        public void ConvertAPITOPLEFTToTOPLEFTTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "TOPLEFT";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(apiTextAnchorPosition1, sdkTextAnchorPosition1.getApiValue());
        }

        [Test]
        public void ConvertAPITOPRIGHTToTOPRIGHTTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "TOPRIGHT";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(apiTextAnchorPosition1, sdkTextAnchorPosition1.getApiValue());
        }

        [Test]
        public void ConvertAPIBOTTOMLEFTToBOTTOMLEFTTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "BOTTOMLEFT";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(apiTextAnchorPosition1, sdkTextAnchorPosition1.getApiValue());
        }

        [Test]
        public void ConvertAPIBOTTOMRIGHTToBOTTOMRIGHTTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "BOTTOMRIGHT";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(apiTextAnchorPosition1, sdkTextAnchorPosition1.getApiValue());
        }

        [Test]
        public void ConvertAPIUnknonwnValueToUnrecognizedTextAnchorPosition()
        {
            apiTextAnchorPosition1 = "NEWLY_ADDED_TEXT ANCHOR POSITION";
            sdkTextAnchorPosition1 = new TextAnchorPositionConverter(apiTextAnchorPosition1).ToSDKTextAnchorPosition();

            Assert.AreEqual(sdkTextAnchorPosition1.getApiValue(), apiTextAnchorPosition1);
        }

        [Test]
        public void ConvertSDKTOPLEFTToAPITOPLEFTT()
        {
            sdkTextAnchorPosition1 = Silanis.ESL.SDK.TextAnchorPosition.TOPLEFT;
            apiTextAnchorPosition1 = new TextAnchorPositionConverter(sdkTextAnchorPosition1).ToAPIAnchorPoint();

            Assert.AreEqual("TOPLEFT", apiTextAnchorPosition1);
        }

        [Test]
        public void ConvertSDKTOPRIGHTToAPITOPRIGHT()
        {
            sdkTextAnchorPosition1 = Silanis.ESL.SDK.TextAnchorPosition.TOPRIGHT;
            apiTextAnchorPosition1 = new TextAnchorPositionConverter(sdkTextAnchorPosition1).ToAPIAnchorPoint();

            Assert.AreEqual("TOPRIGHT", apiTextAnchorPosition1);
        }

        [Test]
        public void ConvertSDKBOTTOMLEFTToAPIBOTTOMLEFT()
        {
            sdkTextAnchorPosition1 = Silanis.ESL.SDK.TextAnchorPosition.BOTTOMLEFT;
            apiTextAnchorPosition1 = new TextAnchorPositionConverter(sdkTextAnchorPosition1).ToAPIAnchorPoint();

            Assert.AreEqual("BOTTOMLEFT", apiTextAnchorPosition1);
        }

        [Test]
        public void ConvertSDKBOTTOMRIGHTToAPIBOTTOMRIGHT()
        {
            sdkTextAnchorPosition1 = Silanis.ESL.SDK.TextAnchorPosition.BOTTOMRIGHT;
            apiTextAnchorPosition1 = new TextAnchorPositionConverter(sdkTextAnchorPosition1).ToAPIAnchorPoint();

            Assert.AreEqual("BOTTOMRIGHT", apiTextAnchorPosition1);
        }

        [Test]
        public void ConvertSDKUnrecognizedTextAnchorPositionToAPIUnknownValue()
        {
            apiTextAnchorPosition1 = "NEWLY_ADDED_TEXT ANCHOR POSITION";
            TextAnchorPosition unrecognizedTextAnchorPosition = TextAnchorPosition.valueOf(apiTextAnchorPosition1);
            string acutalApiScheme = new TextAnchorPositionConverter(unrecognizedTextAnchorPosition).ToAPIAnchorPoint();

            Assert.AreEqual(apiTextAnchorPosition1, acutalApiScheme);
        }

    }
}

