using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Silanis.ESL.API;

namespace SDK.Tests
{
	[TestFixture]
	public class SignerBuilderTest
	{
		[Test]
		public void BuildsSignerWithBasicInformation()
		{
			Silanis.ESL.SDK.Signer signer = SignerBuilder.NewSignerWithEmail("joe@email.com")
				.WithFirstName ("Joe")
				.WithLastName("Smith")
				.SigningOrder (2)
				.Build();

			Assert.AreEqual ("joe@email.com", signer.Email);
			Assert.AreEqual ("Joe", signer.FirstName);
			Assert.AreEqual ("Smith", signer.LastName);
			Assert.AreEqual (2, signer.SigningOrder);
		}

		[Test]
		[ExpectedException(typeof(EslException))]
		public void SignerEmailCannotBeEmpty()
		{
			SignerBuilder.NewSignerWithEmail (" ").WithFirstName ("Billy").WithLastName ("Bob").Build ();
		}

		[Test]
		[ExpectedException(typeof(EslException))]
		public void SignerFirstNameCannotBeEmpty()
		{
			SignerBuilder.NewSignerWithEmail ("billy@bob.com").WithFirstName (" ").WithLastName ("Bob").Build ();
		}

		[Test]
		[ExpectedException(typeof(EslException))]
		public void SignerLastNameCannotBeEmpty()
		{
			SignerBuilder.NewSignerWithEmail ("billy@bob.com").WithFirstName ("Billy").WithLastName (" ").Build ();
		}

		[Test]
		public void CanSpecifyTitleAndCompany()
		{
			Silanis.ESL.SDK.Signer signer = SignerBuilder.NewSignerWithEmail ("billy@bob.com")
				.WithFirstName ("Billy")
				.WithLastName ("Bob")
				.WithTitle ("Managing Director")
				.WithCompany ("Acme Inc")
				.Build ();

			Assert.AreEqual ("Managing Director", signer.Title);
			Assert.AreEqual ("Acme Inc", signer.Company);
		}

		[Test]
		public void AuthenticationDefaultsToEmail()
		{
			Silanis.ESL.SDK.Signer signer = SignerBuilder.NewSignerWithEmail ("billy@bob.com")
				.WithFirstName ("Billy")
				.WithLastName ("Bob")
				.Build ();

			Assert.AreEqual (AuthenticationMethod.EMAIL, signer.AuthenticationMethod);
		}

		[Test]
		public void ProvidingQuestionsAndAnswersSetsAuthenticationMethodToChallenge()
		{
			Silanis.ESL.SDK.Signer signer = SignerBuilder.NewSignerWithEmail ("billy@bob.com")
				.WithFirstName ("Billy")
				.WithLastName ("Bob")
				.ChallengedWithQuestions (ChallengeBuilder.FirstQuestion("What's your favorite sport?")
					                          .Answer("golf"))
				.Build ();

			Assert.AreEqual (AuthenticationMethod.CHALLENGE, signer.AuthenticationMethod);
		}

		[Test]
		public void SavesProvidesQuestionsAndAnswers()
		{
			Silanis.ESL.SDK.Signer signer = SignerBuilder.NewSignerWithEmail ("billy@bob.com")
				.WithFirstName ("Billy")
					.WithLastName ("Bob")
					.ChallengedWithQuestions (ChallengeBuilder.FirstQuestion("What's your favorite sport?")
					                          .Answer("golf")
					                          .SecondQuestion("Do you have a pet?")
					                          .Answer("yes"))
					.Build ();

			Assert.AreEqual (signer.ChallengeQuestion[0], new Challenge("What's your favorite sport?", "golf", Challenge.MaskOptions.None));
			Assert.AreEqual (signer.ChallengeQuestion[1], new Challenge("Do you have a pet?", "yes", Challenge.MaskOptions.None));
		}

		[Test]
		[ExpectedException(typeof(EslException))]
		public void CannotProvideQuestionWithoutAnswer()
		{
			SignerBuilder.NewSignerWithEmail ("billy@bob.com")
				.WithFirstName ("Billy")
				.WithLastName ("Bob")
				.ChallengedWithQuestions (ChallengeBuilder.FirstQuestion("What's your favorite sport?"))
				.Build ();
		}

