//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Page
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("height")]
    public Nullable<Double> Height
    {
                get; set;
        }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("index")]
    public Nullable<Int32> Index
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
    
		    
    [JsonProperty("version")]
    public Nullable<Int32> Version
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