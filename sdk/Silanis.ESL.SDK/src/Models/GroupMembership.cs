//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class GroupMembership
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("groupId")]
    public String GroupId
    {
                get; set;
        }
    
		    
    [JsonProperty("groupName")]
    public String GroupName
    {
                get; set;
        }
    
		    
    [JsonProperty("memberType")]
    public string MemberType
    {
                get; set;
        }
    
		
	
	}
}