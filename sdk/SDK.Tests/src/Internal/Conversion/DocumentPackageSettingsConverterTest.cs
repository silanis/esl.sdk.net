using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestClass]
    public class DocumentPackageSettingsConverterTest
    {
        private DocumentPackageSettings _sdkPackageSettings1;
        private PackageSettings _apiPackageSettings1;
        private PackageSettings _apiPackageSettings2;
        private DocumentPackageSettingsConverter _converter;

        [TestMethod]
        public void ConvertNullSdktoApi()
        {
            _sdkPackageSettings1 = null;
            _converter = new DocumentPackageSettingsConverter(_sdkPackageSettings1);
            Assert.IsNull(_converter.toAPIPackageSettings());
        }

        [TestMethod]
        public void ConvertNullApitoApi()
        {
            _apiPackageSettings1 = null;
            _converter = new DocumentPackageSettingsConverter(_apiPackageSettings1);
            Assert.IsNull(_converter.toAPIPackageSettings());
        }

        [TestMethod]
        public void ConvertApitoApi()
        {
            _apiPackageSettings1 = CreateTypicalAPIPackageSettings();
            _converter = new DocumentPackageSettingsConverter(_apiPackageSettings1);
            _apiPackageSettings2 = _converter.toAPIPackageSettings();

            Assert.IsNotNull(_apiPackageSettings2);
            Assert.AreEqual(_apiPackageSettings2, _apiPackageSettings1);
        }

        [TestMethod]
        public void ConvertApitoSdk()
        {
            _apiPackageSettings1 = CreateTypicalAPIPackageSettings();
            _sdkPackageSettings1 = new DocumentPackageSettingsConverter(_apiPackageSettings1).toSDKDocumentPackageSettings();

            Assert.IsNotNull(_sdkPackageSettings1);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.InPerson, _sdkPackageSettings1.EnableInPerson);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DeclineButton, _sdkPackageSettings1.EnableDecline);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.OptOutButton, _sdkPackageSettings1.EnableOptOut);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DeclineReasons[0], _sdkPackageSettings1.DeclineReasons[0]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DeclineReasons[1], _sdkPackageSettings1.DeclineReasons[1]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DeclineReasons[2], _sdkPackageSettings1.DeclineReasons[2]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DisableDeclineOther, _sdkPackageSettings1.DisableDeclineOther);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.OptOutReasons[0], _sdkPackageSettings1.OptOutReasons[0]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.OptOutReasons[1], _sdkPackageSettings1.OptOutReasons[1]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.OptOutReasons[2], _sdkPackageSettings1.OptOutReasons[2]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DisableOptOutOther, _sdkPackageSettings1.DisableOptOutOther);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HandOver.Href, _sdkPackageSettings1.LinkHref);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HandOver.Text, _sdkPackageSettings1.LinkText);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HandOver.Title, _sdkPackageSettings1.LinkTooltip);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HideCaptureText, _sdkPackageSettings1.HideCaptureText);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HideWatermark, _sdkPackageSettings1.HideWatermark);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.MaxAuthFailsAllowed, _sdkPackageSettings1.MaxAuthAttempts);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.Download, _sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalDownloadButton);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.Confirm, _sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalConfirmButton);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.SaveAsLayout, _sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalSaveAsLayoutButton);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HideLanguageDropdown, !_sdkPackageSettings1.ShowLanguageDropDown);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HidePackageOwnerInPerson, !_sdkPackageSettings1.ShowOwnerInPersonDropDown);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DisableFirstInPersonAffidavit, !_sdkPackageSettings1.EnableFirstAffidavit);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DisableSecondInPersonAffidavit, !_sdkPackageSettings1.EnableSecondAffidavit);
        }

        [TestMethod]
        public void ConvertSdktoApi()
        {
            _sdkPackageSettings1 = CreateTypicalSdkDocumentPackageSettings();
            _apiPackageSettings1 = new DocumentPackageSettingsConverter(_sdkPackageSettings1).toAPIPackageSettings();

            Assert.IsNotNull(_apiPackageSettings1);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.InPerson, _sdkPackageSettings1.EnableInPerson);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DeclineButton, _sdkPackageSettings1.EnableDecline);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.OptOutButton, _sdkPackageSettings1.EnableOptOut);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DeclineReasons[0], _sdkPackageSettings1.DeclineReasons[0]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DeclineReasons[1], _sdkPackageSettings1.DeclineReasons[1]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DeclineReasons[2], _sdkPackageSettings1.DeclineReasons[2]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DisableDeclineOther, _sdkPackageSettings1.DisableDeclineOther);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.OptOutReasons[0], _sdkPackageSettings1.OptOutReasons[0]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.OptOutReasons[1], _sdkPackageSettings1.OptOutReasons[1]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.OptOutReasons[2], _sdkPackageSettings1.OptOutReasons[2]);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DisableOptOutOther, _sdkPackageSettings1.DisableOptOutOther);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HandOver.Href, _sdkPackageSettings1.LinkHref);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HandOver.Text, _sdkPackageSettings1.LinkText);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HandOver.Title, _sdkPackageSettings1.LinkTooltip);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HideCaptureText, _sdkPackageSettings1.HideCaptureText);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HideWatermark, _sdkPackageSettings1.HideWatermark);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.MaxAuthFailsAllowed, _sdkPackageSettings1.MaxAuthAttempts);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.Download, _sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalDownloadButton);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.Confirm, _sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalConfirmButton);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.SaveAsLayout, _sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalSaveAsLayoutButton);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HideLanguageDropdown, !_sdkPackageSettings1.ShowLanguageDropDown);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.HidePackageOwnerInPerson, !_sdkPackageSettings1.ShowOwnerInPersonDropDown);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DisableFirstInPersonAffidavit, !_sdkPackageSettings1.EnableFirstAffidavit);
            Assert.AreEqual(_apiPackageSettings1.Ceremony.DisableSecondInPersonAffidavit, !_sdkPackageSettings1.EnableSecondAffidavit);
        }

        private static DocumentPackageSettings CreateTypicalSdkDocumentPackageSettings()
        {
            var sdkDocumentPackageSettings = DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
                    .WithInPerson()
                    .WithoutDecline()
                    .WithOptOut()
                    .WithoutWatermark()
                    .WithoutCaptureText()
                    .DisableFirstAffidavit()
                    .DisableSecondAffidavit()
                    .HideOwnerInPersonDropDown()
                    .WithoutLanguageDropDown()
                    .WithDeclineReason("Decline reason One")
                    .WithDeclineReason( "Decline reason Two" )
                    .WithDeclineReason( "Decline reason Three" )
                    .WithoutDeclineOther()
                    .WithOptOutReason("Reason One")
                    .WithOptOutReason( "Reason Two" )
                    .WithOptOutReason( "Reason Three" )
                    .WithoutOptOutOther()
                    .WithHandOverLinkHref("http://www.google.ca")
                    .WithHandOverLinkText( "click here" )
                    .WithHandOverLinkTooltip( "link tooltip" )
                    .WithDialogOnComplete()
                    .WithCeremonyLayoutSettings(CeremonyLayoutSettingsBuilder.NewCeremonyLayoutSettings()
                        .WithoutGlobalDownloadButton()
                        .WithoutGlobalConfirmButton()
                        .WithoutGlobalSaveAsLayoutButton()
                        )
                    .Build();

            return sdkDocumentPackageSettings;
        }

        private PackageSettings CreateTypicalAPIPackageSettings()
        {
            var apiCeremonySettings = new CeremonySettings {InPerson = false, DeclineButton = true, OptOutButton = true};

            apiCeremonySettings.AddDeclineReason("Decline reason one");
            apiCeremonySettings.AddDeclineReason("Decline reason two");
            apiCeremonySettings.AddDeclineReason("Decline reason three");

            apiCeremonySettings.AddOptOutReason("Opt out reason one");
            apiCeremonySettings.AddOptOutReason("Opt out reason two");
            apiCeremonySettings.AddOptOutReason("Opt out reason three");

            var link = new Link {Href = "http://www.google.ca", Text = "click here"};
            apiCeremonySettings.HandOver = link;

            apiCeremonySettings.HideCaptureText = true;
            apiCeremonySettings.HideWatermark = true;
            apiCeremonySettings.MaxAuthFailsAllowed = 3;

            apiCeremonySettings.DisableFirstInPersonAffidavit = true;
            apiCeremonySettings.DisableSecondInPersonAffidavit = true;
            apiCeremonySettings.HideLanguageDropdown = true;
            apiCeremonySettings.HidePackageOwnerInPerson = true;

            var style = new Style {BackgroundColor = "white", Color = "blue"};

            var layoutStyle = new LayoutStyle {Dialog = style};

            apiCeremonySettings.Style = layoutStyle;

            var layoutOptions = new LayoutOptions {Iframe = false};
            apiCeremonySettings.Layout = layoutOptions;


            var headerOptions = new HeaderOptions {Breadcrumbs = true, Feedback = true};

            var globalActionsOptions = new GlobalActionsOptions {Confirm = true, Download = true, SaveAsLayout = true};

            headerOptions.GlobalActions = globalActionsOptions;
            layoutOptions.Header = headerOptions;

            var apiPackageSettings = new PackageSettings {Ceremony = apiCeremonySettings};

            return apiPackageSettings;
        }
    }
}

