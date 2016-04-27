//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class LayoutOptions
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("brandingBar")]
    public BrandingBarOptions BrandingBar
    {
                get; set;
        }
    
		    
    [JsonProperty("footer")]
    public FooterOptions Footer
    {
                get; set;
        }
    
		    
    [JsonProperty("header")]
    public HeaderOptions Header
    {
                get; set;
        }
    
		    
    [JsonProperty("iframe")]
    public Nullable<Boolean> Iframe
    {
                get; set;
        }
    
		    
    [JsonProperty("navigator")]
    public Nullable<Boolean> Navigator
    {
                get; set;
        }
    
		
	
	}
}