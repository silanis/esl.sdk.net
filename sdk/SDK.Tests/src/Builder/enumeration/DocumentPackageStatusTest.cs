using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    public class DocumentPackageStatusTest
    {
        [TestMethod]
        public void WhenBuildingDocumentPackageStatusWithApiValueDraftThenDraftDocumentPackageStatusIsReturned()
        {
            var expectedSDKValue = "DRAFT";


            var classUnderTest = DocumentPackageStatus.valueOf("DRAFT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void WhenBuildingDocumentPackageStatusWithApiValueSentThenSentDocumentPackageStatusIsReturned()
        {
            var expectedSDKValue = "SENT";


            var classUnderTest = DocumentPackageStatus.valueOf("SENT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void WhenBuildingDocumentPackageStatusWithApiValueCompletedThenCompletedDocumentPackageStatusIsReturned()
        {
            var expectedSDKValue = "COMPLETED";


            var classUnderTest = DocumentPackageStatus.valueOf("COMPLETED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void WhenBuildingDocumentPackageStatusWithApiValueArchivedThenArchivedDocumentPackageStatusIsReturned()
        {
            var expectedSDKValue = "ARCHIVED";


            var classUnderTest = DocumentPackageStatus.valueOf("ARCHIVED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void WhenBuildingDocumentPackageStatusWithApiValueDeclinedThenDeclinedDocumentPackageStatusIsReturned()
        {
            const string expectedSdkValue = "DECLINED";


            var classUnderTest = DocumentPackageStatus.valueOf("DECLINED");
            var actualSdkValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSdkValue, actualSdkValue);
        }

        [TestMethod]
        public void whenBuildingDocumentPackageStatusWithAPIValueOPTED_OUTThenOPTED_OUTDocumentPackageStatusIsReturned()
        {
            const string expectedSdkValue = "OPTED_OUT";


            var classUnderTest = DocumentPackageStatus.valueOf("OPTED_OUT");
            var actualSdkValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSdkValue, actualSdkValue);
        }

        [TestMethod]
        public void whenBuildingDocumentPackageStatusWithAPIValueEXPIREDThenEXPIREDDocumentPackageStatusIsReturned()
        {
            var expectedSDKValue = "EXPIRED";


            var classUnderTest = DocumentPackageStatus.valueOf("EXPIRED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingDocumentPackageStatusWithUnknownAPIValueThenUNRECOGNIZEDDocumentPackageStatusIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = DocumentPackageStatus.valueOf("ThisDocumentPackageStatusDoesNotExistInSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}

