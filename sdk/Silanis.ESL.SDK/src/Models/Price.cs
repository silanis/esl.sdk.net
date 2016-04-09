//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Price
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("amount")]
    public Nullable<Int32> Amount
    {
                get; set;
        }
    
		    
    [JsonProperty("currency")]
    public Currency Currency
    {
                get; set;
        }
    
		
	
	}
}