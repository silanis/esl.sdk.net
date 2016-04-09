using System.IO;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK.Builder.Internal
{
	public class StreamDocumentSource : DocumentSource
	{
		private readonly Stream input;

		public StreamDocumentSource (Stream input)
		{
			this.input = input;
		}

		public byte[] Content()
		{
			return Streams.ToByteArray (input);
		}
	}
}