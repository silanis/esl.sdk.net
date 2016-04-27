//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class HeaderOptions
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("breadcrumbs")]
    public Nullable<Boolean> Breadcrumbs
    {
                get; set;
        }
    
		    
    [JsonProperty("feedback")]
    public Nullable<Boolean> Feedback
    {
                get; set;
        }
    
		    
    [JsonProperty("globalActions")]
    public GlobalActionsOptions GlobalActions
    {
                get; set;
        }
    
		    
    [JsonProperty("globalNavigation")]
    public Nullable<Boolean> GlobalNavigation
    {
                get; set;
        }
    
		    
    [JsonProperty("sessionBar")]
    public Nullable<Boolean> SessionBar
    {
                get; set;
        }
    
		    
    [JsonProperty("titleBar")]
    public TitleBarOptions TitleBar
    {
                get; set;
        }
    
		
	
	}
}