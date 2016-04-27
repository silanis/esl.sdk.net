//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class DelegationEventReport
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("eventDate")]
    public Nullable<DateTime> EventDate
    {
                get; set;
        }
    
		    
    [JsonProperty("eventDescription")]
    public String EventDescription
    {
                get; set;
        }
    
		    
    [JsonProperty("eventType")]
    public String EventType
    {
                get; set;
        }
    
		    
    [JsonProperty("eventUser")]
    public String EventUser
    {
                get; set;
        }
    
		
	
	}
}