using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class CreateTemplateExample : SdkSample
    {
        public static void Main(string[] args)
        {
			new CreateTemplateExample().Run();
        }
		        
        override public void Execute()
        {
			var template =
                PackageBuilder.NewPackageNamed(PackageName)
					.DescribedAs("This is a template created using the e-SignLive SDK")                	
                	.WithEmailMessage("This message should be delivered to all signers")
                	.WithSigner(SignerBuilder.NewSignerPlaceholder(new Placeholder("PlaceholderId1")))
                	.WithSigner(SignerBuilder.NewSignerPlaceholder(new Placeholder("PlaceholderId2")))
                	.WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                              .FromStream(fileStream1, DocumentType.PDF)
                              .WithSignature(SignatureBuilder.SignatureFor(new Placeholder("PlaceholderId1"))
                                             .OnPage(0)
                                             .WithField(FieldBuilder.CheckBox()
                                                     .OnPage(0)
                                                     .AtPosition(400, 200)
                                                     .WithValue(FieldBuilder.CHECKBOX_CHECKED)
                                                       )
                                             .AtPosition(100, 100)
                                            )
                             )
                	.WithDocument(DocumentBuilder.NewDocumentNamed("Second Document")
                              .FromStream(fileStream2, DocumentType.PDF)
                              .WithSignature(SignatureBuilder.SignatureFor(new Placeholder("PlaceholderId2"))
                                             .OnPage(0)
                                             .AtPosition(100, 200)
                                            )
                             )
                .Build();

			var templateId = eslClient.CreateTemplate(template);
            
			Console.WriteLine("templateId = " + templateId);
        }
    }
}

