using System;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class Message
    {
        private IDictionary<string, Signer> to = new Dictionary<string, Signer>();

        public Message(MessageStatus status, string content, Signer from)
        {
            Status = status;
            Content = content;
            From = from;
        }
            
        public string Content
        {
            get;
            set;
        }

        public Nullable<DateTime> Created
        {
            get;
            set;
        }

        public MessageStatus Status
        {
            get;
            set;
        }

        public Signer From
        {
            get;
            set;
        }

        public IDictionary<string, Signer> To
        {
            get
            {
                return to;
            }
        }

        public void AddTo(Signer value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Argument cannot be null");
            }

            to.Add(value.Email, value);
        }
    }
}
