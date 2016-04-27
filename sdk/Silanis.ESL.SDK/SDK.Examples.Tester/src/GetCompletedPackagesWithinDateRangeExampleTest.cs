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

            AssertEqualsPackageUpdatedDate(example.DraftPackages, example.StartDate, example.EndDate);
            AssertEqualsPackageUpdatedDate(example.SentPackages, example.StartDate, example.EndDate);
            AssertEqualsPackageUpdatedDate(example.DeclinedPackages, example.StartDate, example.EndDate);
            AssertEqualsPackageUpdatedDate(example.ArchivedPackages, example.StartDate, example.EndDate);
            AssertEqualsPackageUpdatedDate(example.CompletedPackages, example.StartDate, example.EndDate);
        }

        private static void AssertEqualsPackageUpdatedDate(IEnumerable<DocumentPackage> packages, DateTime startDate, DateTime endDate) {
            foreach(var draftPackage in packages) {
                Assert.IsTrue(draftPackage.UpdatedDate >= startDate.Date);
                Assert.IsTrue(draftPackage.UpdatedDate < endDate.Date.AddDays(1));
            }
        }
    }
}

