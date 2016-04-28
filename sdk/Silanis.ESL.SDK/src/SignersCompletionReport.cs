using System;

namespace Silanis.ESL.SDK
{
    public class SignersCompletionReport
    {
		private Boolean completed;
		private string email;
		private string firstName;
		private Nullable<DateTime> firstSigned;
		private string id;
		private string lastName;
		private Nullable<DateTime> lastSigned;

		public SignersCompletionReport(string firstName, string lastName)
		{
			this.firstName = firstName;
			this.lastName = lastName;
		}

		public Boolean Completed
		{
			get
			{
				return completed;
			}
			set
			{
				completed = value;
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

		public Nullable<DateTime> FirstSigned
		{
			get
			{
				return firstSigned;
			}
			set
			{
				firstSigned = value;
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

		public Nullable<DateTime> LastSigned
		{
			get
			{
				return lastSigned;
			}
			set
			{
				lastSigned = value;
			}
		}
    }
}

