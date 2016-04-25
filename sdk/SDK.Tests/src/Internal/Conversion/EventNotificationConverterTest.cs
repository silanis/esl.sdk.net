using NUnit.Framework;
using System;
using Silanis.ESL.API;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.src.Internal.Conversion;

namespace SDK.Tests
{
    [TestFixture()]
    public class EventNotificationConverterTest
    {
        private Silanis.ESL.SDK.NotificationEvent sdkNotificationEvent1;
        private string apiNotificationEvent1;

        [Test]
        public void ConvertAPIPACKAGE_ACTIVATEToINCOMPLETENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_ACTIVATE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_COMPLETEToPACKAGE_COMPLETENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_COMPLETE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_EXPIREToPACKAGE_EXPIRENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_EXPIRE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_OPT_OUTToPACKAGE_OPT_OUTNotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_OPT_OUT";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_DECLINEToPACKAGE_DECLINENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_DECLINE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPISIGNER_COMPLETEToSIGNER_COMPLETENotificationEvent()
        {
            apiNotificationEvent1 = "SIGNER_COMPLETE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIDOCUMENT_SIGNEDToDOCUMENT_SIGNEDNotificationEvent()
        {
            apiNotificationEvent1 = "DOCUMENT_SIGNED";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIROLE_REASSIGNToROLE_REASSIGNNotificationEvent()
        {
            apiNotificationEvent1 = "ROLE_REASSIGN";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_CREATEToPACKAGE_CREATENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_CREATE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_DEACTIVATEToPACKAGE_DEACTIVATENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_DEACTIVATE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_READY_FOR_COMPLETEToPACKAGE_READY_FOR_COMPLETENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_READY_FOR_COMPLETE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_TRASHToPACKAGE_TRASHNotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_TRASH";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_RESTOREToPACKAGE_RESTORENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_RESTORE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIPACKAGE_DELETEToPACKAGE_DELETENotificationEvent()
        {
            apiNotificationEvent1 = "PACKAGE_DELETE";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(apiNotificationEvent1, sdkNotificationEvent1.getApiValue());
        }

        [Test]
        public void ConvertAPIUnknonwnValueToUnrecognizedNotificationEvent()
        {
            apiNotificationEvent1 = "NEWLY_ADDED_NOTIFICATION_EVENT";
            sdkNotificationEvent1 = new EventNotificationConverter(apiNotificationEvent1).ToSDKNotificationEvent();

            Assert.AreEqual(sdkNotificationEvent1.getApiValue(), apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKINCOMPLETEToAPIINCOMPLETE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_ACTIVATE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_ACTIVATE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKREJECTEDToAPIREJECTED()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_COMPLETE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_COMPLETE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKDELETEToAPIDELETE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_DELETE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_DELETE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKPACKAGE_OPT_OUTToAPIPACKAGE_OPT_OUT()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_OPT_OUT;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_OPT_OUT", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKPACKAGE_DECLINEToAPIPACKAGE_DECLINE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_DECLINE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_DECLINE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKSIGNER_COMPLETEToAPISIGNER_COMPLETE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.SIGNER_COMPLETE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("SIGNER_COMPLETE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKDOCUMENT_SIGNEDToAPIDOCUMENT_SIGNED()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.DOCUMENT_SIGNED;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("DOCUMENT_SIGNED", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKROLE_REASSIGNToAPIROLE_REASSIGN()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.ROLE_REASSIGN;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("ROLE_REASSIGN", apiNotificationEvent1);
        }


        [Test]
        public void ConvertSDKPACKAGE_CREATEToAPIPACKAGE_CREATE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_CREATE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_CREATE", apiNotificationEvent1);
        }


        [Test]
        public void ConvertSDKPACKAGE_DEACTIVATEToAPIPACKAGE_DEACTIVATE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_DEACTIVATE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_DEACTIVATE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKPACKAGE_READY_FOR_COMPLETEToAPIPACKAGE_READY_FOR_COMPLETE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_READY_FOR_COMPLETION;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_READY_FOR_COMPLETE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKPACKAGE_TRASHToAPIPACKAGE_TRASH()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_TRASH;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_TRASH", apiNotificationEvent1);
        }


        [Test]
        public void ConvertSDKPACKAGE_RESTOREToAPIPACKAGE_RESTORE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_RESTORE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_RESTORE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKPACKAGE_DELETEToAPIPACKAGE_DELETE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_DELETE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_DELETE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKKBA_FAILUREToAPIKBA_FAILURE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.KBA_FAILURE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("KBA_FAILURE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKEMAIL_BOUNCEToAPIEMAIL_BOUNCE()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.EMAIL_BOUNCE;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("EMAIL_BOUNCE", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKPACKAGE_ATTACHMENTToAPIPACKAGE_ATTACHMENT()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.PACKAGE_ATTACHMENT;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("PACKAGE_ATTACHMENT", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKSIGNER_LOCKEDToAPISIGNER_LOCKED()
        {
            sdkNotificationEvent1 = Silanis.ESL.SDK.NotificationEvent.SIGNER_LOCKED;
            apiNotificationEvent1 = new EventNotificationConverter(sdkNotificationEvent1).ToAPICallbackEvent();

            Assert.AreEqual("SIGNER_LOCKED", apiNotificationEvent1);
        }

        [Test]
        public void ConvertSDKUnrecognizedNotificationEventToAPIUnknownValue()
        {
            apiNotificationEvent1 = "NEWLY_ADDED_REQUIREMENT_STATUS";
            NotificationEvent unrecognizedNotificationEvent = NotificationEvent.valueOf(apiNotificationEvent1);
            string acutalApiValue = new EventNotificationConverter(unrecognizedNotificationEvent).ToAPICallbackEvent();

            Assert.AreEqual(apiNotificationEvent1, acutalApiValue);
        }

    }
}

