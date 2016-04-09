//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class ExtractAnchor
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("anchorPoint")]
    public String AnchorPoint
    {
                get; set;
        }
    
		    
    [JsonProperty("characterIndex")]
    public Nullable<Int32> CharacterIndex
    {
                get; set;
        }
    
		    
    [JsonProperty("height")]
    public Nullable<Int32> Height
    {
                get; set;
        }
    
		    
    [JsonProperty("index")]
    public Nullable<Int32> Index
    {
                get; set;
        }
    
		    
    [JsonProperty("leftOffset")]
    public Nullable<Int32> LeftOffset
    {
                get; set;
        }
    
		    
    [JsonProperty("text")]
    public String Text
    {
                get; set;
        }
    
		    
    [JsonProperty("topOffset")]
    public Nullable<Int32> TopOffset
    {
                get; set;
        }
    
		    
    [JsonProperty("width")]
    public Nullable<Int32> Width
    {
                get; set;
        }
    
		
	
	}
}