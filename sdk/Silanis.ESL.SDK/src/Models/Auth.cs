//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Auth
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
        public Auth AddChallenge(AuthChallenge value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _challenges.Add(value);
        return this;
    }
    
		    
    [JsonProperty("scheme")]
    public string Scheme
    {
                get; set;
        }
    
		
	
	}
}