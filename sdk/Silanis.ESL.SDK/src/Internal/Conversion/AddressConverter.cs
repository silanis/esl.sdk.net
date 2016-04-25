using System;

namespace Silanis.ESL.SDK
{
    internal class AddressConverter
    {
        private Address sdkAddress;
        private Silanis.ESL.API.Address apiAddress;

        public AddressConverter( Address sdkAddress )
        {
            this.sdkAddress = sdkAddress;
        }

        public AddressConverter( Silanis.ESL.API.Address apiAddress ) 
        {
            this.apiAddress = apiAddress;
        }

        public Address ToSDKAddress() {
            if (sdkAddress != null)
            {
                return sdkAddress;
            }
            else if (apiAddress != null)
            {
                AddressBuilder builder = AddressBuilder.NewAddress()
                        .WithAddress1(apiAddress.Address1)
                        .WithAddress2(apiAddress.Address2)
                        .WithCity(apiAddress.City)
                        .WithCountry(apiAddress.Country)
                        .WithState(apiAddress.State)
                        .WithZipCode(apiAddress.Zipcode);
                return builder.Build();
            }
            else
            {
                return null;
            }
        }

        public Silanis.ESL.API.Address ToAPIAddress() {
            if (apiAddress != null)
            {
                return apiAddress;
            }
            else if (sdkAddress != null)
            {
                Silanis.ESL.API.Address result = new Silanis.ESL.API.Address();
                result.Address1 = sdkAddress.Address1;
                result.Address2 = sdkAddress.Address2;
                result.City = sdkAddress.City;
                result.Country = sdkAddress.Country;
                result.State = sdkAddress.State;
                result.Zipcode = sdkAddress.ZipCode;
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}

