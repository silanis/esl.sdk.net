//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class License
	{
		
		// Fields
		private IList<Transaction> _transactions = new List<Transaction>();
		
		// Accessors
		    
    [JsonProperty("created")]
    public Nullable<DateTime> Created
    {
                get; set;
        }
    
		    
    [JsonProperty("paidUntil")]
    public Nullable<DateTime> PaidUntil
    {
                get; set;
        }
    
		    
    [JsonProperty("plan")]
    public Plan Plan
    {
                get; set;
        }
    
		    
    [JsonProperty("status")]
    public string Status
    {
                get; set;
        }
    
		    
    [JsonProperty("transactions")]
    public IList<Transaction> Transactions
    {
                get
        {
            return _transactions;
        }
        }
        public License AddTransaction(Transaction value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _transactions.Add(value);
        return this;
    }
    
		
	
	}
}