using System;

namespace Silanis.ESL.SDK
{
    public class GroupMember
    {
		private string email;
		private string firstName;
		private string lastName;
		private GroupMemberType groupMemberType;

        public GroupMember()
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

		public GroupMemberType GroupMemberType
		{
			get
			{
				return groupMemberType;
			}
			set
			{
				groupMemberType = value;
			}
		}
    }
}

