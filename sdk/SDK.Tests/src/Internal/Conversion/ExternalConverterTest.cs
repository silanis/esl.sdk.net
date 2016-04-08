using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class ExternalConverterTest
    {

        private External sdkExternal1;
        private External sdkExternal2;
        private Silanis.ESL.API.External apiExternal1;
        private Silanis.ESL.API.External apiExternal2;
        private ExternalConverter converter;

        [TestMethod]
        public void ConvertNullSDKToAPI()
        {
            sdkExternal1 = null;
            converter = new ExternalConverter(sdkExternal1);
            Assert.IsNull(converter.ToAPIExternal());
        }

        [TestMethod]
        public void ConvertNullAPIToSDK()
        {
            apiExternal1 = null;
            converter = new ExternalConverter(apiExternal1);
            Assert.IsNull(converter.ToSDKExternal());
        }

        [TestMethod]
        public void ConvertNullSDKToSDK()
        {
            sdkExternal1 = null;
            converter = new ExternalConverter(sdkExternal1);
            Assert.IsNull(converter.ToSDKExternal());
        }

        [TestMethod]
        public void ConvertNullAPIToAPI()
        {
            apiExternal1 = null;
            converter = new ExternalConverter(apiExternal1);
            Assert.IsNull(converter.ToAPIExternal());
        }

        [TestMethod]
        public void ConvertSDKToSDK()
        {
            sdkExternal1 = CreateTypicalSDKExternal();
            converter = new ExternalConverter(sdkExternal1);
            sdkExternal2 = converter.ToSDKExternal();
            Assert.IsNotNull(sdkExternal2);
            Assert.AreEqual(sdkExternal2, sdkExternal1);
        }

        [TestMethod]
        public void ConvertAPIToAPI()
        {
            apiExternal1 = CreateTypicalAPIExternal();
            converter = new ExternalConverter(apiExternal1);
            apiExternal2 = converter.ToAPIExternal();
            Assert.IsNotNull(apiExternal2);
            Assert.AreEqual(apiExternal2, apiExternal1);
        }

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            apiExternal1 = CreateTypicalAPIExternal();
            sdkExternal1 = new ExternalConverter(apiExternal1).ToSDKExternal();

            Assert.IsNotNull(sdkExternal1);
            Assert.AreEqual(apiExternal1.Provider, sdkExternal1.Provider);
            Assert.AreEqual(apiExternal1.ProviderName, sdkExternal1.ProviderName);
            Assert.AreEqual(apiExternal1.Id, sdkExternal1.Id);
        }

        [TestMethod]
        public void ConvertSDKToAPI()
        {
            sdkExternal1 = CreateTypicalSDKExternal();
            apiExternal1 = new ExternalConverter(sdkExternal1).ToAPIExternal();

            Assert.IsNotNull(apiExternal1);
            Assert.AreEqual(sdkExternal1.Provider, apiExternal1.Provider);
            Assert.AreEqual(sdkExternal1.ProviderName, apiExternal1.ProviderName);
            Assert.AreEqual(sdkExternal1.Id, apiExternal1.Id);
        }

        private External CreateTypicalSDKExternal()
        {
            var sdkExternal = new External();
            sdkExternal.Id = "sdkExternalId";
            sdkExternal.Provider = "sdkExternalProvider";
            sdkExternal.ProviderName = "sdkExternalProviderName";

            return sdkExternal;
        }

        private Silanis.ESL.API.External CreateTypicalAPIExternal()
        {
            var apiExternal = new Silanis.ESL.API.External();

            apiExternal.Id = "apiExternalId";
            apiExternal.Provider = "apiExternalProvider";
            apiExternal.ProviderName = "apiExternalProviderName";

            return apiExternal;
        }
    }
}

