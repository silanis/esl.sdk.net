//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class Result<T>
	{
		
		// Fields
		private IList<T> _results = new List<T>();
		
		// Accessors
		    
    [JsonProperty("count")]
    public Nullable<Int32> Count
    {
                get; set;
        }
    
		    
    [JsonProperty("results")]
    public IList<T> Results
    {
                get
        {
            return _results;
        }
        }
        public Result<T> AddResult(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _results.Add(value);
        return this;
    }
    
		
	
	}
}