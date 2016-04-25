using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
    public class NotificationEventTest
    {
        [Test]
        public void whenBuildingNotificationEventWithAPIValueDRAFTThenDRAFTNotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_ACTIVATE";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_ACTIVATE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_COMPLETEThenPACKAGE_COMPLETENotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_COMPLETE";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_COMPLETE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_DELETEThenPACKAGE_DELETENotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_DELETE";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_DELETE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_EXPIREThenPACKAGE_EXPIRENotificationEventIsReturned()
        {
            string expectedAPIValue = "PACKAGE_EXPIRE";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_EXPIRE");
            string actualAPIValue = classUnderTest.getApiValue();


            Assert.AreEqual(expectedAPIValue, actualAPIValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_OPT_OUTThenPACKAGE_OPT_OUTNotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_OPT_OUT";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_OPT_OUT");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_DECLINEThenPACKAGE_DECLINENotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_DECLINE";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_DECLINE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValueSIGNER_COMPLETEThenSIGNER_COMPLETENotificationEventIsReturned()
        {
            string expectedSDKValue = "SIGNER_COMPLETE";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("SIGNER_COMPLETE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValueDOCUMENT_SIGNEDThenDOCUMENT_SIGNEDNotificationEventIsReturned()
        {
            string expectedSDKValue = "DOCUMENT_SIGNED";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("DOCUMENT_SIGNED");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValueROLE_REASSIGNThenROLE_REASSIGNNotificationEventIsReturned()
        {
            string expectedSDKValue = "ROLE_REASSIGN";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("ROLE_REASSIGN");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_CREATEThenPACKAGE_CREATENotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_CREATE";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_CREATE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_DEACTIVATEThenPACKAGE_DEACTIVATENotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_DEACTIVATE";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_DEACTIVATE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_READY_FOR_COMPLETEThenPACKAGE_READY_FOR_COMPLETIONNotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_READY_FOR_COMPLETION";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_READY_FOR_COMPLETE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        
        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_TRASHThenPACKAGE_TRASHNotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_TRASH";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_TRASH");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        
        [Test]
        public void whenBuildingNotificationEventWithAPIValuePACKAGE_RESTOREThenPACKAGE_RESTORENotificationEventIsReturned()
        {
            string expectedSDKValue = "PACKAGE_RESTORE";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("PACKAGE_RESTORE");
            string actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }

        [Test]
        public void whenBuildingNotificationEventWithUnknownAPIValueThenUNRECOGNIZEDNotificationEventIsReturned()
        {
            string expectedSDKValue = "UNRECOGNIZED";


            NotificationEvent classUnderTest = NotificationEvent.valueOf("ThisNotificationEventDoesNotExistInSDK");
            String actualSDKValue = classUnderTest.getSdkValue();


            Assert.AreEqual(expectedSDKValue, actualSDKValue);
        }
    }
}

