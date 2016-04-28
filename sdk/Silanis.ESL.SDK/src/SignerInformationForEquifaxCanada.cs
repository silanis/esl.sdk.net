using System;

namespace Silanis.ESL.SDK
{
    public class SignerInformationForEquifaxCanada
    {
        public SignerInformationForEquifaxCanada()
        {
        }

        public SignerInformationForEquifaxCanada(
            string firstName,
            string lastName,
            string streetAddress,
            string city,
            string province,
            string postalCode,
            Int32 timeAtAddress,
            string driversLicenseIndicator,
            string socialSecurityNumber,
            string homePhoneNumber,
            DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            Province = province;
            PostalCode = postalCode;
            TimeAtAddress = timeAtAddress;
            DriversLicenseNumber = driversLicenseIndicator;
            SocialInsuranceNumber = socialSecurityNumber;
            HomePhoneNumber = homePhoneNumber;
            DateOfBirth = dateOfBirth;
        }

        public SignerInformationForEquifaxCanada(
            string firstName,
            string lastName,
            string streetAddress,
            string city,
            string province,
            string postalCode,
            Int32 timeAtAddress,
            string driversLicenseIndicator,
            DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            Province = province;
            PostalCode = postalCode;
            TimeAtAddress = timeAtAddress;
            DriversLicenseNumber = driversLicenseIndicator;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName {
            get;
            set;
        }

        public string LastName {
            get;
            set;
        }
        public string StreetAddress {
            get;
            set;
        }
        public string City {
            get;
            set;
        }
        public string Province {
            get;
            set;
        }
        public string PostalCode {
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
        public string SocialInsuranceNumber {
            get;
            set;
        }
        public string HomePhoneNumber {
            get;
            set;
        }

        public Nullable<DateTime> DateOfBirth {
            get;
            set;
        }
    }
}

