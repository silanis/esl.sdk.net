//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class SignerAuthenticationToken
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("packageId")]
    public String PackageId
    {
                get; set;
        }
    
		    
    [JsonProperty("signerId")]
    public String SignerId
    {
                get; set;
        }


    [JsonProperty("sessionFields")]
    public IDictionary<string, string> SessionFields
    {
            get; set;
        }
    
		    
    [JsonProperty("value")]
    public String Value
    {
                get; set;
        }
    
		
	
	}
}