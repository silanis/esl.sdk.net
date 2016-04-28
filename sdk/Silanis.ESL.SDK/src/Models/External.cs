//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class External
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("data")]
    public IDictionary<string, object> Data
    {
                get; set;
        }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("provider")]
    public String Provider
    {
                get; set;
        }
    
		    
    [JsonProperty("providerName")]
    public String ProviderName
    {
                get; set;
        }
    
		
	
	}
}