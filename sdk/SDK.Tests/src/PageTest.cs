using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class PageTest
	{
		[TestMethod]
		public void KnowsIfMorePagesAreAvailable()
		{
			var initial = new PageRequest (1);
			var page = new Page<object> (null, 23, initial);

			Assert.IsTrue (page.HasNextPage());

			page = new Page<object> (null, 23, initial.Next);
			Assert.IsTrue (page.HasNextPage());

			page = new Page<object> (null, 23, initial.Next.Next);
			Assert.IsFalse (page.HasNextPage());
		}
	}
}