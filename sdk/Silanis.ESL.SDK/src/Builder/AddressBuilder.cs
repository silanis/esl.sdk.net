namespace Silanis.ESL.SDK
{
    public class AddressBuilder
    {
        private string address1;
        private string address2;
        private string city;
        private string country;
        private string state;
        private string zipCode;

        private AddressBuilder() {}

        public static AddressBuilder NewAddress() {
            return new AddressBuilder();
        }

        public AddressBuilder WithAddress1( string address1 ) {
            this.address1 = address1;
            return this;
        }

        public AddressBuilder WithAddress2( string address2 ) {
            this.address2 = address2;
            return this;
        }

        public AddressBuilder WithCity( string city ) {
            this.city = city;
            return this;
        }

        public AddressBuilder WithCountry( string country ) {
            this.country = country;
            return this;
        }

        public AddressBuilder WithState( string state ) {
            this.state = state;
            return this;
        }

        public AddressBuilder WithZipCode( string zipCode ) {
            this.zipCode = zipCode;
            return this;
        }

        public Address Build() {
            var result = new Address();
            result.Address1 = address1;
            result.Address2 = address2;
            result.City = city;
            result.Country = country;
            result.State = state;
            result.ZipCode = zipCode;

            return result;
        }
    }
}