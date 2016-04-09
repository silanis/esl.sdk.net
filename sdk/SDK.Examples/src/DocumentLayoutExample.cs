using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    /// <summary>
    /// Create, get and apply document layouts.
    /// </summary>
    public class DocumentLayoutExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new DocumentLayoutExample().Run();
        }

        public string LayoutId;
        public IList<DocumentPackage> Layouts;
        public DocumentPackage PackageWithLayout;

        public readonly string LayoutPackageName = "Layout " + DateTime.Now;
        public readonly string LayoutPackageDescription = "This is a document layout.";
        public readonly string LayoutDocumentName = "First Document";
        public readonly string Field1Name = "field title";
        public readonly string Field2Name = "field company";
        public readonly string ApplyLayoutDocumentName = "Apply Layout Document";
        public readonly string ApplyLayoutDocumentId = "docId";
        public readonly string ApplyLayoutDocumentDescription = "Document with applied layout description.";

        override public void Execute()
        {
            // Create a package with one document and one signature with two fields
            var superDuperPackage = PackageBuilder.NewPackageNamed(LayoutPackageName)
                .DescribedAs(LayoutPackageDescription)
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithCustomId("Client1")
                    .WithFirstName("John")
                    .WithLastName("Smith")
                    .WithTitle("Managing Director")
                    .WithCompany("Acme Inc."))
                .WithDocument(DocumentBuilder.NewDocumentNamed(LayoutDocumentName)
                    .WithId("documentId")
                    .WithDescription("Layout document description")
                    .FromStream(fileStream1, DocumentType.PDF)
                    .WithSignature(SignatureBuilder.SignatureFor(email1)
                        .OnPage(0)
                        .AtPosition(100, 100)
                        .WithField(FieldBuilder.SignerTitle()
                            .WithName(Field1Name)
                            .OnPage(0)
                            .AtPosition(100, 200))
                        .WithField(FieldBuilder.SignerCompany()
                            .WithName(Field2Name)
                            .OnPage(0)
                            .AtPosition(100, 300))))
                .Build();

            var packageId1 = eslClient.CreatePackage(superDuperPackage);
            superDuperPackage.Id = packageId1;

            // Create layout from package
            LayoutId = eslClient.LayoutService.CreateLayout(superDuperPackage);

            // Get a list of layouts
            Layouts = eslClient.LayoutService.GetLayouts(Direction.ASCENDING, new PageRequest(1, 100));

            // Create a new package to apply document layout to
            var packageFromLayout = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a package created using the e-SignLive SDK")
                .WithEmailMessage("This message should be delivered to all signers")
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithCustomId("Client1")
                    .WithFirstName("John")
                    .WithLastName("Smith")
                    .WithTitle("Managing Director")
                    .WithCompany("Acme Inc."))
                .WithDocument(DocumentBuilder.NewDocumentNamed(ApplyLayoutDocumentName)
                    .WithId(ApplyLayoutDocumentId)
                    .WithDescription(ApplyLayoutDocumentDescription)
                    .FromStream(fileStream2, DocumentType.PDF))
                .Build();

            packageId = eslClient.CreatePackage(packageFromLayout);

            // Apply the layout to document in package
            eslClient.LayoutService.ApplyLayout(packageId, ApplyLayoutDocumentId, LayoutId);

            PackageWithLayout = eslClient.GetPackage(packageId);
        }
    }
}

