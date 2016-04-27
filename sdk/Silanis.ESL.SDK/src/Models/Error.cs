//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Error
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("code")]
    public Nullable<Int32> Code
    {
                get; set;
        }
    
		    
    [JsonProperty("entity")]
    public Entity Entity
    {
                get; set;
        }
    
		    
    [JsonProperty("message")]
    public String Message
    {
                get; set;
        }
    
		    
    [JsonProperty("messageKey")]
    public String MessageKey
    {
                get; set;
        }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("technical")]
    public String Technical
    {
                get; set;
        }
    
		
	
	}
}