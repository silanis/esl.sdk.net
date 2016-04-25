using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class TemplateExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new TemplateExample().Run();
        }

        public PackageId templateId;
        public PackageId instantiatedTemplateId;

        public readonly string UPDATED_TEMPLATE_NAME = "Modified name";
        public readonly string UPDATED_TEMPLATE_DESCRIPTION = "Modified description";

        public readonly string SIGNER1_FIRST_NAME = "John1";
        public readonly string SIGNER1_LAST_NAME = "Smith1";
        public readonly string SIGNER1_TITLE = "Managing Director1";
        public readonly string SIGNER1_COMPANY = "Acme Inc.1";

        public readonly string SIGNER2_FIRST_NAME = "John2";
        public readonly string SIGNER2_LAST_NAME = "Smith2";
        public readonly string SIGNER2_TITLE = "Managing Director2";
        public readonly string SIGNER2_COMPANY = "Acme Inc.2";

        public readonly string PACKAGE_NAME = "Package From Template";

        override public void Execute()
        {
			Document document = DocumentBuilder.NewDocumentNamed("First Document")
				.WithId("doc1")
				.FromStream(fileStream1, DocumentType.PDF)
				.Build();

            DocumentPackage superDuperPackage =
                PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .WithEmailMessage("This message should be delivered to all signers")
                    .WithSigner( SignerBuilder.NewSignerWithEmail( email1 )
                                .WithFirstName(SIGNER1_FIRST_NAME)
                                .WithLastName(SIGNER1_LAST_NAME)
                                .WithTitle(SIGNER1_TITLE)
                                .WithCompany(SIGNER1_COMPANY)
                                )
                    .WithSigner( SignerBuilder.NewSignerWithEmail( email2 )
                                .WithFirstName(SIGNER2_FIRST_NAME)
                                .WithLastName(SIGNER2_LAST_NAME)
                                .WithTitle(SIGNER2_TITLE)
                                .WithCompany(SIGNER2_COMPANY)
                                )
				.WithDocument(document)
                .Build();

			templateId = eslClient.CreateTemplate(superDuperPackage);
            DocumentPackage template = eslClient.GetPackage(templateId);

            template.Id = templateId;

            template.Name = UPDATED_TEMPLATE_NAME;
            template.Description = UPDATED_TEMPLATE_DESCRIPTION;
            template.Autocomplete = false;

            eslClient.TemplateService.Update(template);

			document.Description = "Updated description";
            eslClient.TemplateService.UpdateDocumentMetadata(template, document);

			eslClient.TemplateService.DeleteDocument(templateId, "doc1");

			Console.WriteLine("Template {0} updated", templateId);

            instantiatedTemplateId = eslClient.CreatePackageFromTemplate(templateId,
                                        PackageBuilder.NewPackageNamed(PACKAGE_NAME)
                                             .Build() );
                                             
			Console.Out.WriteLine("Package from template = " + instantiatedTemplateId.Id);
        }
    }
}

