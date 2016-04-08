using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
    public class CreatePackageWithoutDocumentExample : SDKSample
    {
        public static void Main(string[] args)
        {
            new CreatePackageWithoutDocumentExample().Run();
        }

        override public void Execute()
        {
            var superDuperPackage =
                PackageBuilder.NewPackageNamed(PackageName)
                    .Build();

            packageId = eslClient.CreatePackage(superDuperPackage);
            retrievedPackage = eslClient.GetPackage(packageId);
        }
    }
}

