using System;
using System.Collections.Generic;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Internal;

namespace SDK.Examples
{
    public class NotaryJournalExample : SDKSample
    {
        public List<NotaryJournalEntry> sdkJournalEntries;
        public DownloadedFile csvJournalEntries;

        public static void Main(string[] args)
        {
            new NotaryJournalExample().Run();
        }

        override public void Execute()
        {
            sdkJournalEntries = eslClient.PackageService.GetJournalEntries(senderUID);
            csvJournalEntries = eslClient.PackageService.GetJournalEntriesAsCSV(senderUID);
        }
    }
}

