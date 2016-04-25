using System;
using System.IO;
using System.Globalization;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class PackageArchiveExample : SDKSample
	{
        public static void Main (string[] args)
        {
			new PackageArchiveExample().Run();
        }

        override public void Execute()
        {
			Page<DocumentPackage> packages = eslClient.PackageService.GetPackages (DocumentPackageStatus.COMPLETED, new PageRequest(1, 20));
			DocumentPackage completedPackage = packages.NumberOfElements > 0 ? packages.Results[0] : null;

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