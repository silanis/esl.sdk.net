//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class CeremonyEventComplete
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("dialog")]
    public Nullable<Boolean> Dialog
    {
                get; set;
        }
    
		    
    [JsonProperty("redirect")]
    public String Redirect
    {
                get; set;
        }
    
		
	
	}
}