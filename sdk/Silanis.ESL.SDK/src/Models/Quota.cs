//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Quota
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("cycle")]
        public string Cycle
    {
                get; set;
        }
    
		    
    [JsonProperty("limit")]
    public Nullable<Int32> Limit
    {
                get; set;
        }
    
		    
    [JsonProperty("scope")]
    public string Scope
    {
                get; set;
        }
    
		    
    [JsonProperty("target")]
    public string Target
    {
                get; set;
        }
    
		
	
	}
}