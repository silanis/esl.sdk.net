using System;

namespace Silanis.ESL.SDK
{
    public class SignerInformationForEquifaxUSABuilder
    {
        private string firstName;
        private string lastName;
        private string streetAddress;
        private string city;
        private string state;
        private string zip;
        private string socialSecurityNumber;
        private string homePhoneNumber;
        private string driversLicenseNumber;
        private Nullable<Int32> timeAtAddress;
        private Nullable<DateTime> dateOfBirth;


        public static SignerInformationForEquifaxUSABuilder NewSignerInformationForEquifaxUSA() {
            return new SignerInformationForEquifaxUSABuilder();
        }

        public SignerInformationForEquifaxUSABuilder WithFirstName(string firstName)
        {
            this.firstName = firstName;
            return this;
        }

        public SignerInformationForEquifaxUSABuilder WithLastName(string lastName)
        {
            this.lastName = lastName;
            return this;
        }

        public SignerInformationForEquifaxUSABuilder WithStreetAddress(string streetAddress)
        {
            this.streetAddress = streetAddress;
            return this;
        }

        public SignerInformationForEquifaxUSABuilder WithCity(string city)
        {
            this.city = city;
            return this;
        }

        public SignerInformationForEquifaxUSABuilder WithState(string state)
        {
            this.state = state;
            return this;
        }

        public SignerInformationForEquifaxUSABuilder WithZip(string zip)
        {
            this.zip = zip;
            return this;
        }

        public SignerInformationForEquifaxUSABuilder WithSocialSecurityNumber(string socialSecurityNumber)
        {   
            this.socialSecurityNumber = socialSecurityNumber;
            return this;
        }

        public SignerInformationForEquifaxUSABuilder WithHomePhoneNumber(string homePhoneNumber)
        {   
            this.homePhoneNumber = homePhoneNumber;
            return this;
        }

        public SignerInformationForEquifaxUSABuilder WithTimeAtAddress(Nullable<Int32> timeAtAddress)
        {   
            this.timeAtAddress = timeAtAddress;
            return this;
        }


        public SignerInformationForEquifaxUSABuilder WithDriversLicenseNumber(string driversLicenseNumber)
        {   
            this.driversLicenseNumber = driversLicenseNumber;
            return this;
        }

        public SignerInformationForEquifaxUSABuilder WithDateOfBirth(Nullable<DateTime> dateOfBirth)
        {   
            this.dateOfBirth = dateOfBirth;
            return this;
        }

        public SignerInformationForEquifaxUSA Build()
        {
             var result = new SignerInformationForEquifaxUSA();

            result.FirstName = firstName;
            result.LastName = lastName;
            result.StreetAddress = streetAddress;
            result.City = city;
            result.State = state;
            result.Zip = zip;
            result.SocialSecurityNumber = socialSecurityNumber;
            result.HomePhoneNumber = homePhoneNumber;
            result.DriversLicenseNumber = driversLicenseNumber;
            result.TimeAtAddress = timeAtAddress;
            result.DateOfBirth = dateOfBirth;

            return result;
        }
    }
}
