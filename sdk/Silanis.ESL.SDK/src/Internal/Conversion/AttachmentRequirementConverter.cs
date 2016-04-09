using System;

namespace Silanis.ESL.SDK
{
	internal class AttachmentRequirementConverter
    {
		private AttachmentRequirement sdkAttachmentRequirement = null;
		private API.AttachmentRequirement apiAttachmentRequirement = null;

		/// <summary>
		/// Construct with API AttachmentRequirement object involved in conversion.
		/// </summary>
		/// <param name="apiAttachmentRequirement">API attachment requirement.</param>
		public AttachmentRequirementConverter(API.AttachmentRequirement apiAttachmentRequirement)
        {
			this.apiAttachmentRequirement = apiAttachmentRequirement;
        }

		/// <summary>
		/// Construct with SDK AttachmentRequirement object involved in conversion.
		/// </summary>
		/// <param name="sdkAttachmentRequirement">SDK attachment requirement.</param>
		public AttachmentRequirementConverter(AttachmentRequirement sdkAttachmentRequirement)
		{
			this.sdkAttachmentRequirement = sdkAttachmentRequirement;
		}

		/// <summary>
		/// Convert from SDK AttachmentRequirement to API AttachmentRequirement.
		/// </summary>
		/// <returns>The API attachment requirement.</returns>
		public API.AttachmentRequirement ToAPIAttachmentRequirement()
		{
			if (sdkAttachmentRequirement == null)
			{
				return apiAttachmentRequirement;
			}

			var result = new API.AttachmentRequirement();

			if (!String.IsNullOrEmpty(sdkAttachmentRequirement.Id))
			{
                result.Id = sdkAttachmentRequirement.Id;
			}
            result.Name = sdkAttachmentRequirement.Name;
			result.Comment = sdkAttachmentRequirement.SenderComment;
			result.Description = sdkAttachmentRequirement.Description;
			result.Required = sdkAttachmentRequirement.Required;
			result.Data = sdkAttachmentRequirement.Data;

			if (sdkAttachmentRequirement.Status.Equals(null))
			{
                result.Status = RequirementStatus.INCOMPLETE.getApiValue();
			}
			else
			{
				result.Status = new RequirementStatusConverter(sdkAttachmentRequirement.Status).ToAPIRequirementStatus();
			}

			return result;
		}

		/// <summary>
		/// Convert from API AttachmentRequirement to SDK AttachmentRequirement.
		/// </summary>
		/// <returns>The SDK attachment requirement.</returns>
		public AttachmentRequirement ToSDKAttachmentRequirement()
		{
			if (apiAttachmentRequirement == null)
			{
				return sdkAttachmentRequirement;
			}

			if (apiAttachmentRequirement.Name != null)
			{
				var result = new AttachmentRequirement(apiAttachmentRequirement.Name);
				result.SenderComment = apiAttachmentRequirement.Comment;
				result.Description = apiAttachmentRequirement.Description;
				result.Id = apiAttachmentRequirement.Id;
				result.Required = apiAttachmentRequirement.Required.Value;
				result.Data = apiAttachmentRequirement.Data;
				result.Status = new RequirementStatusConverter(apiAttachmentRequirement.Status).ToSDKRequirementStatus();

				return result;
			}

			return sdkAttachmentRequirement;
		}
    }
}

