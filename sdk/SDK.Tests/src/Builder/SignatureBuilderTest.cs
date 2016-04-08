using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
    [TestClass]
    public class SignatureBuilderTest
	{
		private static double TOLERANCE = 0.01d;

		[TestMethod]
		public void BuildCaptureForGroup()
		{
			var groupId = new GroupId("myGroupId");
			var signature = SignatureBuilder.CaptureFor(groupId).Build();

			Assert.AreEqual(groupId, signature.GroupId);
			Assert.IsNull(signature.SignerEmail);
			Assert.AreEqual(SignatureStyle.HAND_DRAWN, signature.Style);
		}

		[TestMethod]
		public void BuildSignatureForGroup()
		{
			var groupId = new GroupId("myGroupId");
			var signature = SignatureBuilder.SignatureFor(groupId).Build();

			Assert.AreEqual(groupId, signature.GroupId);
			Assert.IsNull(signature.SignerEmail);
			Assert.AreEqual(SignatureStyle.FULL_NAME, signature.Style);
		}

		[TestMethod]
		public void BuildAcceptanceForGroup()
		{
			var groupId = new GroupId("myGroupId");
			var signature = SignatureBuilder.AcceptanceFor(groupId).Build();

			Assert.AreEqual(groupId, signature.GroupId);
			Assert.IsNull(signature.SignerEmail);
			Assert.AreEqual(SignatureStyle.ACCEPTANCE, signature.Style);
		}

		[TestMethod]
		public void BuildInitialsForGroup()
		{
			var groupId = new GroupId("myGroupId");
			var signature = SignatureBuilder.InitialsFor(groupId).Build();

			Assert.AreEqual(groupId, signature.GroupId);
			Assert.IsNull(signature.SignerEmail);
			Assert.AreEqual(SignatureStyle.INITIALS, signature.Style);
		}

        [TestMethod]
        public void BuildMobileCaptureForGroup()
        {
            var groupId = new GroupId("myGroupId");
            var signature = SignatureBuilder.MobileCaptureFor(groupId).Build();

            Assert.AreEqual(groupId, signature.GroupId);
            Assert.IsNull(signature.SignerEmail);
            Assert.AreEqual(SignatureStyle.MOBILE_CAPTURE, signature.Style);
        }

		[TestMethod]
		public void BuildsWithDefaultValues()
		{
			var signature = SignatureBuilder.SignatureFor ("some@dude.com").Build ();

			Assert.AreEqual (SignatureBuilder.DEFAULT_HEIGHT, signature.Height);
			Assert.AreEqual (SignatureBuilder.DEFAULT_WIDTH, signature.Width);
			Assert.AreEqual (SignatureBuilder.DEFAULT_STYLE, signature.Style);
		}

		[TestMethod]
		public void CreatesSignatureWithSpecifiedValues()
		{
			var signature = SignatureBuilder.SignatureFor ("some@dude.com")
				.WithStyle (SignatureStyle.HAND_DRAWN)
				.OnPage (1)
				.AtPosition (100, 150)
				.WithSize (125, 125)
				.Build ();

			Assert.AreEqual ("some@dude.com", signature.SignerEmail);
			Assert.AreEqual (SignatureStyle.HAND_DRAWN, signature.Style);
			Assert.AreEqual (1, signature.Page);
			Assert.AreEqual (100, signature.X, TOLERANCE);
			Assert.AreEqual (150, signature.Y, TOLERANCE);
			Assert.AreEqual (125, signature.Width, TOLERANCE);
			Assert.AreEqual (125, signature.Height, TOLERANCE);
		}

		[TestMethod]
		public void CreatingInitialsForSignerSetsStyle()
		{
			var signature = SignatureBuilder.InitialsFor ("some@dude.com").Build ();

			Assert.AreEqual (SignatureStyle.INITIALS, signature.Style);
		}

		[TestMethod]
		public void CreatingCaptureForSignerSetsStyle()
		{
			var signature = SignatureBuilder.CaptureFor ("some@dude.com").Build ();

			Assert.AreEqual (SignatureStyle.HAND_DRAWN, signature.Style);
		}

        [TestMethod]
        public void CreatingMobileCaptureForSignerSetsStyle()
        {
            var signature = SignatureBuilder.MobileCaptureFor ("some@dude.com").Build ();

            Assert.AreEqual (SignatureStyle.MOBILE_CAPTURE, signature.Style);
        }
	}
}