namespace Silanis.ESL.SDK
{
	public class SessionIdAuthHeaderGenerator : AuthHeaderGenerator
    {
		public SessionIdAuthHeaderGenerator(string sessionId) : base("Cookie", "ESIGNLIVE_SESSION_ID" + "=" + sessionId)
        {
        }
    }
}

