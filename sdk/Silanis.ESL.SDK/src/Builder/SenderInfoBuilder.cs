using System;

namespace Silanis.ESL.SDK
{
    public sealed class SenderInfoBuilder
    {
		private string email;
        private string firstName;
        private string lastName;
        private string company;
        private string title;

		private SenderInfoBuilder(string email) {
			this.email = email;
        }

		public static SenderInfoBuilder NewSenderInfo(string email) {
			SenderInfoBuilder result = new SenderInfoBuilder(email);
            return result;
        }

        public SenderInfoBuilder WithName( string firstName, string lastName ) {
            this.firstName = firstName;
            this.lastName = lastName;
            return this;
        }

        public SenderInfoBuilder WithCompany( string company ) {
            this.company = company;
            return this;
        }

        public SenderInfoBuilder WithTitle( string title ) {
            this.title = title;
            return this;
        }

        public SenderInfo Build() {
            SenderInfo result = new SenderInfo();
			result.Email = email;
            result.FirstName = firstName;
            result.LastName = lastName;
            result.Company = company;
            result.Title = title;

            return result;
        }
    }
}

