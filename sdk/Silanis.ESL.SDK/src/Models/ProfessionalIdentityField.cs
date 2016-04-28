//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class ProfessionalIdentityField
	{
		
		// Fields
		private IList<Translation> _translations = null;
		
		// Accessors
		    
    [JsonProperty("category")]
    public String Category
    {
                get; set;
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
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("translations")]
    public IList<Translation> Translations
    {
                get
        {
            return _translations;
        }
        }
        public ProfessionalIdentityField AddTranslation(Translation value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _translations.Add(value);
        return this;
    }
    
		    
    [JsonProperty("type")]
    public String Type
    {
                get; set;
        }
    
		    
    [JsonProperty("value")]
    public String Value
    {
                get; set;
        }
    
		
	
	}
}