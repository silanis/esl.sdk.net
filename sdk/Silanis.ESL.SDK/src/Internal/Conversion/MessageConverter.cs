using Silanis.ESL.API;
using Silanis.ESL.SDK.Builder;

namespace Silanis.ESL.SDK
{
    internal class MessageConverter
    {
        private Message sdkMessage = null;
        private API.Message apiMessage = null;

        public MessageConverter(Message sdkMessage)
        {
            this.sdkMessage = sdkMessage;
        }

        public MessageConverter(API.Message apiMessage)
        {
            this.apiMessage = apiMessage;
        }

        public API.Message ToAPIMessage()
        {
            if (sdkMessage == null)
            {
                return apiMessage;
            }

            var result = new API.Message();

            if (sdkMessage.Content != null)
            {
                result.Content = sdkMessage.Content;
            }

            if (sdkMessage.From != null)
            {
                var fromSigner = sdkMessage.From;
                var fromUser = new User();
                fromUser.Email = fromSigner.Email;
                fromUser.FirstName = fromSigner.FirstName;
                fromUser.LastName = fromSigner.LastName;
                fromUser.Id = fromSigner.Id;
                fromUser.Company = fromSigner.Company;
                fromUser.Title = fromSigner.Title;

                result.From = fromUser;
            }

            if (sdkMessage.To != null && sdkMessage.To.Count != 0)
            {
                foreach (var toSigner in sdkMessage.To.Values)
                {
                    var toUser = new User();
                    toUser.Email = toSigner.Email;
                    toUser.FirstName = toSigner.FirstName;
                    toUser.LastName = toSigner.LastName;
                    toUser.Company = toSigner.Company;
                    toUser.Title = toSigner.Title;

                    result.AddTo(toUser);
                }
            }

            if (sdkMessage.Created != null)
            {
                result.Created = sdkMessage.Created;
            }


            result.Status = new MessageStatusConverter(sdkMessage.Status).ToAPIMessageStatus();

            return result;
        }

        public Message ToSDKMessage()
        {
            if (apiMessage == null)
            {
                return sdkMessage;
            }

            var fromUser = apiMessage.From;
            var fromSigner = SignerBuilder.NewSignerWithEmail(fromUser.Email)
                .WithCompany(fromUser.Company)
                .WithFirstName(fromUser.FirstName)
                .WithLastName(fromUser.LastName)
                .WithCustomId(fromUser.Id)
                .WithTitle(fromUser.Title)
                .Build();

            var result = new Message(new MessageStatusConverter(apiMessage.Status).ToSDKMessageStatus(), apiMessage.Content, fromSigner);

            if (apiMessage.To != null && apiMessage.To.Count != 0)
            {
                foreach (var toUser in apiMessage.To)
                {
                    var to = SignerBuilder.NewSignerWithEmail(toUser.Email)
                        .WithCompany(toUser.Company)
                        .WithFirstName(toUser.FirstName)
                        .WithLastName(toUser.LastName)
                        .WithCustomId(toUser.Id)
                        .WithTitle(toUser.Title)
                        .Build();

                    result.AddTo(to);
                }
            }

            if (apiMessage.Created != null)
            {
                result.Created = apiMessage.Created;
            }

            return result;
        }
    }
}

