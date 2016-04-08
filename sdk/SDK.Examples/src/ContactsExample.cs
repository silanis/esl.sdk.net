using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class ContactsExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new ContactsExample().Run();
        }

        public Sender signerForPackage;
        public IDictionary<string, Sender> beforeContacts;
        public IDictionary<string, Sender> afterContacts;

        override public void Execute()
        {
            this.email2 = GetRandomEmail();

            // Get the contacts (Senders) from account
            beforeContacts = eslClient.AccountService.GetContacts();
            signerForPackage = beforeContacts[email1];

            // Create package with signer using information from contacts
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                    .DescribedAs("This is a package created using the e-SignLive SDK")
                    .ExpiresOn(DateTime.Now.AddMonths(100))
                    .WithEmailMessage("This message should be delivered to all signers")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                        .WithFirstName(signerForPackage.FirstName)
                        .WithLastName(signerForPackage.LastName)
                        .WithTitle(signerForPackage.Title)
                        .WithCompany(signerForPackage.Company))
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                        .WithFirstName("John")
                        .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                        .FromStream(fileStream1, DocumentType.PDF)
                        .WithSignature(SignatureBuilder.SignatureFor(email1)
                            .OnPage(0)
                            .AtPosition(100, 100)))
                    .Build();

            packageId = eslClient.CreatePackageOneStep(superDuperPackage);
            eslClient.SendPackage(packageId);

            afterContacts = eslClient.AccountService.GetContacts();
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

