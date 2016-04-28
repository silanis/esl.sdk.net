//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{


    internal class Session
    {

        // Fields
        private IList<String> _packages = new List<String>();

        // Accessors

        [JsonProperty("account")]
        public Account Account
        {
            get; set;
        }


        [JsonProperty("delegationUser")]
        public DelegationUser DelegationUser
        {
            get; set;
        }


        [JsonProperty("features")]
        public Features Features
        {
            get; set;
        }


        [JsonProperty("inPerson")]
        public Boolean InPerson
        {
            get; set;
        }


        [JsonProperty("packages")]
        public IList<String> Packages
        {
            get
            {
                return _packages;
            }
        }
        public Session AddPackage(String value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Argument cannot be null");
            }

            _packages.Add(value);
            return this;
        }


        [JsonProperty("restricted")]
        public Boolean Restricted
        {
            get; set;
        }


        [JsonProperty("support")]
        public SupportConfiguration Support
        {
            get; set;
        }


        [JsonProperty("user")]
        public User User
        {
            get; set;
        }



    }
}