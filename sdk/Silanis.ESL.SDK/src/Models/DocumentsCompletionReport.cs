//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class DocumentsCompletionReport
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("completed")]
    public Nullable<Boolean> Completed
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
    
		    
    [JsonProperty("lastSigned")]
    public Nullable<DateTime> LastSigned
    {
                get; set;
        }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		
	
	}
}