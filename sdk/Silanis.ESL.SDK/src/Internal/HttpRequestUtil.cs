using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace Silanis.ESL.SDK.Internal
{
    public class HttpRequestUtil
    {

        public const string SESSION_TOKEN_COOKIE_VALUE_KEY = "ESIGNLIVE_SESSION_ID";
        public const string TEMP_SESSION_TOKEN_COOKIE_VALUE_KEY = "ESIGNLIVE_TEMP_TOKEN";
        public const string SESSION_TOKEN_COOKIE_KEY = "Cookie";

        public const string API_KEY_AUTHENTICATION_AUTHORIZATION_KEY = "Authorization";
        public const string API_KEY_AUTHENTICATION_BASIC_PREFIX = "Basic ";

        public static string GetUrlContent(string requestedURL)
        {
            var urlContent = "";
            try 
            {
                var request = (HttpWebRequest)WebRequest.Create (requestedURL);
                request.AllowAutoRedirect = false;

                var location = request.GetResponse().Headers["Location"];
                var cookieSessionToken = ExtractSessionCookieValue(request);
                var cookieTempTokenValue = ExtractTempTokenCookieValue(request);

                var redirectRequest = (HttpWebRequest)WebRequest.Create (location);

                SetAuthentication(redirectRequest, AuthRequestParameters.empty());

                redirectRequest.Headers.Add(SESSION_TOKEN_COOKIE_KEY, BuildSessionTokenCookieValue(cookieSessionToken) + ";" + BuildTempTokenCookieValue(cookieTempTokenValue));

                var response = (HttpWebResponse)redirectRequest.GetResponse ();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    urlContent = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();
                }
            } 
            catch (WebException e) 
            {
                using (var stream = e.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(string.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                 errorDetails, e);
                }
            } 
            catch (Exception e) 
            {
                throw new EslException("Error communicating with esl server. " + e.Message,e);
            }
            return urlContent;
        }

        private static void SetAuthentication(HttpWebRequest request,  AuthRequestParameters authRequestParameters) 
        {
            if (authRequestParameters.hasSessionToken()) 
            {
                request.Headers.Add(SESSION_TOKEN_COOKIE_VALUE_KEY, authRequestParameters.getSessionToken());
            } 
            else if (authRequestParameters.hasApiKey())
            {
                request.Headers.Add(API_KEY_AUTHENTICATION_BASIC_PREFIX, authRequestParameters.getApiKey());
            }
            else if (authRequestParameters.hasTempToken()) 
            {
                request.Headers.Add(TEMP_SESSION_TOKEN_COOKIE_VALUE_KEY, authRequestParameters.getTempToken());
            }  
            else if (authRequestParameters.hasConnectorsAuth()) 
            {
                request.Headers.Add(API_KEY_AUTHENTICATION_BASIC_PREFIX, authRequestParameters.getConnectorsAuth());
            }
        }

        private static string BuildSessionTokenCookieValue(string sessionTokenValue) 
        {
            return SESSION_TOKEN_COOKIE_VALUE_KEY + "=" + sessionTokenValue;
        }
        private static string BuildTempTokenCookieValue(string sessionTokenValue) 
        {
            return TEMP_SESSION_TOKEN_COOKIE_VALUE_KEY + "=" + sessionTokenValue;
        }

        private static string ExtractSessionCookieValue(HttpWebRequest request) 
        {
            return ExtractSessionCookieValue(request, SESSION_TOKEN_COOKIE_VALUE_KEY);
        }

        
        private static string ExtractTempTokenCookieValue(HttpWebRequest request) 
        {
            return ExtractSessionCookieValue(request, TEMP_SESSION_TOKEN_COOKIE_VALUE_KEY);
        }

        private static string ExtractSessionCookieValue(HttpWebRequest request, string sessionKeystring) 
        {
            var setCookieValue = request.GetResponse().Headers["Set-Cookie"];

            if(!string.IsNullOrEmpty(setCookieValue) && setCookieValue.Contains(sessionKeystring) && HasCookieValue(setCookieValue, sessionKeystring)) {
                var SESSION_ID_KEY_WITH_EQUAL = sessionKeystring + "=";
                var startOfSessionIdValue = setCookieValue.IndexOf(SESSION_ID_KEY_WITH_EQUAL) + SESSION_ID_KEY_WITH_EQUAL.Length;
                var endOfCookieValue = setCookieValue.Substring(startOfSessionIdValue);
                var endOfSessionIdValue = endOfCookieValue.IndexOf(";");
                return endOfCookieValue.Substring(0, endOfSessionIdValue);
            }
            return "";
        }

        private static bool HasCookieValue(string setCookieValue, string sessionKeystring) 
        {
            var rgx1 = new Regex(sessionKeystring);
            var rgx2 = new Regex("=");
            return !string.IsNullOrEmpty(rgx2.Replace(rgx1.Replace(setCookieValue, ""), ""));
        }
    }
}

