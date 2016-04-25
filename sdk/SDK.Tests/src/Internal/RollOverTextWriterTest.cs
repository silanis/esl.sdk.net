using NUnit.Framework;
using System;
using Silanis.ESL.SDK.Internal;
using System.Diagnostics;
using System.IO;

namespace SDK.Tests
{
    [TestFixture()]
    public class RollOverTextWriterTest
    {
        private static ILogger log = LoggerFactory.get(typeof(RollOverTextWriterTest));

        [Test()]
        public void TestCase()
        {
            RollOverTextWriter writer = new RollOverTextWriter("esl-sdk-test.log");
            writer.MaxSize = 1000;

            Trace.Listeners.Clear();
            Trace.Listeners.Add(writer);

            for (int i = 0; i < 100; i++)
            {
                log.Warn("log test " + i);
            }

            int fCount = Directory.GetFiles(".", "esl-sdk-test_*.log", SearchOption.TopDirectoryOnly).Length;
            string[] array1 = Directory.GetFiles(".", "esl-sdk-test_*.log", SearchOption.TopDirectoryOnly);
            FileInfo logFile;

            foreach(string s in array1) 
            {
                logFile = new FileInfo(s);
                Assert.GreaterOrEqual(logFile.Length, 1000);
                Assert.LessOrEqual(logFile.Length, 1136);
            }
        }
    }
}