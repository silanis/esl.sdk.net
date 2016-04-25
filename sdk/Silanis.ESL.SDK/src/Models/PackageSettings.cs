//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class PackageSettings
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("ceremony")]
    public CeremonySettings Ceremony
    {
                get; set;
        }
    
		
	
	}
}