//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Message
	{
		
		// Fields
		private IList<Document> _documents = new List<Document>();
		private IList<User> _to = new List<User>();
		
		// Accessors
		    
    [JsonProperty("content")]
    public String Content
    {
                get; set;
        }
    
		    
    [JsonProperty("created")]
    public Nullable<DateTime> Created
    {
                get; set;
        }
    
		    
    [JsonProperty("documents")]
    public IList<Document> Documents
    {
                get
        {
            return _documents;
        }
        }
        public Message AddDocument(Document value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _documents.Add(value);
        return this;
    }
    
		    
    [JsonProperty("from")]
    public User From
    {
                get; set;
        }
    
		    
    [JsonProperty("status")]
    public string Status
    {
                get; set;
        }
    
		    
    [JsonProperty("to")]
    public IList<User> To
    {
                get
        {
            return _to;
        }
        }
        public Message AddTo(User value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _to.Add(value);
        return this;
    }
    
		
	
	}
}