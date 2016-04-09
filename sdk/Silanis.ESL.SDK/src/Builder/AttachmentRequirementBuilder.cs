using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
	/// <summary>
	/// The AttachmentRequirementBuilder class is a convenient class used to create and customize a AttachmentRequirement
	/// associated with a signer.
	/// </summary>
	public class AttachmentRequirementBuilder
    {
		private string desciption;
		private string name;
		private bool isRequired;

		/// <summary>
		/// Initializes a new instance of the <see cref="Silanis.ESL.SDK.AttachmentRequirementBuilder"/> class.
		/// </summary>
		/// <param name="name">The attachment name.</param>
		public AttachmentRequirementBuilder(string name)
        {
			this.name = name;
        }

		/// <summary>
		/// Creates a AttachmentRequirementBuilder instance with name.
		/// </summary>
		public static AttachmentRequirementBuilder NewAttachmentRequirementWithName(string name)
		{
			return new AttachmentRequirementBuilder(name);
		}

		/// <summary>
		/// Sets the attachment's desciption.
		/// </summary>
		public AttachmentRequirementBuilder WithDescription(string desciption)
		{
			this.desciption = desciption;
			return this;
		}

		/// <summary>
		/// Sets the isRequired property to true.
		/// </summary>
		public AttachmentRequirementBuilder IsRequiredAttachment()
		{
			isRequired = true;
			return this;
		}

		public AttachmentRequirement Build()
		{
			Asserts.NotEmptyOrNull(name, "name");
			var attachmentRequirement = new AttachmentRequirement(name);
			attachmentRequirement.Description = desciption;
			attachmentRequirement.Required = isRequired;
			attachmentRequirement.Status = RequirementStatus.INCOMPLETE;

			return attachmentRequirement;
		}
    }
}

