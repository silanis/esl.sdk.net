using System;

namespace Silanis.ESL.SDK
{
    public class NotaryJournalEntryBuilder
    {
        private Nullable<Int32> sequenceNumber;
        private Nullable<DateTime> creationDate;
        private string documentType;
        private string documentName;
        private string signerName;
        private string signatureType;
        private string idType;
        private string idValue;
        private string jurisdiction;
        private string comment;

        private NotaryJournalEntryBuilder()
        {
        }

        public static NotaryJournalEntryBuilder NewNotaryJournalEntry() 
        {
            return new NotaryJournalEntryBuilder();
        }

        public NotaryJournalEntryBuilder WithSequenceNumber( Nullable<Int32> sequenceNumber ) 
        {
            this.sequenceNumber = sequenceNumber;
            return this;
        }

        public NotaryJournalEntryBuilder WithCreationDate( Nullable<DateTime> creationDate ) 
        {
            this.creationDate = creationDate;
            return this;
        }

        public NotaryJournalEntryBuilder WithDocumentType( string documentType ) 
        {
            this.documentType = documentType;
            return this;
        }

        public NotaryJournalEntryBuilder WithDocumentName( string documentName ) 
        {
            this.documentName = documentName;
            return this;
        }

        public NotaryJournalEntryBuilder WithSignerName( string signerName ) 
        {
            this.signerName = signerName;
            return this;
        }

        public NotaryJournalEntryBuilder WithSignatureType( string signatureType ) 
        {
            this.signatureType = signatureType;
            return this;
        }

        public NotaryJournalEntryBuilder WithIdType( string idType ) 
        {
            this.idType = idType;
            return this;
        }

        public NotaryJournalEntryBuilder WithIdValue( string idValue ) 
        {
            this.idValue = idValue;
            return this;
        }

        public NotaryJournalEntryBuilder WithJurisdiction( string jurisdiction ) 
        {
            this.jurisdiction = jurisdiction;
            return this;
        }

        public NotaryJournalEntryBuilder WithComment( string comment ) 
        {
            this.comment = comment;
            return this;
        }

        public Silanis.ESL.SDK.NotaryJournalEntry Build() 
        {
            var result = new Silanis.ESL.SDK.NotaryJournalEntry();
            result.SequenceNumber = sequenceNumber;
            result.CreationDate = creationDate;
            result.DocumentType = documentType;
            result.DocumentName = documentName;
            result.SignerName = signerName;
            result.SignatureType = signatureType;
            result.IdType = idType;
            result.IdValue = idValue;
            result.Jurisdiction = jurisdiction;
            result.Comment = comment;
            return result;
        }
    }
}

