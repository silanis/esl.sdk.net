using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class TemplateExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new TemplateExample().Run();
        }

        public PackageId TemplateId;
        public PackageId InstantiatedTemplateId;

        public readonly string UpdatedTemplateName = "Modified name";
        public readonly string UpdatedTemplateDescription = "Modified description";

        public readonly string Signer1FirstName = "John1";
        public readonly string Signer1LastName = "Smith1";
        public readonly string Signer1Title = "Managing Director1";
        public readonly string Signer1Company = "Acme Inc.1";

        public readonly string Signer2FirstName = "John2";
        public readonly string Signer2LastName = "Smith2";
        public readonly string Signer2Title = "Managing Director2";
        public readonly string Signer2Company = "Acme Inc.2";

        public readonly string PackageNameForTemplate = "Package From Template";

        override public void Execute()
        {
			var document = DocumentBuilder.NewDocumentNamed("First Document")
				.WithId("doc1")
				.FromStream(fileStream1, DocumentType.PDF)
				.Build();

            var superDuperPackage =
                PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .WithEmailMessage("This message should be delivered to all signers")
                    .WithSigner( SignerBuilder.NewSignerWithEmail( email1 )
                                .WithFirstName(Signer1FirstName)
                                .WithLastName(Signer1LastName)
                                .WithTitle(Signer1Title)
                                .WithCompany(Signer1Company)
                                )
                    .WithSigner( SignerBuilder.NewSignerWithEmail( email2 )
                                .WithFirstName(Signer2FirstName)
                                .WithLastName(Signer2LastName)
                                .WithTitle(Signer2Title)
                                .WithCompany(Signer2Company)
                                )
				.WithDocument(document)
                .Build();

			TemplateId = eslClient.CreateTemplate(superDuperPackage);
            var template = eslClient.GetPackage(TemplateId);

            template.Id = TemplateId;

            template.Name = UpdatedTemplateName;
            template.Description = UpdatedTemplateDescription;
            template.Autocomplete = false;

            eslClient.TemplateService.Update(template);

			document.Description = "Updated description";
            eslClient.TemplateService.UpdateDocumentMetadata(template, document);

			eslClient.TemplateService.DeleteDocument(TemplateId, "doc1");

			Console.WriteLine("Template {0} updated", TemplateId);

            InstantiatedTemplateId = eslClient.CreatePackageFromTemplate(TemplateId,
                                        PackageBuilder.NewPackageNamed(PackageNameForTemplate)
                                             .Build() );
                                             
			Console.Out.WriteLine("Package from template = " + InstantiatedTemplateId.Id);
        }
    }
}

