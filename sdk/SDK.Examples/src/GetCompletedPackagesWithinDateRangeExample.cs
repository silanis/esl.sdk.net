using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class GetCompletedPackagesWithinDateRangeExample : SDKSample
    {
        public static void Main (string[] args)
        {
            new GetCompletedPackagesWithinDateRangeExample().Run();
        }

        public readonly DateTime START_DATE = DateTime.Now;
        public readonly DateTime END_DATE = DateTime.Now;

        public Page<DocumentPackage> draftPackages;
        public Page<DocumentPackage> sentPackages;
        public Page<DocumentPackage> declinedPackages;
        public Page<DocumentPackage> archivedPackages;
        public Page<DocumentPackage> completedPackages;

        override public void Execute()
        {

            draftPackages = getPackagesByPackageStatus(DocumentPackageStatus.DRAFT, START_DATE, END_DATE);
            sentPackages = getPackagesByPackageStatus(DocumentPackageStatus.SENT, START_DATE, END_DATE);
            declinedPackages = getPackagesByPackageStatus(DocumentPackageStatus.DECLINED, START_DATE, END_DATE);
            archivedPackages = getPackagesByPackageStatus(DocumentPackageStatus.ARCHIVED, START_DATE, END_DATE);
            completedPackages = getPackagesByPackageStatus(DocumentPackageStatus.COMPLETED, START_DATE, END_DATE);

            // get the packages completed today
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.DRAFT, getPackagesByPackageStatus(DocumentPackageStatus.DRAFT, START_DATE, END_DATE));
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.SENT, getPackagesByPackageStatus(DocumentPackageStatus.SENT, START_DATE, END_DATE));
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.DECLINED, getPackagesByPackageStatus(DocumentPackageStatus.DECLINED, START_DATE, END_DATE));
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.ARCHIVED, getPackagesByPackageStatus(DocumentPackageStatus.ARCHIVED, START_DATE, END_DATE));
            Console.WriteLine("PackageStatus : {0}, The number of pakcages : {1}", DocumentPackageStatus.COMPLETED, getPackagesByPackageStatus(DocumentPackageStatus.COMPLETED, START_DATE, END_DATE));
        }

        private Page<DocumentPackage> getPackagesByPackageStatus(DocumentPackageStatus packageStatus, DateTime startDate, DateTime endDate) {
            var resultPage = eslClient.PackageService.GetUpdatedPackagesWithinDateRange(packageStatus, new PageRequest(1), startDate, endDate);
            return resultPage;
        }
    }
}

