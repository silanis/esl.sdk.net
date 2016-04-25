using System;

namespace Silanis.ESL.SDK
{
    public class Placeholder
    {
        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Placeholder( string id )
        {
            Id = id;
            Name = id;
        }

        public Placeholder( string id, string name )
        {
            Id = id;
            Name = name;
        }
    }
}

