using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class EventNotificationConverterTest
    {
        private NotificationEvent sdkNotificationEvent1;
        private string apiNotificationEvent1;

        [TestMethod]
        public void ConvertAPIPACKAGE_ACTIVATEToINCOMPLETENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_ACTIVATE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_COMPLETEToPACKAGE_COMPLETENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_COMPLETE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_EXPIREToPACKAGE_EXPIRENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_EXPIRE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_OPT_OUTToPACKAGE_OPT_OUTNotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_OPT_OUT";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_DECLINEToPACKAGE_DECLINENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_DECLINE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPISIGNER_COMPLETEToSIGNER_COMPLETENotificationEvent()
        {
            apiNotificationEvent1 = "SIGNER_COMPLETE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIDOCUMENT_SIGNEDToDOCUMENT_SIGNEDNotificationEvent()
        {
            apiNotificationEvent1 = "DOCUMENT_SIGNED";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIROLE_REASSIGNToROLE_REASSIGNNotificationEvent()
        {
            apiNotificationEvent1 = "ROLE_REASSIGN";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_CREATEToPACKAGE_CREATENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_CREATE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_DEACTIVATEToPACKAGE_DEACTIVATENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_DEACTIVATE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_READY_FOR_COMPLETEToPACKAGE_READY_FOR_COMPLETENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_READY_FOR_COMPLETE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_TRASHToPACKAGE_TRASHNotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_TRASH";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_RESTOREToPACKAGE_RESTORENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_RESTORE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIPACKAGE_DELETEToPACKAGE_DELETENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_DELETE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [TestMethod]
        public void ConvertAPIUnknonwnValueToUnrecognizedNotificationEvent()
        {
            apiNotificationEvent1 = "NEWLY_ADDED_NOTIFICATION_EVENT";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(sdkNotificationEvent1.getApiValue(), apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKINCOMPLETEToAPIINCOMPLETE()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_ACTIVATE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_ACTIVATE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKREJECTEDToAPIREJECTED()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_COMPLETE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_COMPLETE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKDELETEToAPIDELETE()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_DELETE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_DELETE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKPACKAGE_OPT_OUTToAPIPACKAGE_OPT_OUT()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_OPT_OUT;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_OPT_OUT", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKPACKAGE_DECLINEToAPIPACKAGE_DECLINE()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_DECLINE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_DECLINE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKSIGNER_COMPLETEToAPISIGNER_COMPLETE()
        {
            sdkNotificationEvent1 = NotificationEvent.SIGNER_COMPLETE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("SIGNER_COMPLETE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKDOCUMENT_SIGNEDToAPIDOCUMENT_SIGNED()
        {
            sdkNotificationEvent1 = NotificationEvent.DOCUMENT_SIGNED;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("DOCUMENT_SIGNED", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKROLE_REASSIGNToAPIROLE_REASSIGN()
        {
            sdkNotificationEvent1 = NotificationEvent.ROLE_REASSIGN;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("ROLE_REASSIGN", apiNotificationEvent1);
        }


        [TestMethod]
        public void ConvertSDKPACKAGE_CREATEToAPIPACKAGE_CREATE()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_CREATE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_CREATE", apiNotificationEvent1);
        }


        [TestMethod]
        public void ConvertSDKPACKAGE_DEACTIVATEToAPIPACKAGE_DEACTIVATE()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_DEACTIVATE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_DEACTIVATE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKPACKAGE_READY_FOR_COMPLETEToAPIPACKAGE_READY_FOR_COMPLETE()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_READY_FOR_COMPLETION;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_READY_FOR_COMPLETE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKPACKAGE_TRASHToAPIPACKAGE_TRASH()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_TRASH;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_TRASH", apiNotificationEvent1);
        }


        [TestMethod]
        public void ConvertSDKPACKAGE_RESTOREToAPIPACKAGE_RESTORE()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_RESTORE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_RESTORE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKPACKAGE_DELETEToAPIPACKAGE_DELETE()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_DELETE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_DELETE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKKBA_FAILUREToAPIKBA_FAILURE()
        {
            sdkNotificationEvent1 = NotificationEvent.KBA_FAILURE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("KBA_FAILURE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKEMAIL_BOUNCEToAPIEMAIL_BOUNCE()
        {
            sdkNotificationEvent1 = NotificationEvent.EMAIL_BOUNCE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("EMAIL_BOUNCE", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKPACKAGE_ATTACHMENTToAPIPACKAGE_ATTACHMENT()
        {
            sdkNotificationEvent1 = NotificationEvent.PACKAGE_ATTACHMENT;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_ATTACHMENT", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKSIGNER_LOCKEDToAPISIGNER_LOCKED()
        {
            sdkNotificationEvent1 = NotificationEvent.SIGNER_LOCKED;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("SIGNER_LOCKED", apiNotificationEvent1);
        }

        [TestMethod]
        public void ConvertSDKUnrecognizedNotificationEventToAPIUnknownValue()
        {
            apiNotificationEvent1 = "NEWLY_ADDED_REQUIREMENT_STATUS";
            var unrecognizedNotificationEvent = NotificationEvent.valueOf(apiNotificationEvent1);
            var acutalApiValue = new EventNotificationConverter(unrecognizedNotificationEvent).ToAPICallbackEvent();

            Assert.AreEqual(apiNotificationEvent1, acutalApiValue);
        }

    }
}

