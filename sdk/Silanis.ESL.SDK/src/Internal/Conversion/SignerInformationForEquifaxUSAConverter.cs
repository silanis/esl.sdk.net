using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    internal class SignerInformationForEquifaxUSAConverter
    {
        private Silanis.ESL.SDK.SignerInformationForEquifaxUSA sdkSignerInformationForEquifaxUSA = null;
        private Silanis.ESL.API.SignerInformationForEquifaxUSA apiSignerInformationForEquifaxUSA = null;

        /// <summary>
        /// Construct with API SignerInformationForEquifaxUSA object involved in conversion.
        /// </summary>
        /// <param name="apiSignerInformationForEquifaxUSA">API attachment requirement.</param>
        public SignerInformationForEquifaxUSAConverter(Silanis.ESL.API.SignerInformationForEquifaxUSA apiSignerInformationForEquifaxUSA)
        {
            this.apiSignerInformationForEquifaxUSA = apiSignerInformationForEquifaxUSA;
        }

        /// <summary>
        /// Construct with SDK SignerInformationForEquifaxUSA object involved in conversion.
        /// </summary>
        /// <param name="sdkSignerInformationForEquifaxUSA">SDK attachment requirement.</param>
        public SignerInformationForEquifaxUSAConverter(Silanis.ESL.SDK.SignerInformationForEquifaxUSA sdkSignerInformationForEquifaxUSA)
        {
            this.sdkSignerInformationForEquifaxUSA = sdkSignerInformationForEquifaxUSA;
        }

        /// <summary>
        /// Convert from SDK SignerInformationForEquifaxUSA to API SignerInformationForEquifaxUSA.
        /// </summary>
        /// <returns>The API attachment requirement.</returns>
        public Silanis.ESL.API.SignerInformationForEquifaxUSA ToAPISignerInformationForEquifaxUSA()
        {
            if (sdkSignerInformationForEquifaxUSA == null)
            {
                return apiSignerInformationForEquifaxUSA;
            }

            Silanis.ESL.API.SignerInformationForEquifaxUSA result = new Silanis.ESL.API.SignerInformationForEquifaxUSA();

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
        public Silanis.ESL.SDK.SignerInformationForEquifaxUSA ToSDKSignerInformationForEquifaxUSA()
        {
            if (apiSignerInformationForEquifaxUSA == null)
            {
                return sdkSignerInformationForEquifaxUSA;
            }

            Silanis.ESL.SDK.SignerInformationForEquifaxUSA result = new Silanis.ESL.SDK.SignerInformationForEquifaxUSA();

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