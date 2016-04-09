namespace Silanis.ESL.SDK
{
    public class AuthenticationToken
    {
		public string Token { get; private set; }

        public AuthenticationToken(string token)
        {
            Token = token;
        }

		public override string ToString ()
		{
			return Token;
		}
    }
}