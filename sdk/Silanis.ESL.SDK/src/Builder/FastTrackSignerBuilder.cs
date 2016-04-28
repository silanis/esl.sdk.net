namespace Silanis.ESL.SDK
{
    public class FastTrackSignerBuilder
    {
        private string id;
        private string email;
        private string firstName;
        private string lastName;

        private FastTrackSignerBuilder(string id) 
        {
            this.id = id;
        }

        public static FastTrackSignerBuilder NewSignerWithId(string id) 
        {
            return new FastTrackSignerBuilder(id);
        }

        public FastTrackSignerBuilder WithEmail(string email) 
        {
            this.email = email;
            return this;
        }

        public FastTrackSignerBuilder WithFirstName(string firstName) 
        {
            this.firstName = firstName;
            return this;
        }

        public FastTrackSignerBuilder WithLastName(string lastName) 
        {
            this.lastName = lastName;
            return this;
        }

        public FastTrackSigner Build() 
        {
            var result = new FastTrackSigner();
            result.Id = id;
            result.Email = email;
            result.FirstName = firstName;
            result.LastName = lastName;
            return result;
        }
    }
}

