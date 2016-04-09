//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class SignatureStyle
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("handdrawn")]
    public String Handdrawn
    {
                get; set;
        }
    
		    
    [JsonProperty("textual")]
    public TextualSignatureStyle Textual
    {
                get; set;
        }
    
		
	
	}
}