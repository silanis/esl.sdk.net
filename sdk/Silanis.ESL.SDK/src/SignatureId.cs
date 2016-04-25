using System;

namespace Silanis.ESL.SDK
{
    public class SignatureId
    {
        private string id;

        public string Id
        {
            get
            {
                return id;
            }
        }

        public SignatureId( string id )
        {
            this.id = id;
        }
    }
}

