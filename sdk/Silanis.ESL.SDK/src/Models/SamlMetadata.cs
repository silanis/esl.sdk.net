//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class SamlMetadata
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("accountUid")]
    public String AccountUid
    {
                get; set;
        }
    
		    
    [JsonProperty("active")]
    public Nullable<Boolean> Active
    {
                get; set;
        }
    
		    
    [JsonProperty("entityId")]
    public String EntityId
    {
                get; set;
        }
    
		    
    [JsonProperty("metadata")]
    public String Metadata
    {
                get; set;
        }
    
		    
    [JsonProperty("publicKey")]
    public String PublicKey
    {
                get; set;
        }
    
		    
    [JsonProperty("uid")]
    public String Uid
    {
                get; set;
        }
    
		    
    [JsonProperty("url")]
    public String Url
    {
                get; set;
        }
    
		
	
	}
}