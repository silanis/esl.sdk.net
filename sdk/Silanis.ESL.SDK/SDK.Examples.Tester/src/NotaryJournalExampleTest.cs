using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace SDK.Examples
{
    [TestFixture()]
    public class NotaryJournalExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            NotaryJournalExample example = new NotaryJournalExample();
            example.Run();

            Assert.IsNotNull(example.sdkJournalEntries);
            Assert.IsNotNull(example.csvJournalEntries.Filename);
            Assert.IsNotNull(example.csvJournalEntries.Contents);

            CSVReader reader = new CSVReader(new StreamReader(new MemoryStream(example.csvJournalEntries.Contents)));
            IList<string[]> rows = reader.readAll();

            if(example.sdkJournalEntries.Count > 0) {
                Assert.AreEqual(example.sdkJournalEntries.Count + 1, rows.Count);
            }

        }
    }
}

