using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Globalization;

namespace SDK.Examples
{
    public class UpdatePackageExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new UpdatePackageExample().Run();
        }

        public readonly string OPT_OUT_REASON_1 = "OptOut reason One";
        public readonly string OPT_OUT_REASON_2 = "OptOut reason Two";
        public readonly string OPT_OUT_REASON_3 = "OptOut reason Three";

        public readonly string OLD_LOGO_IMAGE_LINK = "old logo image link";
        public readonly string OLD_LOGO_IMAGE_SOURCE = "old logo image source";

        public readonly string OLD_DECLINE_REASON_1 = "old decline reason #1";
        public readonly string OLD_DECLINE_REASON_2 = "old decline reason #2";
        public readonly string OLD_DECLINE_REASON_3 = "old decline reason #3";

        public readonly string OLD_HAND_OVER_LINK_HREF = "http://www.old.ca";
        public readonly string OLD_HAND_OVER_LINK_TEXT = "old hand over link text";
        public readonly string OLD_HAND_OVER_LINK_TOOL_TIP = "old hand over link tool tip";

        public readonly string OLD_OPT_OUT_REASON_1 = "old opt out reason #1";
        public readonly string OLD_OPT_OUT_REASON_2 = "old opt out reason #2";
        public readonly string OLD_OPT_OUT_REASON_3 = "old opt out reason #3";

        public readonly string OLD_PACKAGE_NAME = "Old Package Name";
        public readonly string OLD_DESCRIPTION = "Old Description";
        public readonly string OLD_EMAIL_MESSAGE = "Old Email Message";
        public readonly DateTime OLD_EXPIRY_DATE = DateTime.Now.AddMonths(1);
        public readonly CultureInfo OLD_LANGUAGE = CultureInfo.GetCultureInfo("en");

        // Visibility is for only template
        public readonly Visibility OLD_VISIBILITY = Visibility.ACCOUNT;
        public readonly bool OLD_NOTARIZED = false;

        public readonly string NEW_LOGO_IMAGE_LINK = "new logo image link";
        public readonly string NEW_LOGO_IMAGE_SOURCE = "new logo image source";

        public readonly string NEW_DECLINE_REASON_1 = "new decline reason #1";
        public readonly string NEW_DECLINE_REASON_2 = "new decline reason #2";
        public readonly string NEW_DECLINE_REASON_3 = "new decline reason #3";

        public readonly string NEW_HAND_OVER_LINK_HREF = "http://www.new.ca";
        public readonly string NEW_HAND_OVER_LINK_TEXT = "new hand over link text";
        public readonly string NEW_HAND_OVER_LINK_TOOL_TIP = "new hand over link tool tip";

        public readonly string NEW_OPT_OUT_REASON_1 = "new opt out reason #1";
        public readonly string NEW_OPT_OUT_REASON_2 = "new opt out reason #2";
        public readonly string NEW_OPT_OUT_REASON_3 = "new opt out reason #3";

        public readonly string NEW_PACKAGE_NAME = "new package name";
        public readonly string NEW_DESCRIPTION = "new description";
        public readonly string NEW_EMAIL_MESSAGE = "new email message";
        public readonly DateTime NEW_EXPIRY_DATE = DateTime.Now.AddMonths(2);
        public readonly CultureInfo NEW_LANGUAGE = CultureInfo.GetCultureInfo("fr");

        public readonly Visibility NEW_VISIBILITY = Visibility.SENDER;
        public readonly bool NEW_NOTARIZED = true;

        public DocumentPackage packageToCreate, packageToUpdate, createdPackage, updatedPackage;
        public DocumentPackageSettings settingsToCreate, settingsToUpdate, createdSettings, updatedSettings;
        public CeremonyLayoutSettings layoutSettingsToCreate, layoutSettingsToUpdate, createdLayoutSettings, updatedLayoutSettings;

        override public void Execute()
        {
            layoutSettingsToCreate = CeremonyLayoutSettingsBuilder.NewCeremonyLayoutSettings()
                                .WithBreadCrumbs()
                                .WithGlobalConfirmButton()
                                .WithGlobalDownloadButton()
                                .WithGlobalNavigation()
                                .WithGlobalSaveAsLayoutButton()
                                .WithIFrame()
                                .WithLogoImageLink( OLD_LOGO_IMAGE_LINK )
                                .WithLogoImageSource( OLD_LOGO_IMAGE_SOURCE )
                                .WithNavigator()
                                .WithProgressBar()
                                .WithSessionBar()
                                .WithTitle()
                                .Build();
            
            settingsToCreate = DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
                    .WithCaptureText()
                    .WithDecline()
                    .WithDeclineReason(OLD_DECLINE_REASON_1)
                    .WithDeclineReason(OLD_DECLINE_REASON_2)
                    .WithDeclineReason(OLD_DECLINE_REASON_3)
                    .WithDialogOnComplete()
                    .WithDocumentToolbarDownloadButton()
                    .WithHandOverLinkHref(OLD_HAND_OVER_LINK_HREF)
                    .WithHandOverLinkText(OLD_HAND_OVER_LINK_TEXT)
                    .WithHandOverLinkTooltip(OLD_HAND_OVER_LINK_TOOL_TIP)
                    .WithInPerson()
                    .WithOptOut()
                    .WithOptOutReason(OLD_OPT_OUT_REASON_1)
                    .WithOptOutReason(OLD_OPT_OUT_REASON_2)
                    .WithOptOutReason(OLD_OPT_OUT_REASON_3)
                    .WithWatermark()
                    .WithCeremonyLayoutSettings(layoutSettingsToCreate)
                    .Build();
            
            packageToCreate = PackageBuilder.NewPackageNamed(OLD_PACKAGE_NAME)
                                          .DescribedAs(OLD_DESCRIPTION)
                                          .WithEmailMessage(OLD_EMAIL_MESSAGE)
                                          .ExpiresOn(OLD_EXPIRY_DATE)
                                          .WithLanguage(OLD_LANGUAGE)
                                          .WithVisibility(OLD_VISIBILITY)
                                          .WithNotarized(OLD_NOTARIZED)
                                          .WithAutomaticCompletion()
                                          .WithSettings(settingsToCreate)
                                          .Build();

            packageId = eslClient.CreatePackage(packageToCreate);

            createdPackage = eslClient.GetPackage( packageId );
            createdSettings = createdPackage.Settings;
            createdLayoutSettings = createdSettings.CeremonyLayoutSettings;

            layoutSettingsToUpdate = CeremonyLayoutSettingsBuilder.NewCeremonyLayoutSettings()
                                .WithoutBreadCrumbs()
                                .WithoutGlobalConfirmButton()
                                .WithoutGlobalDownloadButton()
                                .WithoutGlobalNavigation()
                                .WithoutGlobalSaveAsLayoutButton()
                                .WithoutIFrame()
                                .WithLogoImageLink( NEW_LOGO_IMAGE_LINK )
                                .WithLogoImageSource( NEW_LOGO_IMAGE_SOURCE )
                                .WithoutNavigator()
                                .WithoutProgressBar()
                                .WithoutSessionBar()
                                .WithoutTitle()
                    .Build();

            settingsToUpdate = DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
                    .WithoutCaptureText()
                    .WithDecline()
                    .WithDeclineReason(NEW_DECLINE_REASON_1)
                    .WithDeclineReason(NEW_DECLINE_REASON_2)
                    .WithDeclineReason(NEW_DECLINE_REASON_3)
                    .WithoutDialogOnComplete()
                    .WithoutDocumentToolbarDownloadButton()
                    .WithHandOverLinkHref(NEW_HAND_OVER_LINK_HREF)
                    .WithHandOverLinkText(NEW_HAND_OVER_LINK_TEXT)
                    .WithHandOverLinkTooltip(NEW_HAND_OVER_LINK_TOOL_TIP)
                    .WithoutInPerson()
                    .WithoutOptOut()
                    .WithOptOutReason(NEW_OPT_OUT_REASON_1)
                    .WithOptOutReason(NEW_OPT_OUT_REASON_2)
                    .WithOptOutReason(NEW_OPT_OUT_REASON_3)
                    .WithoutWatermark()
                    .WithCeremonyLayoutSettings(layoutSettingsToUpdate)
                    .Build();

            packageToUpdate = PackageBuilder.NewPackageNamed( NEW_PACKAGE_NAME )
                               .WithEmailMessage( NEW_EMAIL_MESSAGE )
                               .ExpiresOn(NEW_EXPIRY_DATE)
                               .WithLanguage(NEW_LANGUAGE)
                               .WithVisibility(NEW_VISIBILITY)
                               .WithNotarized(NEW_NOTARIZED)
                               .WithoutAutomaticCompletion()
                               .WithSettings( settingsToUpdate )
                               .Build();

            eslClient.UpdatePackage(packageId, packageToUpdate);

            updatedPackage = eslClient.GetPackage( packageId );
            updatedSettings = updatedPackage.Settings;
            updatedLayoutSettings = updatedSettings.CeremonyLayoutSettings;
        }
    }
}
