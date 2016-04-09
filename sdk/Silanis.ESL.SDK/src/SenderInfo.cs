namespace Silanis.ESL.SDK
{
    public class SenderInfo
    {
		private string email;
        private string firstName;
        private string lastName;
        private string company;
        private string title;

        public SenderInfo()
        {
        }

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
    }
}

