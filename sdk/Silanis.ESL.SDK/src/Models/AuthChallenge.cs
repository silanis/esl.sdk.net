//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class AuthChallenge
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("answer")]
    public String Answer
    {
                get; set;
        }
    
		    
    [JsonProperty("maskInput")]
    public Nullable<Boolean> MaskInput
    {
                get; set;
        }
    
		    
    [JsonProperty("question")]
    public String Question
    {
                get; set;
        }
    
		
	
	}
}