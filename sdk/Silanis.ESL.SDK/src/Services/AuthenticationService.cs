using System;
using System.Web;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class AuthenticationService
    {
        private readonly UnauthenticatedRestClient _client;
        private readonly UrlTemplate _webpageTemplate;
        private readonly UrlTemplate _authenticationTemplate;

        public AuthenticationService(string webpageUrl)
        {
            _client = new UnauthenticatedRestClient();
            _authenticationTemplate = new UrlTemplate(webpageUrl + UrlTemplate.ESL_AUTHENTICATION_PATH);
            _webpageTemplate = new UrlTemplate(webpageUrl);
        }

        public string GetSessionIdForUserAuthenticationToken(string userAuthenticationToken)
        {
            var path = _authenticationTemplate.UrlFor(UrlTemplate.AUTHENTICATION_PATH_FOR_USER_AUTHENTICATION_TOKEN)
                                                .Replace("{authenticationToken}", userAuthenticationToken)
                                                .Build();
            try {
                var stringResponse = _client.GetUnauthenticated(path);
                var userSessionIdToken = Json.Deserialize<SessionToken> (stringResponse);
                return userSessionIdToken.Token;
            }
            catch (EslServerException e) {
                throw new EslServerException("Could not authenticate using an authentication token."+ " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not authenticate using an authentication token."+ " Exception: " + e.Message, e);
            }
        }        

        public string BuildRedirectToDesignerForUserAuthenticationToken(string userAuthenticationToken, PackageId packageId)
        {
            try {
                var redirectPath = _webpageTemplate.UrlFor(UrlTemplate.DESIGNER_REDIRECT_PATH)
                        .Replace("{packageId}", packageId.Id)
                        .Build();
                var encodedRedirectPath = HttpUtility.UrlEncode(redirectPath);
                var path = _authenticationTemplate.UrlFor(UrlTemplate.AUTHENTICATION_PATH_FOR_USER_AUTHENTICATION_TOKEN_WITH_REDIRECT)
                        .Replace("{authenticationToken}", userAuthenticationToken)
                        .Replace("{redirectUrl}", encodedRedirectPath)
                        .Build();
                return path;
            } catch (Exception e) {
                throw new EslException("Could not authenticate using a user authentication token."+ " Exception: " + e.Message, e);
            }
        }        

        public string GetSessionIdForSenderAuthenticationToken(string senderAuthenticationToken)
        {
            var path = _authenticationTemplate.UrlFor(UrlTemplate.AUTHENTICATION_PATH_FOR_SENDER_AUTHENTICATION_TOKEN)
                                                .Replace("{senderAuthenticationToken}", senderAuthenticationToken)
                                                .Build();
            try {
                var stringResponse = _client.GetUnauthenticated(path);
                var userSessionIdToken = Json.Deserialize<SessionToken> (stringResponse);
                return userSessionIdToken.Token;
            } 
            catch (EslServerException e) {
                throw new EslServerException("Could not authenticate using a sender authentication token."+ " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not authenticate using a sender authentication token."+ " Exception: " + e.Message, e);
            }
        }        

        public string BuildRedirectToDesignerForSender(string senderAuthenticationToken, PackageId packageId)
        {
            try {
                var redirectPath = _webpageTemplate.UrlFor(UrlTemplate.DESIGNER_REDIRECT_PATH)
                        .Replace("{packageId}", packageId.Id)
                        .Build();
                var encodedRedirectPath = HttpUtility.UrlEncode(redirectPath);
                var path = _authenticationTemplate.UrlFor(UrlTemplate.AUTHENTICATION_PATH_FOR_SENDER_AUTHENTICATION_TOKEN_WITH_REDIRECT)
                        .Replace("{senderAuthenticationToken}", senderAuthenticationToken)
                        .Replace("{redirectUrl}", encodedRedirectPath)
                        .Build();

                return path;
            } catch (Exception e) {
                throw new EslException("Could not create a redirect to designer for a sender."+ " Exception: " + e.Message, e);
            }
        }        

        public string BuildRedirectToPackageViewForSender(string userAuthenticationToken, PackageId packageId)
        {
            try {
                var redirectPath = _webpageTemplate.UrlFor(UrlTemplate.PACKAGE_VIEW_REDIRECT_PATH)
                    .Replace("{packageId}", packageId.Id)
                        .Build();
                var encodedRedirectPath = HttpUtility.UrlEncode(redirectPath);
                var path = _authenticationTemplate.UrlFor(UrlTemplate.AUTHENTICATION_PATH_FOR_USER_AUTHENTICATION_TOKEN_WITH_REDIRECT)
                    .Replace("{authenticationToken}", userAuthenticationToken)
                        .Replace("{redirectUrl}", encodedRedirectPath)
                        .Build();

                return path;
            } catch (Exception e) {
                throw new EslException("Could not create a redirect to package view for a sender."+ " Exception: " + e.Message, e);
            }
        }       

        public string GetSessionIdForSignerAuthenticationToken(string signerAuthenticationToken)
        {
            var path = _authenticationTemplate.UrlFor(UrlTemplate.AUTHENTICATION_PATH_FOR_SIGNER_AUTHENTICATION_TOKEN)
                .Replace("{signerAuthenticationToken}", signerAuthenticationToken)
                    .Build();

            try {
                var stringResponse = _client.GetUnauthenticated(path);
                var userSessionIdToken = Json.Deserialize<SessionToken> (stringResponse);
                return userSessionIdToken.Token;
            } 
            catch (EslServerException e) {
                throw new EslServerException("Could not authenticate using a signer authentication token."+ " Exception: " + e.Message, e.ServerError, e);
            }
            catch (Exception e) {
                throw new EslException("Could not authenticate using a signer authentication token."+ " Exception: " + e.Message, e);
            }
        }

        public string BuildRedirectToSigningForSigner(string signerAuthenticationToken, PackageId packageId)
        {
            try {
                var redirectPath = _webpageTemplate.UrlFor(UrlTemplate.SIGNING_REDIRECT_PATH)
                        .Replace("{packageId}", packageId.Id)
                        .Build();
                var encodedRedirectPath = HttpUtility.UrlEncode(redirectPath);
                var path = _authenticationTemplate.UrlFor(UrlTemplate.AUTHENTICATION_PATH_FOR_SIGNER_AUTHENTICATION_TOKEN_WITH_REDIRECT)
                        .Replace("{signerAuthenticationToken}", signerAuthenticationToken)
                        .Replace("{redirectUrl}", encodedRedirectPath)
                        .Build();

                return path;
            } catch (Exception e) {
                throw new EslException("Could not authenticate using a user authentication token."+ " Exception: " + e.Message, e);
            }
        }
    }
}

