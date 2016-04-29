using System;
using Silanis.ESL.SDK;
using System.IO;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class DocumentDeliveryByEmailExample
    {
        public static string apiToken = "YOUR TOKEN HERE";
        public static string baseUrl = "ENVIRONMENT URL HERE";


        public static void Main (string[] args)
        {
            // Create new esl client with api token and base url
            EslClient client = new EslClient (apiToken, baseUrl);
            FileInfo file = new FileInfo (Directory.GetCurrentDirectory() + "/src/document.pdf");

            DocumentPackage package = PackageBuilder.NewPackageNamed ("C# DocumentDeliveryByEmailExample Package " + DateTime.Now)
                .DescribedAs ("This is a new package")
                    .WithSigner(SignerBuilder.NewSignerWithEmail("john.smith@email.com")
                                .DeliverSignedDocumentsByEmail()
                                .WithFirstName("John")
                                .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
                                  .FromFile(file.FullName)
                                  .WithSignature(SignatureBuilder.CaptureFor ("john.smith@email.com")
                                   .OnPage (0)
                                   .AtPosition (500, 300)))
                    .Build ();

            PackageId id = client.CreatePackage (package);

            client.SendPackage(id);
        }
    }
}

