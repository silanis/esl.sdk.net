using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    public class DocumentPackageStatusTest
    {
        [Test]
        public void whenBuildingDocumentPackageStatusWithAPIValueDRAFTThenDRAFTDocumentPackageStatusIsReturned()
        {
            string expectedSDKValue = "DRAFT";


            DocumentPackageStatus classUnderTest = DocumentPackageStatus.valueOf("DRAFT");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingDocumentPackageStatusWithAPIValueSENTThenSENTDocumentPackageStatusIsReturned()
        {
            string expectedSDKValue = "SENT";


            DocumentPackageStatus classUnderTest = DocumentPackageStatus.valueOf("SENT");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingDocumentPackageStatusWithAPIValueCOMPLETEDThenCOMPLETEDDocumentPackageStatusIsReturned()
        {
            string expectedSDKValue = "COMPLETED";


            DocumentPackageStatus classUnderTest = DocumentPackageStatus.valueOf("COMPLETED");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingDocumentPackageStatusWithAPIValueARCHIVEDThenARCHIVEDDocumentPackageStatusIsReturned()
        {
            string expectedSDKValue = "ARCHIVED";


            DocumentPackageStatus classUnderTest = DocumentPackageStatus.valueOf("ARCHIVED");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingDocumentPackageStatusWithAPIValueDECLINEDThenDECLINEDDocumentPackageStatusIsReturned()
        {
            string expectedSDKValue = "DECLINED";


            DocumentPackageStatus classUnderTest = DocumentPackageStatus.valueOf("DECLINED");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingDocumentPackageStatusWithAPIValueOPTED_OUTThenOPTED_OUTDocumentPackageStatusIsReturned()
        {
            string expectedSDKValue = "OPTED_OUT";


            DocumentPackageStatus classUnderTest = DocumentPackageStatus.valueOf("OPTED_OUT");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingDocumentPackageStatusWithAPIValueEXPIREDThenEXPIREDDocumentPackageStatusIsReturned()
        {
            string expectedSDKValue = "EXPIRED";


            DocumentPackageStatus classUnderTest = DocumentPackageStatus.valueOf("EXPIRED");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingDocumentPackageStatusWithUnknownAPIValueThenUNRECOGNIZEDDocumentPackageStatusIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            DocumentPackageStatus classUnderTest = DocumentPackageStatus.valueOf("ThisDocumentPackageStatusDoesNotExistInSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}

