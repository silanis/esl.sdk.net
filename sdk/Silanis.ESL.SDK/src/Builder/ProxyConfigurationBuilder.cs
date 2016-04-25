using Silanis.ESL.SDK;

/**
 * Created by whou on 03/12/14.
 */

namespace Silanis.ESL.SDK.Builder
{
	public class ProxyConfigurationBuilder {

		private string httpHost;
		private int httpPort;
		private string userName;
		private string password;

		private ProxyConfigurationBuilder() {
		}

		public static ProxyConfigurationBuilder NewProxyConfiguration() {
			return new ProxyConfigurationBuilder();
		}

		public ProxyConfigurationBuilder WithHttpHost(string httpHost) {
			this.httpHost = httpHost;
			return this;
		}

		public ProxyConfigurationBuilder WithHttpPort(int httpPort) {
			this.httpPort = httpPort;
			return this;
		}

		public ProxyConfigurationBuilder WithCredentials(string userName, string password) {
			this.userName = userName;
			this.password = password;
			return this;
		}

		public ProxyConfiguration Build() {
			Validate();
			ProxyConfiguration result = new ProxyConfiguration();
			if (IsHttpProxy()) {
				result.SetHttpHost(httpHost);
				result.SetHttpPort(httpPort);
				result.SetHttpScheme();
			} 
			if (IsCredentialsNotNull()) {
				result.SetUserName(userName);
				result.SetPassword(password);
				result.SetCredentials(true);
			}
			return result;
		}

		private void Validate() {
			if ((httpHost != null && httpPort == 0)
			    || (httpHost == null && httpPort != 0)){
                throw new EslException("Proxy setup error.", null);
			}
		}

		private bool IsCredentialsNotNull() {
			return userName != null && password != null;
		}

		private bool IsHttpProxy() {
			return httpHost != null && httpPort != 0;
		}

	}
}