using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class GroupSummary
    {
        private IDictionary<string, object> data;
        private string email;
        private string id;
        private string name;

        public GroupSummary()
        {
        }

        public IDictionary<string, object> Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
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
    }
}

