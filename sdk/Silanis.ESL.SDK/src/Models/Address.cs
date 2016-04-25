//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Address
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("address1")]
    public String Address1
    {
                get; set;
        }
    
		    
    [JsonProperty("address2")]
    public String Address2
    {
                get; set;
        }
    
		    
    [JsonProperty("city")]
    public String City
    {
                get; set;
        }
    
		    
    [JsonProperty("country")]
    public String Country
    {
                get; set;
        }
    
		    
    [JsonProperty("state")]
    public String State
    {
                get; set;
        }
    
		    
    [JsonProperty("zipcode")]
    public String Zipcode
    {
                get; set;
        }
    
		
	
	}
}