using System;
using Silanis.ESL.API;

namespace Silanis.ESL.SDK
{
	internal class CeremonyLayoutSettingsConverter
    {
		private Silanis.ESL.SDK.CeremonyLayoutSettings sdkCeremonyLayoutSettings = null;
		private Silanis.ESL.API.LayoutOptions apiLayoutOptions = null;

		public CeremonyLayoutSettingsConverter(Silanis.ESL.SDK.CeremonyLayoutSettings sdkCeremonyLayoutSettings)
        {
			this.sdkCeremonyLayoutSettings = sdkCeremonyLayoutSettings;
        }

		public CeremonyLayoutSettingsConverter(Silanis.ESL.API.LayoutOptions apiLayoutOptions)
		{
			this.apiLayoutOptions = apiLayoutOptions;
		}

		public Silanis.ESL.API.LayoutOptions ToAPILayoutOptions()
		{
			if (sdkCeremonyLayoutSettings == null)
			{
				return apiLayoutOptions;
			}

			var titleBarOptions = new TitleBarOptions();
			if (sdkCeremonyLayoutSettings.ShowTitle != null) {
				titleBarOptions.Title = sdkCeremonyLayoutSettings.ShowTitle.Value;
			}
			if (sdkCeremonyLayoutSettings.ProgressBar != null) {
				titleBarOptions.ProgressBar = sdkCeremonyLayoutSettings.ProgressBar.Value;
			}

			var headerOptions = new HeaderOptions();
			if (sdkCeremonyLayoutSettings.BreadCrumbs != null) {
				headerOptions.Breadcrumbs = sdkCeremonyLayoutSettings.BreadCrumbs.Value;
			}
			if (sdkCeremonyLayoutSettings.SessionBar != null) {
				headerOptions.SessionBar = sdkCeremonyLayoutSettings.SessionBar.Value;
			}
			if (sdkCeremonyLayoutSettings.GlobalNavigation != null) {
				headerOptions.GlobalNavigation = sdkCeremonyLayoutSettings.GlobalNavigation.Value;
			}
			if (titleBarOptions != null) {
				headerOptions.TitleBar = titleBarOptions;
			}
			var globalActionsOptions = new GlobalActionsOptions();

			if (sdkCeremonyLayoutSettings.ShowGlobalConfirmButton != null)
			{
				globalActionsOptions.Confirm = sdkCeremonyLayoutSettings.ShowGlobalConfirmButton.Value;
			}
			if (sdkCeremonyLayoutSettings.ShowGlobalDownloadButton != null)
			{
				globalActionsOptions.Download = sdkCeremonyLayoutSettings.ShowGlobalDownloadButton.Value;
			}
			if (sdkCeremonyLayoutSettings.ShowGlobalSaveAsLayoutButton != null)
			{
				globalActionsOptions.SaveAsLayout = sdkCeremonyLayoutSettings.ShowGlobalSaveAsLayoutButton.Value;
			}
			headerOptions.GlobalActions = globalActionsOptions;

			BrandingBarOptions brandingBarOptions = null;
			if ( sdkCeremonyLayoutSettings.LogoImageLink != null || sdkCeremonyLayoutSettings.LogoImageSource != null ) {
				brandingBarOptions = new BrandingBarOptions();
				var logo = new Image();
				logo.Link = sdkCeremonyLayoutSettings.LogoImageLink;
				logo.Src = sdkCeremonyLayoutSettings.LogoImageSource;
				brandingBarOptions.Logo = logo;
			}

			var result = new LayoutOptions();
			if (sdkCeremonyLayoutSettings.IFrame != null) {
				result.Iframe = sdkCeremonyLayoutSettings.IFrame.Value;
			}
			if (sdkCeremonyLayoutSettings.Navigator != null) {
				result.Navigator = sdkCeremonyLayoutSettings.Navigator.Value;
			}
			result.Footer = new FooterOptions();
			result.Header = headerOptions;
			result.BrandingBar = brandingBarOptions;

			return result;
		}

        public Silanis.ESL.SDK.CeremonyLayoutSettings ToSDKCeremonyLayoutSettings()
        {
            if (apiLayoutOptions == null)
            {
                return sdkCeremonyLayoutSettings;
            }

            var result = new CeremonyLayoutSettings();

            result.IFrame = apiLayoutOptions.Iframe;

            if (apiLayoutOptions.Header != null)
            {
                result.BreadCrumbs = apiLayoutOptions.Header.Breadcrumbs;
                result.SessionBar = apiLayoutOptions.Header.SessionBar;
                result.GlobalNavigation = apiLayoutOptions.Header.GlobalNavigation;

                if (apiLayoutOptions.Header.GlobalActions != null)
                {
                    result.ShowGlobalConfirmButton = apiLayoutOptions.Header.GlobalActions.Confirm;
                    result.ShowGlobalDownloadButton = apiLayoutOptions.Header.GlobalActions.Download;
                    result.ShowGlobalSaveAsLayoutButton = apiLayoutOptions.Header.GlobalActions.SaveAsLayout;
                }

                if (apiLayoutOptions.Header.TitleBar != null)
                {
                    result.ShowTitle = apiLayoutOptions.Header.TitleBar.Title;
                    result.ProgressBar = apiLayoutOptions.Header.TitleBar.ProgressBar;
                }
            }

            result.Navigator = apiLayoutOptions.Navigator;

            if (apiLayoutOptions.BrandingBar != null && apiLayoutOptions.BrandingBar.Logo != null)
            {
                result.LogoImageLink = apiLayoutOptions.BrandingBar.Logo.Link;
                result.LogoImageSource = apiLayoutOptions.BrandingBar.Logo.Src;
            }

            return result;
        }
    }
}

