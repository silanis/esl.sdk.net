using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class SignerOrderingExample : SdkSample
	{
        public static void Main (string[] args)
        {
            new SignerOrderingExample().Run();
        }

        public DocumentPackage SavedPackage, AfterReorder;

        override public void Execute()
		{
            var package = PackageBuilder.NewPackageNamed (PackageName)
					.DescribedAs ("This is a signer workflow example")
					.WithSigner(SignerBuilder.NewSignerWithEmail(email1)
					            .WithFirstName("Coco")
					            .WithLastName("Beware")
								.SigningOrder(1))
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email2)
                                .WithFirstName("John")
                                .WithLastName("Smith")
                                .SigningOrder(2))			
					.Build ();

            packageId = eslClient.CreatePackage (package);
            
			Console.WriteLine("Package created, id = " + packageId);

			SavedPackage = EslClient.GetPackage(packageId);

            // Reorder signers
            AfterReorder = eslClient.GetPackage(packageId);
            AfterReorder.GetSigner(email2).SigningOrder = 1;
            AfterReorder.GetSigner(email1).SigningOrder = 2;
            eslClient.PackageService.OrderSigners(AfterReorder);

            AfterReorder = eslClient.GetPackage(packageId);

			Console.WriteLine("Signer order changed");
		}
	}
}