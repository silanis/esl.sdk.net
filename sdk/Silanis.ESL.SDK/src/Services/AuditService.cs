using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK.Services
{
	/// <summary>
	/// The AuditService class provides a method to get the audit trail for a package.
	/// </summary>
	public class AuditService
	{
		private string apiToken;
		private UrlTemplate template;

		/// <summary>
		/// Initializes a new instance of the <see cref="Silanis.ESL.SDK.AuditService"/> class.
		/// </summary>
		/// <param name="apiToken">API token.</param>
		/// <param name="baseUrl">Base URL.</param>
		public AuditService (string apiToken, string baseUrl)
		{
			this.apiToken = apiToken;
			template = new UrlTemplate (baseUrl);
		}

		/// <summary>
		/// Gets the audit trail for a package and returns a list of audits.
		/// </summary>
		/// <returns>A list of audits.</returns>
		/// <param name="packageId">The package id.</param>
		public List<Audit> GetAudit (PackageId packageId)
		{
			var path = template.UrlFor (UrlTemplate.AUDIT_PATH)
				.Replace ("{packageId}", packageId.Id)
					.Build ();

			try {
				var response = Converter.ToString (HttpMethods.GetHttp (apiToken, path));
				var eventList = JsonConvert.DeserializeObject <Dictionary<string,object>> (response);
				if (eventList.ContainsKey ("audit-events")) {
					return JsonConvert.DeserializeObject<List<Audit>> (eventList ["audit-events"].ToString ());
				}
				return null;
			}
            catch (EslServerException e) {
                throw new EslServerException ("Could not get audit." + " Exception: " + e.Message,e.ServerError,e);
            }
            catch (Exception e) {
				throw new EslException ("Could not get audit." + " Exception: " + e.Message,e);
			}
		}

	}
}

