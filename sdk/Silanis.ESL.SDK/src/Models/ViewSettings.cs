//

using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class ViewSettings
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("layout")]
    public LayoutOptions Layout
    {
                get; set;
        }
    
		    
    [JsonProperty("style")]
    public LayoutStyle Style
    {
                get; set;
        }
    
		
	
	}
}