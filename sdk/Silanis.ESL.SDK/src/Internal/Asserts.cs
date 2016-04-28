using System;

namespace Silanis.ESL.SDK.Internal
{
	public class Asserts
	{
		private Asserts () {}

		public static void NotEmptyOrNull(String assertedValue, String argumentName)
		{
			if (assertedValue == null || assertedValue.Trim ().Length == 0) 
			{
				throw new EslException (String.Format ("{0} cannot be null or an empty string", argumentName),null);
			}
		}

		public static void NonZero(double assertedValue, String fieldName) {
			if (assertedValue == 0) {
				throw new EslException(String.Format("{0} cannot be 0", fieldName),null);
			}
		}
	}
}