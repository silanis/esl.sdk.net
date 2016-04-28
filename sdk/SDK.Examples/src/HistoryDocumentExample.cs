using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    /// <summary>
    /// The HistoryDocumentExample class provides an example to help adding a document from an external provider 
    /// which is the history list of documents uploaded. However, most external providers require pre-development
    /// configurations.
    /// Please contact us for more information
    /// </summary>

    public class HistoryDocumentExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new HistoryDocumentExample().Run();
        }

        public string ExternalDocumentName;

        override public void Execute()
        {
            ExternalDocumentName = "External Document " + DateTime.Now;

            var superDuperPackage =
                    PackageBuilder.NewPackageNamed("ExternalPackage: " + DateTime.Now)
                        .DescribedAs("This is a package created using the e-SignLive SDK")
                        .ExpiresOn(DateTime.Now.AddMonths(100))
                        .WithEmailMessage("This message should be delivered to all signers")
                        .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                    .WithCustomId("Client1")
                                    .WithFirstName("John")
                                    .WithLastName("Smith")
                                    .WithTitle("Managing Director")
                                    .WithCompany("Acme Inc.")
            )
                        .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                    .WithFirstName("Patty")
                                    .WithLastName("Galant")
            )
                        .WithDocument(DocumentBuilder.NewDocumentNamed(ExternalDocumentName)
                                      .FromStream(fileStream1, DocumentType.PDF)
                                      .WithSignature(SignatureBuilder.SignatureFor(email1)
                                       .OnPage(0)
                                       .AtPosition(100, 100)
            )
            )
                        .Build();

            packageId = eslClient.CreatePackageOneStep(superDuperPackage);
            eslClient.SendPackage(packageId);

                PackageBuilder.NewPackageNamed(PackageName)
                    .DescribedAs("This is a package created using the e-SignLive SDK")
                    .ExpiresOn(DateTime.Now.AddMonths(100))
                    .WithEmailMessage("This message should be delivered to all signers")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithCustomId("Client1")
                                .WithFirstName("John")
                                .WithLastName("Smith")
                                .WithTitle("Managing Director")
                                .WithCompany("Acme Inc.")
                                )
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithFirstName("Patty")
                                .WithLastName("Galant")
                                )
                    .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                                  .FromStream(fileStream2, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email2)
                                   .OnPage(0)
                                   .AtPosition(100, 100)
                                   )
                                  )
                    .Build();

            packageId = eslClient.CreatePackageOneStep(superDuperPackage);

            var documentsHistory = eslClient.PackageService.GetDocuments();
            IList<Document> externalDocuments = new List<Document>();

            foreach (var document in documentsHistory)
            {
                if (document.Name == ExternalDocumentName)
                {
                    externalDocuments.Add(document);
                }
            }

            eslClient.PackageService.AddDocumentWithExternalContent(packageId.Id, externalDocuments);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

