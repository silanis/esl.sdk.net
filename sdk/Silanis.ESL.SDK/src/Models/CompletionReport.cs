//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class CompletionReport
	{
		
		// Fields
		private IList<SenderCompletionReport> _senders = new List<SenderCompletionReport>();
		
		// Accessors
		    
    [JsonProperty("from")]
    public Nullable<DateTime> From
    {
                get; set;
        }
    
		    
    [JsonProperty("senders")]
    public IList<SenderCompletionReport> Senders
    {
                get
        {
            return _senders;
        }
        }
        public CompletionReport AddSender(SenderCompletionReport value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _senders.Add(value);
        return this;
    }
    
		    
    [JsonProperty("to")]
    public Nullable<DateTime> To
    {
                get; set;
        }
    
		
	
	}
}