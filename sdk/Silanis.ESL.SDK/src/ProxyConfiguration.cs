/**
 * Created by whou on 05/12/14.
 */
namespace Silanis.ESL.SDK
{
	public class ProxyConfiguration {

		private string httpHost;
		private int httpPort;
		private string userName;
		private string password;
		private Scheme scheme;
		private bool credentials;

		public ProxyConfiguration(){
			httpHost = null;
			httpPort = 0;
			userName = null;
			password = null;
			scheme = 0;
			credentials = false;
		}

		public string GetHttpHost() {
			return httpHost;
		}
		public void SetHttpHost(string httpHost) {
			this.httpHost = httpHost;
		}

		public int GetHttpPort() {
			return httpPort;
		}
		public void SetHttpPort(int httpPort) {
			this.httpPort = httpPort;
		}

		public string GetUserName() {
			return userName;
		}
		public void SetUserName(string userName) {
			this.userName = userName;
		}

		public string GetPassword() {
			return password;
		}
		public void SetPassword(string password) {
			this.password = password;
		}

		public string GetScheme() {
                return "http";
		}

		public bool HasCredentials() {
			return credentials;
		}
		public void SetCredentials(bool credentials) {
			this.credentials = credentials;
		}

		public string GetHost() {
				return httpHost;
		}

		public int GetPort() {
				return httpPort;
		}

		private enum Scheme{
			http, https
		}

		public void SetHttpScheme() {
			scheme = Scheme.http;
		}

	}
}