using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class DateHelperTest
    {
		private readonly string expectedDateInUTC = "2010-01-01T12:30:00Z";

		[TestMethod]
        public void TestCase()
        {
			var date = new DateTime(2010, 1, 1, 7, 30, 0);

			var result = DateHelper.dateToIsoUtcFormat(date);

			Assert.AreEqual(result, expectedDateInUTC);
        }
    }
}

