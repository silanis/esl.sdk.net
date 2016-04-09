namespace Silanis.ESL.SDK
{
    internal class SignerInformationForEquifaxUSAConverter
    {
        private SignerInformationForEquifaxUSA sdkSignerInformationForEquifaxUSA = null;
        private API.SignerInformationForEquifaxUSA apiSignerInformationForEquifaxUSA = null;

        /// <summary>
        /// Construct with API SignerInformationForEquifaxUSA object involved in conversion.
        /// </summary>
        /// <param name="apiSignerInformationForEquifaxUSA">API attachment requirement.</param>
        public SignerInformationForEquifaxUSAConverter(API.SignerInformationForEquifaxUSA apiSignerInformationForEquifaxUSA)
        {
            this.apiSignerInformationForEquifaxUSA = apiSignerInformationForEquifaxUSA;
        }

        /// <summary>
        /// Construct with SDK SignerInformationForEquifaxUSA object involved in conversion.
        /// </summary>
        /// <param name="sdkSignerInformationForEquifaxUSA">SDK attachment requirement.</param>
        public SignerInformationForEquifaxUSAConverter(SignerInformationForEquifaxUSA sdkSignerInformationForEquifaxUSA)
        {
            this.sdkSignerInformationForEquifaxUSA = sdkSignerInformationForEquifaxUSA;
        }

        /// <summary>
        /// Convert from SDK SignerInformationForEquifaxUSA to API SignerInformationForEquifaxUSA.
        /// </summary>
        /// <returns>The API attachment requirement.</returns>
        public API.SignerInformationForEquifaxUSA ToAPISignerInformationForEquifaxUSA()
        {
            if (sdkSignerInformationForEquifaxUSA == null)
            {
                return apiSignerInformationForEquifaxUSA;
            }

            var result = new API.SignerInformationForEquifaxUSA();

            result.FirstName = sdkSignerInformationForEquifaxUSA.FirstName;
            result.LastName = sdkSignerInformationForEquifaxUSA.LastName;
            result.StreetAddress = sdkSignerInformationForEquifaxUSA.StreetAddress;
            result.City = sdkSignerInformationForEquifaxUSA.City;
            result.State = sdkSignerInformationForEquifaxUSA.State;
            result.Zip = sdkSignerInformationForEquifaxUSA.Zip;
            result.SocialSecurityNumber = sdkSignerInformationForEquifaxUSA.SocialSecurityNumber;
            result.HomePhoneNumber = sdkSignerInformationForEquifaxUSA.HomePhoneNumber;
            result.TimeAtAddress = sdkSignerInformationForEquifaxUSA.TimeAtAddress;
            result.DriversLicenseNumber = sdkSignerInformationForEquifaxUSA.DriversLicenseNumber;
            result.DateOfBirth = sdkSignerInformationForEquifaxUSA.DateOfBirth;
            return result;
        }

        /// <summary>
        /// Convert from API SignerInformationForEquifaxUSA to SDK SignerInformationForEquifaxUSA.
        /// </summary>
        /// <returns>The SDK attachment requirement.</returns>
        public SignerInformationForEquifaxUSA ToSDKSignerInformationForEquifaxUSA()
        {
            if (apiSignerInformationForEquifaxUSA == null)
            {
                return sdkSignerInformationForEquifaxUSA;
            }

            var result = new SignerInformationForEquifaxUSA();

            result.FirstName = apiSignerInformationForEquifaxUSA.FirstName;
            result.LastName = apiSignerInformationForEquifaxUSA.LastName;
            result.StreetAddress = apiSignerInformationForEquifaxUSA.StreetAddress;
            result.City = apiSignerInformationForEquifaxUSA.City;
            result.State = apiSignerInformationForEquifaxUSA.State;
            result.Zip = apiSignerInformationForEquifaxUSA.Zip;
            result.SocialSecurityNumber = apiSignerInformationForEquifaxUSA.SocialSecurityNumber;
            result.HomePhoneNumber = apiSignerInformationForEquifaxUSA.HomePhoneNumber;
            result.TimeAtAddress = apiSignerInformationForEquifaxUSA.TimeAtAddress;
            result.DriversLicenseNumber = apiSignerInformationForEquifaxUSA.DriversLicenseNumber;
            result.DateOfBirth = apiSignerInformationForEquifaxUSA.DateOfBirth;

            return result;
        }
    }
}