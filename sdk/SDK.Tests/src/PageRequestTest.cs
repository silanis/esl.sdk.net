using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	public class PageRequestTest
	{
		[TestMethod]
		public void CanDetermineNextRequestFromCurrent()
		{
			var first = new PageRequest (1, 10);

			Assert.AreEqual (11, first.Next.From);
			Assert.AreEqual (21, first.Next.Next.From);
		}
	}
}