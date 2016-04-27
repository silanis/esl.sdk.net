using Silanis.ESL.SDK;
using System.IO;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DocumentRetrievalExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new DocumentRetrievalExample().Run();
        }

        public byte[] PdfDownloadedBytes, OriginalPdfDownloadedBytes, ZippedDownloadedBytes;

        override public void Execute()
        {
            fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/prêt.pdf").FullName);

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

            var id = eslClient.CreatePackageOneStep(superDuperPackage);

            eslClient.SendPackage(id);

            PdfDownloadedBytes = eslClient.DownloadDocument(id, docId);  
            OriginalPdfDownloadedBytes = eslClient.DownloadOriginalDocument(id, docId);
            ZippedDownloadedBytes = eslClient.DownloadZippedDocuments(id);

            // To write the byte[] to a file, use:
            // System.IO.File.WriteAllBytes("/path/to/directory/myDocument.pdf", pdfDocumentBytes);
        }
    }
}
