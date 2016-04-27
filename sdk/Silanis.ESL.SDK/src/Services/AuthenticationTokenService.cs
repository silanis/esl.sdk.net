using System;
using Silanis.ESL.SDK.Internal;
using Silanis.ESL.API;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class AuthenticationTokenService
    {
		private readonly RestClient _restClient;
		private readonly UrlTemplate _template;

		public AuthenticationTokenService (RestClient restClient, string baseUrl)
		{
			_restClient = restClient;
			_template = new UrlTemplate (baseUrl);
		}

        [Obsolete("call CreateUserAuthenticationToken instead")]
        public AuthenticationToken CreateAuthenticationToken ()
        {
            var userAuthenticationToken = CreateUserAuthenticationToken();
            var authenticationToken = new AuthenticationToken(userAuthenticationToken);
            return authenticationToken;
        }

        public string CreateUserAuthenticationToken ()
        {
            var path = _template.UrlFor (UrlTemplate.USER_AUTHENTICATION_TOKEN_PATH).Build ();

            try {
                var response = _restClient.Post(path, "");              
                return Json.Deserialize<API.AuthenticationToken> (response).Value;
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
                var path = _template.UrlFor (UrlTemplate.SENDER_AUTHENTICATION_TOKEN_PATH).Build ();
                var senderAuthenticationToken = new SenderAuthenticationToken();
                senderAuthenticationToken.PackageId = packageId.Id;
                var serializedObject = Json.Serialize(senderAuthenticationToken);
                var response = _restClient.Post(path, serializedObject);              
                return Json.Deserialize<SenderAuthenticationToken> (response).Value;
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
                var path = _template.UrlFor (UrlTemplate.SIGNER_AUTHENTICATION_TOKEN_PATH).Build ();
                var signerAuthenticationToken = new SignerAuthenticationToken
                {
                    PackageId = packageId.Id,
                    SignerId = signerId,
                    SessionFields = fields
                };

                var serializedObject = Json.Serialize(signerAuthenticationToken);
                var response = _restClient.Post(path, serializedObject);              
                return Json.Deserialize<SignerAuthenticationToken> (response).Value;
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