//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class AttachmentRequirement
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("comment")]
    public String Comment
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
    
		    
    [JsonProperty("required")]
    public Nullable<Boolean> Required
    {
                get; set;
        }
    
		    
    [JsonProperty("status")]
    public string Status
    {
                get; set;
        }
    
		
	
	}
}