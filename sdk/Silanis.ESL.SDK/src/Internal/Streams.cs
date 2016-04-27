using System.IO;

namespace Silanis.ESL.SDK.Internal
{
	public class Streams
	{
		private Streams () {}

		public static byte[] ToByteArray(Stream input)
		{
			byte[] result;

			using (input)
			{
				var length = input.Length;
				if (length > 2147483647L)
				{
					throw new IOException ("Reading more than 2GB with this call is not supported");
				}

				var num = 0;
				var i = (int)length;
				var array = new byte[length];

				while (i > 0)
				{
					var num2 = input.Read (array, num, i);
					if (num2 == 0)
					{
						throw new IOException ("Unexpected end of stream");
					}
					num += num2;
					i -= num2;
				}

				result = array;
			}

			return result;
		}
	}
}