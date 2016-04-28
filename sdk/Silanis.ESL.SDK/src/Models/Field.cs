//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Field
	{

        internal Field(){
            Subtype = "FULLNAME";
            Type = "SIGNATURE";
        }
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("binding")]
    public String Binding
    {
                get; set;
        }
    
		    
    [JsonProperty("data")]
    public IDictionary<string, object> Data
    {
                get; set;
        }
    
		    
    [JsonProperty("extract")]
    public Nullable<Boolean> Extract
    {
                get; set;
        }
    
		    
    [JsonProperty("extractAnchor")]
    public ExtractAnchor ExtractAnchor
    {
                get; set;
        }
    
		    
    [JsonProperty("height")]
    public Nullable<Double> Height
    {
                get; set;
        }
    
		    
    [JsonProperty("id")]
    public String Id
    {
                get; set;
        }
    
		    
    [JsonProperty("left")]
    public Nullable<Double> Left
    {
                get; set;
        }
    
		    
    [JsonProperty("name")]
    public String Name
    {
                get; set;
        }
    
		    
    [JsonProperty("page")]
    public Nullable<Int32> Page
    {
                get; set;
        }
    
		    
    [JsonProperty("subtype")]
        public string Subtype
    {
                get; set;
        }
    
		    
    [JsonProperty("top")]
    public Nullable<Double> Top
    {
                get; set;
        }
    
		    
    [JsonProperty("type")]
    public string Type
    {
                get; set;
        }
    
		    
    [JsonProperty("validation")]
    public FieldValidation Validation
    {
                get; set;
        }
    
		    
    [JsonProperty("value")]
    public String Value
    {
                get; set;
        }
    
		    
    [JsonProperty("width")]
    public Nullable<Double> Width
    {
                get; set;
        }
    
		
	
	}
}