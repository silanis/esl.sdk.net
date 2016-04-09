using System;
using Newtonsoft.Json;

namespace Silanis.ESL.API
{
    internal class NotaryJournalEntry
    {
        // Fields
        // Accessors
        [JsonProperty("sequenceNumber")]
        public Nullable<Int32> SequenceNumber
        {
            get;
            set;
        }

        [JsonProperty("creationDate")]
        public Nullable<DateTime> CreationDate
        {
            get;
            set;
        }

        [JsonProperty("documentType")]
        public String DocumentType
        {
            get;
            set;
        }

        [JsonProperty("documentName")]
        public String DocumentName
        {
            get;
            set;
        }

        [JsonProperty("signerName")]
        public String SignerName
        {
            get;
            set;
        }

        [JsonProperty("signatureType")]
        public String SignatureType
        {
            get;
            set;
        }

        [JsonProperty("idType")]
        public String IdType
        {
            get;
            set;
        }
        [JsonProperty("idValue")]
        public String IdValue
        {
            get;
            set;
        }

        [JsonProperty("jurisdiction")]
        public String Jurisdiction
        {
            get;
            set;
        }

        [JsonProperty("comment")]
        public String Comment
        {
            get;
            set;
        }
    }
}

