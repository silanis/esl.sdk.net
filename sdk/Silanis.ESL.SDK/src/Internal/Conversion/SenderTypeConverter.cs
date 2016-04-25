using System;

namespace Silanis.ESL.SDK
{
	internal class SenderTypeConverter
    {
		private Silanis.ESL.SDK.SenderType sdkSenderType;
		private string apiSenderType;

		/// <summary>
		/// Construct with API SenderType object involved in conversion.
		/// </summary>
		/// <param name="apiSenderType">API sender type.</param>
		public SenderTypeConverter(string apiSenderType)
		{
			this.apiSenderType = apiSenderType;
		}

		/// <summary>
		/// Construct with SDK SenderType object involved in conversion.
		/// </summary>
		/// <param name="sdkSenderType">SDK sender type.</param>
		public SenderTypeConverter(Silanis.ESL.SDK.SenderType sdkSenderType)
		{
			this.sdkSenderType = sdkSenderType;
		}

		/// <summary>
		/// Convert from SDK SenderType to API SenderType.
		/// </summary>
		/// <returns>The API sender type.</returns>
		public string ToAPISenderType()
		{
            return sdkSenderType.getApiValue();
		}

		/// <summary>
		/// Convert from API SenderType to SDK SenderType.
		/// </summary>
		/// <returns>The SDK sender type.</returns>
		public Silanis.ESL.SDK.SenderType ToSDKSenderType()
		{
            return Silanis.ESL.SDK.SenderType.valueOf(apiSenderType);
		}
    }
}

