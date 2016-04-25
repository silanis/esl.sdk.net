using System;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class AuthenticationTokenService
    {
		private RestClient restClient;
		private UrlTemplate template;

		public AuthenticationTokenService (RestClient restClient, string baseUrl)
		{
			this.restClient = restClient;
			template = new UrlTemplate (baseUrl);
		}

        [Obsolete("call CreateUserAuthenticationToken instead")]
        public Silanis.ESL.SDK.AuthenticationToken CreateAuthenticationToken ()
        {
            string userAuthenticationToken = CreateUserAuthenticationToken();
            Silanis.ESL.SDK.AuthenticationToken authenticationToken = new Silanis.ESL.SDK.AuthenticationToken(userAuthenticationToken);
            return authenticationToken;
        }

        public string CreateUserAuthenticationToken ()
        {
            string path = template.UrlFor (UrlTemplate.USER_AUTHENTICATION_TOKEN_PATH).Build ();

            try {
                string response = restClient.Post(path, "");              
                return JsonConvert.DeserializeObject<Silanis.ESL.API.AuthenticationToken> (response).Value;
            }
            catch (EslServerException e) {
                throw new EslServerException ("Could not create an authentication token for a user." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Could not create an authentication token for a user." + " Exception: " + e.Message, e);
            }
        }

        public string CreateSenderAuthenticationToken (PackageId packageId)
        {
            try {
                string path = template.UrlFor (UrlTemplate.SENDER_AUTHENTICATION_TOKEN_PATH).Build ();
                SenderAuthenticationToken senderAuthenticationToken = new SenderAuthenticationToken();
                senderAuthenticationToken.PackageId = packageId.Id;
                string serializedObject = JsonConvert.SerializeObject(senderAuthenticationToken);
                string response = restClient.Post(path, serializedObject);              
                return JsonConvert.DeserializeObject<SenderAuthenticationToken> (response).Value;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Could not create an authentication token for a sender." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Could not create an authentication token for a sender." + " Exception: " + e.Message, e);
            }
        }

        public string CreateSignerAuthenticationToken (PackageId packageId, string signerId)
        {
            return CreateSignerAuthenticationToken(packageId, signerId, null);
        }

        public string CreateSignerAuthenticationToken (PackageId packageId, string signerId, IDictionary<string, string> fields)
        {
            try {
                string path = template.UrlFor (UrlTemplate.SIGNER_AUTHENTICATION_TOKEN_PATH).Build ();
                SignerAuthenticationToken signerAuthenticationToken = new SignerAuthenticationToken();
                signerAuthenticationToken.PackageId = packageId.Id;
                signerAuthenticationToken.SignerId = signerId;
                signerAuthenticationToken.SessionFields = fields;

                string serializedObject = JsonConvert.SerializeObject(signerAuthenticationToken);
                string response = restClient.Post(path, serializedObject);              
                return JsonConvert.DeserializeObject<SignerAuthenticationToken> (response).Value;
            } 
            catch (EslServerException e) {
                throw new EslServerException ("Could not create an authentication token for a signer." + " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException ("Could not create an authentication token for a signer." + " Exception: " + e.Message, e);
            }
        }
    }
}