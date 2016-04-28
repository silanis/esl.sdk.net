using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class Group
    {
		private GroupId id;
		private string name;
		private string email;
		private DateTime created;
		private DateTime updated;
		private bool emailMembers;
		private List<GroupMember> members;

        public Group()
        {
			members = new List<GroupMember>();
        }

		public GroupId Id
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

		public DateTime Created
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

		public DateTime Updated
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

		public bool EmailMembers
		{
			get
			{
				return emailMembers;
			}
			set
			{
				emailMembers = value;
			}
		}

		public List<GroupMember> Members
		{
			get
			{
				return members;
			}
			set
			{
				members = value;
			}
		}
    }
}

