//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Account
	{
		
		// Fields
		private IList<CustomField> _customFields = new List<CustomField>();
		private IList<License> _licenses = new List<License>();
		
		// Accessors
		    
    [JsonProperty("company")]
    public Company Company
    {
                get; set;
        }
    
		    
    [JsonProperty("created")]
    public Nullable<DateTime> Created
    {
                get; set;
        }
    
		    
    [JsonProperty("customFields")]
    public IList<CustomField> CustomFields
    {
                get
        {
            return _customFields;
        }
        }
        public Account AddCustomField(CustomField value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _customFields.Add(value);
        return this;
    }
    
		    
    [JsonProperty("data")]
    public IDictionary<string, object> Data
    {
                get; set;
        }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("licenses")]
    public IList<License> Licenses
    {
                get
        {
            return _licenses;
        }
        }
        public Account AddLicense(License value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _licenses.Add(value);
        return this;
    }
    
		    
    [JsonProperty("logoUrl")]
    public String LogoUrl
    {
                get; set;
        }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("owner")]
    public String Owner
    {
                get; set;
        }
    
		    
    [JsonProperty("providers")]
    public AccountProviders Providers
    {
                get; set;
        }
    
		    
    [JsonProperty("updated")]
    public Nullable<DateTime> Updated
    {
                get; set;
        }
    
		
	
	}
}