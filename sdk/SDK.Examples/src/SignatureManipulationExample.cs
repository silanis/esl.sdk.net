using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;

namespace SDK.Examples
{
    public class SignatureManipulationExample : SDKSample
    {
        public readonly string DOCUMENT_NAME = "SignatureManipulationExample";

        private string documentId = "documentId";

        public Signature signature1;
        public Signature signature2;
        public Signature signature3;
        public Signature modifiedSignature;
        public Signature updatedSignature1;
        public Signature updatedSignature2;

        public List<Signature> addedSignatures;
        public List<Signature> deletedSignatures;
        public List<Signature> modifiedSignatures;
        public List<Signature> updatedSignatures;

        public DocumentPackage createdPackage;

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
                    .WithDocument(DocumentBuilder.NewDocumentNamed(DOCUMENT_NAME)
                                  .WithId("documentId")
                                  .FromStream(fileStream1, DocumentType.PDF)
            )

                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);

            signature1 = SignatureBuilder.SignatureFor(email1)
                .OnPage(0)
                    .WithId(new SignatureId("signatureId1"))
                    .AtPosition(100, 100)
                    .Build();

            signature2 = SignatureBuilder.SignatureFor(email2)
                .OnPage(0)
                    .WithId(new SignatureId("signatureId2"))
                    .AtPosition(100, 200)
                    .Build();

            signature3 = SignatureBuilder.SignatureFor(email3)
                .OnPage(0)
                    .WithId(new SignatureId("signatureId3"))
                    .AtPosition(100, 300)
                    .Build();

            modifiedSignature = SignatureBuilder.SignatureFor(email1)
                .OnPage(0)
                    .WithId(new SignatureId("signatureId3"))
                    .AtPosition(200, 400)
                    .Build();

            // Adding the signatures
            createdPackage = eslClient.GetPackage(packageId);
            eslClient.ApprovalService.AddApproval(createdPackage, documentId, signature1);
            eslClient.ApprovalService.AddApproval(createdPackage, documentId, signature2);
            eslClient.ApprovalService.AddApproval(createdPackage, documentId, signature3);
            addedSignatures = eslClient.GetPackage(packageId).GetDocument(DOCUMENT_NAME).Signatures;

            // Deleting signature for signer 1
            eslClient.ApprovalService.DeleteApproval(packageId, "documentId", "signatureId1");
            deletedSignatures = eslClient.GetPackage(packageId).GetDocument(DOCUMENT_NAME).Signatures;

            // Updating the information for the third signature
            createdPackage = eslClient.GetPackage(packageId);
            eslClient.ApprovalService.ModifyApproval(createdPackage, "documentId", modifiedSignature);
            modifiedSignatures = eslClient.GetPackage(packageId).GetDocument(DOCUMENT_NAME).Signatures;

            // Update all the signatures in the document with the provided list of signatures
            updatedSignature1 = SignatureBuilder.SignatureFor(email2)
                .OnPage(0)
                .AtPosition(300, 300)
                .WithId(new SignatureId("signatureId2"))
                .WithField(FieldBuilder.SignerName()
                    .AtPosition(100, 100)
                    .OnPage(0))
                .Build();

            updatedSignature2 = SignatureBuilder.SignatureFor(email3)
                .OnPage(0)
                .AtPosition(300, 500)
                .WithId(new SignatureId("signatureId3"))
                .Build();

            var signatureList = new List<Signature>();
            signatureList.Add(updatedSignature1);
            signatureList.Add(updatedSignature2);
            eslClient.ApprovalService.UpdateApprovals(createdPackage, documentId, signatureList);
            updatedSignatures = eslClient.GetPackage(packageId).GetDocument(DOCUMENT_NAME).Signatures;
        }
    }
}

