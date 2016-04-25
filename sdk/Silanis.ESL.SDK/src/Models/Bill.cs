//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Bill
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("address")]
    public Address Address
    {
                get; set;
        }
    
		    
    [JsonProperty("creditCard")]
    public CreditCard CreditCard
    {
                get; set;
        }
    
		    
    [JsonProperty("phone")]
    public String Phone
    {
                get; set;
        }
    
		    
    [JsonProperty("plan")]
    public String Plan
    {
                get; set;
        }
    
		    
    [JsonProperty("senderQuantity")]
    public Nullable<Int32> SenderQuantity
    {
                get; set;
        }
    
		
	
	}
}