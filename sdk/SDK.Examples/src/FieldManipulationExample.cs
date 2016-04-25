using System;
using System.IO;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class FieldManipulationExample : SDKSample
    {
        private string documentId = "documentId";
        private SignatureId signatureId = new SignatureId("signatureId");

        public Field field1;
        public Field field2;
        public Field field3;
        public Field updatedField;

        public List<Field> addedFields;
        public List<Field> deletedFields;
        public List<Field> updatedFields;

        public DocumentPackage createdPackage;

        override public void Execute()
        {
            DocumentPackage superDuperPackage =
                PackageBuilder.NewPackageNamed(PackageName)
                    .DescribedAs("This is a package created using the e-SignLive SDK")
                    .ExpiresOn(DateTime.Now.AddMonths(100))
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithCustomId("signatureId1")
                                .WithFirstName("firstName1")
                                .WithLastName("lastName1"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("FieldManipulationExample")
                                  .WithId("documentId")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .WithId(signatureId)
                                   .AtPosition(100, 100))
                                  )
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);

            field1 = FieldBuilder.RadioButton("group1")
                .WithName("field1")
                    .WithId("fieldId1")
                    .AtPosition(400, 100)
                    .OnPage(0)
                    .Build();


            field2 = FieldBuilder.RadioButton("group1")
                .WithName("field2")
                    .WithId("fieldId2")
                    .AtPosition(400, 200)
                    .OnPage(0)
                    .Build();

            field3 = FieldBuilder.RadioButton("group1")
                .WithName("field3")
                    .WithId("fieldId3")
                    .AtPosition(400, 300)
                    .OnPage(0)
                    .Build();

            updatedField = FieldBuilder.RadioButton("group1")
                .WithName("updatedField")
                    .WithId("fieldId3")
                    .AtPosition(400, 300)
                    .OnPage(0)
                    .Build();

            // Adding the fields
            eslClient.ApprovalService.AddField(packageId, documentId, signatureId, field1);
            eslClient.ApprovalService.AddField(packageId, documentId, signatureId, field2);
            eslClient.ApprovalService.AddField(packageId, documentId, signatureId, field3);

            createdPackage = eslClient.GetPackage(packageId);
            addedFields = eslClient.ApprovalService.GetApproval(createdPackage, documentId, signatureId.Id).Fields;

            // Deleting field1
            eslClient.ApprovalService.DeleteField(packageId, documentId, signatureId, field1.Id);

            createdPackage = eslClient.GetPackage(packageId);
            deletedFields = eslClient.ApprovalService.GetApproval(createdPackage, documentId, signatureId.Id).Fields;

            // Updating the information for the third field
            eslClient.ApprovalService.ModifyField(packageId, documentId, signatureId, updatedField);

            createdPackage = eslClient.GetPackage(packageId);
            updatedFields = eslClient.ApprovalService.GetApproval(createdPackage, documentId, signatureId.Id).Fields;
        }
    }
}

