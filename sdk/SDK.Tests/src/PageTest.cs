using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	public class PageTest
	{
		[Test]
		public void KnowsIfMorePagesAreAvailable()
		{
			PageRequest initial = new PageRequest (1);
			Page<object> page = new Page<object> (null, 23, initial);

			Assert.IsTrue (page.HasNextPage());

			page = new Page<object> (null, 23, initial.Next);
			Assert.IsTrue (page.HasNextPage());

			page = new Page<object> (null, 23, initial.Next.Next);
			Assert.IsFalse (page.HasNextPage());
		}
	}
}