using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	public class PageRequestTest
	{
		[Test]
		public void CanDetermineNextRequestFromCurrent()
		{
			PageRequest first = new PageRequest (1, 10);

			Assert.AreEqual (11, first.Next.From);
			Assert.AreEqual (21, first.Next.Next.From);
		}
	}
}