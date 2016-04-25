using System;
using System.Text;

namespace Silanis.ESL.SDK.Internal
{
	/// <summary>
	/// A helper class to convert from string to byte array and vice verse.
	/// </summary>
	public class Converter
	{
		/// <summary>
		/// Convert string to byte array.
		/// </summary>
		/// <returns>The byte array.</returns>
		/// <param name="str">String.</param>
		public static byte[] ToBytes (string str)
		{
			System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding ();
			return encoding.GetBytes (str);
		}

		/// <summary>
		/// Convert byte array to string.
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="bytes">Byte array.</param>
		public static string ToString (byte[] bytes)
		{
			if (bytes != null && bytes.Length > 0)
			{
				System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
				string result = enc.GetString(bytes);
				return result;
			}
			else
			{
				return "";
			}
		}

        public static string ToString (DownloadedFile downloadedFile)
        {
            byte[] bytes = downloadedFile.Contents;
            if (bytes != null && bytes.Length > 0)
            {
                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                string result = enc.GetString(bytes);
                return result;
            }
            else
            {
                return "";
            }
        }

		public static string apiKeyToUID (string apiKey)
		{
			string decodedString = Encoding.UTF8.GetString(Convert.FromBase64String(apiKey));
			char[] deliminator = { ':' };
			return decodedString.Split(deliminator)[0];
		}
	}
}

