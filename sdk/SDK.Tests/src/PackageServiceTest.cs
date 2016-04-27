using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.API;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Services;
using System;
using System.Collections.Generic;
using Document = Silanis.ESL.API.Document;
using External = Silanis.ESL.API.External;
using Field = Silanis.ESL.API.Field;

namespace SDK.Tests.src
{
    [TestClass]
    public class PackageServiceTest
    {
        private static Document Document
        {
            get
            {
                return new Document
                {
                    Approvals = new List<Approval>
                { new Approval
                    {
                        Accepted = new DateTime(2000, 10, 1, 1, 2, 3),
                        Data = new Dictionary<string, object>
                        {
                            {"hello", "hi"},
                            {"date", new DateTime(2000, 10, 1, 1, 2, 3)}
                        },
                        Id = "fdshgjklfdshgjfdsfgds",
                        Name = "Approval1",
                        Role = "paul",
                        Signed = new DateTime(2000, 10, 1, 1, 2, 3)
                    }, new Approval
                    {
                        Accepted = new DateTime(2000, 10, 1, 1, 2, 3),
                        Data = new Dictionary<string, object>
                        {
                            {"goobye", "bye"},
                            {"date",new DateTime(2000, 10, 1, 1, 2, 3)}
                        },
                        Id = "fdjshfldknsjafs",
                        Name = "Approval2",
                        Role = "paul",
                        Signed = new DateTime(2000, 10, 1, 1, 2, 3)
                    }
                },
                    Data = new Dictionary<string, object>
                {
                    {"message", "this is a message"}
                },
                    Description = "hello there",
                    External = new External
                    {
                        Data = new Dictionary<string, object>
                        {
                            {"another", "dictionary"},
                            {"index", 1}
                        },
                        Id = "fdshafjkdsbajfbsda",
                        Provider = "eSignLive",
                        ProviderName = "eSignLive Name"
                    },
                    Extract = true,
                    Fields = new List<Field> { new Field
                    {
                        Id = "fdshafdjsakbfjkdsal",
                        Binding = "fdsajfldsjnafkdsjab",
                        Extract = true,
                        ExtractAnchor = new ExtractAnchor
                        {
                            AnchorPoint = "fdsahfdsafjkasd",
                            CharacterIndex = 2,
                            LeftOffset = 2,
                            Text = "fdnsafhdlbsjnakl",
                            TopOffset = 4,
                            Height = 50,
                            Width = 120
                        },
                        Data = new Dictionary<string, object>
                        {
                            {"fdsafsda", "fdsafdhtdrsfgvsd"}
                        },
                        Name = "ndfjlk;dsamfdksal;mfdsa",
                        Height = 12.3,
                        Page = 2,
                        Value = "fdsafdsafdsadsa",
                        Validation = new FieldValidation
                        {
                            ErrorCode = 233,
                            ErrorMessage = "error",
                            MaxLength = 500,
                            MinLength = 10,
                            Pattern = "fdsgtere",
                            Required = true
                        },
                        Subtype = "fbdsahfdhsalv",
                        Type = "Fadvhdasjkfdsa"
                    }, new Field
                    {
                        Id = "dsabfhdjsalfdsa",
                        Binding = "fdsafdsafdsa",
                        Extract = true,
                        ExtractAnchor = new ExtractAnchor
                        {
                            AnchorPoint = "fdnsjafklbdsa jdskla",
                            CharacterIndex = 2,
                            LeftOffset = 2,
                            Text = "hi",
                            TopOffset = 4,
                            Height = 50,
                            Width = 120
                        },
                        Data = new Dictionary<string, object>{},
                        Name = "nfdjsaklfjdnsakcldsa",
                        Height = 12.3,
                        Page = 2,
                        Value = "hello",
                        Validation = new FieldValidation
                        {
                            ErrorCode = 233,
                            ErrorMessage = "error2",
                            MaxLength = 500,
                            MinLength = 10,
                            Pattern = "fdsgdfsgdfvsdrw",
                            Required = true
                        },
                        Subtype = "fdnsafhdbojnjdsan",
                        Type = "dsnajvbaslnfue"
                    } },
                    Id = "Fdsanfdjsafndsa",
                    Index = 0,
                    Name = "TestPackage",
                    Pages = new List<Page> { new Page
                    {
                        Height = 500.2,
                        Id = "nkfdl;safmdks;a",
                        Index = 1,
                        Width = 300.34,
                        Version = 1,
                        Top = 10
                    }, new Page
                    {
                        Height = 560.2,
                        Id = "fdnsjafkd;sanfdjsa;",
                        Index = 2,
                        Width = 340.34,
                        Version = 1,
                        Top = 10
                    } },
                    Size = 42343224
                };
            }
        }

