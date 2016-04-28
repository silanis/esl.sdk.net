namespace Silanis.ESL.SDK
{
    public class AccountMemberBuilder
    {
        private Address address;
        private string company;
        private string email;
        private string firstName;
        private string lastName;
        private string language;
        private string phoneNumber;
        private string title;
        private SenderStatus status = SenderStatus.INVITED;

        private AccountMemberBuilder( string email )
        {
            this.email = email;
        }

        public static AccountMemberBuilder NewAccountMember( string email ) {
            return new AccountMemberBuilder( email );
        }

        public AccountMemberBuilder WithCompany( string company ) {
            this.company = company;
            return this;
        }

        public AccountMemberBuilder WithFirstName( string firstName ) {
            this.firstName = firstName;
            return this;
        }

        public AccountMemberBuilder WithLastName( string lastName ) {
            this.lastName = lastName;
            return this;
        }

        public AccountMemberBuilder WithLanguage( string language ) {
            this.language = language;
            return this;
        }

        public AccountMemberBuilder WithPhoneNumber( string phoneNumber ) {
            this.phoneNumber = phoneNumber;
            return this;
        }

        public AccountMemberBuilder WithTitle( string title ) {
            this.title = title;
            return this;
        }

        public AccountMemberBuilder WithAddress( AddressBuilder builder ) {
            return WithAddress(builder.Build());
        }

        public AccountMemberBuilder WithAddress( Address address ) {
            this.address = address;
            return this;
        }
        
        public AccountMemberBuilder WithStatus(SenderStatus status)
        {
            this.status = status;
            return this;
        }

        public AccountMember Build() {
            var result = new AccountMember();

            result.Address = address;
            result.Company = company;
            result.Email = email;
            result.FirstName = firstName;
            result.LastName = lastName;
            result.Language = language;
            result.PhoneNumber = phoneNumber;
            result.Title = title;
            if ( null!=status ) result.Status = status;

            return result;
        }
    }
}

