using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	[TestClass]
	public class PackageStatusConverterTest
	{
		private DocumentPackageStatus sdkPackageStatus1;
		private string apiPackageStatus1;

		[TestMethod]
		public void ConvertAPIToSDK()
		{
            apiPackageStatus1 = DocumentPackageStatus.EXPIRED.getApiValue();
			sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

			Assert.AreEqual(sdkPackageStatus1.ToString(), apiPackageStatus1.ToString());
		}

        [TestMethod]
        public void ConvertAPIDraftToSDKDraft()
        {
            var expectedSDKStatus = "DRAFT";
            apiPackageStatus1 = DocumentPackageStatus.DRAFT.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [TestMethod]
        public void ConvertAPISentDraftToSDKSent()
        {
            var expectedSDKStatus = "SENT";
            apiPackageStatus1 = DocumentPackageStatus.SENT.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [TestMethod]
        public void ConvertAPICompletedToSDKCompleted()
        {
            var expectedSDKStatus = "COMPLETED";
            apiPackageStatus1 = DocumentPackageStatus.COMPLETED.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [TestMethod]
        public void ConvertAPIArchivedToSDKArchived()
        {
            var expectedSDKStatus = "ARCHIVED";
            apiPackageStatus1 = DocumentPackageStatus.ARCHIVED.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [TestMethod]
        public void ConvertAPIDeclinedToSDKDeclined()
        {
            var expectedSDKStatus = "DECLINED";
            apiPackageStatus1 = DocumentPackageStatus.DECLINED.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [TestMethod]
        public void ConvertAPIOpted_OutToSDKOpted_Out()
        {
            var expectedSDKStatus = "OPTED_OUT";
            apiPackageStatus1 = DocumentPackageStatus.OPTED_OUT.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [TestMethod]
        public void ConvertAPIExpiredToSDKExpired()
        {
            var expectedSDKStatus = "EXPIRED";
            apiPackageStatus1 = DocumentPackageStatus.EXPIRED.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

		[TestMethod]
		public void ConvertSDKToAPI()
		{
            sdkPackageStatus1 = DocumentPackageStatus.DRAFT;
			apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

			Assert.AreEqual(apiPackageStatus1.ToString(), sdkPackageStatus1.ToString());
		}

        [TestMethod]
        public void ConvertSDKDraftToAPIDraft()
        {
            var expectedAPIValue = "DRAFT";
            sdkPackageStatus1 = DocumentPackageStatus.DRAFT;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [TestMethod]
        public void ConvertSDKSentToAPISent()
        {
            var expectedAPIValue = "SENT";
            sdkPackageStatus1 = DocumentPackageStatus.SENT;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [TestMethod]
        public void ConvertCompletedToAPICompleted()
        {
            var expectedAPIValue = "COMPLETED";
            sdkPackageStatus1 = DocumentPackageStatus.COMPLETED;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [TestMethod]
        public void ConvertSDKArchivedToAPIArchived()
        {
            var expectedAPIValue = "ARCHIVED";
            sdkPackageStatus1 = DocumentPackageStatus.ARCHIVED;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [TestMethod]
        public void ConvertSDKDeclinedToAPIDeclined()
        {
            var expectedAPIValue = "DECLINED";
            sdkPackageStatus1 = DocumentPackageStatus.DECLINED;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }


        [TestMethod]
        public void ConvertSDKOpted_OutToAPIOpted_Out()
        {
            var expectedAPIValue = "OPTED_OUT";
            sdkPackageStatus1 = DocumentPackageStatus.OPTED_OUT;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [TestMethod]
        public void ConvertSDKExpiredToAPIExpired()
        {
            var expectedAPIValue = "EXPIRED";
            sdkPackageStatus1 = DocumentPackageStatus.EXPIRED;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [TestMethod]
        public void ConvertAPIUnknonwnValueToUnrecognizedDocumentPackageStatus()
        {
            apiPackageStatus1 = "NEWLY_ADDED_AUTHENTICATION_METHOD";
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(sdkPackageStatus1.getApiValue(), apiPackageStatus1);
        }

        [TestMethod]
        public void ConvertSDKUnrecognizedPackageStatusToAPIUnknownValue()
        {
            apiPackageStatus1 = "NEWLY_ADDED_AUTHENTICATION_METHOD";
            var unrecognizedSDKDocumentPackageStatus = DocumentPackageStatus.valueOf(apiPackageStatus1);
            var acutalAPIPackageStatus = new PackageStatusConverter(unrecognizedSDKDocumentPackageStatus).ToAPIPackageStatus();

            Assert.AreEqual(apiPackageStatus1, acutalAPIPackageStatus);
        }

	}
}

