//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class CreditCard
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("cvv")]
    public String Cvv
    {
                get; set;
        }
    
		    
    [JsonProperty("expiration")]
    public CcExpiration Expiration
    {
                get; set;
        }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("number")]
    public String Number
    {
                get; set;
        }
    
		    
    [JsonProperty("type")]
    public String Type
    {
                get; set;
        }
    
		
	
	}
}