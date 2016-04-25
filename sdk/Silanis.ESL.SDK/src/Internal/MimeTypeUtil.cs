using System;
using System.Collections.Generic;
using System.IO;

namespace Silanis.ESL.SDK.Internal
{
	/// <summary>
	/// For internal use.
	/// </summary>
	public class MimeTypeUtil
	{

		private static readonly Dictionary<string, string> FileExtensionMap = new Dictionary<string, string>();
		
        static MimeTypeUtil()
        {            
            // PDF
			FileExtensionMap["pdf"] = "application/pdf";

			// MS Office
			FileExtensionMap["doc"] = "application/msword";
			FileExtensionMap["dot"] = "application/msword";
			FileExtensionMap["docx"] = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
			FileExtensionMap["dotx"] = "application/vnd.openxmlformats-officedocument.wordprocessingml.template";
			FileExtensionMap["docm"] = "application/vnd.ms-word.document.macroEnabled.12";
			FileExtensionMap["dotm"] = "application/vnd.ms-word.template.macroEnabled.12";
			FileExtensionMap["xls"] = "application/vnd.ms-excel";
			FileExtensionMap["xlt"] = "application/vnd.ms-excel";
			FileExtensionMap["xla"] = "application/vnd.ms-excel";
			FileExtensionMap["xlsx"] = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
			FileExtensionMap["xltx"] = "application/vnd.openxmlformats-officedocument.spreadsheetml.template";
			FileExtensionMap["xlsm"] = "application/vnd.ms-excel.sheet.macroEnabled.12";
			FileExtensionMap["xltm"] = "application/vnd.ms-excel.template.macroEnabled.12";
			FileExtensionMap["xlam"] = "application/vnd.ms-excel.addin.macroEnabled.12";
			FileExtensionMap["xlsb"] = "application/vnd.ms-excel.sheet.binary.macroEnabled.12";
			FileExtensionMap["ppt"] = "application/vnd.ms-powerpoint";
			FileExtensionMap["pot"] = "application/vnd.ms-powerpoint";
			FileExtensionMap["pps"] = "application/vnd.ms-powerpoint";
			FileExtensionMap["ppa"] = "application/vnd.ms-powerpoint";
			FileExtensionMap["pptx"] = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
			FileExtensionMap["potx"] = "application/vnd.openxmlformats-officedocument.presentationml.template";
			FileExtensionMap["ppsx"] = "application/vnd.openxmlformats-officedocument.presentationml.slideshow";
			FileExtensionMap["ppam"] = "application/vnd.ms-powerpoint.addin.macroEnabled.12";
			FileExtensionMap["pptm"] = "application/vnd.ms-powerpoint.presentation.macroEnabled.12";
			FileExtensionMap["potm"] = "application/vnd.ms-powerpoint.presentation.macroEnabled.12";
			FileExtensionMap["ppsm"] = "application/vnd.ms-powerpoint.slideshow.macroEnabled.12";
			// Open Office
			FileExtensionMap["odt"] = "application/vnd.oasis.opendocument.text";
			FileExtensionMap["ott"] = "application/vnd.oasis.opendocument.text-template";
			FileExtensionMap["oth"] = "application/vnd.oasis.opendocument.text-web";
			FileExtensionMap["odm"] = "application/vnd.oasis.opendocument.text-master";
			FileExtensionMap["odg"] = "application/vnd.oasis.opendocument.graphics";
			FileExtensionMap["otg"] = "application/vnd.oasis.opendocument.graphics-template";
			FileExtensionMap["odp"] = "application/vnd.oasis.opendocument.presentation";
			FileExtensionMap["otp"] = "application/vnd.oasis.opendocument.presentation-template";
			FileExtensionMap["ods"] = "application/vnd.oasis.opendocument.spreadsheet";
			FileExtensionMap["ots"] = "application/vnd.oasis.opendocument.spreadsheet-template";
			FileExtensionMap["odc"] = "application/vnd.oasis.opendocument.chart";
			FileExtensionMap["odf"] = "application/vnd.oasis.opendocument.formula";
			FileExtensionMap["odb"] = "application/vnd.oasis.opendocument.database";
			FileExtensionMap["odi"] = "application/vnd.oasis.opendocument.image";
			FileExtensionMap["oxt"] = "application/vnd.openofficeorg.extension";
        }

		public static string GetMIMEType (string fileName)
		{
			if (FileExtensionMap.ContainsKey (Path.GetExtension (fileName).Remove (0, 1))) {
				return FileExtensionMap [Path.GetExtension (fileName).Remove (0, 1)];
			}
			return "unknown/unknown";
		}
	}
}