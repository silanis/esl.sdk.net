//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Transaction
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("created")]
    public Nullable<DateTime> Created
    {
                get; set;
        }
    
		    
    [JsonProperty("creditCard")]
    public CreditCard CreditCard
    {
                get; set;
        }
    
		    
    [JsonProperty("price")]
    public Price Price
    {
                get; set;
        }
    
		
	
	}
}