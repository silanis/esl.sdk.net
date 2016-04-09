//

using Newtonsoft.Json;
namespace Silanis.ESL.API
{
	
	
	internal class KnowledgeBasedAuthentication
	{
		
		// Fields
		
		// Accessors

        [JsonProperty("knowledgeBasedAuthenticationStatus")]
        public string KnowledgeBasedAuthenticationStatus
        {
            get; set;
        }

    [JsonProperty("signerInformationForEquifaxCanada")]
    public SignerInformationForEquifaxCanada SignerInformationForEquifaxCanada
    {
                get; set;
        }
    
		    
    [JsonProperty("signerInformationForEquifaxUSA")]
    public SignerInformationForEquifaxUSA SignerInformationForEquifaxUSA
    {
                get; set;
        }
    
		
	
	}
}