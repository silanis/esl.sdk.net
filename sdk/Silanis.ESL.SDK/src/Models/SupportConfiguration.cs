//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class SupportConfiguration
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("email")]
    public String Email
    {
                get; set;
        }
    
		    
    [JsonProperty("phone")]
    public String Phone
    {
                get; set;
        }
    
		
	
	}
}