using System;

namespace Silanis.ESL.SDK
{
    public class KnowledgeBasedAuthentication
    {

        public KnowledgeBasedAuthentication() 
        {
        }

        public SignerInformationForEquifaxCanada SignerInformationForEquifaxCanada
        {
            get; set;
        }

        public SignerInformationForEquifaxUSA SignerInformationForEquifaxUSA
        {
            get; set;
        }

        public KnowledgeBasedAuthenticationStatus KnowledgeBasedAuthenticationStatus
        {
            get; set;
        }
    }
}

