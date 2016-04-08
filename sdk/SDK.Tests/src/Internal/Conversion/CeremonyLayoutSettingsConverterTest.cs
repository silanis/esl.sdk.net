using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.API;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class CeremonyLayoutSettingsConverterTest
    {
		private CeremonyLayoutSettings sdkCeremonyLayoutSettings1;
        private CeremonyLayoutSettings sdkCeremonyLayoutSettings2;
		private LayoutOptions apiLayoutOptions1;
		private LayoutOptions apiLayoutOptions2;
		private CeremonyLayoutSettingsConverter converter;

		[TestMethod]
		public void ConvertNullSDKToAPI()
		{
			sdkCeremonyLayoutSettings1 = null;
			converter = new CeremonyLayoutSettingsConverter(sdkCeremonyLayoutSettings1);

			Assert.IsNull(converter.ToAPILayoutOptions());
		}

        [TestMethod]
        public void ConvertNullAPIToSDK()
        {
            apiLayoutOptions1 = null;
            converter = new CeremonyLayoutSettingsConverter(apiLayoutOptions1);

            Assert.IsNull(converter.ToSDKCeremonyLayoutSettings());
        }

        [TestMethod]
        public void ConvertNullSDKToSDK()
        {
            sdkCeremonyLayoutSettings1 = null;
            converter = new CeremonyLayoutSettingsConverter(sdkCeremonyLayoutSettings1);

            Assert.IsNull(converter.ToSDKCeremonyLayoutSettings());
        }

		[TestMethod]
		public void ConvertNullAPIToAPI()
		{
			apiLayoutOptions1 = null;
			converter = new CeremonyLayoutSettingsConverter(apiLayoutOptions1);

			Assert.IsNull(converter.ToAPILayoutOptions());
		}

        [TestMethod]
        public void ConvertSDKToSDK()
        {
            sdkCeremonyLayoutSettings1 = CreateTypicalSDKCeremonyLayoutSettings();
            sdkCeremonyLayoutSettings2 = new CeremonyLayoutSettingsConverter(sdkCeremonyLayoutSettings1).ToSDKCeremonyLayoutSettings();

            Assert.IsNotNull(sdkCeremonyLayoutSettings2);
            Assert.AreEqual(sdkCeremonyLayoutSettings2, sdkCeremonyLayoutSettings1);
        }

		[TestMethod]
		public void ConvertAPIToAPI()
		{
			apiLayoutOptions1 = CreateTypicalAPICeremonyLayoutSettings();
			converter = new CeremonyLayoutSettingsConverter(apiLayoutOptions1);
			apiLayoutOptions2 = converter.ToAPILayoutOptions();

			Assert.IsNotNull(apiLayoutOptions2);
			Assert.AreEqual(apiLayoutOptions2, apiLayoutOptions1);
		}

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            apiLayoutOptions1 = CreateTypicalAPICeremonyLayoutSettings();
            sdkCeremonyLayoutSettings1 = new CeremonyLayoutSettingsConverter(apiLayoutOptions1).ToSDKCeremonyLayoutSettings();

            Assert.IsNotNull(sdkCeremonyLayoutSettings1);
            Assert.IsNull(sdkCeremonyLayoutSettings1.LogoImageLink);
            Assert.IsNull(sdkCeremonyLayoutSettings1.LogoImageSource);
            Assert.AreEqual(sdkCeremonyLayoutSettings1.IFrame, apiLayoutOptions1.Iframe);
            Assert.AreEqual(sdkCeremonyLayoutSettings1.ShowTitle, apiLayoutOptions1.Header.TitleBar.Title);
            Assert.AreEqual(sdkCeremonyLayoutSettings1.SessionBar, apiLayoutOptions1.Header.SessionBar);
            Assert.AreEqual(sdkCeremonyLayoutSettings1.ProgressBar, apiLayoutOptions1.Header.TitleBar.ProgressBar);
            Assert.AreEqual(sdkCeremonyLayoutSettings1.BreadCrumbs, apiLayoutOptions1.Header.Breadcrumbs);
            Assert.AreEqual(sdkCeremonyLayoutSettings1.GlobalNavigation, apiLayoutOptions1.Header.GlobalNavigation);
            Assert.AreEqual(sdkCeremonyLayoutSettings1.ShowGlobalConfirmButton, apiLayoutOptions1.Header.GlobalActions.Confirm);
            Assert.AreEqual(sdkCeremonyLayoutSettings1.ShowGlobalDownloadButton, apiLayoutOptions1.Header.GlobalActions.Download);
            Assert.AreEqual(sdkCeremonyLayoutSettings1.ShowGlobalSaveAsLayoutButton, apiLayoutOptions1.Header.GlobalActions.SaveAsLayout);
        }

		[TestMethod]
		public void ConvertSDKToAPI()
		{
			sdkCeremonyLayoutSettings1 = CreateTypicalSDKCeremonyLayoutSettings();
			apiLayoutOptions1 = new CeremonyLayoutSettingsConverter(sdkCeremonyLayoutSettings1).ToAPILayoutOptions();

			Assert.IsNotNull(apiLayoutOptions1);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.LogoImageLink, apiLayoutOptions1.BrandingBar.Logo.Link);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.LogoImageSource, apiLayoutOptions1.BrandingBar.Logo.Src);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.IFrame, apiLayoutOptions1.Iframe);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.ShowTitle, apiLayoutOptions1.Header.TitleBar.Title);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.SessionBar, apiLayoutOptions1.Header.SessionBar);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.ProgressBar, apiLayoutOptions1.Header.TitleBar.ProgressBar);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.BreadCrumbs, apiLayoutOptions1.Header.Breadcrumbs);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.GlobalNavigation, apiLayoutOptions1.Header.GlobalNavigation);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.ShowGlobalConfirmButton, apiLayoutOptions1.Header.GlobalActions.Confirm);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.ShowGlobalDownloadButton, apiLayoutOptions1.Header.GlobalActions.Download);
			Assert.AreEqual(sdkCeremonyLayoutSettings1.ShowGlobalSaveAsLayoutButton, apiLayoutOptions1.Header.GlobalActions.SaveAsLayout);
		}

		private CeremonyLayoutSettings CreateTypicalSDKCeremonyLayoutSettings()
		{
			var settings = new CeremonyLayoutSettings();
			settings.LogoImageLink = "logoImageLink";
			settings.LogoImageSource = "logoImageSource";
			settings.IFrame = true;
			settings.ShowTitle = true;
			settings.SessionBar = true;
			settings.ProgressBar = true;
			settings.BreadCrumbs = true;
			settings.GlobalNavigation = true;
			settings.ShowGlobalConfirmButton = true;
			settings.ShowGlobalDownloadButton = true;
			settings.ShowGlobalSaveAsLayoutButton = true;

			return settings;
		}

		private LayoutOptions CreateTypicalAPICeremonyLayoutSettings()
		{
			var layoutOptions = new LayoutOptions();
            layoutOptions.BrandingBar = null;
            layoutOptions.Iframe = false;
            layoutOptions.Navigator = true;
            layoutOptions.Footer = null;
            layoutOptions.Header = new HeaderOptions();
            layoutOptions.Header.TitleBar = new TitleBarOptions();
            layoutOptions.Header.TitleBar.ProgressBar = true;
            layoutOptions.Header.TitleBar.Title = true;
            layoutOptions.Header.Breadcrumbs = true;
            layoutOptions.Header.GlobalActions = new GlobalActionsOptions();
            layoutOptions.Header.GlobalActions.Confirm = true;
            layoutOptions.Header.GlobalActions.Download = true;
            layoutOptions.Header.GlobalActions.SaveAsLayout = true;
            layoutOptions.Header.GlobalNavigation = true;
            layoutOptions.Header.SessionBar = true;
            layoutOptions.Header.Feedback = true;

			return layoutOptions;
		}
    }
}

