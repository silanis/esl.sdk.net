using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    [TestFixture]
    public class UsageReportCategoryTest
    {
        [Test]
        public void whenBuildingUsageReportCategoryWithAPIValueACTIVEThenACTIVEUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "ACTIVE";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("ACTIVE");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingUsageReportCategoryWithAPIValueDRAFTThenDRAFTUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "DRAFT";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("DRAFT");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingUsageReportCategoryWithAPIValueSENTThenSENTUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "SENT";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("SENT");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [Test]
        public void whenBuildingUsageReportCategoryWithAPIValueCOMPLETEDThenCOMPLETEDUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "COMPLETED";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("COMPLETED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingUsageReportCategoryWithAPIValueARCHIVEDThenARCHIVEDUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "ARCHIVED";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("ARCHIVED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingUsageReportCategoryWithAPIValueDECLINEDThenDECLINEDUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "DECLINED";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("DECLINED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingUsageReportCategoryWithAPIValueOPTED_OUTThenOPTED_OUTUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "OPTED_OUT";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("OPTED_OUT");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [Test]
        public void whenBuildingUsageReportCategoryWithAPIValueEXPIREDThenEXPIREDUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "EXPIRED";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("EXPIRED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
        [Test]
        public void whenBuildingUsageReportCategoryWithAPIValueTRASHEDThenTRASHEDUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "TRASHED";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("TRASHED");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingUsageReportCategoryWithUnknownAPIValueThenUNRECOGNIZEDUsageReportCategoryIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            Silanis.ESL.SDK.UsageReportCategory classUnderTest = Silanis.ESL.SDK.UsageReportCategory.valueOf("ThisUsageReportCategoryDoesNotExistINSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}   