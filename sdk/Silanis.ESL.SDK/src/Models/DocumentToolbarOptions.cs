//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class DocumentToolbarOptions
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("downloadButton")]
    public Nullable<Boolean> DownloadButton
    {
                get; set;
        }
    
		
	
	}
}