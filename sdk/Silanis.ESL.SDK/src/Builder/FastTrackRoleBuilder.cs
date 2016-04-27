using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class FastTrackRoleBuilder
    {
        private string id;
        private string name;
        private List<FastTrackSigner> signers = new List<FastTrackSigner>();

        private FastTrackRoleBuilder(string id) 
        {
            this.id = id;
        }

        public static FastTrackRoleBuilder NewRoleWithId(string id) 
        {
            return new FastTrackRoleBuilder(id);
        }

        public FastTrackRoleBuilder WithName(string name) 
        {
            this.name = name;
            return this;
        }

        public FastTrackRoleBuilder WithSigner( FastTrackSigner signer ) 
        {
            signers.Add(signer);
            return this;
        }

        public FastTrackRole Build() 
        {
            var role = new FastTrackRole();
            role.Id = id;
            role.Name = name;
            role.Signers = signers;
            return role;
        }
    }
}

