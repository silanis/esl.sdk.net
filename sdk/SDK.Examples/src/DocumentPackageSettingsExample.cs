using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DocumentPackageSettingsExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new DocumentPackageSettingsExample().Run();
        }

        public readonly string DeclineReason1 = "Decline reason One";
        public readonly string DeclineReason2 = "Decline reason Two";
        public readonly string DeclineReason3 = "Decline reason Three";

        public readonly string OptOutReason1 = "OptOut reason One";
        public readonly string OptOutReason2 = "OptOut reason Two";
        public readonly string OptOutReason3 = "OptOut reason Three";

        override public void Execute() {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
				.WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
				              .WithInPerson()
                              .WithoutLanguageDropDown()
                              .DisableFirstAffidavit()
                              .DisableSecondAffidavit()
                              .HideOwnerInPersonDropDown()
				              .WithDecline()
							  .WithOptOut()
                              .WithDeclineReason(DeclineReason1)
                              .WithDeclineReason(DeclineReason2)
                              .WithDeclineReason(DeclineReason3)
                              .WithoutDeclineOther()
                              .WithOptOutReason(OptOutReason1)
                              .WithOptOutReason(OptOutReason2)
                              .WithOptOutReason(OptOutReason3)
                              .WithoutOptOutOther()
				              .WithHandOverLinkHref("http://www.google.ca")
				              .WithHandOverLinkText("click here")
				              .WithHandOverLinkTooltip("link tooltip")
				              .WithCeremonyLayoutSettings(CeremonyLayoutSettingsBuilder.NewCeremonyLayoutSettings()
                                            .WithoutGlobalConfirmButton()
                                            .WithoutGlobalDownloadButton()
                                            .WithoutGlobalSaveAsLayoutButton() ) )
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("John")
					            .WithLastName("Smith"))
					.WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                   .WithSignature(SignatureBuilder.SignatureFor(email1)
					               .OnPage(0)
					               .AtPosition(100, 100)))
					.Build();

            packageId = eslClient.CreateAndSendPackage(superDuperPackage);
            retrievedPackage = eslClient.GetPackage( packageId );
        }
    }
}

