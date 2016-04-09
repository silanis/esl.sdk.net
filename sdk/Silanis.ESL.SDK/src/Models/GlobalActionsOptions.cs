//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class GlobalActionsOptions
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("confirm")]
    public Nullable<Boolean> Confirm
    {
                get; set;
        }
    
		    
    [JsonProperty("download")]
    public Nullable<Boolean> Download
    {
                get; set;
        }
    
		    
    [JsonProperty("hideEvidenceSummary")]
    public Nullable<Boolean> HideEvidenceSummary
    {
                get; set;
        }
    
		    
    [JsonProperty("saveAsLayout")]
    public Nullable<Boolean> SaveAsLayout
    {
                get; set;
        }
    
		
	
	}
}