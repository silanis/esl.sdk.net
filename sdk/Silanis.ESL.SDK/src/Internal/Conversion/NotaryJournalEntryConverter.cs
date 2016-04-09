namespace Silanis.ESL.SDK
{
    internal class NotaryJournalEntryConverter
    {
        private API.NotaryJournalEntry apiNotaryJournalEntry;
        private NotaryJournalEntry sdkNotaryJournalEntry;

        public NotaryJournalEntryConverter( NotaryJournalEntry sdkNotaryJournalEntry ) {
            this.sdkNotaryJournalEntry = sdkNotaryJournalEntry;
            apiNotaryJournalEntry = null;
        }

        public NotaryJournalEntryConverter( API.NotaryJournalEntry apiNotaryJournalEntry ) {
            this.apiNotaryJournalEntry = apiNotaryJournalEntry;
            sdkNotaryJournalEntry = null;
        }

        public API.NotaryJournalEntry ToAPINotaryJournalEntry()
        {
            if (sdkNotaryJournalEntry == null)
            {
                return apiNotaryJournalEntry;
            }
            var result = new API.NotaryJournalEntry();

            result.SequenceNumber = sdkNotaryJournalEntry.SequenceNumber;
            result.CreationDate = sdkNotaryJournalEntry.CreationDate;
            result.DocumentType = sdkNotaryJournalEntry.DocumentType;
            result.DocumentName = sdkNotaryJournalEntry.DocumentName;
            result.SignerName = sdkNotaryJournalEntry.SignerName;
            result.SignatureType = sdkNotaryJournalEntry.SignatureType;
            result.IdType = sdkNotaryJournalEntry.IdType;
            result.IdValue = sdkNotaryJournalEntry.IdValue;
            result.Jurisdiction = sdkNotaryJournalEntry.Jurisdiction;
            result.Comment = sdkNotaryJournalEntry.Comment;

            return result;
        }

        public NotaryJournalEntry ToSDKNotaryJournalEntry()
        {
            if (apiNotaryJournalEntry == null)
            {
                return sdkNotaryJournalEntry;
            }

            return NotaryJournalEntryBuilder.NewNotaryJournalEntry()
                .WithSequenceNumber( apiNotaryJournalEntry.SequenceNumber)
                    .WithCreationDate(apiNotaryJournalEntry.CreationDate)
                    .WithDocumentType(apiNotaryJournalEntry.DocumentType)
                    .WithDocumentName(apiNotaryJournalEntry.DocumentName)
                    .WithSignerName(apiNotaryJournalEntry.SignerName)
                    .WithSignatureType(apiNotaryJournalEntry.SignatureType)
                    .WithIdType(apiNotaryJournalEntry.IdType)
                    .WithIdValue(apiNotaryJournalEntry.IdValue)
                    .WithJurisdiction(apiNotaryJournalEntry.Jurisdiction)
                    .WithComment(apiNotaryJournalEntry.Comment)
                    .Build();
        }
    }
}

