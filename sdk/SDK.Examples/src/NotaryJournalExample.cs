using System.Collections.Generic;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    public class NotaryJournalExample : SdkSample
    {
        public List<NotaryJournalEntry> SdkJournalEntries;
        public DownloadedFile CsvJournalEntries;

        public static void Main(string[] args)
        {
            new NotaryJournalExample().Run();
        }

        override public void Execute()
        {
            SdkJournalEntries = eslClient.PackageService.GetJournalEntries(senderUID);
            CsvJournalEntries = eslClient.PackageService.GetJournalEntriesAsCSV(senderUID);
        }
    }
}

