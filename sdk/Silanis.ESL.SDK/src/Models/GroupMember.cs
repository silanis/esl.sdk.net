//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class GroupMember
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("email")]
    public String Email
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
    
		    
    [JsonProperty("memberType")]
    public string MemberType
    {
                get; set;
        }
    
		    
    [JsonProperty("pending")]
    public Nullable<Boolean> Pending
    {
                get; set;
        }
    
		    
    [JsonProperty("userId")]
    public String UserId
    {
                get; set;
        }
    
		
	
	}
}