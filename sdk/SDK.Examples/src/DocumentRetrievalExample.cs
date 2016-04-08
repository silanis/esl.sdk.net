using System;
using Silanis.ESL.SDK;
using System.IO;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DocumentRetrievalExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new DocumentRetrievalExample().Run();
        }

        public byte[] pdfDownloadedBytes, originalPdfDownloadedBytes, zippedDownloadedBytes;

        override public void Execute()
        {
            this.fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/prêt.pdf").FullName);

            var docId = "myDocumentId";
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                            .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                            .WithFirstName("George")
                            .WithLastName("Faltour").Build())
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                    .FromStream(fileStream1, DocumentType.PDF)
                            .WithId(docId)
                            .WithSignature(SignatureBuilder.SignatureFor(email1)
                           .    AtPosition(100, 100).OnPage(0))
                          ).Build();

            var packageId = eslClient.CreatePackageOneStep(superDuperPackage);

            eslClient.SendPackage(packageId);

            pdfDownloadedBytes = eslClient.DownloadDocument(packageId, docId);  
            originalPdfDownloadedBytes = eslClient.DownloadOriginalDocument(packageId, docId);
            zippedDownloadedBytes = eslClient.DownloadZippedDocuments(packageId);

            // To write the byte[] to a file, use:
            // System.IO.File.WriteAllBytes("/path/to/directory/myDocument.pdf", pdfDocumentBytes);
        }
    }
}
