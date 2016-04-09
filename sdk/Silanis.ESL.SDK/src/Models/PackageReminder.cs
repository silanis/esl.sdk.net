//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class PackageReminder
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("date")]
    public Nullable<DateTime> Date
    {
                get; set;
        }
    
		    
    [JsonProperty("sentDate")]
    public Nullable<DateTime> SentDate
    {
                get; set;
        }
    
		
	
	}
}