using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestClass]
    public class GetCompletedPackagesWithinDateRangeExampleTest
    {
        [TestMethod]
        public void Verify() {
            var example = new GetCompletedPackagesWithinDateRangeExample();
            example.Run();

            AssertEqualsPackageUpdatedDate(example.draftPackages, example.START_DATE, example.END_DATE);
            AssertEqualsPackageUpdatedDate(example.sentPackages, example.START_DATE, example.END_DATE);
            AssertEqualsPackageUpdatedDate(example.declinedPackages, example.START_DATE, example.END_DATE);
            AssertEqualsPackageUpdatedDate(example.archivedPackages, example.START_DATE, example.END_DATE);
            AssertEqualsPackageUpdatedDate(example.completedPackages, example.START_DATE, example.END_DATE);
        }

        private static void AssertEqualsPackageUpdatedDate(IEnumerable<DocumentPackage> packages, DateTime startDate, DateTime endDate) {
            foreach(var draftPackage in packages) {
                Assert.IsTrue(draftPackage.UpdatedDate >= startDate.Date);
                Assert.IsTrue(draftPackage.UpdatedDate < endDate.Date.AddDays(1));
            }
        }
    }
}

