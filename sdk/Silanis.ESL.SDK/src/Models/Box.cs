//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Box
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("height")]
    public Nullable<Double> Height
    {
                get; set;
        }
    
		    
    [JsonProperty("left")]
    public Nullable<Double> Left
    {
                get; set;
        }
    
		    
    [JsonProperty("top")]
    public Nullable<Double> Top
    {
                get; set;
        }
    
		    
    [JsonProperty("width")]
    public Nullable<Double> Width
    {
                get; set;
        }
    
		
	
	}
}