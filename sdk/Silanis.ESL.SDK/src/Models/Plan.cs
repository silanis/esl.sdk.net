//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Plan
	{
		
		// Fields
		private IList<Quota> _quotas = new List<Quota>();
		
		// Accessors
		    
    [JsonProperty("contract")]
    public string Contract
    {
                get; set;
        }
    
		    
    [JsonProperty("cycle")]
        public string Cycle
    {
                get; set;
        }
    
		    
    [JsonProperty("data")]
    public IDictionary<string, object> Data
    {
                get; set;
        }
    
		    
    [JsonProperty("description")]
    public String Description
    {
                get; set;
        }
    
		    
    [JsonProperty("features")]
    public IDictionary<string, object> Features
    {
                get; set;
        }
    
		    
    [JsonProperty("freeCycles")]
    public CycleCount FreeCycles
    {
                get; set;
        }
    
		    
    [JsonProperty("group")]
    public String Group
    {
                get; set;
        }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("original")]
    public String Original
    {
                get; set;
        }
    
		    
    [JsonProperty("price")]
    public Price Price
    {
                get; set;
        }
    
		    
    [JsonProperty("quotas")]
    public IList<Quota> Quotas
    {
                get
        {
            return _quotas;
        }
        }
        public Plan AddQuota(Quota value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _quotas.Add(value);
        return this;
    }
    
		
	
	}
}