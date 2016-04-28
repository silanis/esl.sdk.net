using System;

namespace Silanis.ESL.SDK
{
    public class DateHelper
    {

		public static string dateToIsoUtcFormat(DateTime date)
        {
//			string result = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
//			Console.WriteLine("1 : " + result);
			var result = date.ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
			Console.WriteLine("2 : " + result);
			return result;
        }
    }
}

