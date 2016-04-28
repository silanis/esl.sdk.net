//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class User
	{
		
		// Fields
		private IList<ProfessionalIdentityField> _professionalIdentityFields = new List<ProfessionalIdentityField>();
		private IList<String> _specialTypes = new List<String>();
		private IList<UserCustomField> _userCustomFields = new List<UserCustomField>();
		
		// Accessors
		    
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
        public User AddProfessionalIdentityField(ProfessionalIdentityField value)
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
        public User AddSpecialType(String value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _specialTypes.Add(value);
        return this;
    }
    
		    
    [JsonProperty("title")]
    public String Title
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
        public User AddUserCustomField(UserCustomField value)
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