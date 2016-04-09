using System;
using System.Globalization;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class UpdatePackageExample : SdkSample
    {
        public readonly string NewDeclineReason1 = "new decline reason #1";
        public readonly string NewDeclineReason2 = "new decline reason #2";
        public readonly string NewDeclineReason3 = "new decline reason #3";
        public readonly string NewDescription = "new description";
        public readonly string NewEmailMessage = "new email message";
        public readonly DateTime NewExpiryDate = DateTime.Now.AddMonths(2);

        public readonly string NewHandOverLinkHref = "http://www.new.ca";
        public readonly string NewHandOverLinkText = "new hand over link text";
        public readonly string NewHandOverLinkToolTip = "new hand over link tool tip";
        public readonly CultureInfo NewLanguage = CultureInfo.GetCultureInfo("fr");
        public readonly string NewLogoImageLink = "new logo image link";
        public readonly string NewLogoImageSource = "new logo image source";
        public readonly bool NewNotarized = true;
        public readonly string NewOptOutReason1 = "new opt out reason #1";
        public readonly string NewOptOutReason2 = "new opt out reason #2";
        public readonly string NewOptOutReason3 = "new opt out reason #3";

        public readonly string NewPackageName = "new package name";
        public readonly Visibility NewVisibility = Visibility.SENDER;
        public readonly string OldDeclineReason1 = "old decline reason #1";
        public readonly string OldDeclineReason2 = "old decline reason #2";
        public readonly string OldDeclineReason3 = "old decline reason #3";
        public readonly string OldDescription = "Old Description";
        public readonly string OldEmailMessage = "Old Email Message";
        public readonly DateTime OldExpiryDate = DateTime.Now.AddMonths(1);

        public readonly string OldHandOverLinkHref = "http://www.old.ca";
        public readonly string OldHandOverLinkText = "old hand over link text";
        public readonly string OldHandOverLinkToolTip = "old hand over link tool tip";
        public readonly CultureInfo OldLanguage = CultureInfo.GetCultureInfo("en");
        public readonly string OldLogoImageLink = "old logo image link";
        public readonly string OldLogoImageSource = "old logo image source";
        public readonly bool OldNotarized = false;

        public readonly string OldOptOutReason1 = "old opt out reason #1";
        public readonly string OldOptOutReason2 = "old opt out reason #2";
        public readonly string OldOptOutReason3 = "old opt out reason #3";

        public readonly string OldPackageName = "Old Package Name";

        // Visibility is for only template
        public readonly Visibility OldVisibility = Visibility.ACCOUNT;
        public readonly string OptOutReason1 = "OptOut reason One";
        public readonly string OptOutReason2 = "OptOut reason Two";
        public readonly string OptOutReason3 = "OptOut reason Three";
        public CeremonyLayoutSettings createdLayoutSettings;
        public DocumentPackage createdPackage;
        public DocumentPackageSettings createdSettings;

        public CeremonyLayoutSettings layoutSettingsToCreate,
            layoutSettingsToUpdate;

        public DocumentPackage packageToCreate, packageToUpdate;
        public DocumentPackageSettings settingsToCreate, settingsToUpdate;

        public CeremonyLayoutSettings updatedLayoutSettings;

        public DocumentPackage updatedPackage;
        public DocumentPackageSettings updatedSettings;

        public static void Main(string[] args)
        {
            new UpdatePackageExample().Run();
        }

        public override void Execute()
        {
            layoutSettingsToCreate = CeremonyLayoutSettingsBuilder.NewCeremonyLayoutSettings()
                .WithBreadCrumbs()
                .WithGlobalConfirmButton()
                .WithGlobalDownloadButton()
                .WithGlobalNavigation()
                .WithGlobalSaveAsLayoutButton()
                .WithIFrame()
                .WithLogoImageLink(OldLogoImageLink)
                .WithLogoImageSource(OldLogoImageSource)
                .WithNavigator()
                .WithProgressBar()
                .WithSessionBar()
                .WithTitle()
                .Build();

            settingsToCreate = DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
                .WithCaptureText()
                .WithDecline()
                .WithDeclineReason(OldDeclineReason1)
                .WithDeclineReason(OldDeclineReason2)
                .WithDeclineReason(OldDeclineReason3)
                .WithDialogOnComplete()
                .WithDocumentToolbarDownloadButton()
                .WithHandOverLinkHref(OldHandOverLinkHref)
                .WithHandOverLinkText(OldHandOverLinkText)
                .WithHandOverLinkTooltip(OldHandOverLinkToolTip)
                .WithInPerson()
                .WithOptOut()
                .WithOptOutReason(OldOptOutReason1)
                .WithOptOutReason(OldOptOutReason2)
                .WithOptOutReason(OldOptOutReason3)
                .WithWatermark()
                .WithCeremonyLayoutSettings(layoutSettingsToCreate)
                .Build();

            packageToCreate = PackageBuilder.NewPackageNamed(OldPackageName)
                .DescribedAs(OldDescription)
                .WithEmailMessage(OldEmailMessage)
                .ExpiresOn(OldExpiryDate)
                .WithLanguage(OldLanguage)
                .WithVisibility(OldVisibility)
                .WithNotarized(OldNotarized)
                .WithAutomaticCompletion()
                .WithSettings(settingsToCreate)
                .Build();

            packageId = eslClient.CreatePackage(packageToCreate);

            createdPackage = eslClient.GetPackage(packageId);
            createdSettings = createdPackage.Settings;
            createdLayoutSettings = createdSettings.CeremonyLayoutSettings;

            layoutSettingsToUpdate = CeremonyLayoutSettingsBuilder.NewCeremonyLayoutSettings()
                .WithoutBreadCrumbs()
                .WithoutGlobalConfirmButton()
                .WithoutGlobalDownloadButton()
                .WithoutGlobalNavigation()
                .WithoutGlobalSaveAsLayoutButton()
                .WithoutIFrame()
                .WithLogoImageLink(NewLogoImageLink)
                .WithLogoImageSource(NewLogoImageSource)
                .WithoutNavigator()
                .WithoutProgressBar()
                .WithoutSessionBar()
                .WithoutTitle()
                .Build();

            settingsToUpdate = DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
                .WithoutCaptureText()
                .WithDecline()
                .WithDeclineReason(NewDeclineReason1)
                .WithDeclineReason(NewDeclineReason2)
                .WithDeclineReason(NewDeclineReason3)
                .WithoutDialogOnComplete()
                .WithoutDocumentToolbarDownloadButton()
                .WithHandOverLinkHref(NewHandOverLinkHref)
                .WithHandOverLinkText(NewHandOverLinkText)
                .WithHandOverLinkTooltip(NewHandOverLinkToolTip)
                .WithoutInPerson()
                .WithoutOptOut()
                .WithOptOutReason(NewOptOutReason1)
                .WithOptOutReason(NewOptOutReason2)
                .WithOptOutReason(NewOptOutReason3)
                .WithoutWatermark()
                .WithCeremonyLayoutSettings(layoutSettingsToUpdate)
                .Build();

            packageToUpdate = PackageBuilder.NewPackageNamed(NewPackageName)
                .WithEmailMessage(NewEmailMessage)
                .ExpiresOn(NewExpiryDate)
                .WithLanguage(NewLanguage)
                .WithVisibility(NewVisibility)
                .WithNotarized(NewNotarized)
                .WithoutAutomaticCompletion()
                .WithSettings(settingsToUpdate)
                .Build();

            eslClient.UpdatePackage(packageId, packageToUpdate);

            updatedPackage = eslClient.GetPackage(packageId);
            updatedSettings = updatedPackage.Settings;
            updatedLayoutSettings = updatedSettings.CeremonyLayoutSettings;
        }
    }
}