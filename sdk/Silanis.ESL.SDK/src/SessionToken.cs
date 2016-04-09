using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
	/// <summary>
	/// The session token for a signer.
	/// </summary>
	public class SessionToken
	{
		public SessionToken() {}

		public SessionToken(string token)
		{
			Token = token;
		}

		[JsonProperty("sessionToken")]
		public string Token { get; private set; }

		public override string ToString ()
		{
			return Token;
		}
	}
}