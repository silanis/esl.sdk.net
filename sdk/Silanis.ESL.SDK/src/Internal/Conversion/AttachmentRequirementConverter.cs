using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	internal class AttachmentRequirementConverter
    {
		private Silanis.ESL.SDK.AttachmentRequirement sdkAttachmentRequirement = null;
		private Silanis.ESL.API.AttachmentRequirement apiAttachmentRequirement = null;

		/// <summary>
		/// Construct with API AttachmentRequirement object involved in conversion.
		/// </summary>
		/// <param name="apiAttachmentRequirement">API attachment requirement.</param>
		public AttachmentRequirementConverter(Silanis.ESL.API.AttachmentRequirement apiAttachmentRequirement)
        {
			this.apiAttachmentRequirement = apiAttachmentRequirement;
        }

		/// <summary>
		/// Construct with SDK AttachmentRequirement object involved in conversion.
		/// </summary>
		/// <param name="sdkAttachmentRequirement">SDK attachment requirement.</param>
		public AttachmentRequirementConverter(Silanis.ESL.SDK.AttachmentRequirement sdkAttachmentRequirement)
		{
			this.sdkAttachmentRequirement = sdkAttachmentRequirement;
		}

		/// <summary>
		/// Convert from SDK AttachmentRequirement to API AttachmentRequirement.
		/// </summary>
		/// <returns>The API attachment requirement.</returns>
		public Silanis.ESL.API.AttachmentRequirement ToAPIAttachmentRequirement()
		{
			if (sdkAttachmentRequirement == null)
			{
				return apiAttachmentRequirement;
			}

			Silanis.ESL.API.AttachmentRequirement result = new Silanis.ESL.API.AttachmentRequirement();

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
                result.Status = Silanis.ESL.SDK.RequirementStatus.INCOMPLETE.getApiValue();
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
		public Silanis.ESL.SDK.AttachmentRequirement ToSDKAttachmentRequirement()
		{
			if (apiAttachmentRequirement == null)
			{
				return sdkAttachmentRequirement;
			}

			if (apiAttachmentRequirement.Name != null)
			{
				Silanis.ESL.SDK.AttachmentRequirement result = new Silanis.ESL.SDK.AttachmentRequirement(apiAttachmentRequirement.Name);
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

