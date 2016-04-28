//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Group
	{
		
		// Fields
		private IList<GroupMember> _members = new List<GroupMember>();
		
		// Accessors
		    
    [JsonProperty("account")]
    public Account Account
    {
                get; set;
        }
    
		    
    [JsonProperty("created")]
    public Nullable<DateTime> Created
    {
                get; set;
        }
    
		    
    [JsonProperty("data")]
    public IDictionary<string, object> Data
    {
                get; set;
        }
    
		    
    [JsonProperty("email")]
    public String Email
    {
                get; set;
        }
    
		    
    [JsonProperty("emailMembers")]
    public Nullable<Boolean> EmailMembers
    {
                get; set;
        }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("members")]
    public IList<GroupMember> Members
    {
                get
        {
            return _members;
        }
        }
        public Group AddMember(GroupMember value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _members.Add(value);
        return this;
    }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("updated")]
    public Nullable<DateTime> Updated
    {
                get; set;
        }
    
		
	
	}
}