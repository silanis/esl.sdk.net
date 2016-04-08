using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    public class NotificationEventTest
    {
        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValueDRAFTThenDRAFTNotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_ACTIVATE";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_ACTIVATE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_COMPLETEThenPACKAGE_COMPLETENotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_COMPLETE";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_COMPLETE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_DELETEThenPACKAGE_DELETENotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_DELETE";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_DELETE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_EXPIREThenPACKAGE_EXPIRENotificationEventIsReturned()
        {
            var expectedAPIValue = "PACKAGE_EXPIRE";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_EXPIRE");
            var actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_OPT_OUTThenPACKAGE_OPT_OUTNotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_OPT_OUT";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_OPT_OUT");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_DECLINEThenPACKAGE_DECLINENotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_DECLINE";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_DECLINE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValueSIGNER_COMPLETEThenSIGNER_COMPLETENotificationEventIsReturned()
        {
            var expectedSDKValue = "SIGNER_COMPLETE";


            var classUnderTest = NotificationEvent.valueOf("SIGNER_COMPLETE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValueDOCUMENT_SIGNEDThenDOCUMENT_SIGNEDNotificationEventIsReturned()
        {
            var expectedSDKValue = "DOCUMENT_SIGNED";


            var classUnderTest = NotificationEvent.valueOf("DOCUMENT_SIGNED");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValueROLE_REASSIGNThenROLE_REASSIGNNotificationEventIsReturned()
        {
            var expectedSDKValue = "ROLE_REASSIGN";


            var classUnderTest = NotificationEvent.valueOf("ROLE_REASSIGN");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_CREATEThenPACKAGE_CREATENotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_CREATE";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_CREATE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_DEACTIVATEThenPACKAGE_DEACTIVATENotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_DEACTIVATE";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_DEACTIVATE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_READY_FOR_COMPLETEThenPACKAGE_READY_FOR_COMPLETIONNotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_READY_FOR_COMPLETION";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_READY_FOR_COMPLETE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        
        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_TRASHThenPACKAGE_TRASHNotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_TRASH";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_TRASH");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        
        [TestMethod]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_RESTOREThenPACKAGE_RESTORENotificationEventIsReturned()
        {
            var expectedSDKValue = "PACKAGE_RESTORE";


            var classUnderTest = NotificationEvent.valueOf("PACKAGE_RESTORE");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [TestMethod]
        public void whenBuildingNotificationEventWithUnknownAPIValueThenUNRECOGNIZEDNotificationEventIsReturned()
        {
            var expectedSDKValue = "UNRECOGNIZED";


            var classUnderTest = NotificationEvent.valueOf("ThisNotificationEventDoesNotExistInSDK");
            var actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}

