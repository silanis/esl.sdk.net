using System;
using System.IO;
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

    public class HistoryDocumentExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new HistoryDocumentExample().Run();
        }

        public string externalDocumentName;

        override public void Execute()
        {
            externalDocumentName = "External Document " + DateTime.Now;

            DocumentPackage superDuperPackage =
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
                        .WithDocument(DocumentBuilder.NewDocumentNamed(externalDocumentName)
                                      .FromStream(fileStream1, DocumentType.PDF)
                                      .WithSignature(SignatureBuilder.SignatureFor(email1)
                                       .OnPage(0)
                                       .AtPosition(100, 100)
            )
            )
                        .Build();

            packageId = eslClient.CreatePackageOneStep(superDuperPackage);
            eslClient.SendPackage(packageId);

            DocumentPackage documentWithExternalContent =
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

            IList<Silanis.ESL.SDK.Document> documentsHistory = eslClient.PackageService.GetDocuments();
            IList<Silanis.ESL.SDK.Document> externalDocuments = new List<Silanis.ESL.SDK.Document>();

            foreach (Silanis.ESL.SDK.Document document in documentsHistory)
            {
                if (document.Name == externalDocumentName)
                {
                    externalDocuments.Add(document);
                }
            }

            eslClient.PackageService.AddDocumentWithExternalContent(packageId.Id, externalDocuments);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

