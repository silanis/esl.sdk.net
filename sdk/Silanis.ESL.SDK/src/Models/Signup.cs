//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Signup
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("bill")]
    public Bill Bill
    {
                get; set;
        }
    
		    
    [JsonProperty("email")]
    public String Email
    {
                get; set;
        }
    
		    
    [JsonProperty("emailVerified")]
    public Nullable<Boolean> EmailVerified
    {
                get; set;
        }
    
		    
    [JsonProperty("firstName")]
    public String FirstName
    {
                get; set;
        }
    
		    
    [JsonProperty("lastName")]
    public String LastName
    {
                get; set;
        }
    
		    
    [JsonProperty("name")]
    public String Name
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
    
		    
    [JsonProperty("phone")]
    public String Phone
    {
                get; set;
        }
    
		
	
	}
}