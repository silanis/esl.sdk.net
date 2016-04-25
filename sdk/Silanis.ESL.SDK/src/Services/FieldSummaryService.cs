using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK.Services
{
	/// <summary>
	/// The FieldSummaryService class provides a method to get the field summary for a package.
	/// </summary>
	public class FieldSummaryService
	{
        private FieldSummaryApiClient apiClient;
		/// <summary>
		/// Initializes a new instance of the <see cref="Silanis.ESL.SDK.FieldSummaryService"/> class.
		/// </summary>
		/// <param name="apiToken">API token.</param>
		/// <param name="baseUrl">Base URL.</param>
		internal FieldSummaryService (FieldSummaryApiClient apiClient)
		{
            this.apiClient = apiClient;
		}

		/// <summary>
		/// Gets the field summary for the package and returns a list of field summaries.
		/// </summary>
		/// <returns>A list of field summaries.</returns>
		/// <param name="packageId">The package id.</param>
		public List<FieldSummary> GetFieldSummary (PackageId packageId)
		{
            // Usually we would convert to the sdk model objects expected here, but since their is not api model object being returned,
            // We decided it would be better to deserialize the json directly to our sdk object, instead of returning a raw string.
            return apiClient.GetFieldSummary(packageId.Id);
		}
	}
}

