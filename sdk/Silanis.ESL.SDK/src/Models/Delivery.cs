//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Delivery
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("download")]
    public Nullable<Boolean> Download
    {
                get; set;
        }
    
		    
    [JsonProperty("email")]
    public Nullable<Boolean> Email
    {
                get; set;
        }
    
		    
    [JsonProperty("provider")]
    public Nullable<Boolean> Provider
    {
                get; set;
        }
    
		
	
	}
}