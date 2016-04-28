using System;
using Silanis.ESL.SDK;
using System.Collections.Generic;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class FieldManipulationExample : SdkSample
    {
        private const string DocumentId = "documentId";
        private readonly SignatureId _signatureId = new SignatureId("signatureId");

        public Field Field1;
        public Field Field2;
        public Field Field3;
        public Field UpdatedField;

        public List<Field> AddedFields;
        public List<Field> DeletedFields;
        public List<Field> UpdatedFields;

        public DocumentPackage CreatedPackage;

        override public void Execute()
        {
            var superDuperPackage =
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
                                   .WithId(_signatureId)
                                   .AtPosition(100, 100))
                                  )
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);

            Field1 = FieldBuilder.RadioButton("group1")
                .WithName("field1")
                    .WithId("fieldId1")
                    .AtPosition(400, 100)
                    .OnPage(0)
                    .Build();


            Field2 = FieldBuilder.RadioButton("group1")
                .WithName("field2")
                    .WithId("fieldId2")
                    .AtPosition(400, 200)
                    .OnPage(0)
                    .Build();

            Field3 = FieldBuilder.RadioButton("group1")
                .WithName("field3")
                    .WithId("fieldId3")
                    .AtPosition(400, 300)
                    .OnPage(0)
                    .Build();

            UpdatedField = FieldBuilder.RadioButton("group1")
                .WithName("updatedField")
                    .WithId("fieldId3")
                    .AtPosition(400, 300)
                    .OnPage(0)
                    .Build();

            // Adding the fields
            eslClient.ApprovalService.AddField(packageId, DocumentId, _signatureId, Field1);
            eslClient.ApprovalService.AddField(packageId, DocumentId, _signatureId, Field2);
            eslClient.ApprovalService.AddField(packageId, DocumentId, _signatureId, Field3);

            CreatedPackage = eslClient.GetPackage(packageId);
            AddedFields = eslClient.ApprovalService.GetApproval(CreatedPackage, DocumentId, _signatureId.Id).Fields;

            // Deleting field1
            eslClient.ApprovalService.DeleteField(packageId, DocumentId, _signatureId, Field1.Id);

            CreatedPackage = eslClient.GetPackage(packageId);
            DeletedFields = eslClient.ApprovalService.GetApproval(CreatedPackage, DocumentId, _signatureId.Id).Fields;

            // Updating the information for the third field
            eslClient.ApprovalService.ModifyField(packageId, DocumentId, _signatureId, UpdatedField);

            CreatedPackage = eslClient.GetPackage(packageId);
            UpdatedFields = eslClient.ApprovalService.GetApproval(CreatedPackage, DocumentId, _signatureId.Id).Fields;
        }
    }
}

