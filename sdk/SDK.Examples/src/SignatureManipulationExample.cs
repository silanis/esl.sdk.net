using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class SignatureManipulationExample : SdkSample
    {
        public readonly string DocumentName = "SignatureManipulationExample";

        private const string DocumentId = "documentId";

        public Signature Signature1;
        public Signature Signature2;
        public Signature Signature3;
        public Signature ModifiedSignature;
        public Signature UpdatedSignature1;
        public Signature UpdatedSignature2;

        public List<Signature> AddedSignatures;
        public List<Signature> DeletedSignatures;
        public List<Signature> ModifiedSignatures;
        public List<Signature> UpdatedSignatures;

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
                                .WithLastName("lastName1")
            )
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithCustomId("signatureId2")
                                .WithFirstName("firstName2")
                                .WithLastName("lastName2")
            )
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email3)
                                .WithCustomId("signatureId3")
                                .WithFirstName("firstName3")
                                .WithLastName("lastName3")
            )
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DocumentName)
                                  .WithId("documentId")
                                  .FromStream(fileStream1, DocumentType.PDF)
            )

                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);

            Signature1 = SignatureBuilder.SignatureFor(email1)
                .OnPage(0)
                    .WithId(new SignatureId("signatureId1"))
                    .AtPosition(100, 100)
                    .Build();

            Signature2 = SignatureBuilder.SignatureFor(email2)
                .OnPage(0)
                    .WithId(new SignatureId("signatureId2"))
                    .AtPosition(100, 200)
                    .Build();

            Signature3 = SignatureBuilder.SignatureFor(email3)
                .OnPage(0)
                    .WithId(new SignatureId("signatureId3"))
                    .AtPosition(100, 300)
                    .Build();

            ModifiedSignature = SignatureBuilder.SignatureFor(email1)
                .OnPage(0)
                    .WithId(new SignatureId("signatureId3"))
                    .AtPosition(200, 400)
                    .Build();

            // Adding the signatures
            CreatedPackage = eslClient.GetPackage(packageId);
            eslClient.ApprovalService.AddApproval(CreatedPackage, DocumentId, Signature1);
            eslClient.ApprovalService.AddApproval(CreatedPackage, DocumentId, Signature2);
            eslClient.ApprovalService.AddApproval(CreatedPackage, DocumentId, Signature3);
            AddedSignatures = eslClient.GetPackage(packageId).GetDocument(DocumentName).Signatures;

            // Deleting signature for signer 1
            eslClient.ApprovalService.DeleteApproval(packageId, "documentId", "signatureId1");
            DeletedSignatures = eslClient.GetPackage(packageId).GetDocument(DocumentName).Signatures;

            // Updating the information for the third signature
            CreatedPackage = eslClient.GetPackage(packageId);
            eslClient.ApprovalService.ModifyApproval(CreatedPackage, "documentId", ModifiedSignature);
            ModifiedSignatures = eslClient.GetPackage(packageId).GetDocument(DocumentName).Signatures;

            // Update all the signatures in the document with the provided list of signatures
            UpdatedSignature1 = SignatureBuilder.SignatureFor(email2)
                .OnPage(0)
                .AtPosition(300, 300)
                .WithId(new SignatureId("signatureId2"))
                .WithField(FieldBuilder.SignerName()
                    .AtPosition(100, 100)
                    .OnPage(0))
                .Build();

            UpdatedSignature2 = SignatureBuilder.SignatureFor(email3)
                .OnPage(0)
                .AtPosition(300, 500)
                .WithId(new SignatureId("signatureId3"))
                .Build();

            var signatureList = new List<Signature>();
            signatureList.Add(UpdatedSignature1);
            signatureList.Add(UpdatedSignature2);
            eslClient.ApprovalService.UpdateApprovals(CreatedPackage, DocumentId, signatureList);
            UpdatedSignatures = eslClient.GetPackage(packageId).GetDocument(DocumentName).Signatures;
        }
    }
}

