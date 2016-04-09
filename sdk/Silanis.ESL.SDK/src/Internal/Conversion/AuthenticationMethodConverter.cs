using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
	internal class AuthenticationMethodConverter
	{
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

		private AuthenticationMethod sdkAuthMethod;
		private string apiAuthMethod;

		public AuthenticationMethodConverter(string apiAuthMethod)
		{
			this.apiAuthMethod = apiAuthMethod;
		}

		public AuthenticationMethodConverter(AuthenticationMethod sdkAuthMethod)
		{
			this.sdkAuthMethod = sdkAuthMethod;
		}

		public string ToAPIAuthMethod()
		{
            return sdkAuthMethod.getApiValue();
		}

		public AuthenticationMethod ToSDKAuthMethod()
		{
            return AuthenticationMethod.valueOf(apiAuthMethod);
		}
	}
}

