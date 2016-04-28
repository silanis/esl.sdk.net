//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Document
	{
		
		// Fields
		private IList<Approval> _approvals = new List<Approval>();
		private IList<Field> _fields = new List<Field>();
		private IList<Page> _pages = new List<Page>();
		
		// Accessors
		    
    [JsonProperty("approvals")]
    public IList<Approval> Approvals
    {
                get
        {
            return _approvals;
        }
            set
            {
                _approvals = value;
            }
        }
        public Document AddApproval(Approval value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _approvals.Add(value);
        return this;
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
    
		    
    [JsonProperty("external")]
    public External External
    {
                get; set;
        }
    
		    
    [JsonProperty("extract")]
    public Nullable<Boolean> Extract
    {
                get; set;
        }
    
		    
    [JsonProperty("fields")]
    public IList<Field> Fields
    {
                get
        {
            return _fields;
        }
            set
            {
                _fields = value;
            }
        }
        public Document AddField(Field value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _fields.Add(value);
        return this;
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
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("pages")]
    public IList<Page> Pages
    {
                get
        {
            return _pages;
        }
            set
            {
                _pages = value;
            }
        }
        public Document AddPage(Page value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _pages.Add(value);
        return this;
    }
    
		    
    [JsonProperty("size")]
    public Nullable<Int32> Size
    {
                get; set;
        }
    
		
	
	}
}