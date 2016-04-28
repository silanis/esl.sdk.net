using System;

namespace Silanis.ESL.SDK
{
    public class SignerInformationForEquifaxUSA
    {
        public SignerInformationForEquifaxUSA()
        {
        }

        public SignerInformationForEquifaxUSA(
            string firstName,
            string lastName,
            string streetAddress,
            string city,
            string state,
            string zip,
            string socialSecurityNumber,
            string homePhoneNumber,
            Int32 timeAtAddress,
            string driversLicenseNumber,
            DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Zip = zip;
            SocialSecurityNumber = socialSecurityNumber;
            HomePhoneNumber = homePhoneNumber;
            TimeAtAddress = timeAtAddress;
            DriversLicenseNumber = driversLicenseNumber;
            DateOfBirth = dateOfBirth;
        }

        public SignerInformationForEquifaxUSA(
            string firstName,
            string lastName,
            string streetAddress,
            string city,
            string state,
            string zip,
            string socialInsuranceNumber,
            Int32 timeAtAddress,
            string driversLicenseNumber,
            DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Zip = zip;
            SocialSecurityNumber = socialInsuranceNumber;
            TimeAtAddress = timeAtAddress;
            DriversLicenseNumber = driversLicenseNumber;
            DateOfBirth = dateOfBirth;
        }

        public string City {
            get;
            set;
        }

        public Nullable<DateTime> DateOfBirth {
            get;
            set;
        }

        public string FirstName {
            get;
            set;
        }

        public string HomePhoneNumber {
            get;
            set;
        }

        public string LastName {
            get;
            set;
        }

        public string SocialSecurityNumber {
            get;
            set;
        }

        public string State {
            get;
            set;
        }

        public string StreetAddress {
            get;
            set;
        }
        public string Zip {
            get;
            set;
        }
        public Nullable<Int32> TimeAtAddress {
            get;
            set;
        }
        public string DriversLicenseNumber {
            get;
            set;
        }

    }
}