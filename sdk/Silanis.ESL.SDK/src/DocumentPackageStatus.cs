using System;
using System.Collections.Generic;
using System.Reflection;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
	public class DocumentPackageStatus : EslEnumeration
	{
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static DocumentPackageStatus DRAFT = new DocumentPackageStatus("DRAFT", "DRAFT", 0);
        public static DocumentPackageStatus SENT = new DocumentPackageStatus("SENT", "SENT", 1);
        public static DocumentPackageStatus COMPLETED = new DocumentPackageStatus("COMPLETED", "COMPLETED", 2);
        public static DocumentPackageStatus ARCHIVED = new DocumentPackageStatus("ARCHIVED", "ARCHIVED", 3);
        public static DocumentPackageStatus DECLINED = new DocumentPackageStatus("DECLINED", "DECLINED", 4);
        public static DocumentPackageStatus OPTED_OUT = new DocumentPackageStatus("OPTED_OUT", "OPTED_OUT", 5);
        public static DocumentPackageStatus EXPIRED = new DocumentPackageStatus("EXPIRED", "EXPIRED", 6);
        private static Dictionary<string,DocumentPackageStatus> allDocumentPackageStatus = new Dictionary<string,DocumentPackageStatus>();

        static DocumentPackageStatus()
        {
            allDocumentPackageStatus.Add(DRAFT.getApiValue(), DocumentPackageStatus.DRAFT);
            allDocumentPackageStatus.Add(SENT.getApiValue(), DocumentPackageStatus.SENT);
            allDocumentPackageStatus.Add(COMPLETED.getApiValue(), DocumentPackageStatus.COMPLETED);
            allDocumentPackageStatus.Add(ARCHIVED.getApiValue(), DocumentPackageStatus.ARCHIVED);
            allDocumentPackageStatus.Add(DECLINED.getApiValue(), DocumentPackageStatus.DECLINED);
            allDocumentPackageStatus.Add(OPTED_OUT.getApiValue(), DocumentPackageStatus.OPTED_OUT);
            allDocumentPackageStatus.Add(EXPIRED.getApiValue(), DocumentPackageStatus.EXPIRED);
        }

        private DocumentPackageStatus(string apiValue, string sdkValue, int index):base(apiValue, sdkValue, index) 
        {           
        }

        internal static DocumentPackageStatus valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allDocumentPackageStatus.ContainsKey(apiValue))
            {
                return allDocumentPackageStatus[apiValue];
            }
            log.Warn("Unknown API DocumentPackageStatus {0}. The upgrade is required.", apiValue);
            return new DocumentPackageStatus(apiValue, "UNRECOGNIZED", allDocumentPackageStatus.Values.Count);
        }

        public static string[] GetNames()
        {
            string[] names = new string[allDocumentPackageStatus.Count];
            int i = 0;
            foreach(DocumentPackageStatus documentPackageStatus in allDocumentPackageStatus.Values)
            {
                names[i] = documentPackageStatus.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator DocumentPackageStatus(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static DocumentPackageStatus[] Values()
        {
            return (new List<DocumentPackageStatus>(allDocumentPackageStatus.Values)).ToArray();
        }

        public static DocumentPackageStatus parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(DocumentPackageStatus documentPackageStatus in allDocumentPackageStatus.Values)
            {
                if (String.Equals(documentPackageStatus.GetName(), value))
                {
                    return documentPackageStatus;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the DocumentPackageStatus");
        }

	}
}