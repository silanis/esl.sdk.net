using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	[TestFixture]
	public class PackageStatusConverterTest
	{
		private Silanis.ESL.SDK.DocumentPackageStatus sdkPackageStatus1;
		private string apiPackageStatus1;

		[Test]
		public void ConvertAPIToSDK()
		{
            apiPackageStatus1 = DocumentPackageStatus.EXPIRED.getApiValue();
			sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

			Assert.AreEqual(sdkPackageStatus1.ToString(), apiPackageStatus1.ToString());
		}

        [Test]
        public void ConvertAPIDraftToSDKDraft()
        {
            string expectedSDKStatus = "DRAFT";
            apiPackageStatus1 = DocumentPackageStatus.DRAFT.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [Test]
        public void ConvertAPISentDraftToSDKSent()
        {
            string expectedSDKStatus = "SENT";
            apiPackageStatus1 = DocumentPackageStatus.SENT.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [Test]
        public void ConvertAPICompletedToSDKCompleted()
        {
            string expectedSDKStatus = "COMPLETED";
            apiPackageStatus1 = DocumentPackageStatus.COMPLETED.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [Test]
        public void ConvertAPIArchivedToSDKArchived()
        {
            string expectedSDKStatus = "ARCHIVED";
            apiPackageStatus1 = DocumentPackageStatus.ARCHIVED.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [Test]
        public void ConvertAPIDeclinedToSDKDeclined()
        {
            string expectedSDKStatus = "DECLINED";
            apiPackageStatus1 = DocumentPackageStatus.DECLINED.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [Test]
        public void ConvertAPIOpted_OutToSDKOpted_Out()
        {
            string expectedSDKStatus = "OPTED_OUT";
            apiPackageStatus1 = DocumentPackageStatus.OPTED_OUT.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

        [Test]
        public void ConvertAPIExpiredToSDKExpired()
        {
            string expectedSDKStatus = "EXPIRED";
            apiPackageStatus1 = DocumentPackageStatus.EXPIRED.getApiValue();
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(expectedSDKStatus, sdkPackageStatus1.ToString());
        }

		[Test]
		public void ConvertSDKToAPI()
		{
            sdkPackageStatus1 = DocumentPackageStatus.DRAFT;
			apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

			Assert.AreEqual(apiPackageStatus1.ToString(), sdkPackageStatus1.ToString());
		}

        [Test]
        public void ConvertSDKDraftToAPIDraft()
        {
            string expectedAPIValue = "DRAFT";
            sdkPackageStatus1 = DocumentPackageStatus.DRAFT;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [Test]
        public void ConvertSDKSentToAPISent()
        {
            string expectedAPIValue = "SENT";
            sdkPackageStatus1 = DocumentPackageStatus.SENT;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [Test]
        public void ConvertCompletedToAPICompleted()
        {
            string expectedAPIValue = "COMPLETED";
            sdkPackageStatus1 = DocumentPackageStatus.COMPLETED;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [Test]
        public void ConvertSDKArchivedToAPIArchived()
        {
            string expectedAPIValue = "ARCHIVED";
            sdkPackageStatus1 = DocumentPackageStatus.ARCHIVED;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [Test]
        public void ConvertSDKDeclinedToAPIDeclined()
        {
            string expectedAPIValue = "DECLINED";
            sdkPackageStatus1 = DocumentPackageStatus.DECLINED;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }


        [Test]
        public void ConvertSDKOpted_OutToAPIOpted_Out()
        {
            string expectedAPIValue = "OPTED_OUT";
            sdkPackageStatus1 = DocumentPackageStatus.OPTED_OUT;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [Test]
        public void ConvertSDKExpiredToAPIExpired()
        {
            string expectedAPIValue = "EXPIRED";
            sdkPackageStatus1 = DocumentPackageStatus.EXPIRED;
            apiPackageStatus1 = new PackageStatusConverter(sdkPackageStatus1).ToAPIPackageStatus();

            Assert.AreEqual(expectedAPIValue, apiPackageStatus1);
        }

        [Test]
        public void ConvertAPIUnknonwnValueToUnrecognizedDocumentPackageStatus()
        {
            apiPackageStatus1 = "NEWLY_ADDED_AUTHENTICATION_METHOD";
            sdkPackageStatus1 = new PackageStatusConverter(apiPackageStatus1).ToSDKPackageStatus();

            Assert.AreEqual(sdkPackageStatus1.getApiValue(), apiPackageStatus1);
        }

        [Test]
        public void ConvertSDKUnrecognizedPackageStatusToAPIUnknownValue()
        {
            apiPackageStatus1 = "NEWLY_ADDED_AUTHENTICATION_METHOD";
            DocumentPackageStatus unrecognizedSDKDocumentPackageStatus = DocumentPackageStatus.valueOf(apiPackageStatus1);
            string acutalAPIPackageStatus = new PackageStatusConverter(unrecognizedSDKDocumentPackageStatus).ToAPIPackageStatus();

            Assert.AreEqual(apiPackageStatus1, acutalAPIPackageStatus);
        }

	}
}

