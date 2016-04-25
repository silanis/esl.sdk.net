using NUnit.Framework;
using System;
using Silanis.ESL.SDK.Internal;

namespace SDK.Tests
{
    [TestFixture()]
    public class ConverterTest
    {
		public static readonly string jenkinsApiKey = "amVua2luc1VzZXJJZDpCc2JwMnlzSUFEZ0g=";
		public static readonly string expectedJenkinsUID = "jenkinsUserId";

		[Test()]
		public void apiKeyToUIDTest()
        {
			string result = Converter.apiKeyToUID(jenkinsApiKey);

			Assert.AreEqual(expectedJenkinsUID, result);
        }
    }
}

