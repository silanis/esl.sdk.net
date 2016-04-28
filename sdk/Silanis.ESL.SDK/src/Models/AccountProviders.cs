//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class AccountProviders
	{
		
		// Fields
		private IList<Provider> _documents = new List<Provider>();
		private IList<Provider> _users = new List<Provider>();
		
		// Accessors
		    
    [JsonProperty("documents")]
    public IList<Provider> Documents
    {
                get
        {
            return _documents;
        }
        }
        public AccountProviders AddDocument(Provider value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _documents.Add(value);
        return this;
    }
    
		    
    [JsonProperty("users")]
    public IList<Provider> Users
    {
                get
        {
            return _users;
        }
        }
        public AccountProviders AddUser(Provider value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _users.Add(value);
        return this;
    }
    
		
	
	}
}