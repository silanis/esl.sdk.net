namespace Silanis.ESL.SDK
{
    internal class AddressConverter
    {
        private Address sdkAddress;
        private API.Address apiAddress;

        public AddressConverter( Address sdkAddress )
        {
            this.sdkAddress = sdkAddress;
        }

        public AddressConverter( API.Address apiAddress ) 
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
                var builder = AddressBuilder.NewAddress()
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

        public API.Address ToAPIAddress() {
            if (apiAddress != null)
            {
                return apiAddress;
            }
            else if (sdkAddress != null)
            {
                var result = new API.Address();
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

