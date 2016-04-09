//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Style
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("backgroundColor")]
    public String BackgroundColor
    {
                get; set;
        }
    
		    
    [JsonProperty("color")]
    public String Color
    {
                get; set;
        }
    
		
	
	}
}