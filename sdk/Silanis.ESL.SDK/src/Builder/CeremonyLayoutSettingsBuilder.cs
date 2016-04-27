using System;

namespace Silanis.ESL.SDK
{
	public class CeremonyLayoutSettingsBuilder
	{
		private Nullable<bool> iFrame = null;
		private Nullable<bool> breadCrumbs = null;
		private Nullable<bool> sessionBar = null;
		private Nullable<bool> globalNavigation = null;
		private Nullable<bool> progressBar = null;
		private Nullable<bool> showTitle = null;
		private Nullable<bool> navigator = null;
        private Nullable<bool> showGlobalDownloadButton = null;
        private Nullable<bool> showGlobalSaveAsLayoutButton = null;
        private Nullable<bool> showGlobalConfirmButton = null;

		private string logoImageSource = null;
		private string logoImageLink = null;

        public CeremonyLayoutSettingsBuilder WithGlobalDownloadButton()
        {
            showGlobalDownloadButton = true;
            return this;
        }

        public CeremonyLayoutSettingsBuilder WithoutGlobalDownloadButton()
        {
            showGlobalDownloadButton = false;
            return this;
        }

        public CeremonyLayoutSettingsBuilder WithGlobalSaveAsLayoutButton()
        {
            showGlobalSaveAsLayoutButton = true;
            return this;
        }

        public CeremonyLayoutSettingsBuilder WithoutGlobalSaveAsLayoutButton()
        {
            showGlobalSaveAsLayoutButton = false;
            return this;
        }

        public CeremonyLayoutSettingsBuilder WithGlobalConfirmButton()
        {
            showGlobalConfirmButton = true;
            return this;
        }

        public CeremonyLayoutSettingsBuilder WithoutGlobalConfirmButton()
        {
            showGlobalConfirmButton = false;
            return this;
        }

		public CeremonyLayoutSettingsBuilder WithIFrame()
		{
			iFrame = true;
			return this;
		}

        public CeremonyLayoutSettingsBuilder WithoutIFrame()
        {
            iFrame = false;
            return this;
        }

        public CeremonyLayoutSettingsBuilder WithBreadCrumbs()
        {
            breadCrumbs = true;
            return this;
        }

		public CeremonyLayoutSettingsBuilder WithoutBreadCrumbs()
		{
			breadCrumbs = false;
			return this;
		}

        public CeremonyLayoutSettingsBuilder WithSessionBar()
        {
            sessionBar = true;
            return this;
        }

		public CeremonyLayoutSettingsBuilder WithoutSessionBar()
		{
			sessionBar = false;
			return this;
		}

        public CeremonyLayoutSettingsBuilder WithGlobalNavigation()
        {
            globalNavigation = true;
            return this;
        }

		public CeremonyLayoutSettingsBuilder WithoutGlobalNavigation()
		{
			globalNavigation = false;
			return this;
		}

        public CeremonyLayoutSettingsBuilder WithProgressBar()
        {
            progressBar = true;
            return this;
        }

		public CeremonyLayoutSettingsBuilder WithoutProgressBar()
		{
			progressBar = false;
			return this;
		}

        public CeremonyLayoutSettingsBuilder WithTitle()
        {
            showTitle = true;
            return this;
        }

		public CeremonyLayoutSettingsBuilder WithoutTitle()
		{
			showTitle = false;
			return this;
		}

        public CeremonyLayoutSettingsBuilder WithNavigator()
        {
            navigator = true;
            return this;
        }

		public CeremonyLayoutSettingsBuilder WithoutNavigator()
		{
			navigator = false;
			return this;
		}

		public CeremonyLayoutSettingsBuilder WithLogoImageSource( String logoImageSource )
		{
			this.logoImageSource = logoImageSource;
			return this;
		}

		public CeremonyLayoutSettingsBuilder WithLogoImageLink( String logoImageLink )
		{
			this.logoImageLink = logoImageLink;
			return this;
		}

		public static CeremonyLayoutSettingsBuilder NewCeremonyLayoutSettings()
		{
			return new CeremonyLayoutSettingsBuilder ();
		}

		private CeremonyLayoutSettingsBuilder ()
		{
		}

		public CeremonyLayoutSettings Build()
		{
			var result = new CeremonyLayoutSettings ();
			result.IFrame = iFrame;
			result.BreadCrumbs = breadCrumbs;
			result.SessionBar = sessionBar;
			result.GlobalNavigation = globalNavigation;
			result.ProgressBar = progressBar;
			result.ShowTitle = showTitle;
			result.Navigator = navigator;
            result.ShowGlobalConfirmButton = showGlobalConfirmButton;
            result.ShowGlobalDownloadButton = showGlobalDownloadButton;
            result.ShowGlobalSaveAsLayoutButton = showGlobalSaveAsLayoutButton;
			result.LogoImageSource = logoImageSource;
			result.LogoImageLink = logoImageLink;

			return result;
		}
	}
}

