//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class UsageReport
	{
		
		// Fields
		private IList<SenderUsageReport> _senders = new List<SenderUsageReport>();
		
		// Accessors
		    
    [JsonProperty("from")]
    public Nullable<DateTime> From
    {
                get; set;
        }
    
		    
    [JsonProperty("senders")]
    public IList<SenderUsageReport> Senders
    {
                get
        {
            return _senders;
        }
        }
        public UsageReport AddSender(SenderUsageReport value)
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