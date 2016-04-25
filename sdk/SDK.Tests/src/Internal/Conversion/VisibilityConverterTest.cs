using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class VisibilityConverterTest
    {
        private Silanis.ESL.SDK.Visibility sdkVisibility1, sdkVisibility2, sdkVisibility3;
        private string apiVisibility1, apiVisibility2, apiVisibility3;

        [Test]
        public void ConvertAPIToSDK()
        {
            apiVisibility1 = "ACCOUNT";
            sdkVisibility1 = new VisibilityConverter(apiVisibility1).ToSDKVisibility();
            Assert.AreEqual(sdkVisibility1.getApiValue(), apiVisibility1);

            apiVisibility2 = "SENDER";
            sdkVisibility2 = new VisibilityConverter(apiVisibility2).ToSDKVisibility();
            Assert.AreEqual(sdkVisibility2.getApiValue(), apiVisibility2);

            apiVisibility3 = "NEWLY_ADDED_TYPE";
            sdkVisibility3 = new VisibilityConverter(apiVisibility3).ToSDKVisibility();
            Assert.AreEqual(sdkVisibility3.getApiValue(), apiVisibility3);
        }

        [Test]
        public void ConvertSDKToAPI()
        {
            sdkVisibility1 = Silanis.ESL.SDK.Visibility.ACCOUNT;
            apiVisibility1 = new VisibilityConverter(sdkVisibility1).ToAPIVisibility();
            Assert.AreEqual("ACCOUNT", apiVisibility1);

            sdkVisibility2 = Silanis.ESL.SDK.Visibility.SENDER;
            apiVisibility2 = new VisibilityConverter(sdkVisibility2).ToAPIVisibility();
            Assert.AreEqual("SENDER", apiVisibility2);

            sdkVisibility3 = Silanis.ESL.SDK.Visibility.valueOf("NEWLY_ADDED_TYPE");
            apiVisibility3 = new VisibilityConverter(sdkVisibility3).ToAPIVisibility();
            Assert.AreEqual("NEWLY_ADDED_TYPE", apiVisibility3);
        }
    }
}

