using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;

namespace SDK.Tests
{
	[TestClass]
    public class AttachmentRequirementBuilderTest
    {
		[TestMethod]
		public void BuildWithSpecificValues() {
			var name = "Driver's license";
			var description = "Please upload driver's license";
			var isRequired = true;

			var attachmentRequirement = AttachmentRequirementBuilder.NewAttachmentRequirementWithName(name)
				.WithDescription(description)
				.IsRequiredAttachment()
				.Build();

			Assert.AreEqual(name, attachmentRequirement.Name);
			Assert.AreEqual(description, attachmentRequirement.Description);
			Assert.AreEqual(isRequired, attachmentRequirement.Required);
		}

        [TestMethod]
		[ExpectedException(typeof(EslException))]
		public void AttachmentNameCannotBeNull()
		{
			AttachmentRequirementBuilder.NewAttachmentRequirementWithName(null).Build();
		}

        [TestMethod]
		[ExpectedException(typeof(EslException))]
		public void AttachmentNameCannotBeEmptyString()
		{
			AttachmentRequirementBuilder.NewAttachmentRequirementWithName("").Build();
		}
    }
}

