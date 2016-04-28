//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{


    internal class Callback
    {

        // Fields
        private IList<string> _events = new List<string>();

        // Accessors

        [JsonProperty("events")]
        public IList<string> Events
        {
            get
            {
                return _events;
            }
        }
        public Callback AddEvent(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Argument cannot be null");
            }

            _events.Add(value);
            return this;
        }


        [JsonProperty("key")]
        public String Key
        {
            get; set;
        }


        [JsonProperty("url")]
        public String Url
        {
            get; set;
        }



    }
}