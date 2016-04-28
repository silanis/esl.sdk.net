using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    /// <summary>
    /// Example of how to configure the SMS authentication method for a signer
    /// </summary>
    public class SignerSmsAuthenticationExample : SdkSample
    {
        public static void Main(string[] args)
        {
            new SignerSmsAuthenticationExample().Run();
        }

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
                .DescribedAs("This is a SMS authentication example")
                .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                    .WithFirstName("John")
                    .WithLastName("Smith")
                    .WithSMSSentTo(sms1))
                .WithDocument(DocumentBuilder.NewDocumentNamed("First Document")
                    .FromStream(fileStream1, DocumentType.PDF)
                    .WithSignature(SignatureBuilder.SignatureFor(email1)
                        .OnPage(0)
                        .AtPosition(199, 100)))
                .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);		
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

