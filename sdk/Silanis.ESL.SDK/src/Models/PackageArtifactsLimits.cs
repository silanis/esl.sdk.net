//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class PackageArtifactsLimits
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("documents")]
    public Nullable<Int32> Documents
    {
                get; set;
        }
    
		    
    [JsonProperty("roles")]
    public Nullable<Int32> Roles
    {
                get; set;
        }
    
		
	
	}
}