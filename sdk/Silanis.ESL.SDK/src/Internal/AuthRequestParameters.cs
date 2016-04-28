using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class AuthRequestParameters
    {
        private readonly string sessionToken;
        private readonly string apiKey;
        private string tempToken;
        private string connectorsAuth;
        private readonly IDictionary<string, string> headers;

        public AuthRequestParameters(string sessionToken, string apiKey, IDictionary<string, string> headers) 
        {
            this.sessionToken = sessionToken;
            this.apiKey = apiKey;
            this.headers = headers;
            tempToken = null;
        }

        public AuthRequestParameters(string sessionToken, string apiKey, string tempToken, IDictionary<string, string> headers) 
        {
            this.sessionToken = sessionToken;
            this.apiKey = apiKey;
            this.tempToken = tempToken;
            this.headers = headers;
        }

        public AuthRequestParameters(string sessionToken, string apiKey, string tempToken, string connectorsAuth, IDictionary<string, string> headers) 
        {
            this.sessionToken = sessionToken;
            this.apiKey = apiKey;
            this.tempToken = tempToken;
            this.connectorsAuth = connectorsAuth;
            this.headers = headers;
        }

        private AuthRequestParameters()
        {
            apiKey = null;
            sessionToken = null;
            tempToken = null;
            headers = null;
        }

        public AuthRequestParameters(string sessionId, string apiKey) 
        {
            this.apiKey = apiKey;
            sessionToken = sessionId;
            tempToken = null;
            headers = null;
        }

        public string getSessionToken() 
        {
            return sessionToken;
        }

        public string getApiKey() 
        {
            return apiKey;
        }

        public IDictionary<string, string> getHeaders() 
        {
            return headers;
        }

        public string getTempToken() 
        {
            return tempToken;
        }

        public bool hasSessionToken() 
        {
            return sessionToken != null;
        }

        public bool hasApiKey() 
        {
            return apiKey != null;
        }

        public bool hasTempToken()
        {
            return tempToken != null;
        }

        public bool hasConnectorsAuth()
        {
            return connectorsAuth != null;
        }

        public string getConnectorsAuth() 
        {
            return connectorsAuth;
        }

        public static AuthRequestParameters empty() 
        {
            return new AuthRequestParameters();
        }

        public bool hasHeaders() 
        {
            return headers != null;
        }

        public static AuthRequestParameters withTempToken(string tempToken) 
        {
            var authRequestParameters = new AuthRequestParameters();
            authRequestParameters.tempToken = tempToken;
            return authRequestParameters;
        }
    }
}

