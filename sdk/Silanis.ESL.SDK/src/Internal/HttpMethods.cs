using System;
using System.Net;
using System.IO;
using System.Net.Configuration;
using System.Reflection;
using System.Text;

namespace Silanis.ESL.SDK.Internal
{
	/// <summary>
	/// For internal use.
	/// </summary>
	public class HttpMethods
	{
        public const string ESL_API_VERSION = "11.0";
        public const string ESL_API_VERSION_HEADER = "esl-api-version=" + ESL_API_VERSION;

        public const string CONTENT_TYPE_APPLICATION_JSON = "application/json";
        public const string ESL_CONTENT_TYPE_APPLICATION_JSON = CONTENT_TYPE_APPLICATION_JSON + "; " + ESL_API_VERSION_HEADER;

        public const string CONTENT_TYPE_APPLICATION_MULTIPART = "multipart/form-data";
        public const string ESL_CONTENT_TYPE_APPLICATION_MULTIPART = CONTENT_TYPE_APPLICATION_MULTIPART + "; " + ESL_API_VERSION_HEADER + "; boundary={0}";

        public const string ACCEPT_TYPE_APPLICATION_JSON = "application/json";
        public const string ACCEPT_TYPE_APPLICATION_OCTET_STREAM = "application/octet-stream";
        public const string ACCEPT_TYPE_APPLICATION = "*/*";
        public const string ESL_ACCEPT_TYPE_APPLICATION_JSON = ACCEPT_TYPE_APPLICATION_JSON + "; " + ESL_API_VERSION_HEADER;
        public const string ESL_ACCEPT_TYPE_APPLICATION_OCTET_STREAM = ACCEPT_TYPE_APPLICATION_OCTET_STREAM + "; " + ESL_API_VERSION_HEADER;
        public const string ESL_ACCEPT_TYPE_APPLICATION = ACCEPT_TYPE_APPLICATION + "; " + ESL_API_VERSION_HEADER;

        public static ProxyConfiguration proxyConfiguration;

        private static readonly object syncLock = new object();

		public static byte[] PostHttp (string apiToken, string path, byte[] content)
		{
            try {
                var request = (HttpWebRequest)WebRequest.Create (path);
				request.Method = "POST";
				request.ContentType = ESL_CONTENT_TYPE_APPLICATION_JSON;
				request.ContentLength = content.Length;
				request.Headers.Add ("Authorization", "Basic " + apiToken);
                request.Accept = ESL_ACCEPT_TYPE_APPLICATION_JSON;
                SetProxy(request);

				using (var dataStream = request.GetRequestStream ()) {
					dataStream.Write (content, 0, content.Length);
				}

				var response = request.GetResponse ();

				using (var responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);
	          
					var result = memoryStream.ToArray();
					return result;
				}
            }
            catch (WebException e){
                using (var stream = e.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(String.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                                errorDetails, e);
                }
            }
            catch (Exception e) {
                throw new EslException("Error communicating with esl server. " + e.Message, e);
            }
		}

        public static byte[] PostHttp (AuthHeaderGenerator authHeaderGen, string path, byte[] content)
        {
            try {
                var request = (HttpWebRequest)WebRequest.Create (path);
                request.Method = "POST";
                request.ContentType = ESL_CONTENT_TYPE_APPLICATION_JSON;
                request.ContentLength = content.Length;
                AddAuthorizationHeader(request, authHeaderGen);
                request.Accept = ESL_ACCEPT_TYPE_APPLICATION_JSON;
                SetProxy(request);

                using (var dataStream = request.GetRequestStream ()) {
                    dataStream.Write (content, 0, content.Length);
                }

                var response = request.GetResponse ();

                using (var responseStream = response.GetResponseStream()) {
                    var memoryStream = new MemoryStream ();
                    CopyTo (responseStream, memoryStream);

                    var result = memoryStream.ToArray();
                    return result;
                }
            }
            catch (WebException e){
                using (var stream = e.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(String.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                 errorDetails, e);
                }
            }
            catch (Exception e) {
                throw new EslException("Error communicating with esl server. " + e.Message, e);
            }
        }

