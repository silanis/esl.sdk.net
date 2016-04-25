using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class CeremonyLayoutSettingsConverterTest
    {
		private Silanis.ESL.SDK.CeremonyLayoutSettings sdkCeremonyLayoutSettings1 = null;
        private Silanis.ESL.SDK.CeremonyLayoutSettings sdkCeremonyLayoutSettings2 = null;
		private Silanis.ESL.API.LayoutOptions apiLayoutOptions1 = null;
		private Silanis.ESL.API.LayoutOptions apiLayoutOptions2 = null;
		private Silanis.ESL.SDK.CeremonyLayoutSettingsConverter converter = null;

		[Test()]
		public void ConvertNullSDKToAPI()
		{
			sdkCeremonyLayoutSettings1 = null;
			converter = new CeremonyLayoutSettingsConverter(sdkCeremonyLayoutSettings1);

			Assert.IsNull(converter.ToAPILayoutOptions());
		}

        [Test()]
        public void ConvertNullAPIToSDK()
        {
            apiLayoutOptions1 = null;
            converter = new CeremonyLayoutSettingsConverter(apiLayoutOptions1);

            Assert.IsNull(converter.ToSDKCeremonyLayoutSettings());
        }

        [Test()]
        public void ConvertNullSDKToSDK()
        {
            sdkCeremonyLayoutSettings1 = null;
            converter = new CeremonyLayoutSettingsConverter(sdkCeremonyLayoutSettings1);

            Assert.IsNull(converter.ToSDKCeremonyLayoutSettings());
        }

		[Test()]
		public void ConvertNullAPIToAPI()
		{
			apiLayoutOptions1 = null;
			converter = new CeremonyLayoutSettingsConverter(apiLayoutOptions1);

			Assert.IsNull(converter.ToAPILayoutOptions());
		}

        [Test()]
        public void ConvertSDKToSDK()
        {
            sdkCeremonyLayoutSettings1 = CreateTypicalSDKCeremonyLayoutSettings();
            sdkCeremonyLayoutSettings2 = new CeremonyLayoutSettingsConverter(sdkCeremonyLayoutSettings1).ToSDKCeremonyLayoutSettings();

            Assert.IsNotNull(sdkCeremonyLayoutSettings2);
            Assert.AreEqual(sdkCeremonyLayoutSettings2, sdkCeremonyLayoutSettings1);
        }

		[Test()]
		public void ConvertAPIToAPI()
		{
			apiLayoutOptions1 = CreateTypicalAPICeremonyLayoutSettings();
			converter = new CeremonyLayoutSettingsConverter(apiLayoutOptions1);
			apiLayoutOptions2 = converter.ToAPILayoutOptions();

			Assert.IsNotNull(apiLayoutOptions2);
			Assert.AreEqual(apiLayoutOptions2, apiLayoutOptions1);
		}

        [Test()]
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

		[Test()]
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

		private Silanis.ESL.SDK.CeremonyLayoutSettings CreateTypicalSDKCeremonyLayoutSettings()
		{
			Silanis.ESL.SDK.CeremonyLayoutSettings settings = new Silanis.ESL.SDK.CeremonyLayoutSettings();
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

		private Silanis.ESL.API.LayoutOptions CreateTypicalAPICeremonyLayoutSettings()
		{
			Silanis.ESL.API.LayoutOptions layoutOptions = new Silanis.ESL.API.LayoutOptions();
            layoutOptions.BrandingBar = null;
            layoutOptions.Iframe = false;
            layoutOptions.Navigator = true;
            layoutOptions.Footer = null;
            layoutOptions.Header = new Silanis.ESL.API.HeaderOptions();
            layoutOptions.Header.TitleBar = new Silanis.ESL.API.TitleBarOptions();
            layoutOptions.Header.TitleBar.ProgressBar = true;
            layoutOptions.Header.TitleBar.Title = true;
            layoutOptions.Header.Breadcrumbs = true;
            layoutOptions.Header.GlobalActions = new Silanis.ESL.API.GlobalActionsOptions();
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

