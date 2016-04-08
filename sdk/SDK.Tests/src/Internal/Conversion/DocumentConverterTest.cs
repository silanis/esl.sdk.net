using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.API;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using Document = Silanis.ESL.SDK.Document;

namespace SDK.Tests
{
    [TestClass]
    public class DocumentConverterTest
    {
        private Document _sdkDocument1;
        private Document _sdkDocument2;
        private Silanis.ESL.API.Document _apiDocument1;
        private Silanis.ESL.API.Document _apiDocument2;
        private readonly Package _apiPackage = null;
        private DocumentConverter _converter;

        readonly FileInfo _file = new FileInfo(Directory.GetCurrentDirectory() + "/src/document.pdf");

        [TestMethod]
        public void ConvertNullSdktoApi()
        {
            _sdkDocument1 = null;
            _converter = new DocumentConverter(_sdkDocument1);
            Assert.IsNull(_converter.ToAPIDocument());
        }

        [TestMethod]
        public void ConvertNullApitoSdk()
        {
            _apiDocument1 = null;
            _converter = new DocumentConverter(_apiDocument1, _apiPackage);
            Assert.IsNull(_converter.ToSDKDocument());
        }

        [TestMethod]
        public void ConvertNullSdktoSdk()
        {
            _sdkDocument1 = null;
            _converter = new DocumentConverter(_sdkDocument1);
            Assert.IsNull(_converter.ToSDKDocument());
        }

        [TestMethod]
        public void ConvertNullApitoApi()
        {
            _apiDocument1 = null;
            _converter = new DocumentConverter(_apiDocument1, _apiPackage);
            Assert.IsNull(_converter.ToAPIDocument());
        }

        [TestMethod]
        public void ConvertSdktoSdk()
        {
            _sdkDocument1 = CreateTypicalSdkDocument();
            _converter = new DocumentConverter(_sdkDocument1);
            _sdkDocument2 = _converter.ToSDKDocument();
            Assert.IsNotNull(_sdkDocument2);
            Assert.AreEqual(_sdkDocument2, _sdkDocument1);
        }

        [TestMethod]
        public void ConvertApitoApi()
        {
            _apiDocument1 = CreateTypicalApiDocument();
            _converter = new DocumentConverter(_apiDocument1, _apiPackage);
            _apiDocument2 = _converter.ToAPIDocument();
            Assert.IsNotNull(_apiDocument2);
            Assert.AreEqual(_apiDocument2, _apiDocument1);
        }

        [TestMethod]
        public void ConvertApitoSdk()
        {
            _apiDocument1 = CreateTypicalApiDocument();
            _sdkDocument1 = new DocumentConverter(_apiDocument1, _apiPackage).ToSDKDocument();

            Assert.IsNotNull(_sdkDocument1);
            Assert.AreEqual(_sdkDocument1.Name, _apiDocument1.Name);
            Assert.AreEqual(_sdkDocument1.Description, _apiDocument1.Description);
            Assert.AreEqual(_sdkDocument1.Index, _apiDocument1.Index);
            Assert.AreEqual(_sdkDocument1.Id, _apiDocument1.Id);
        }

        [TestMethod]
        public void ConvertSdktoApi()
        {
            _sdkDocument1 = CreateTypicalSdkDocument();
            _apiDocument1 = new DocumentConverter(_sdkDocument1).ToAPIDocument();

            Assert.IsNotNull(_apiDocument1);
            Assert.AreEqual(_sdkDocument1.Name, _apiDocument1.Name);
            Assert.AreEqual(_sdkDocument1.Description, _apiDocument1.Description);
            Assert.AreEqual(_sdkDocument1.Index, _apiDocument1.Index);
            Assert.AreEqual(_sdkDocument1.Id, _apiDocument1.Id);
        }

        [TestMethod]
        public void ConvertToApiWithNullId()
        {
            _sdkDocument1 = DocumentBuilder.NewDocumentNamed( "sdkDocumentNullId" )
                .WithDescription( "sdkDocument with null ID" )
                    .FromFile(_file.FullName)
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com")
                                   .OnPage(0))                                
                    .Build();

            _converter = new DocumentConverter(_sdkDocument1);
            Assert.IsNull(_converter.ToAPIDocument().Id);
        }

        [TestMethod]
        public void ConvertToApiWithNullDescription()
        {
            _sdkDocument1 = DocumentBuilder.NewDocumentNamed( "sdkDocumentNullDes" )
                .WithId( "sdkDocumentId" )
                    .FromFile(_file.FullName)
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com")
                                   .OnPage(0))                                
                    .Build();

            _converter = new DocumentConverter(_sdkDocument1);
            Assert.IsNull(_converter.ToAPIDocument().Description);
        }

        private Document CreateTypicalSdkDocument()
        {
            var sdkDocument = DocumentBuilder.NewDocumentNamed( "sdkDocument" )
                .WithDescription( "sdkDocument Description" )
                    .WithId( "sdkDocumentId" )
                    .FromFile(_file.FullName)
                    .WithSignature(SignatureBuilder.SignatureFor("john.smith@email.com")
                                   .OnPage(0))                                
                    .Build();

            return sdkDocument;
        }

        private static Silanis.ESL.API.Document CreateTypicalApiDocument()
        {
            var apiDocument = new Silanis.ESL.API.Document
            {
                Name = "apiDocument",
                Index = 1,
                Description = "apiDocument Description",
                Id = "apiDocumentId"
            };

            return apiDocument;
        }
       
    }
}

