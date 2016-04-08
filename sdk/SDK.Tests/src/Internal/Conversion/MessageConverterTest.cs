using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System.Collections.Generic;
using Silanis.ESL.API;
using Message = Silanis.ESL.SDK.Message;
using Signer = Silanis.ESL.SDK.Signer;

namespace SDK.Tests
{
    [TestClass]
    public class MessageConverterTest
    {
        private Message sdkMessage1;
        private Message sdkMessage2;
        private Silanis.ESL.API.Message apiMessage1;
        private Silanis.ESL.API.Message apiMessage2;
        private MessageConverter converter;

        [TestMethod]
        public void ConvertNullSDKToAPI()
        {
            sdkMessage1 = null;
            converter = new MessageConverter(sdkMessage1);

            Assert.IsNull(converter.ToAPIMessage());
        }

        [TestMethod]
        public void ConvertNullAPIToSDK()
        {
            apiMessage1 = null;
            converter = new MessageConverter(apiMessage1);

            Assert.IsNull(converter.ToSDKMessage());
        }

        [TestMethod]
        public void ConvertNullSDKToSDK()
        {
            sdkMessage1 = null;
            converter = new MessageConverter(sdkMessage1);

            Assert.IsNull(converter.ToSDKMessage());
        }

        [TestMethod]
        public void ConvertNullAPIToAPI()
        {
            apiMessage1 = null;
            converter = new MessageConverter(apiMessage1);

            Assert.IsNull(converter.ToAPIMessage());
        }

        [TestMethod]
        public void ConvertSDKToSDK()
        {
            sdkMessage1 = CreateTypicalSDKMessage();
            sdkMessage2 = new MessageConverter(sdkMessage1).ToSDKMessage();

            Assert.IsNotNull(sdkMessage2);
            Assert.AreEqual(sdkMessage1, sdkMessage2);
        }

        [TestMethod]
        public void ConvertAPIToAPI()
        {
            apiMessage1 = CreateTypicalAPIMessage();
            apiMessage2 = new MessageConverter(apiMessage1).ToAPIMessage();

            Assert.IsNotNull(apiMessage1);
            Assert.AreEqual(apiMessage1, apiMessage2);
        }

        [TestMethod]
        public void ConvertAPIToSDK()
        {
            apiMessage1 = CreateTypicalAPIMessage();
            sdkMessage1 = new MessageConverter(apiMessage1).ToSDKMessage();

            Assert.IsNotNull(sdkMessage1);
            Assert.AreEqual(apiMessage1.Content, sdkMessage1.Content);
            Assert.AreEqual(apiMessage1.Status.ToString(), sdkMessage1.Status.ToString());
            Assert.AreEqual(apiMessage1.Created, sdkMessage1.Created);
            Assert.AreEqual(apiMessage1.From.FirstName, sdkMessage1.From.FirstName);
            Assert.AreEqual(apiMessage1.From.LastName, sdkMessage1.From.LastName);
            Assert.AreEqual(apiMessage1.From.Id, sdkMessage1.From.Id);
            Assert.AreEqual(apiMessage1.From.Email, sdkMessage1.From.Email);
            Assert.AreEqual(apiMessage1.To[0].FirstName, sdkMessage1.To["email2@email.com"].FirstName);
            Assert.AreEqual(apiMessage1.To[0].LastName, sdkMessage1.To["email2@email.com"].LastName);
            Assert.AreEqual(apiMessage1.To[0].Email, sdkMessage1.To["email2@email.com"].Email);
        }

        [TestMethod]
        public void ConvertSDKToAPI()
        {
            sdkMessage1 = CreateTypicalSDKMessage();
            apiMessage1 = new MessageConverter(sdkMessage1).ToAPIMessage();

            Assert.IsNotNull(apiMessage1);
            Assert.AreEqual(sdkMessage1.Content, apiMessage1.Content);
            Assert.AreEqual(sdkMessage1.Status.ToString(), apiMessage1.Status.ToString());
            Assert.AreEqual(sdkMessage1.Created, apiMessage1.Created);
            Assert.AreEqual(sdkMessage1.From.FirstName, apiMessage1.From.FirstName);
            Assert.AreEqual(sdkMessage1.From.LastName, apiMessage1.From.LastName);
            Assert.AreEqual(sdkMessage1.From.Id, apiMessage1.From.Id);
            Assert.AreEqual(sdkMessage1.From.Email, apiMessage1.From.Email);
            Assert.AreEqual(sdkMessage1.To["email2@email.com"].FirstName, apiMessage1.To[0].FirstName);
            Assert.AreEqual(sdkMessage1.To["email2@email.com"].LastName, apiMessage1.To[0].LastName);
            Assert.AreEqual(sdkMessage1.To["email2@email.com"].Email, apiMessage1.To[0].Email);
        }

        private Message CreateTypicalSDKMessage()
        {
            var fromSigner = SignerBuilder.NewSignerWithEmail("email@email.com")
                .WithFirstName("John")
                .WithLastName("Smith")
                .WithCustomId("user1")
                .Build();

            var sdkMessage = new Message(MessageStatus.NEW, "decline reason", fromSigner);

            sdkMessage.Created = DateTime.Now;

            IDictionary<string, Signer> toSigners = new Dictionary<string, Signer>();
            var toSigner = SignerBuilder.NewSignerWithEmail("email2@email.com")
                .WithFirstName("Patty")
                .WithLastName("Galant")
                .WithCustomId("user2")
                .Build();
            toSigners.Add(toSigner.Email, toSigner);
            sdkMessage.AddTo(toSigner);

            return sdkMessage;
        }

        private Silanis.ESL.API.Message CreateTypicalAPIMessage()
        {
            var apiMessage = new Silanis.ESL.API.Message();
            apiMessage.Content = "Opt-out reason";
            apiMessage.Status = MessageStatus.READ.getApiValue();
            apiMessage.Created = DateTime.Now;

            var fromUser = new User();
            fromUser.FirstName = "John";
            fromUser.LastName = "Smith";
            fromUser.Id = "user1";
            fromUser.Email = "email@email.com";
            apiMessage.From = fromUser;

            var toUser = new User();
            toUser.FirstName = "Patty";
            toUser.LastName = "Galant";
            toUser.Id = "user2";
            toUser.Email = "email2@email.com";
            apiMessage.AddTo(toUser);

            return apiMessage;
        }
    }
}

