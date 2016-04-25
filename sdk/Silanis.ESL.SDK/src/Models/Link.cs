//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Link
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("href")]
    public String Href
    {
                get; set;
        }
    
		    
    [JsonProperty("text")]
    public String Text
    {
                get; set;
        }
    
		    
    [JsonProperty("title")]
    public String Title
    {
                get; set;
        }
    
		
	
	}
}