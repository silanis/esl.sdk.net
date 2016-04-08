using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDK.Examples
{
    [TestClass]
    public class NotaryJournalExampleTest
    {
        [TestMethod]
        public void VerifyResult()
        {
            var example = new NotaryJournalExample();
            example.Run();

            Assert.IsNotNull(example.sdkJournalEntries);
            Assert.IsNotNull(example.csvJournalEntries.Filename);
            Assert.IsNotNull(example.csvJournalEntries.Contents);

            var reader = new CSVReader(new StreamReader(new MemoryStream(example.csvJournalEntries.Contents)));
            var rows = reader.readAll();

            if(example.sdkJournalEntries.Count > 0) {
                Assert.AreEqual(example.sdkJournalEntries.Count + 1, rows.Count);
            }

        }
    }
}

