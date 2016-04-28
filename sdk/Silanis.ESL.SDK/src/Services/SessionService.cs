using System;
using System.Web;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK.Services
{
	/// <summary>
	/// The SessionService class provides a method to create a session token for a signer.
	/// </summary>
	public class SessionService
	{
		private readonly string _apiToken;
		private readonly UrlTemplate _template;
		private readonly AuthenticationTokenService _authenticationService;
	    private readonly Json _json;

	    /// <summary>
	    /// Initializes a new instance of the <see cref="SessionService"/> class.
	    /// </summary>
	    /// <param name="apiToken">API token.</param>
	    /// <param name="baseUrl">Base URL.</param>
	    /// <param name="jsonSerializerSettings"></param>
        [Obsolete("Please use EslClient")]
	    public SessionService (string apiToken, string baseUrl, JsonSerializerSettings jsonSerializerSettings)
		{
		    _json = new Json(jsonSerializerSettings);
			_apiToken = apiToken;
			_template = new UrlTemplate (baseUrl);
			_authenticationService = new AuthenticationTokenService(new RestClient(apiToken), baseUrl);

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="SessionService"/> class.
		/// </summary>
		/// <param name="apiToken">API token.</param>
		/// <param name="baseUrl">Base URL.</param>
		internal SessionService (string apiToken, string baseUrl)
		{
            _json = new Json();
			_apiToken = apiToken;
			_template = new UrlTemplate (baseUrl);
			_authenticationService = new AuthenticationTokenService(new RestClient(apiToken), baseUrl);

		}

		public SessionToken CreateSessionToken (PackageId packageId, string signerId)
		{
			return CreateSignerSessionToken(packageId, signerId);
		}

		[Obsolete("Call AuthenticationTokenService.CreateSenderAuthenticationToken() instead.")]
		public SessionToken CreateSenderSessionToken()
		{
			var token = _authenticationService.CreateAuthenticationToken();

			return new SessionToken(token.Token);
		}

		/// <summary>
		/// Creates a session token for a signer and returns the session token.
		/// </summary>
		/// <returns>The session token for signer.</returns>
		/// <param name="packageId">The package id.</param>
		/// <param name="signerId">The signer to create a session token for.</param>
		public SessionToken CreateSignerSessionToken (PackageId packageId, string signerId)
		{

			var path = _template.UrlFor (UrlTemplate.SESSION_PATH)
                .Replace ("{packageId}", packageId.Id)
                .Replace ("{signerId}", HttpUtility.UrlEncode(signerId))
                .Build ();

			try {
				var response = Converter.ToString (HttpMethods.PostHttp (_apiToken, path, new byte[0]));
				return _json.Deserialize<SessionToken>(response);
            }
            catch (EslServerException e) {
                throw new EslServerException ("Could not create a session token for signer." + " Exception: " + e.Message, e.ServerError, e);
            } 
            catch (Exception e) {
				throw new EslException ("Could not create a session token for signer." + " Exception: " + e.Message, e);
			}
		}
	}
}

