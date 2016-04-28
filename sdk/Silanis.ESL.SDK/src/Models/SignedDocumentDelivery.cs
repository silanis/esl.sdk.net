//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class SignedDocumentDelivery
	{
		
		// Fields
		private IList<External> _destinations = new List<External>();
		private IList<Document> _excludedDocuments = new List<Document>();
		
		// Accessors
		    
    [JsonProperty("destinations")]
    public IList<External> Destinations
    {
                get
        {
            return _destinations;
        }
        }
        public SignedDocumentDelivery AddDestination(External value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _destinations.Add(value);
        return this;
    }
    
		    
    [JsonProperty("excludedDocuments")]
    public IList<Document> ExcludedDocuments
    {
                get
        {
            return _excludedDocuments;
        }
        }
        public SignedDocumentDelivery AddExcludedDocument(Document value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _excludedDocuments.Add(value);
        return this;
    }
    
		    
    [JsonProperty("filePrefix")]
    public String FilePrefix
    {
                get; set;
        }
    
		    
    [JsonProperty("fileSuffix")]
    public String FileSuffix
    {
                get; set;
        }
    
		
	
	}
}