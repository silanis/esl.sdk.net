//

using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class LayoutStyle
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("brandingBar")]
    public Image BrandingBar
    {
                get; set;
        }
    
		    
    [JsonProperty("dialog")]
    public Style Dialog
    {
                get; set;
        }
    
		    
    [JsonProperty("titleBar")]
    public Style TitleBar
    {
                get; set;
        }
    
		    
    [JsonProperty("toolbar")]
    public Style Toolbar
    {
                get; set;
        }
    
		
	
	}
}