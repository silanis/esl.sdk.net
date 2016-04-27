using System;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class PackageTrashExample : SdkSample
	{
        public static void Main (string[] args)
        {
			new PackageTrashExample().Run();
        }

        override public void Execute()
        {
            var superDuperPackage = PackageBuilder.NewPackageNamed(PackageName)
				.DescribedAs( "This package should be trashed" )					                                                           
                    .Build();

            var package = eslClient.CreatePackage( superDuperPackage );
            
			Console.WriteLine("packageId = " + package);

			eslClient.PackageService.Trash(package);

			Console.WriteLine("Package {0} should be trashed", package);
        }
	}
}