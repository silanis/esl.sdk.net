using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestFixture()]
    public class DateHelperTest
    {
		private readonly string expectedDateInUTC = "2010-01-01T12:30:00Z";

		[Test()]
        public void TestCase()
        {
			DateTime date = new DateTime(2010, 1, 1, 7, 30, 0);

			String result = DateHelper.dateToIsoUtcFormat(date);

			Assert.AreEqual(result, expectedDateInUTC);
        }
    }
}

