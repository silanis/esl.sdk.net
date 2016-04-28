//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class GuestAuth
	{
		
		// Fields
		private IList<AuthChallenge> _challenges = new List<AuthChallenge>();
		
		// Accessors
		    
    [JsonProperty("challenges")]
    public IList<AuthChallenge> Challenges
    {
                get
        {
            return _challenges;
        }
        }
        public GuestAuth AddChallenge(AuthChallenge value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _challenges.Add(value);
        return this;
    }
    
		    
    [JsonProperty("loginToken")]
    public String LoginToken
    {
                get; set;
        }
    
		    
    [JsonProperty("package")]
    public Package Package
    {
                get; set;
        }
    
		    
    [JsonProperty("scheme")]
    public string Scheme
    {
                get; set;
        }
    
		    
    [JsonProperty("user")]
    public User User
    {
                get; set;
        }
    
		
	
	}
}