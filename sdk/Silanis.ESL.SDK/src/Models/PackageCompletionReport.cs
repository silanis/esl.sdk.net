//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class PackageCompletionReport
	{
		
		// Fields
		private IList<DocumentsCompletionReport> _documents = new List<DocumentsCompletionReport>();
		private IList<SignersCompletionReport> _signers = new List<SignersCompletionReport>();
		
		// Accessors
		    
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
    
		    
    [JsonProperty("documents")]
    public IList<DocumentsCompletionReport> Documents
    {
                get
        {
            return _documents;
        }
        }
        public PackageCompletionReport AddDocument(DocumentsCompletionReport value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _documents.Add(value);
        return this;
    }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("signers")]
    public IList<SignersCompletionReport> Signers
    {
                get
        {
            return _signers;
        }
        }
        public PackageCompletionReport AddSigner(SignersCompletionReport value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _signers.Add(value);
        return this;
    }
    
		    
    [JsonProperty("status")]
    public string Status
    {
                get; set;
        }
    
		    
    [JsonProperty("trashed")]
    public Nullable<Boolean> Trashed
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