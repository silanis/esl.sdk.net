using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
	public class PackageArchiveExample : SdkSample
	{
        public static void Main (string[] args)
        {
			new PackageArchiveExample().Run();
        }

        override public void Execute()
        {
			var packages = eslClient.PackageService.GetPackages (DocumentPackageStatus.COMPLETED, new PageRequest(1, 20));
			var completedPackage = packages.NumberOfElements > 0 ? packages.Results[0] : null;

			if (completedPackage != null)
			{
				eslClient.PackageService.Archive(completedPackage.Id);
				Console.WriteLine("Package {0} should be archived", completedPackage.Id);
			}
			else
			{
				Console.WriteLine("No package was archived");
			}
        }
	}
}