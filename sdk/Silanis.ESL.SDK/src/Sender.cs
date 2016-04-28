using System;

namespace Silanis.ESL.SDK
{
    public class Sender
    {
		private SenderStatus status;
		private SenderType type;
		private string company;
		private Nullable<DateTime> created;
		private string email;
		private string firstName;
		private string lastName;
		private string language;
		private string phone;
		private string title;
		private Nullable<DateTime> updated;
		private string id;
		private string name;
        private External external;

		public Sender()
        {
            status = SenderStatus.INVITED;
            type = SenderType.REGULAR;
        }

		public SenderStatus Status
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
			}
		}

		public SenderType Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
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

		public Nullable<DateTime> Created
		{
			get
			{
				return created;
			}
			set
			{
				created = value;
			}
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

		public string Language
		{
			get
			{
				return language;
			}
			set
			{
				language = value;
			}
		}

		public string Phone
		{
			get
			{
				return phone;
			}
			set
			{
				phone = value;
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

		public Nullable<DateTime> Updated
		{
			get
			{
				return updated;
			}
			set
			{
				updated = value;
			}
		}

		public string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

        public External External
        {
            get
            {
                return external;
            }
            set
            {
                external = value;
            }
        }
    }
}

