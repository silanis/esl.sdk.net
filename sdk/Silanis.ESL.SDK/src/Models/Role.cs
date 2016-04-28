//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Role
	{
		
		// Fields
		private IList<AttachmentRequirement> _attachmentRequirements = new List<AttachmentRequirement>();
		private IList<Signer> _signers = new List<Signer>();
		private IList<String> _specialTypes = new List<String>();
		
		// Accessors
		    
    [JsonProperty("attachmentRequirements")]
    public IList<AttachmentRequirement> AttachmentRequirements
    {
                get
        {
            return _attachmentRequirements;
        }
        }
        public Role AddAttachmentRequirement(AttachmentRequirement value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _attachmentRequirements.Add(value);
        return this;
    }
    
		    
    [JsonProperty("data")]
    public IDictionary<string, object> Data
    {
                get; set;
        }
    
		    
    [JsonProperty("emailMessage")]
    public BaseMessage EmailMessage
    {
                get; set;
        }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("index")]
    public Nullable<Int32> Index
    {
                get; set;
        }
    
		    
    [JsonProperty("locked")]
    public Nullable<Boolean> Locked
    {
                get; set;
        }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("reassign")]
    public Nullable<Boolean> Reassign
    {
                get; set;
        }
    
		    
    [JsonProperty("signers")]
    public IList<Signer> Signers
    {
                get
        {
            return _signers;
        }
        }
        public Role AddSigner(Signer value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _signers.Add(value);
        return this;
    }
    
		    
    [JsonProperty("specialTypes")]
    public IList<String> SpecialTypes
    {
                get
        {
            return _specialTypes;
        }
        }
        public Role AddSpecialType(String value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _specialTypes.Add(value);
        return this;
    }
    
		    
    [JsonProperty("type")]
    public string Type
    {
                get; set;
        }
    
		
	
	}
}