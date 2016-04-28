//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Approval
	{
		
		// Fields
		private IList<Field> _fields = new List<Field>();
		
		// Accessors
		    
    [JsonProperty("accepted")]
    public Nullable<DateTime> Accepted
    {
                get; set;
        }
    
		    
    [JsonProperty("data")]
    public IDictionary<string, object> Data
    {
                get; set;
        }
    
		    
    [JsonProperty("fields")]
    public IList<Field> Fields
    {
                get
        {
            return _fields;
        }
        }
        public Approval AddField(Field value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _fields.Add(value);
        return this;
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
    
		    
    [JsonProperty("role")]
    public String Role
    {
                get; set;
        }
    
		    
    [JsonProperty("signed")]
    public Nullable<DateTime> Signed
    {
                get; set;
        }
    
		
	
	}
}