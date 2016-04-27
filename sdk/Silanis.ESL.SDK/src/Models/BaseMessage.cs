//
using System;
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