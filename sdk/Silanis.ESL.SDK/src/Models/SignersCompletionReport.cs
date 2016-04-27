//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class SignersCompletionReport
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("completed")]
    public Nullable<Boolean> Completed
    {
                get; set;
        }
    
		    
    [JsonProperty("email")]
    public String Email
    {
                get; set;
        }
    
		    
    [JsonProperty("firstName")]
    public String FirstName
    {
                get; set;
        }
    
		    
    [JsonProperty("firstSigned")]
    public Nullable<DateTime> FirstSigned
    {
                get; set;
        }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("lastName")]
    public String LastName
    {
                get; set;
        }
    
		    
    [JsonProperty("lastSigned")]
    public Nullable<DateTime> LastSigned
    {
                get; set;
        }
    
		
	
	}
}