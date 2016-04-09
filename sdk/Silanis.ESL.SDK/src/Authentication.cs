using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
	public class Authentication
	{
		private readonly AuthenticationMethod method;
		private List<Challenge> challenges = new List<Challenge>();

		public Authentication(AuthenticationMethod method)
		{
			this.method = method;
		}

		public Authentication(IList<Challenge> challenges) : this(AuthenticationMethod.CHALLENGE)
		{
			this.challenges.AddRange(challenges);
		}

		public Authentication(string phoneNumber) : this(AuthenticationMethod.SMS)
		{
			PhoneNumber = phoneNumber;
		}

		public AuthenticationMethod Method
		{
			get
			{
				return method;
			}
		}

		public IList<Challenge> Challenges
		{
			get
			{
				return challenges.AsReadOnly();
			}
		}

		public string PhoneNumber
		{
			get;
			private set;
		}
	}
}