		[Test]
		public void ProvidingSignerCellPhoneNumberSetsUpSMSAuthentication() 
		{
			Silanis.ESL.SDK.Signer signer = SignerBuilder.NewSignerWithEmail ("billy@bob.com")
				.WithFirstName ("Billy")
				.WithLastName ("Bob")
				.WithSMSSentTo ("1112223333")
				.Build ();

			Assert.AreEqual (AuthenticationMethod.SMS, signer.AuthenticationMethod);
			Assert.AreEqual ("1112223333", signer.PhoneNumber);
		}

		[Test]
		[ExpectedException(typeof(EslException))]
		public void EmptyPhoneNumberNotAllowed()
		{
			SignerBuilder.NewSignerWithEmail ("billy@bob.com")
				.WithFirstName ("Billy")
					.WithLastName ("Bob")
					.WithSMSSentTo (" ")
					.Build ();
		}

		[Test]
		public void CanConfigureSignedDocumentDelivery()
		{
			Silanis.ESL.SDK.Signer signer = SignerBuilder.NewSignerWithEmail ("billy@bob.com")
				.WithFirstName ("Billy")
					.WithLastName ("Bob")
					.DeliverSignedDocumentsByEmail()
					.Build ();

			Assert.IsTrue (signer.DeliverSignedDocumentsByEmail);
		}

		[Test]
		public void CanSetAndGetAttachmentRequirements()
		{
			Silanis.ESL.SDK.AttachmentRequirement attachmentRequirement = AttachmentRequirementBuilder.NewAttachmentRequirementWithName("Driver's license")
				.WithDescription("Please upload scanned driver's license.")
				.IsRequiredAttachment()
				.Build();

			Silanis.ESL.SDK.Signer signer = SignerBuilder.NewSignerWithEmail("billy@bob.com")
				.WithFirstName("Billy")
				.WithLastName("Bob")
				.WithAttachmentRequirement(attachmentRequirement)
				.Build();

			Assert.AreEqual(signer.Attachments.Count, 1);
			Assert.AreEqual(signer.GetAttachmentRequirement("Driver's license").Name, attachmentRequirement.Name);
			Assert.AreEqual(signer.GetAttachmentRequirement("Driver's license").Description, attachmentRequirement.Description);
			Assert.AreEqual(signer.GetAttachmentRequirement("Driver's license").Required, attachmentRequirement.Required);
			Assert.AreEqual(signer.GetAttachmentRequirement("Driver's license").Status, attachmentRequirement.Status);
		}

		[Test]
		public void CanAddTwoAttachmentRequirement()
		{
			Silanis.ESL.SDK.AttachmentRequirement attachmentRequirement1 = AttachmentRequirementBuilder.NewAttachmentRequirementWithName("Driver's license")
				.WithDescription("Please upload scanned driver's license.")
				.IsRequiredAttachment()
				.Build();
			Silanis.ESL.SDK.AttachmentRequirement attachmentRequirement2 = AttachmentRequirementBuilder.NewAttachmentRequirementWithName("Medicare card")
				.WithDescription("Please upload scanned medicare card.")
				.IsRequiredAttachment()
				.Build();

			Silanis.ESL.SDK.Signer signer = SignerBuilder.NewSignerWithEmail("billy@bob.com")
				.WithFirstName("Billy")
				.WithLastName("Bob")
				.WithAttachmentRequirement(attachmentRequirement1)
				.WithAttachmentRequirement(attachmentRequirement2)
				.Build();

			Assert.AreEqual(signer.Attachments.Count, 2);
			Assert.AreEqual(signer.GetAttachmentRequirement("Driver's license").Name, attachmentRequirement1.Name);
			Assert.AreEqual(signer.GetAttachmentRequirement("Driver's license").Description, attachmentRequirement1.Description);
			Assert.AreEqual(signer.GetAttachmentRequirement("Driver's license").Required, attachmentRequirement1.Required);
			Assert.AreEqual(signer.GetAttachmentRequirement("Driver's license").Status, attachmentRequirement1.Status);
			Assert.AreEqual(signer.GetAttachmentRequirement("Medicare card").Name, attachmentRequirement2.Name);
			Assert.AreEqual(signer.GetAttachmentRequirement("Medicare card").Description, attachmentRequirement2.Description);
			Assert.AreEqual(signer.GetAttachmentRequirement("Medicare card").Required, attachmentRequirement2.Required);
			Assert.AreEqual(signer.GetAttachmentRequirement("Medicare card").Status.ToString(), attachmentRequirement2.Status.ToString());
		}
	}
} 	