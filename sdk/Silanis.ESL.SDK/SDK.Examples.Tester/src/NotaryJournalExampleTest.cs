using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Examples.Internal;

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

            Assert.IsNotNull(example.SdkJournalEntries);
            Assert.IsNotNull(example.CsvJournalEntries.Filename);
            Assert.IsNotNull(example.CsvJournalEntries.Contents);

            var reader = new CsvReader(new StreamReader(new MemoryStream(example.CsvJournalEntries.Contents)));
            var rows = reader.ReadAll();

            if(example.SdkJournalEntries.Count > 0) {
                Assert.AreEqual(example.SdkJournalEntries.Count + 1, rows.Count);
            }

        }
    }
}

