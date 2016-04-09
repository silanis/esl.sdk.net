namespace Silanis.ESL.SDK
{
	internal class SenderStatusConverter
    {
		private SenderStatus sdkSenderStatus;
		private string apiSenderStatus;

		/// <summary>
		/// Construct with API SenderStatus object involved in conversion.
		/// </summary>
		/// <param name="apiSenderStatus">API sender status.</param>
		public SenderStatusConverter(string apiSenderStatus)
		{
			this.apiSenderStatus = apiSenderStatus;
		}

		/// <summary>
		/// Construct with SDK SenderStatus object involved in conversion.
		/// </summary>
		/// <param name="sdkSenderStatus">SDK sender status.</param>
		public SenderStatusConverter(SenderStatus sdkSenderStatus)
		{
			this.sdkSenderStatus = sdkSenderStatus;
		}

		/// <summary>
		/// Convert from SDK SenderStatus to API SenderStatus.
		/// </summary>
		/// <returns>The API sender status.</returns>
		public string ToAPISenderStatus()
		{
            return sdkSenderStatus.getApiValue();
		}

		/// <summary>
		/// Convert from API SenderStatus to SDK SenderStatus.
		/// </summary>
		/// <returns>The SDK sender status.</returns>
		public SenderStatus ToSDKSenderStatus()
		{
           return SenderStatus.valueOf(apiSenderStatus);
		}
    }
}

