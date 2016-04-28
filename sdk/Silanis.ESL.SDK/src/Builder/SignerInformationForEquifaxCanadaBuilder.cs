using System;

namespace Silanis.ESL.SDK
{
    public class SignerInformationForEquifaxCanadaBuilder
    {
        private string firstName;
        private string lastName;
        private string streetAddress;
        private string city;
        private string province;
        private string postalCode;
        private Nullable<Int32> timeAtAddress;
        private string driversLicenseNumber;
        private string socialInsuranceNumber;
        private string homePhoneNumber;
        private Nullable<DateTime> dateOfBirth;


        public static SignerInformationForEquifaxCanadaBuilder NewSignerInformationForEquifaxCanada() {
                return new SignerInformationForEquifaxCanadaBuilder();
        }
        
        public SignerInformationForEquifaxCanadaBuilder WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithStreetAddress(string streetAddress)
        {
            this.streetAddress = streetAddress;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithCity(string city)
        {
            this.city = city;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithProvince(string province)
        {
            this.province = province;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithPostalCode(string postalCode)
        {
            this.postalCode = postalCode;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithTimeAtAddress(Nullable<Int32> timeAtAddress)
        {   
            this.timeAtAddress = timeAtAddress;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithDriversLicenseNumber(string driversLicenseNumber)
        {   
            this.driversLicenseNumber = driversLicenseNumber;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithSocialInsuranceNumber(string socialInsuranceNumber)
        {   
            this.socialInsuranceNumber = socialInsuranceNumber;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithHomePhoneNumber(string homePhoneNumber)
        {   
            this.homePhoneNumber = homePhoneNumber;
            return this;
        }

        public SignerInformationForEquifaxCanadaBuilder WithDateOfBirth(Nullable<DateTime> dateOfBirth)
        {   
            this.dateOfBirth = dateOfBirth;
            return this;
        }

        public SignerInformationForEquifaxCanada Build()
        {
            var result = new SignerInformationForEquifaxCanada();

            result.FirstName = firstName;
            result.LastName = lastName;
            result.StreetAddress = streetAddress;
            result.City = city;
            result.Province = province;
            result.PostalCode = postalCode;
            result.TimeAtAddress = timeAtAddress;
            result.DriversLicenseNumber = driversLicenseNumber;
            result.SocialInsuranceNumber = socialInsuranceNumber;
            result.HomePhoneNumber = homePhoneNumber;
            result.DateOfBirth = dateOfBirth;

            return result;
        }
    }
}



