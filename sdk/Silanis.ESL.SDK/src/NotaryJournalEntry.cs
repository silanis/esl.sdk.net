using System;

namespace Silanis.ESL.SDK
{
    public class NotaryJournalEntry
    {

        public NotaryJournalEntry()
        {
        }

        public Nullable<Int32> SequenceNumber
        {
            get;
            set;
        }

        public Nullable<DateTime> CreationDate
        {
            get;
            set;
        }

        public string DocumentType
        {
            get;
            set;
        }

        public string DocumentName
        {
            get;
            set;
        }

        public string SignerName
        {
            get;
            set;
        }

        public string SignatureType
        {
            get;
            set;
        }

        public string IdType
        {
            get;
            set;
        }

        public string IdValue
        {
            get;
            set;
        }

        public string Jurisdiction
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }
    }
}

