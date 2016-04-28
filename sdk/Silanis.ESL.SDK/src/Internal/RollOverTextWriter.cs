using System;
using System.Diagnostics;
using System.IO;

namespace Silanis.ESL.SDK.Internal
{
    internal class RollOverTextWriter : TextWriterTraceListener
    {
        DateTime _currentDate;
        private string _fileName;
        public long MaxSize { get; set; }
        private int suffix;

        public RollOverTextWriter(string file) : base(file)
        {
            _fileName = file;
            var baseStream = ((StreamWriter)Writer).BaseStream;
            MaxSize = 20971520;
        }

        public override void Write(string message)
        {
            checkRollover();
            base.Write(message);
        }

        public override void WriteLine(string message)
        {
            checkRollover();
            base.WriteLine(message);
        }

        private string generateFilename()
        {
            _currentDate = DateTime.UtcNow;
            suffix = suffix + 1;
            if (suffix == 100)
                suffix = 0;
            return Path.Combine(Path.GetDirectoryName(_fileName),
                                Path.GetFileNameWithoutExtension(_fileName) + "_" +
                                _currentDate.ToString("yyyyMMddhhmmssfff") + "_" +
                                suffix + 
                                Path.GetExtension(_fileName));
        }

        private void checkRollover()
        {
            var baseStream = ((StreamWriter)Writer).BaseStream;
            if (string.IsNullOrEmpty(_fileName))
            {
                _fileName = ((FileStream)baseStream).Name;
            }
            // If the date has changed, close the current stream and create a new file for today’s date
            if (baseStream.Length > MaxSize)
            {
                Writer.Close();
                CopyStream(File.OpenRead(_fileName), File.OpenWrite(generateFilename()));
                File.WriteAllText(_fileName, string.Empty);
                Writer = new StreamWriter(_fileName, true);
            }
        }

        private void CopyStream(Stream src, Stream dest)
        {
            var buffer = new byte[4096];
            int len;
            while ((len = src.Read(buffer, 0, buffer.Length)) > 0)
            {
                dest.Write(buffer, 0, len);
            }
            src.Close();
            dest.Close();
        }
    }
}
