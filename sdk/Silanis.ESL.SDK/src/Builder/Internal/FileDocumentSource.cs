using System;
using System.IO;

namespace Silanis.ESL.SDK.Builder.Internal
{
	public class FileDocumentSource : DocumentSource
	{
		private readonly FileInfo file;

		public FileDocumentSource (string fileName) : this(new FileInfo(fileName))
		{
		}

		public FileDocumentSource (FileInfo file)
		{
			if (file == null)
			{
				throw new ArgumentNullException ("file argument cannot be null");
			}

			if (!file.Exists)
			{
				throw new EslException (String.Format ("file {0} does not exists", file.FullName),null);
			}

			this.file = file;
		}

		public byte[] Content ()
		{
			return File.ReadAllBytes(file.FullName);
		}
	}
}