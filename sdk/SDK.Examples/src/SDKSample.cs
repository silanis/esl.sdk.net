using System;
using Silanis.ESL.SDK;
using System.IO;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    public abstract class SdkSample
    {
		protected EslClient eslClient;
        protected PackageId packageId;
        protected string packageName;
        protected DocumentPackage retrievedPackage;
        protected Stream fileStream1, fileStream2;

        protected Props props = Props.GetInstance();

        public string email1, email2, email3, email4, email5, email6, senderEmail, sms1, sms2, sms3, sms4, sms5, sms6, senderSms, webpageUrl, senderUID;

        protected SdkSample()
        {
            eslClient = new EslClient(props.Get( "api.key" ), props.Get( "api.url" ), props.Get( "webpage.url" ));
            SetProperties();
        }

        protected SdkSample( string apiKey, string apiUrl )
        {
            eslClient = new EslClient(apiKey, apiUrl);
            SetProperties();
        }

        public abstract void Execute();

        public void Run() 
        {
            Execute();
        }

        private void SetProperties()
        {
            email1 = props.Get( "1.email" );
            email2 = props.Get( "2.email" );
            email3 = props.Get( "3.email" );
            email4 = props.Get( "4.email" );
            email5 = props.Get( "5.email" );
            email6 = props.Get( "6.email" );
            senderEmail = props.Get( "sender.email" );
            sms1 = props.Get( "1.sms" );
            sms2 = props.Get( "2.sms" );
            sms3 = props.Get( "3.sms" );
            sms4 = props.Get( "4.sms" );
            sms5 = props.Get( "5.sms" );
            sms6 = props.Get( "6.sms" );
            senderSms = props.Get( "sender.sms" );
            webpageUrl = props.Get( "webpage.url" );
            senderUID = Converter.apiKeyToUID(props.Get("api.key"));

            fileStream1 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document.pdf").FullName);
            fileStream2 = File.OpenRead(new FileInfo(Directory.GetCurrentDirectory() + "/src/document.pdf").FullName);
        }

        public EslClient EslClient
        {
            get
            {
                return eslClient;
            }
        }

        public PackageId PackageId
        {
            get
            {
                return packageId;
            }
        }

        public DocumentPackage RetrievedPackage
        {
            get 
            {
                if (null == retrievedPackage) 
                {
                    retrievedPackage = eslClient.GetPackage(packageId);
                }
                return retrievedPackage; 
            }
        }

        public string PackageName
        {
            get
            {
                if (null == packageName)
                {
                    packageName = GetType().Name + " : " + DateTime.Now;
                }
                return packageName;
            }
        }
        
        protected string GetRandomEmail() {
            return Guid.NewGuid().ToString().Replace("-","") + "@e-signlive.com";
        }
    }
}

