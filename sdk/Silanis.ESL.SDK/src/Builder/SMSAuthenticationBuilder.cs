using System;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK.Builder
{
	public class SMSAuthenticationBuilder : AuthenticationBuilder
	{
		private readonly string phoneNumber;

		public SMSAuthenticationBuilder (string phoneNumber)
		{
			this.phoneNumber = phoneNumber;
		}

		public override Authentication Build()
		{
			Asserts.NotEmptyOrNull (phoneNumber, "phoneNumber");
			var result = new Authentication(phoneNumber);

			return result;
		}
	}
}