        public string MetadataJson
        {
            get
            {
                return
                    "{\"data\":{\"message\":\"this is a message\"},\"description\":\"hello there\",\"external\":{\"data\":{\"another\":\"dictionary\",\"index\":1},\"id\":\"fdshafjkdsbajfbsda\",\"provider\":\"eSignLive\",\"providerName\":\"eSignLive Name\"},\"extract\":true,\"id\":\"Fdsanfdjsafndsa\",\"index\":0,\"name\":\"TestPackage\",\"size\":42343224}";
            }
        }

        public string DocumentJson
        {
            get
            {
                return
                    "{\"approvals\":[{\"accepted\":\"2000-10-01T01:02:03Z\",\"data\":{\"hello\":\"hi\",\"date\":\"2000-10-01T01:02:03Z\"}" +
                    ",\"fields\":[],\"id\":\"fdshgjklfdshgjfdsfgds\",\"name\":\"Approval1\",\"role\":\"paul\"," +
                    "\"signed\":\"2000-10-01T01:02:03Z\"},{\"accepted\":\"2000-10-01T01:02:03Z\"," +
                    "\"data\":{\"goobye\":\"bye\",\"date\":\"2000-10-01T01:02:03Z\"},\"fields\":[]," +
                    "\"id\":\"fdjshfldknsjafs\",\"name\":\"Approval2\",\"role\":\"paul\",\"signed\":\"2000-10-01T01:02:03Z\"}]," +
                    "\"data\":{\"message\":\"this is a message\"},\"description\":\"hello there\"," +
                    "\"external\":{\"data\":{\"another\":\"dictionary\",\"index\":1},\"id\":\"fdshafjkdsbajfbsda\"," +
                    "\"provider\":\"eSignLive\",\"providerName\":\"eSignLive Name\"},\"extract\":true," +
                    "\"fields\":[{\"binding\":\"fdsajfldsjnafkdsjab\",\"data\":{\"fdsafsda\":\"fdsafdhtdrsfgvsd\"}," +
                    "\"extract\":true,\"extractAnchor\":{\"anchorPoint\":\"fdsahfdsafjkasd\",\"characterIndex\":2," +
                    "\"height\":50,\"leftOffset\":2,\"text\":\"fdnsafhdlbsjnakl\",\"topOffset\":4,\"width\":120}," +
                    "\"height\":12.3,\"id\":\"fdshafdjsakbfjkdsal\",\"name\":\"ndfjlk;dsamfdksal;mfdsa\",\"page\":2," +
                    "\"subtype\":\"fbdsahfdhsalv\",\"type\":\"Fadvhdasjkfdsa\",\"validation\":{\"enum\":[],\"errorCode\":233," +
                    "\"errorMessage\":\"error\",\"maxLength\":500,\"minLength\":10,\"pattern\":\"fdsgtere\",\"required\":true}," +
                    "\"value\":\"fdsafdsafdsadsa\"},{\"binding\":\"fdsafdsafdsa\",\"data\":{},\"extract\":true," +
                    "\"extractAnchor\":{\"anchorPoint\":\"fdnsjafklbdsa jdskla\",\"characterIndex\":2,\"height\":50,\"leftOffset\":2," +
                    "\"text\":\"hi\",\"topOffset\":4,\"width\":120},\"height\":12.3,\"id\":\"dsabfhdjsalfdsa\"," +
                    "\"name\":\"nfdjsaklfjdnsakcldsa\",\"page\":2,\"subtype\":\"fdnsafhdbojnjdsan\",\"type\":\"dsnajvbaslnfue\"," +
                    "\"validation\":{\"enum\":[],\"errorCode\":233,\"errorMessage\":\"error2\",\"maxLength\":500,\"minLength\":10," +
                    "\"pattern\":\"fdsgdfsgdfvsdrw\",\"required\":true},\"value\":\"hello\"}],\"id\":\"Fdsanfdjsafndsa\"," +
                    "\"index\":0,\"name\":\"TestPackage\",\"pages\":[{\"height\":500.2,\"id\":\"nkfdl;safmdks;a\",\"index\":1," +
                    "\"top\":10.0,\"version\":1,\"width\":300.34},{\"height\":560.2,\"id\":\"fdnsjafkd;sanfdjsa;\",\"index\":2," +
                    "\"top\":10.0,\"version\":1,\"width\":340.34}],\"size\":42343224}";
            }
        }

        [TestMethod]
        public void WhenSerializingDocumentMetaData()
        {
            var packageService = new PackageService(new RestClient("fdsagdgsfdfds"), null);
            var result = packageService.SerializeDocumentMetaData(Document);
            Assert.AreEqual(MetadataJson, result);
        }

        [TestMethod]
        public void WhenSerializingDocument()
        {
            var packageService = new PackageService(null, null);
            var result = packageService.SerializeInternalDocument(Document);
            Assert.AreEqual(DocumentJson, result);
        }
    }
}