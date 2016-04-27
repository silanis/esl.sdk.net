//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class SenderAuthenticationToken
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("packageId")]
    public String PackageId
    {
                get; set;
        }
    
		    
    [JsonProperty("value")]
    public String Value
    {
                get; set;
        }
    
		
	
	}
}