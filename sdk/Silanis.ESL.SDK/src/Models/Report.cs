//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Report
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("from")]
    public Nullable<DateTime> From
    {
                get; set;
        }
    
		    
    [JsonProperty("to")]
    public Nullable<DateTime> To
    {
                get; set;
        }
    
		
	
	}
}