using System.Collections.Generic;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
    public class FastTrackRole
    {
        private List<FastTrackSigner> signers = new List<FastTrackSigner>();

        [JsonProperty("id")]
        public string Id 
        {
            get;
            set;
        }

        [JsonProperty("name")]
        public string Name 
        {
            get;
            set;
        }

        [JsonProperty("signers")]
        public List<FastTrackSigner> Signers 
        {
            get
            {
                return signers;
            }
            set
            {
                signers = value;
            }
        }
    }
}

