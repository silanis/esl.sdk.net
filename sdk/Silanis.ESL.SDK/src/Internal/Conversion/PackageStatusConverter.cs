using System;

namespace Silanis.ESL.SDK
{
	internal class PackageStatusConverter
    {
		private Silanis.ESL.SDK.DocumentPackageStatus sdkPackageStatus;
		private string apiPackageStatus;

		/// <summary>
		/// Construct with API PackageStatus object involved in conversion.
		/// </summary>
		/// <param name="apiPackageStatus">API package status.</param>
		public PackageStatusConverter(string apiPackageStatus)
		{
			this.apiPackageStatus = apiPackageStatus;
		}

		/// <summary>
		/// Construct with SDK PackageStatus object involved in conversion.
		/// </summary>
		/// <param name="sdkPackageStatus">SDK package status.</param>
		public PackageStatusConverter(Silanis.ESL.SDK.DocumentPackageStatus sdkPackageStatus)
		{
			this.sdkPackageStatus = sdkPackageStatus;
		}

		/// <summary>
		/// Convert from SDK PackageStatus to API PackageStatus.
		/// </summary>
		/// <returns>The API package status.</returns>
		public string ToAPIPackageStatus()
		{
            return sdkPackageStatus.getApiValue();			
		}

		/// <summary>
		/// Convert from API PackageStatus to SDK PackageStatus.
		/// </summary>
		/// <returns>The SDK package status.</returns>
		public Silanis.ESL.SDK.DocumentPackageStatus ToSDKPackageStatus()
		{
            return Silanis.ESL.SDK.DocumentPackageStatus.valueOf(apiPackageStatus);
		}
    }
}

