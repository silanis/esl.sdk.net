using System;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
	/// <summary>
	/// Audit.
	/// </summary>
	public class Audit
	{
		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value>The type.</value>
		[JsonProperty("type")]
		public string type { get; private set; }

		/// <summary>
		/// Gets the date time.
		/// </summary>
		/// <value>The date time.</value>
		[JsonProperty("date-time")]
		public string dateTime { get; private set; }

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		[JsonProperty("target")]
		public string target { get; private set; }

		/// <summary>
		/// Gets the user.
		/// </summary>
		/// <value>The user.</value>
		[JsonProperty("user")]
		public string user { get; private set; }

		/// <summary>
		/// Gets the email.
		/// </summary>
		/// <value>The email.</value>
		[JsonProperty("user-email")]
		public string email { get; private set; }

		/// <summary>
		/// Gets the ip.
		/// </summary>
		/// <value>The ip.</value>
		[JsonProperty("user-ip")]
		public string ip { get; private set; }

		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <value>The data.</value>
		[JsonProperty("data")]
		public string data { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Silanis.ESL.SDK.Audit"/> class.
		/// </summary>
		/// <param name="type">Type.</param>
		/// <param name="dateTime">Date time.</param>
		/// <param name="target">Target.</param>
		/// <param name="user">User.</param>
		/// <param name="email">Email.</param>
		/// <param name="ip">Ip.</param>
		/// <param name="data">Data.</param>
		public Audit (string type, string dateTime, string target, string user, string email, string ip, string data)
		{
			this.type = type;
			this.dateTime = dateTime;
			this.target = target;
			this.user = user;
			this.email = email;
			this.ip = ip;
			this.data = data;
		}
	

	}
}

