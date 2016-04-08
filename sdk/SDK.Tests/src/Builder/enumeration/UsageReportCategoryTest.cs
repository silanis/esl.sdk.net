
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class UsageReportCategoryTest
    {
        [TestMethod]
        public void whenBuildingUsageReportCategoryWithAPIValueACTIVEThenACTIVEUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "ACTIVE";


            var classUnderTest = UsageReportCategory.valueOf("ACTIVE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingUsageReportCategoryWithAPIValueDRAFTThenDRAFTUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "DRAFT";


            var classUnderTest = UsageReportCategory.valueOf("DRAFT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingUsageReportCategoryWithAPIValueSENTThenSENTUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "SENT";


            var classUnderTest = UsageReportCategory.valueOf("SENT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [TestMethod]
        public void whenBuildingUsageReportCategoryWithAPIValueCOMPLETEDThenCOMPLETEDUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "COMPLETED";


            var classUnderTest = UsageReportCategory.valueOf("COMPLETED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingUsageReportCategoryWithAPIValueARCHIVEDThenARCHIVEDUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "ARCHIVED";


            var classUnderTest = UsageReportCategory.valueOf("ARCHIVED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingUsageReportCategoryWithAPIValueDECLINEDThenDECLINEDUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "DECLINED";


            var classUnderTest = UsageReportCategory.valueOf("DECLINED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingUsageReportCategoryWithAPIValueOPTED_OUTThenOPTED_OUTUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "OPTED_OUT";


            var classUnderTest = UsageReportCategory.valueOf("OPTED_OUT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [TestMethod]
        public void whenBuildingUsageReportCategoryWithAPIValueEXPIREDThenEXPIREDUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "EXPIRED";


            var classUnderTest = UsageReportCategory.valueOf("EXPIRED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [TestMethod]
        public void whenBuildingUsageReportCategoryWithAPIValueTRASHEDThenTRASHEDUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "TRASHED";


            var classUnderTest = UsageReportCategory.valueOf("TRASHED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingUsageReportCategoryWithUnknownAPIValueThenUNRECOGNIZEDUsageReportCategoryIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = UsageReportCategory.valueOf("ThisUsageReportCategoryDoesNotExistINSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   