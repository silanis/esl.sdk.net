using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.IO;

namespace SDK.Examples
{
    public class DocumentPackageSettingsExample : SDKSample
    {
        public static void Main (string[] args)
        {
            new DocumentPackageSettingsExample().Run();
        }

        public readonly string DECLINE_REASON_1 = "Decline reason One";
        public readonly string DECLINE_REASON_2 = "Decline reason Two";
        public readonly string DECLINE_REASON_3 = "Decline reason Three";

        public readonly string OPT_OUT_REASON_1 = "OptOut reason One";
        public readonly string OPT_OUT_REASON_2 = "OptOut reason Two";
        public readonly string OPT_OUT_REASON_3 = "OptOut reason Three";

        override public void Execute() {
            DocumentPackage superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
				.WithSettings(DocumentPackageSettingsBuilder.NewDocumentPackageSettings()
				              .WithInPerson()
                              .WithoutLanguageDropDown()
                              .DisableFirstAffidavit()
                              .DisableSecondAffidavit()
                              .HideOwnerInPersonDropDown()
				              .WithDecline()
							  .WithOptOut()
                              .WithDeclineReason(DECLINE_REASON_1)
                              .WithDeclineReason(DECLINE_REASON_2)
                              .WithDeclineReason(DECLINE_REASON_3)
                              .WithoutDeclineOther()
                              .WithOptOutReason(OPT_OUT_REASON_1)
                              .WithOptOutReason(OPT_OUT_REASON_2)
                              .WithOptOutReason(OPT_OUT_REASON_3)
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

