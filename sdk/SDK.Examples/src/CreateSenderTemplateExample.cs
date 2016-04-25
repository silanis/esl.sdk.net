using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class CreateSenderTemplateExample : SDKSample
    {
        public PackageId templateId;
        public Visibility visibility = Visibility.SENDER;

        public static void Main(string[] args)
        {
            new CreateSenderTemplateExample().Run();
        }

        override public void Execute()
        {
            DocumentPackage template =
                PackageBuilder.NewPackageNamed("CreateSenderTemplateExample: " + DateTime.Now)
                    .DescribedAs("This is a Template created using the e-SignLive SDK")      
                    .WithVisibility(visibility)
                    .WithEmailMessage("This message should be delivered to all signers")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                                    .WithFirstName("Patty")    
                                                    .WithLastName("Galant"))   
                    .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                                  .WithId("documentId")  
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                  .OnPage(0)
                                  .AtPosition(400, 200)
                               ))
                    .Build();

            templateId = eslClient.CreateTemplate(template);

            Console.WriteLine("templateId = " + templateId);
        }

    }
}

