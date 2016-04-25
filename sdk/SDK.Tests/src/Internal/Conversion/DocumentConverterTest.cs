using System;
using NUnit.Framework;
using Silanis.ESL.SDK;
using System.IO;
using Silanis.ESL.SDK.Builder;

namespace SDK.Tests
{
    [TestFixture()]
    public class DocumentConverterTest
    {
        private Silanis.ESL.SDK.Document sdkDocument1 = null;
        private Silanis.ESL.SDK.Document sdkDocument2 = null;
        private Silanis.ESL.API.Document apiDocument1 = null;
        private Silanis.ESL.API.Document apiDocument2 = null;
        private Silanis.ESL.API.Package apiPackage = null;
        private DocumentConverter converter = null;

        FileInfo file = new FileInfo(Directory.GetCurrentDirectory() + "/src/document.pdf");

        [Test()]
        public void ConvertNullSDKToAPI()
        {
            sdkDocument1 = null;
            converter = new DocumentConverter(sdkDocument1);
            Assert.IsNull(converter.ToAPIDocument());
        }

        [Test()]
        public void ConvertNullAPIToSDK()
        {
            apiDocument1 = null;
            converter = new DocumentConverter(apiDocument1, apiPackage);
            Assert.IsNull(converter.ToSDKDocument());
        }

        [Test()]
        public void ConvertNullSDKToSDK()
        {
            sdkDocument1 = null;
            converter = new DocumentConverter(sdkDocument1);
            Assert.IsNull(converter.ToSDKDocument());
        }

        [Test()]
        public void ConvertNullAPIToAPI()
        {
            apiDocument1 = null;
            converter = new DocumentConverter(apiDocument1, apiPackage);
            Assert.IsNull(converter.ToAPIDocument());
        }

        [Test()]
        public void ConvertSDKToSDK()
        {
            sdkDocument1 = CreateTypicalSDKDocument();
            converter = new DocumentConverter(sdkDocument1);
            sdkDocument2 = converter.ToSDKDocument();
            Assert.IsNotNull(sdkDocument2);
            Assert.AreEqual(sdkDocument2, sdkDocument1);
        }

        [Test()]
        public void ConvertAPIToAPI()
        {
            apiDocument1 = CreateTypicalAPIDocument();
            converter = new DocumentConverter(apiDocument1, apiPackage);
            apiDocument2 = converter.ToAPIDocument();
            Assert.IsNotNull(apiDocument2);
            Assert.AreEqual(apiDocument2, apiDocument1);
        }

        [Test()]
        public void ConvertAPIToSDK()
        {
            apiDocument1 = CreateTypicalAPIDocument();
            sdkDocument1 = new DocumentConverter(apiDocument1, apiPackage).ToSDKDocument();

            Assert.IsNotNull(sdkDocument1);
            Assert.AreEqual(sdkDocument1.Name, apiDocument1.Name);
            Assert.AreEqual(sdkDocument1.Description, apiDocument1.Description);
            Assert.AreEqual(sdkDocument1.Index, apiDocument1.Index);
            Assert.AreEqual(sdkDocument1.Id, apiDocument1.Id);
        }

        [Test()]
        public void ConvertSDKToAPI()
        {
            sdkDocument1 = CreateTypicalSDKDocument();
            apiDocument1 = new DocumentConverter(sdkDocument1).ToAPIDocument();

            Assert.IsNotNull(apiDocument1);
            Assert.AreEqual(sdkDocument1.Name, apiDocument1.Name);
            Assert.AreEqual(sdkDocument1.Description, apiDocument1.Description);
            Assert.AreEqual(sdkDocument1.Index, apiDocument1.Index);
            Assert.AreEqual(sdkDocument1.Id, apiDocument1.Id);
        }

        [Test()]
        public void ConvertToAPIWithNullId()
        {
            sdkDocument1 = DocumentBuilder.NewDocumentNamed( "sdkDocumentNullId" )
                .WithDescription( "sdkDocument with null ID" )
                    .FromFile(file.FullName)
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com")
                                   .OnPage(0))                                
                    .Build();

            converter = new DocumentConverter(sdkDocument1);
            Assert.IsNull(converter.ToAPIDocument().Id);
        }

        [Test()]
        public void ConvertToAPIWithNullDescription()
        {
            sdkDocument1 = DocumentBuilder.NewDocumentNamed( "sdkDocumentNullDes" )
                .WithId( "sdkDocumentId" )
                    .FromFile(file.FullName)
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com")
                                   .OnPage(0))                                
                    .Build();

            converter = new DocumentConverter(sdkDocument1);
            Assert.IsNull(converter.ToAPIDocument().Description);
        }

        private Silanis.ESL.SDK.Document CreateTypicalSDKDocument()
        {
            Silanis.ESL.SDK.Document sdkDocument = DocumentBuilder.NewDocumentNamed( "sdkDocument" )
                .WithDescription( "sdkDocument Description" )
                    .WithId( "sdkDocumentId" )
                    .FromFile(file.FullName)
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com")
                                   .OnPage(0))                                
                    .Build();

            return sdkDocument;
        }

        private Silanis.ESL.API.Document CreateTypicalAPIDocument()
        {
            Silanis.ESL.API.Document apiDocument = new Silanis.ESL.API.Document();

            apiDocument.Name = "apiDocument";
            apiDocument.Index = 1;
            apiDocument.Description = "apiDocument Description";
            apiDocument.Id = "apiDocumentId";

            return apiDocument;
        }
       
    }
}

