using NUnit.Framework;
using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture()]
    public class DocumentPackageSettingsConverterTest
    {
        private Silanis.ESL.SDK.DocumentPackageSettings sdkPackageSettings1 = null;
        private Silanis.ESL.API.PackageSettings apiPackageSettings1 = null;
        private Silanis.ESL.API.PackageSettings apiPackageSettings2 = null;
        private DocumentPackageSettingsConverter converter = null;

        [Test()]
        public void ConvertNullSDKToAPI()
        {
            sdkPackageSettings1 = null;
            converter = new DocumentPackageSettingsConverter(sdkPackageSettings1);
            Assert.IsNull(converter.toAPIPackageSettings());
        }

        [Test()]
        public void ConvertNullAPIToAPI()
        {
            apiPackageSettings1 = null;
            converter = new DocumentPackageSettingsConverter(apiPackageSettings1);
            Assert.IsNull(converter.toAPIPackageSettings());
        }

        [Test()]
        public void ConvertAPIToAPI()
        {
            apiPackageSettings1 = CreateTypicalAPIPackageSettings();
            converter = new DocumentPackageSettingsConverter(apiPackageSettings1);
            apiPackageSettings2 = converter.toAPIPackageSettings();

            Assert.IsNotNull(apiPackageSettings2);
            Assert.AreEqual(apiPackageSettings2, apiPackageSettings1);
        }

        [Test()]
        public void ConvertAPIToSDK()
        {
            apiPackageSettings1 = CreateTypicalAPIPackageSettings();
            sdkPackageSettings1 = new DocumentPackageSettingsConverter(apiPackageSettings1).toSDKDocumentPackageSettings();

            Assert.IsNotNull(sdkPackageSettings1);
            Assert.AreEqual(apiPackageSettings1.Ceremony.InPerson, sdkPackageSettings1.EnableInPerson);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DeclineButton, sdkPackageSettings1.EnableDecline);
            Assert.AreEqual(apiPackageSettings1.Ceremony.OptOutButton, sdkPackageSettings1.EnableOptOut);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DeclineReasons[0], sdkPackageSettings1.DeclineReasons[0]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DeclineReasons[1], sdkPackageSettings1.DeclineReasons[1]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DeclineReasons[2], sdkPackageSettings1.DeclineReasons[2]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DisableDeclineOther, sdkPackageSettings1.DisableDeclineOther);
            Assert.AreEqual(apiPackageSettings1.Ceremony.OptOutReasons[0], sdkPackageSettings1.OptOutReasons[0]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.OptOutReasons[1], sdkPackageSettings1.OptOutReasons[1]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.OptOutReasons[2], sdkPackageSettings1.OptOutReasons[2]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DisableOptOutOther, sdkPackageSettings1.DisableOptOutOther);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HandOver.Href, sdkPackageSettings1.LinkHref);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HandOver.Text, sdkPackageSettings1.LinkText);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HandOver.Title, sdkPackageSettings1.LinkTooltip);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HideCaptureText, sdkPackageSettings1.HideCaptureText);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HideWatermark, sdkPackageSettings1.HideWatermark);
            Assert.AreEqual(apiPackageSettings1.Ceremony.MaxAuthFailsAllowed, sdkPackageSettings1.MaxAuthAttempts);
            Assert.AreEqual(apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.Download, sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalDownloadButton);
            Assert.AreEqual(apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.Confirm, sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalConfirmButton);
            Assert.AreEqual(apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.SaveAsLayout, sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalSaveAsLayoutButton);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HideLanguageDropdown, !sdkPackageSettings1.ShowLanguageDropDown);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HidePackageOwnerInPerson, !sdkPackageSettings1.ShowOwnerInPersonDropDown);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DisableFirstInPersonAffidavit, !sdkPackageSettings1.EnableFirstAffidavit);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DisableSecondInPersonAffidavit, !sdkPackageSettings1.EnableSecondAffidavit);
        }

        [Test()]
        public void ConvertSDKToAPI()
        {
            sdkPackageSettings1 = CreateTypicalSDKDocumentPackageSettings();
            apiPackageSettings1 = new DocumentPackageSettingsConverter(sdkPackageSettings1).toAPIPackageSettings();

            Assert.IsNotNull(apiPackageSettings1);
            Assert.AreEqual(apiPackageSettings1.Ceremony.InPerson, sdkPackageSettings1.EnableInPerson);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DeclineButton, sdkPackageSettings1.EnableDecline);
            Assert.AreEqual(apiPackageSettings1.Ceremony.OptOutButton, sdkPackageSettings1.EnableOptOut);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DeclineReasons[0], sdkPackageSettings1.DeclineReasons[0]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DeclineReasons[1], sdkPackageSettings1.DeclineReasons[1]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DeclineReasons[2], sdkPackageSettings1.DeclineReasons[2]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DisableDeclineOther, sdkPackageSettings1.DisableDeclineOther);
            Assert.AreEqual(apiPackageSettings1.Ceremony.OptOutReasons[0], sdkPackageSettings1.OptOutReasons[0]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.OptOutReasons[1], sdkPackageSettings1.OptOutReasons[1]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.OptOutReasons[2], sdkPackageSettings1.OptOutReasons[2]);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DisableOptOutOther, sdkPackageSettings1.DisableOptOutOther);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HandOver.Href, sdkPackageSettings1.LinkHref);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HandOver.Text, sdkPackageSettings1.LinkText);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HandOver.Title, sdkPackageSettings1.LinkTooltip);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HideCaptureText, sdkPackageSettings1.HideCaptureText);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HideWatermark, sdkPackageSettings1.HideWatermark);
            Assert.AreEqual(apiPackageSettings1.Ceremony.MaxAuthFailsAllowed, sdkPackageSettings1.MaxAuthAttempts);
            Assert.AreEqual(apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.Download, sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalDownloadButton);
            Assert.AreEqual(apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.Confirm, sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalConfirmButton);
            Assert.AreEqual(apiPackageSettings1.Ceremony.Layout.Header.GlobalActions.SaveAsLayout, sdkPackageSettings1.CeremonyLayoutSettings.ShowGlobalSaveAsLayoutButton);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HideLanguageDropdown, !sdkPackageSettings1.ShowLanguageDropDown);
            Assert.AreEqual(apiPackageSettings1.Ceremony.HidePackageOwnerInPerson, !sdkPackageSettings1.ShowOwnerInPersonDropDown);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DisableFirstInPersonAffidavit, !sdkPackageSettings1.EnableFirstAffidavit);
            Assert.AreEqual(apiPackageSettings1.Ceremony.DisableSecondInPersonAffidavit, !sdkPackageSettings1.EnableSecondAffidavit);
        }

        private Silanis.ESL.SDK.DocumentPackageSettings CreateTypicalSDKDocumentPackageSettings()
        {
            Silanis.ESL.SDK.DocumentPackageSettings sdkDocumentPackageSettings = DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
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

        private Silanis.ESL.API.PackageSettings CreateTypicalAPIPackageSettings()
        {
            Silanis.ESL.API.CeremonySettings apiCeremonySettings = new Silanis.ESL.API.CeremonySettings();

            apiCeremonySettings.InPerson = false;
            apiCeremonySettings.DeclineButton = true;
            apiCeremonySettings.OptOutButton = true;

            apiCeremonySettings.AddDeclineReason("Decline reason one");
            apiCeremonySettings.AddDeclineReason("Decline reason two");
            apiCeremonySettings.AddDeclineReason("Decline reason three");

            apiCeremonySettings.AddOptOutReason("Opt out reason one");
            apiCeremonySettings.AddOptOutReason("Opt out reason two");
            apiCeremonySettings.AddOptOutReason("Opt out reason three");

            Silanis.ESL.API.Link link = new Silanis.ESL.API.Link();
            link.Href = "http://www.google.ca";
            link.Text = "click here";
            apiCeremonySettings.HandOver = link;

            apiCeremonySettings.HideCaptureText = true;
            apiCeremonySettings.HideWatermark = true;
            apiCeremonySettings.MaxAuthFailsAllowed = 3;

            apiCeremonySettings.DisableFirstInPersonAffidavit = true;
            apiCeremonySettings.DisableSecondInPersonAffidavit = true;
            apiCeremonySettings.HideLanguageDropdown = true;
            apiCeremonySettings.HidePackageOwnerInPerson = true;

            Style style = new Style();
            style.BackgroundColor = "white";
            style.Color = "blue";

            LayoutStyle layoutStyle = new LayoutStyle();
            layoutStyle.Dialog = style;

            apiCeremonySettings.Style = layoutStyle;

            LayoutOptions layoutOptions = new LayoutOptions();
            layoutOptions.Iframe = false;
            apiCeremonySettings.Layout = layoutOptions;


            HeaderOptions headerOptions = new HeaderOptions();
            headerOptions.Breadcrumbs = true;
            headerOptions.Feedback = true;

            GlobalActionsOptions globalActionsOptions = new GlobalActionsOptions();
            globalActionsOptions.Confirm = true;
            globalActionsOptions.Download = true;
            globalActionsOptions.SaveAsLayout = true;

            headerOptions.GlobalActions = globalActionsOptions;
            layoutOptions.Header = headerOptions;

            Silanis.ESL.API.PackageSettings apiPackageSettings = new Silanis.ESL.API.PackageSettings();
            apiPackageSettings.Ceremony = apiCeremonySettings;

            return apiPackageSettings;
        }
    }
}

