using System;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.SDK;
using NUnit.Framework;

namespace SDK.Tests
{
	public class SignatureBuilderTest
	{
		private static double TOLERANCE = 0.01d;

		[Test]
		public void BuildCaptureForGroup()
		{
			GroupId groupId = new GroupId("myGroupId");
			Signature signature = SignatureBuilder.CaptureFor(groupId).Build();

			Assert.AreEqual(groupId, signature.GroupId);
			Assert.IsNull(signature.SignerEmail);
			Assert.AreEqual(SignatureStyle.HAND_DRAWN, signature.Style);
		}

		[Test]
		public void BuildSignatureForGroup()
		{
			GroupId groupId = new GroupId("myGroupId");
			Signature signature = SignatureBuilder.SignatureFor(groupId).Build();

			Assert.AreEqual(groupId, signature.GroupId);
			Assert.IsNull(signature.SignerEmail);
			Assert.AreEqual(SignatureStyle.FULL_NAME, signature.Style);
		}

		[Test]
		public void BuildAcceptanceForGroup()
		{
			GroupId groupId = new GroupId("myGroupId");
			Signature signature = SignatureBuilder.AcceptanceFor(groupId).Build();

			Assert.AreEqual(groupId, signature.GroupId);
			Assert.IsNull(signature.SignerEmail);
			Assert.AreEqual(SignatureStyle.ACCEPTANCE, signature.Style);
		}

		[Test]
		public void BuildInitialsForGroup()
		{
			GroupId groupId = new GroupId("myGroupId");
			Signature signature = SignatureBuilder.InitialsFor(groupId).Build();

			Assert.AreEqual(groupId, signature.GroupId);
			Assert.IsNull(signature.SignerEmail);
			Assert.AreEqual(SignatureStyle.INITIALS, signature.Style);
		}

        [Test]
        public void BuildMobileCaptureForGroup()
        {
            GroupId groupId = new GroupId("myGroupId");
            Signature signature = SignatureBuilder.MobileCaptureFor(groupId).Build();

            Assert.AreEqual(groupId, signature.GroupId);
            Assert.IsNull(signature.SignerEmail);
            Assert.AreEqual(SignatureStyle.MOBILE_CAPTURE, signature.Style);
        }

		[Test]
		public void BuildsWithDefaultValues()
		{
			Signature signature = SignatureBuilder.SignatureFor ("some@dude.com").Build ();

			Assert.AreEqual (SignatureBuilder.DEFAULT_HEIGHT, signature.Height);
			Assert.AreEqual (SignatureBuilder.DEFAULT_WIDTH, signature.Width);
			Assert.AreEqual (SignatureBuilder.DEFAULT_STYLE, signature.Style);
		}

		[Test]
		public void CreatesSignatureWithSpecifiedValues()
		{
			Signature signature = SignatureBuilder.SignatureFor ("some@dude.com")
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

		[Test]
		public void CreatingInitialsForSignerSetsStyle()
		{
			Signature signature = SignatureBuilder.InitialsFor ("some@dude.com").Build ();

			Assert.AreEqual (SignatureStyle.INITIALS, signature.Style);
		}

		[Test]
		public void CreatingCaptureForSignerSetsStyle()
		{
			Signature signature = SignatureBuilder.CaptureFor ("some@dude.com").Build ();

			Assert.AreEqual (SignatureStyle.HAND_DRAWN, signature.Style);
		}

        [Test]
        public void CreatingMobileCaptureForSignerSetsStyle()
        {
            Signature signature = SignatureBuilder.MobileCaptureFor ("some@dude.com").Build ();

            Assert.AreEqual (SignatureStyle.MOBILE_CAPTURE, signature.Style);
        }
	}
}