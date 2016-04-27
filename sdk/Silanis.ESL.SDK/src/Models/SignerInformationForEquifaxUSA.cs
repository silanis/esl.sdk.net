//
using System;
using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class SignerInformationForEquifaxUSA
	{
		
		// Fields
		
		// Accessors
		    
    [JsonProperty("city")]
    public String City
    {
                get; set;
        }
    
		    
    [JsonProperty("dateOfBirth")]
    public Nullable<DateTime> DateOfBirth
    {
                get; set;
        }
    
    [JsonProperty("driversLicenseNumber")]
    public String DriversLicenseNumber
        {
            get; set;
        }



    [JsonProperty("firstName")]
    public String FirstName
    {
                get; set;
        }
    
		    
    [JsonProperty("homePhoneNumber")]
    public String HomePhoneNumber
    {
                get; set;
        }
    
		    
    [JsonProperty("lastName")]
    public String LastName
    {
                get; set;
        }
    
		    
    [JsonProperty("socialSecurityNumber")]
    public String SocialSecurityNumber
    {
                get; set;
        }
    
		    
    [JsonProperty("state")]
    public String State
    {
                get; set;
        }
    
		    
    [JsonProperty("streetAddress")]
    public String StreetAddress
    {
                get; set;
        }
    

   [JsonProperty("timeAtAddress")]
        public Nullable<Int32> TimeAtAddress
   {
            get; set;
        }


    [JsonProperty("zip")]
    public String Zip
    {
                get; set;
        }
    
		
	
	}
}