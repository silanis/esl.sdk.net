//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class PackageReminderSchedule
	{
		
		// Fields
		private IList<PackageReminder> _reminders = new List<PackageReminder>();
		
		// Accessors
		    
    [JsonProperty("intervalInDays")]
    public Nullable<Int32> IntervalInDays
    {
                get; set;
        }
    
		    
    [JsonProperty("packageId")]
    public String PackageId
    {
                get; set;
        }
    
		    
    [JsonProperty("reminders")]
    public IList<PackageReminder> Reminders
    {
                get
        {
            return _reminders;
        }
        }
        public PackageReminderSchedule AddReminder(PackageReminder value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("Argument cannot be null");
        }
        
        _reminders.Add(value);
        return this;
    }
    
		    
    [JsonProperty("repetitionsCount")]
    public Nullable<Int32> RepetitionsCount
    {
                get; set;
        }
    
		    
    [JsonProperty("startInDaysDelay")]
    public Nullable<Int32> StartInDaysDelay
    {
                get; set;
        }
    
		
	
	}
}