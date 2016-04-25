using System;
using Newtonsoft.Json;

namespace Silanis.ESL.SDK
{
	/// <summary>
	/// Field summary.
	/// </summary>
	public class FieldSummary
	{
		/// <summary>
		/// Gets the signer id.
		/// </summary>
		/// <value>The signer id.</value>
		[JsonProperty("signerId")]
		public string SignerId { get; private set; }

		/// <summary>
		/// Gets the document id.
		/// </summary>
		/// <value>The document id.</value>
		[JsonProperty("documentId")]
		public string DocumentId { get; private set; }

		/// <summary>
		/// Gets the field id.
		/// </summary>
		/// <value>The field id.</value>
		[JsonProperty("fieldId")]
		public string FieldId { get; private set; }

		/// <summary>
		/// Gets the field value.
		/// </summary>
		/// <value>The field value.</value>
		[JsonProperty("fieldValue")]
		public string FieldValue { get; private set; }

        /// <summary>
        /// Gets the field name.
        /// </summary>
        /// <value>The field name.</value>
        [JsonProperty("fieldName")]
        public string FieldName { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Silanis.ESL.SDK.FieldSummary"/> class.
		/// </summary>
		public FieldSummary ()
		{
		}

	}
}

