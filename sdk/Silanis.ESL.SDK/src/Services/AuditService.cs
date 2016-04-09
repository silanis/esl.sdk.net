using System;
using System.Collections.Generic;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK.Services
{
	/// <summary>
	/// The AuditService class provides a method to get the audit trail for a package.
	/// </summary>
	public class AuditService
	{
		private readonly string _apiToken;
		private readonly UrlTemplate _template;

		/// <summary>
		/// Initializes a new instance of the <see cref="AuditService"/> class.
		/// </summary>
		/// <param name="apiToken">API token.</param>
		/// <param name="baseUrl">Base URL.</param>
		public AuditService (string apiToken, string baseUrl)
		{
			_apiToken = apiToken;
			_template = new UrlTemplate (baseUrl);
		}

		/// <summary>
		/// Gets the audit trail for a package and returns a list of audits.
		/// </summary>
		/// <returns>A list of audits.</returns>
		/// <param name="packageId">The package id.</param>
		public List<Audit> GetAudit (PackageId packageId)
		{
			var path = _template.UrlFor (UrlTemplate.AUDIT_PATH)
				.Replace ("{packageId}", packageId.Id)
					.Build ();

			try {
				var response = Converter.ToString (HttpMethods.GetHttp (_apiToken, path));
				var eventList = Json.Deserialize<Dictionary<string,object>> (response);
				if (eventList.ContainsKey ("audit-events")) {
					return Json.Deserialize<List<Audit>> (eventList ["audit-events"].ToString ());
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

