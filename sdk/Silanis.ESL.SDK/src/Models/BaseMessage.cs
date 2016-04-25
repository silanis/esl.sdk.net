//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class BaseMessage
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("content")]
    public String Content
    {
                get; set;
        }
    
		
	
	}
}