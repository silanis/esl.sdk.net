using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class SignerOrderingExample : SDKSample
	{
        public static void Main (string[] args)
        {
            new SignerOrderingExample().Run();
        }

        public DocumentPackage savedPackage, afterReorder;

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

			savedPackage = EslClient.GetPackage(packageId);

            // Reorder signers
            afterReorder = eslClient.GetPackage(packageId);
            afterReorder.GetSigner(email2).SigningOrder = 1;
            afterReorder.GetSigner(email1).SigningOrder = 2;
            eslClient.PackageService.OrderSigners(afterReorder);

            afterReorder = eslClient.GetPackage(packageId);

			Console.WriteLine("Signer order changed");
		}
	}
}