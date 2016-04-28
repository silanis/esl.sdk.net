using System;
using System.Collections.Generic;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class ContactsExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new ContactsExample().Run();
        }

        public Sender SignerForPackage;
        public IDictionary<string, Sender> BeforeContacts;
        public IDictionary<string, Sender> AfterContacts;

        override public void Execute()
        {
            email2 = GetRandomEmail();

            // Get the contacts (Senders) from account
            BeforeContacts = eslClient.AccountService.GetContacts();
            SignerForPackage = BeforeContacts[email1];

            // Create package with signer using information from contacts
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                    .DescribedAs("This is a package created using the e-SignLive SDK")
                    .ExpiresOn(DateTime.Now.AddMonths(100))
                    .WithEmailMessage("This message should be delivered to all signers")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                        .WithFirstName(SignerForPackage.FirstName)
                        .WithLastName(SignerForPackage.LastName)
                        .WithTitle(SignerForPackage.Title)
                        .WithCompany(SignerForPackage.Company))
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

            AfterContacts = eslClient.AccountService.GetContacts();
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

