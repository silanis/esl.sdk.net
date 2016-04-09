namespace Silanis.ESL.SDK
{
	public class ApiTokenAuthHeaderGenerator : AuthHeaderGenerator
    {
		public ApiTokenAuthHeaderGenerator(string apiToken) : base("Authorization", "Basic " + apiToken)
        {
        }
    }
}