		public static byte[] PutHttp (string apiToken, string path, byte[] content)
		{
			try {
                var request = (HttpWebRequest)WebRequest.Create (path);
				request.Method = "PUT";
				request.ContentType = ESL_CONTENT_TYPE_APPLICATION_JSON;
				request.ContentLength = content.Length;
				request.Headers.Add ("Authorization", "Basic " + apiToken);
                request.Accept = ESL_ACCEPT_TYPE_APPLICATION_JSON;
                SetProxy(request);

				using (var dataStream = request.GetRequestStream ()) {
					dataStream.Write (content, 0, content.Length);
				}

				var response = request.GetResponse ();

				using (var responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);

					var result = memoryStream.ToArray();

					return result;
				}
			}
            catch (WebException e){
                using (var stream = e.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(String.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                                errorDetails, e);
                }
            }
			catch (Exception e) {
				throw new EslException("Error communicating with esl server. " + e.Message,e);
			}
		}

        /// <summary>
        /// Can only be called for unauthenticated path such as /auth
        /// Gets the http.
        /// </summary>
        public static byte[] GetHttp (string path)
        {
            var message = "";
            UseUnsafeHeaderParsing(ref message);
            try {
                var request = (HttpWebRequest)WebRequest.Create (path);
                request.Method = "GET";
                request.Accept = ESL_ACCEPT_TYPE_APPLICATION_JSON;
                SetProxy(request);

                var response = request.GetResponse ();

                using (var responseStream = response.GetResponseStream()) {
                    var memoryStream = new MemoryStream ();
                    CopyTo (responseStream, memoryStream);
                    var result = memoryStream.ToArray();

                    return result;
                }
            }
            catch (WebException e){
                using (var stream = e.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(String.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                                errorDetails, e);
                }
            }
            catch (Exception e) {
                throw new EslException("Error communicating with esl server. " + e.Message,e);
            }
        }

        public static bool UseUnsafeHeaderParsing(ref string strError)
        {
            var assembly = Assembly.GetAssembly(typeof(SettingsSection));
            if (null == assembly)
            {
                strError = "Could not access Assembly";
                return false;
            }

            var type = assembly.GetType("System.Net.Configuration.SettingsSectionInternal");
            if (null == type)
            {
                strError = "Could not access internal settings";
                return false;
            }

            var obj = type.InvokeMember("Section",
                                           BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic,
                                           null, null, new object[] { });

            if (null == obj)
            {
                strError = "Could not invoke Section member";
                return false;
            }

            // If it's not already set, set it.
            var fi = type.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
            if (null == fi)
            {
                strError = "Could not access useUnsafeHeaderParsing field";
                return false;
            }

            if (!Convert.ToBoolean(fi.GetValue(obj)))
            {
                fi.SetValue(obj, true);
            }

            return true;
        }

        public static DownloadedFile GetHttpJson (string apiToken, string path, string acceptType)
		{
			try {
				var request = (HttpWebRequest)WebRequest.Create (path);
				request.Method = "GET";
				request.Headers.Add ("Authorization", "Basic " + apiToken);
				request.Accept = acceptType;
                SetProxy(request);

				var response = request.GetResponse ();

				using (var responseStream = response.GetResponseStream()) {

					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);
					var result = memoryStream.ToArray();

                    var downloadedFile = new DownloadedFile("", result);
                    return downloadedFile;
				}
			}
            catch (WebException e){
                using (var stream = e.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(String.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                                errorDetails, e);
                }
            }
			catch (Exception e) {
				throw new EslException("Error communicating with esl server. " + e.Message,e);
			}
		}

        public static DownloadedFile GetHttp (string apiToken, string path)
		{
			try {
                var request = (HttpWebRequest)WebRequest.Create (path);
				request.Method = "GET";
				request.Headers.Add ("Authorization", "Basic " + apiToken);
                request.Accept = ESL_ACCEPT_TYPE_APPLICATION;
                SetProxy(request);

				var response = request.GetResponse ();

				using (var responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);
                    var result = memoryStream.ToArray();

                    var fileName = "";
                    if(!String.IsNullOrEmpty(response.Headers["Content-Disposition"])) 
                    {
                        fileName = GetFilename(response.Headers["Content-Disposition"].ToString());
                    }

                    var downloadedFile = new DownloadedFile(fileName, result);

                    return downloadedFile;
				}
			}
            catch (WebException e){
                using (var stream = e.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(String.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                                errorDetails, e);
                }
            }
			catch (Exception e) {
				throw new EslException("Error communicating with esl server. " + e.Message,e);
			}
		}

        private static string GetFilename(string disposition) 
        {
            var fileNameTitle = "filename=\"";
            var parts = disposition.Split(';');

            foreach(var part in parts) 
            {
                var index = part.IndexOf(fileNameTitle);
                if (index > 0) 
                {
                    return Uri.UnescapeDataString(part.Substring(fileNameTitle.Length+1, part.Length-fileNameTitle.Length-2));
                }
            }

            return "";
        }

        public static DownloadedFile GetHttpAsOctetStream (string apiToken, string path)
        {
            try {
                var request = (HttpWebRequest)WebRequest.Create (path);
                request.Method = "GET";
                request.Headers.Add ("Authorization", "Basic " + apiToken);
                request.Accept = ESL_ACCEPT_TYPE_APPLICATION_OCTET_STREAM;
                SetProxy(request);

                var response = request.GetResponse ();

                using (var responseStream = response.GetResponseStream()) {
                    var memoryStream = new MemoryStream ();
                    CopyTo (responseStream, memoryStream);
                    var result = memoryStream.ToArray();

                    var downloadedFile = new DownloadedFile("", result);

                    return downloadedFile;
                }
            }
            catch (WebException e){
                using (var stream = e.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(String.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                 errorDetails, e);
                }
            }
            catch (Exception e) {
                throw new EslException("Error communicating with esl server. " + e.Message,e);
            }
        }

        public static byte[] DeleteHttp (string apiToken, string path)
		{
			try {
                var request = (HttpWebRequest)WebRequest.Create (path);
				request.Method = "DELETE";
				request.Headers.Add ("Authorization", "Basic " + apiToken);
                request.Accept = ESL_ACCEPT_TYPE_APPLICATION_JSON;
                SetProxy(request);

				var response = request.GetResponse ();

				using (var responseStream = response.GetResponseStream()) {
					var memoryStream = new MemoryStream ();
					CopyTo (responseStream, memoryStream);
					var result = memoryStream.ToArray();

					return result;
				}
			}
            catch (WebException e){
                using (var stream = e.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(String.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                                errorDetails, e);
                }
            }
			catch (Exception e) {
				throw new EslException("Error communicating with esl server. " + e.Message,e);
			}
		}

		public static void AddAuthorizationHeader(WebRequest request, AuthHeaderGenerator authHeaderGen)
		{
			request.Headers.Add(authHeaderGen.Name, authHeaderGen.Value);
		}

        public static string MultipartPostHttp (string apiToken, string path, byte[] content, string boundary, AuthHeaderGenerator authHeaderGen)
        {
            var request = WebRequest.Create(path);
            try
            {
                request.Method = "POST";
                request.ContentType = string.Format(ESL_CONTENT_TYPE_APPLICATION_MULTIPART, boundary);
                request.ContentLength = content.Length;
                AddAuthorizationHeader(request, authHeaderGen);
                SetProxy(request);

                using (var dataStream = request.GetRequestStream ())
                {
                    dataStream.Write(content, 0, content.Length);
                }

                var response = request.GetResponse();

                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                using (var stream = e.Response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                {
                    var errorDetails = reader.ReadToEnd();
                    throw new EslServerException(String.Format("{0} HTTP {1} on URI {2}. Optional details: {3}", e.Message, 
                                                               ((HttpWebResponse)e.Response).Method, e.Response.ResponseUri, errorDetails),
                                                 errorDetails, e);
                }
            }
            catch (Exception e)
            {
                throw new EslException("Error communicating with esl server. " + e.Message, e);
            }
        }

		private static void CopyTo (Stream input, Stream output)
		{
			var buffer = new byte[64 * 1024]; // Fairly arbitrary size
			int bytesRead;

			while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0) {
				output.Write (buffer, 0, bytesRead);
			}
		}

        private static void SetProxy (WebRequest request)
        {
            if (proxyConfiguration != null)
            {
                var webProxy = new WebProxy(new Uri(proxyConfiguration.GetScheme() 
                                                         + "://" 
                                                         + proxyConfiguration.GetHost() 
                                                         + ":" 
                                                         + proxyConfiguration.GetPort()));
                if (proxyConfiguration.HasCredentials())
                {
                    webProxy.Credentials = new NetworkCredential(proxyConfiguration.GetUserName(), 
                                                                 proxyConfiguration.GetPassword());
                }
                request.Proxy = webProxy;
            }
        }
	}
}

