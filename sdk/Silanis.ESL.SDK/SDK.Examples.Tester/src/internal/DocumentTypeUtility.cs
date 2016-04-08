namespace Silanis.ESL.SDK
{
	internal class DocumentTypeUtility
	{
		public static string NormalizeName(DocumentType type, string name)
		{
			var normalized = name.Replace (' ', '_');

			if (!normalized.EndsWith (Extension(type)))
			{
				if (normalized.EndsWith("."))
				{
					normalized = normalized.Substring (0, normalized.Length - 1);
				}

				normalized += "." + Extension(type);
			}

			return normalized;
		}

		public static string Extension(DocumentType type)
		{
			switch (type)
			{
			case DocumentType.PDF:
				return "pdf";
			case DocumentType.WORD:
				return "docx";
			default:
				throw new EslException("Unknown DocumentType: " + type,null);
			}
		}
	}
}