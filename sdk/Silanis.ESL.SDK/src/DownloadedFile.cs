using System;

namespace Silanis.ESL.SDK
{
    public class DownloadedFile
    {
        private string filename;
        private byte[] contents;

        public DownloadedFile()
        {
        }

        public DownloadedFile(string filename, byte[] contents)
        {
            this.filename = filename;
            this.contents = contents;
        }

        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }

        public byte[] Contents
        {
            get
            {
                return contents;
            }
            set
            {
                contents = value;
            }
        }
    }
}

