//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class FieldValidation
	{
		
		// Fields
		private IList<String> _enum = new List<String>();
		
		// Accessors
		    
    [JsonProperty("enum")]
    public IList<String> Enum
    {
                get
        {
            return _enum;
        }
        }
        public FieldValidation AddEnum(String value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _enum.Add(value);
        return this;
    }
    
		    
    [JsonProperty("errorCode")]
    public Nullable<Int32> ErrorCode
    {
                get; set;
        }
    
		    
    [JsonProperty("errorMessage")]
    public String ErrorMessage
    {
                get; set;
        }
    
		    
    [JsonProperty("maxLength")]
    public Nullable<Int32> MaxLength
    {
                get; set;
        }
    
		    
    [JsonProperty("minLength")]
    public Nullable<Int32> MinLength
    {
                get; set;
        }
    
		    
    [JsonProperty("pattern")]
    public String Pattern
    {
                get; set;
        }
    
		    
    [JsonProperty("required")]
    public Nullable<Boolean> Required
    {
                get; set;
            }
    
		
	
	}
}