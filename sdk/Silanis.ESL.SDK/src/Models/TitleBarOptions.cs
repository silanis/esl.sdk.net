//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class TitleBarOptions
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("progressBar")]
    public Nullable<Boolean> ProgressBar
    {
                get; set;
        }
    
		    
    [JsonProperty("title")]
    public Nullable<Boolean> Title
    {
                get; set;
        }
    
		
	
	}
}