using System;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
/**
 * Created by whou on 08/12/14.
 */
namespace SDK.Examples
{
    public class ProxyConfigurationExample : SdkSample
    {
        private const string HttpProxyUrl = "10.0.22.81";
        private const int HttpProxyPort = 8001;
        private const bool AllowAllSslCertificates = true;

        private const string HttpProxyWithCredentialsUrl = "10.0.22.81";
        private const int HttpProxyWithCredentialsPort = 8002;
        private const string HttpProxyUserName = "httpUser";
        private const string HttpProxyPassword = "httpPwd";

        public EslClient  EslClientWithHttpProxy, EslClientWithHttpProxyHasCredentials;
        public PackageId PackageId1, PackageId2;
        public DocumentPackage Package1, Package2;

        public static void Main (string[] args)
        {
            new ProxyConfigurationExample(Props.GetInstance()).Run();
        }

        public ProxyConfigurationExample( Props props ) : this(props.Get("api.key"), props.Get("api.url")) {
        }

        public ProxyConfigurationExample(string apiKey, string apiUrl) : base(apiKey, apiUrl)
        {
            ProxyConfiguration httpProxyConfiguration = ProxyConfigurationBuilder.NewProxyConfiguration()
                .WithHttpHost(HttpProxyUrl)
                .WithHttpPort(HttpProxyPort)
                .Build();

            ProxyConfiguration httpProxyWithCredentialsConfiguration = ProxyConfigurationBuilder.NewProxyConfiguration()
                .WithHttpHost(HttpProxyWithCredentialsUrl)
                .WithHttpPort(HttpProxyWithCredentialsPort)
                .WithCredentials(HttpProxyUserName, HttpProxyPassword)
                .Build();

            EslClientWithHttpProxy = new EslClient(apiKey, apiUrl, AllowAllSslCertificates, httpProxyConfiguration);
            EslClientWithHttpProxyHasCredentials = new EslClient(apiKey, apiUrl, AllowAllSslCertificates, httpProxyWithCredentialsConfiguration);
        }

        
        override public void Execute()
        {
            Package1 = PackageBuilder.NewPackageNamed("ProxyConfigurationExample1: " + DateTime.Now)
                .DescribedAs("This is a new package1")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John")
                                .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document1")
                                  .FromStream(fileStream1, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100)))
                    .Build();

            PackageId1 = EslClientWithHttpProxy.CreateAndSendPackage(Package1);

            Package2 = PackageBuilder.NewPackageNamed("ProxyConfigurationExample2: " + DateTime.Now)
                .DescribedAs("This is a new package2")
                    .WithSigner(SignerBuilder.NewSignerWithEmail(email1)
                                .WithFirstName("John")
                                .WithLastName("Smith"))
                    .WithDocument(DocumentBuilder.NewDocumentNamed("My Document2")
                                  .FromStream(fileStream2, DocumentType.PDF)
                                  .WithSignature(SignatureBuilder.SignatureFor(email1)
                                   .OnPage(0)
                                   .AtPosition(100, 100)))
                    .Build();

            PackageId2 = EslClientWithHttpProxyHasCredentials.CreateAndSendPackage(Package2);
        }
    }
}