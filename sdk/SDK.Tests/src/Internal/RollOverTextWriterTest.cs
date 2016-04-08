using Microsoft.VisualStudio.TestTools.UnitTesting;
using Silanis.ESL.SDK.Internal;
using System.Diagnostics;
using System.IO;

namespace SDK.Tests
{
    [TestClass]
    public class RollOverTextWriterTest
    {
        private static readonly ILogger log = LoggerFactory.get(typeof(RollOverTextWriterTest));

        [TestMethod]
        public void TestCase()
        {
            var writer = new RollOverTextWriter("esl-sdk-test.log");
            writer.MaxSize = 1000;

            Trace.Listeners.Clear();
            Trace.Listeners.Add(writer);

            for (var i = 0; i < 100; i++)
            {
                log.Warn("log test " + i);
            }

            var fCount = Directory.GetFiles(".", "esl-sdk-test_*.log", SearchOption.TopDirectoryOnly).Length;
            var array1 = Directory.GetFiles(".", "esl-sdk-test_*.log", SearchOption.TopDirectoryOnly);
            FileInfo logFile;

            foreach(var s in array1) 
            {
                logFile = new FileInfo(s);
                Assert.IsTrue(logFile.Length >= 1000);
                Assert.IsTrue(logFile.Length <= 1136);
            }
        }
    }
}