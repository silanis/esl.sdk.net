//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Sender
	{
		
		// Fields
		private IList<GroupMembership> _memberships = new List<GroupMembership>();
		private IList<ProfessionalIdentityField> _professionalIdentityFields = new List<ProfessionalIdentityField>();
		private IList<String> _specialTypes = new List<String>();
		private IList<UserCustomField> _userCustomFields = new List<UserCustomField>();

        internal Sender(){
            Status = "INVITED";
            Type = "REGULAR";
        }
		
		// Accessors
		    
    [JsonProperty("account")]
    public Account Account
    {
                get; set;
        }
    
		    
    [JsonProperty("activated")]
    public Nullable<DateTime> Activated
    {
                get; set;
        }
    
		    
    [JsonProperty("address")]
    public Address Address
    {
                get; set;
        }
    
		    
    [JsonProperty("company")]
    public String Company
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
    
		    
    [JsonProperty("external")]
    public External External
    {
                get; set;
        }
    
		    
    [JsonProperty("firstName")]
    public String FirstName
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
    
		    
    [JsonProperty("lastName")]
    public String LastName
    {
                get; set;
        }
    
		    
    [JsonProperty("locked")]
    public Nullable<DateTime> Locked
    {
                get; set;
        }
    
		    
    [JsonProperty("memberships")]
    public IList<GroupMembership> Memberships
    {
                get
        {
            return _memberships;
        }
        }
        public Sender AddMembership(GroupMembership value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _memberships.Add(value);
        return this;
    }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("phone")]
    public String Phone
    {
                get; set;
        }
    
		    
    [JsonProperty("professionalIdentityFields")]
    public IList<ProfessionalIdentityField> ProfessionalIdentityFields
    {
                get
        {
            return _professionalIdentityFields;
        }
        }
        public Sender AddProfessionalIdentityField(ProfessionalIdentityField value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _professionalIdentityFields.Add(value);
        return this;
    }
    
		    
    [JsonProperty("signature")]
    public SignatureStyle Signature
    {
                get; set;
        }
    
		    
    [JsonProperty("specialTypes")]
    public IList<String> SpecialTypes
    {
                get
        {
            return _specialTypes;
        }
        }
        public Sender AddSpecialType(String value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _specialTypes.Add(value);
        return this;
    }
    
		    
    [JsonProperty("status")]
    public string Status
    {
                get; set;
        }
    
		    
    [JsonProperty("title")]
    public String Title
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
    
		    
    [JsonProperty("userCustomFields")]
    public IList<UserCustomField> UserCustomFields
    {
                get
        {
            return _userCustomFields;
        }
        }
        public Sender AddUserCustomField(UserCustomField value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _userCustomFields.Add(value);
        return this;
    }
    
		
	
	}
}