using Silanis.ESL.SDK.Internal;
using System;
using System.Reflection;

namespace Silanis.ESL.SDK
{
	internal class AuthenticationMethodConverter
	{
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

		private Silanis.ESL.SDK.AuthenticationMethod sdkAuthMethod;
		private string apiAuthMethod;

		public AuthenticationMethodConverter(string apiAuthMethod)
		{
			this.apiAuthMethod = apiAuthMethod;
		}

		public AuthenticationMethodConverter(Silanis.ESL.SDK.AuthenticationMethod sdkAuthMethod)
		{
			this.sdkAuthMethod = sdkAuthMethod;
		}

		public string ToAPIAuthMethod()
		{
            return sdkAuthMethod.getApiValue();
		}

		public Silanis.ESL.SDK.AuthenticationMethod ToSDKAuthMethod()
		{
            return Silanis.ESL.SDK.AuthenticationMethod.valueOf(apiAuthMethod);
		}
	}
}

