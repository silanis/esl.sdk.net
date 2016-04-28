//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class BaseTemplate
	{
		
		// Fields
		private IList<Document> _documents = new List<Document>();
		private IList<Message> _messages = new List<Message>();
		private IList<Role> _roles = new List<Role>();
		
		// Accessors
		    
    [JsonProperty("autocomplete")]
    public Nullable<Boolean> Autocomplete
    {
                get; set;
        }
    
		    
    [JsonProperty("consent")]
    public String Consent
    {
                get; set;
        }
    
		    
    [JsonProperty("data")]
    public IDictionary<string, object> Data
    {
                get; set;
        }
    
		    
    [JsonProperty("description")]
    public String Description
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
        public BaseTemplate AddDocument(Document value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _documents.Add(value);
        return this;
    }
    
		    
    [JsonProperty("due")]
    public Nullable<DateTime> Due
    {
                get; set;
        }
    
		    
    [JsonProperty("emailMessage")]
    public String EmailMessage
    {
                get; set;
        }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("language")]
    public String Language
    {
                get; set;
        }
    
		    
    [JsonProperty("limits")]
    public PackageArtifactsLimits Limits
    {
                get; set;
        }
    
		    
    [JsonProperty("messages")]
    public IList<Message> Messages
    {
                get
        {
            return _messages;
        }
        }
        public BaseTemplate AddMessage(Message value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _messages.Add(value);
        return this;
    }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("notarized")]
    public Nullable<Boolean> Notarized
    {
                get; set;
        }
    
		    
    [JsonProperty("notaryRoleId")]
    public String NotaryRoleId
    {
                get; set;
        }
    
		    
    [JsonProperty("roles")]
    public IList<Role> Roles
    {
                get
        {
            return _roles;
        }
        }
        public BaseTemplate AddRole(Role value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _roles.Add(value);
        return this;
    }
    
		    
    [JsonProperty("sender")]
    public Sender Sender
    {
                get; set;
        }
    
		    
    [JsonProperty("settings")]
    public PackageSettings Settings
    {
                get; set;
        }
    
		    
    [JsonProperty("signedDocumentDelivery")]
    public SignedDocumentDelivery SignedDocumentDelivery
    {
                get; set;
        }
    
		    
    [JsonProperty("status")]
    public string Status
    {
                get; set;
        }
    
		    
    [JsonProperty("type")]
    public string Type
    {
                get; set;
        }
    
		    
    [JsonProperty("updated")]
    public Nullable<DateTime> Updated
    {
                get; set;
        }
    
		    
    [JsonProperty("visibility")]
    public string Visibility
    {
                get; set;
        }
    
		
	
	}
}