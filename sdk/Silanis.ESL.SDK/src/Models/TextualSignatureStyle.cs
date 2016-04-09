//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class TextualSignatureStyle
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("color")]
    public String Color
    {
                get; set;
        }
    
		    
    [JsonProperty("font")]
    public String Font
    {
                get; set;
        }
    
		
	
	}
}