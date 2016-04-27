//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Credentials
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("email")]
    public String Email
    {
                get; set;
        }
    
		    
    [JsonProperty("newPassword")]
    public String NewPassword
    {
                get; set;
        }
    
		    
    [JsonProperty("password")]
    public String Password
    {
                get; set;
        }
    
		
	
	}
}