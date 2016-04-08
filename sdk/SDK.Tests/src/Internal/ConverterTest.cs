using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Internal;

namespace SDK.Tests
{
    [TestClass]
    public class ConverterTest
    {
		public static readonly string jenkinsApiKey = "amVua2luc1VzZXJJZDpCc2JwMnlzSUFEZ0g=";
		public static readonly string expectedJenkinsUID = "jenkinsUserId";

		[TestMethod]
		public void apiKeyToUIDTest()
        {
			var result = Converter.apiKeyToUID(jenkinsApiKey);

			Assert.AreEqual(expectedJenkinsUID, result);
        }
    }
}

