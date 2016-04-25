//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class CcExpiration
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("month")]
    public Nullable<Int32> Month
    {
                get; set;
        }
    
		    
    [JsonProperty("year")]
    public Nullable<Int32> Year
    {
                get; set;
        }
    
		
	
	}
}