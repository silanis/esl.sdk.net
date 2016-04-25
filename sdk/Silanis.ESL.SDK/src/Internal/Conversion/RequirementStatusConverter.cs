using System;

namespace Silanis.ESL.SDK
{
	internal class RequirementStatusConverter
    {
		private Silanis.ESL.SDK.RequirementStatus sdkRequirementStatus;
		private string apiRequirementStatus;

		/// <summary>
		/// Construct with API RequirementStatus object involved in conversion.
		/// </summary>
		/// <param name="apiRequirementStatus">API requirement status.</param>
		public RequirementStatusConverter(string apiRequirementStatus)
		{
			this.apiRequirementStatus = apiRequirementStatus;
		}

		/// <summary>
		/// Construct with SDK RequirementStatus object involved in conversion.
		/// </summary>
		/// <param name="sdkRequirementStatus">SDK requirement status.</param>
		public RequirementStatusConverter(Silanis.ESL.SDK.RequirementStatus sdkRequirementStatus)
		{
			this.sdkRequirementStatus = sdkRequirementStatus;
		}

		/// <summary>
		/// Convert from SDK RequirementStatus to API RequirementStatus.
		/// </summary>
		/// <returns>The API requirement status.</returns>
		public string ToAPIRequirementStatus()
		{
            return sdkRequirementStatus.getApiValue();
		}

		/// <summary>
		/// Convert from API RequirementStatus to SDK RequirementStatus.
		/// </summary>
		/// <returns>The SDK requirement status.</returns>
		public Silanis.ESL.SDK.RequirementStatus ToSDKRequirementStatus()
		{
            return Silanis.ESL.SDK.RequirementStatus.valueOf(apiRequirementStatus);
		}
    }
}

