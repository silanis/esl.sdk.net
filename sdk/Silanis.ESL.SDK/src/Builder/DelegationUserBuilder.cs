namespace Silanis.ESL.SDK.Builder
{
    public class DelegationUserBuilder
    {
        private string email;
        private string firstName;
        private string id;
        private string lastName;
        private string name;

        public DelegationUserBuilder(string email)
        {
            this.email = email;
        }

        public static DelegationUserBuilder NewDelegationUser( string email ) 
        {
            return new DelegationUserBuilder(email);
        }

        public static DelegationUserBuilder NewDelegationUser( Sender sender ) {
            return new DelegationUserBuilder( sender.Email )
                    .WithFirstName(sender.FirstName)
                    .WithId(sender.Id)
                    .WithLastName(sender.LastName)
                    .WithName(sender.Name);
        }

        public DelegationUserBuilder WithFirstName( string firstName ) 
        {
            this.firstName = firstName;
            return this;
        }

        public DelegationUserBuilder WithId( string id ) 
        {
            this.id = id;
            return this;
        }

        public DelegationUserBuilder WithLastName( string lastName ) 
        {
            this.lastName = lastName;
            return this;
        }

        public DelegationUserBuilder WithName( string name ) 
        {
            this.name = name;
            return this;
        }

        public DelegationUser Build() 
        {
            var result = new DelegationUser();
            result.Email = email;
            result.FirstName = firstName;
            result.Id = id;
            result.LastName = lastName;
            result.Name = name;
            return result;
        }
    }
}

