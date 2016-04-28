//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class UserCustomField
	{
		
		// Fields
		private IList<Translation> _translations = null;
		
		// Accessors
		    
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
        public UserCustomField AddTranslation(Translation value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _translations.Add(value);
        return this;
    }
    
		    
    [JsonProperty("value")]
    public String Value
    {
                get; set;
        }
    
		
	
	}
}