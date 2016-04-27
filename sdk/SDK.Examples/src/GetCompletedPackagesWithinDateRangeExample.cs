using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class GetCompletedPackagesWithinDateRangeExample : SdkSample
    {
        public static void Main (string[] args)
        {
            new GetCompletedPackagesWithinDateRangeExample().Run();
        }

        public readonly DateTime StartDate = DateTime.Now;
        public readonly DateTime EndDate = DateTime.Now;

        public Page<DocumentPackage> DraftPackages;
        public Page<DocumentPackage> SentPackages;
        public Page<DocumentPackage> DeclinedPackages;
        public Page<DocumentPackage> ArchivedPackages;
        public Page<DocumentPackage> CompletedPackages;

        override public void Execute()
        {

            DraftPackages = GetPackagesByPackageStatus(DocumentPackageStatus.DRAFT, StartDate, EndDate);
            SentPackages = GetPackagesByPackageStatus(DocumentPackageStatus.SENT, StartDate, EndDate);
            DeclinedPackages = GetPackagesByPackageStatus(DocumentPackageStatus.DECLINED, StartDate, EndDate);
            ArchivedPackages = GetPackagesByPackageStatus(DocumentPackageStatus.ARCHIVED, StartDate, EndDate);
            CompletedPackages = GetPackagesByPackageStatus(DocumentPackageStatus.COMPLETED, StartDate, EndDate);

            // get the packages completed today
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.DRAFT, GetPackagesByPackageStatus(DocumentPackageStatus.DRAFT, StartDate, EndDate));
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.SENT, GetPackagesByPackageStatus(DocumentPackageStatus.SENT, StartDate, EndDate));
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.DECLINED, GetPackagesByPackageStatus(DocumentPackageStatus.DECLINED, StartDate, EndDate));
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.ARCHIVED, GetPackagesByPackageStatus(DocumentPackageStatus.ARCHIVED, StartDate, EndDate));
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.COMPLETED, GetPackagesByPackageStatus(DocumentPackageStatus.COMPLETED, StartDate, EndDate));
        }

        private Page<DocumentPackage> GetPackagesByPackageStatus(DocumentPackageStatus packageStatus, DateTime startDate, DateTime endDate) {
            var resultPage = eslClient.PackageService.GetUpdatedPackagesWithinDateRange(packageStatus, new PageRequest(1), startDate, endDate);
            return resultPage;
        }
    }
}

