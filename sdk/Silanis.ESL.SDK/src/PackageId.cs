using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
	/// <summary>
	/// The package id.
	/// </summary>
	public class PackageId
	{
		[JsonProperty("id")]
		public string Id { get; private set; }

		public PackageId ()
		{
		}

		public PackageId (string Id)
		{
			this.Id = Id;
		}

		public override string ToString ()
		{
			return Id;
		}
	}
}