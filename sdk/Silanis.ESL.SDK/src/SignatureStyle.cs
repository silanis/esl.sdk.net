using System;
using System.Collections.Generic;
using System.Reflection;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class SignatureStyle : EslEnumeration
	{
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static SignatureStyle HAND_DRAWN = new SignatureStyle("CAPTURE", "HAND_DRAWN", 0);
        public static SignatureStyle FULL_NAME = new SignatureStyle("FULLNAME", "FULL_NAME", 1);
        public static SignatureStyle INITIALS = new SignatureStyle("INITIALS", "INITIALS", 2);
        public static SignatureStyle ACCEPTANCE = new SignatureStyle("FULLNAME", "ACCEPTANCE", 3);
        public static SignatureStyle MOBILE_CAPTURE = new SignatureStyle("MOBILE_CAPTURE", "MOBILE_CAPTURE", 4);
        private static Dictionary<string,SignatureStyle> allSignatureStyles = new Dictionary<string,SignatureStyle>();

        static SignatureStyle()
        {
            allSignatureStyles.Add(HAND_DRAWN.getApiValue(), SignatureStyle.HAND_DRAWN);
            allSignatureStyles.Add(FULL_NAME.getApiValue(), SignatureStyle.FULL_NAME);
            allSignatureStyles.Add(INITIALS.getApiValue(), SignatureStyle.INITIALS);
            allSignatureStyles.Add(MOBILE_CAPTURE.getApiValue(), SignatureStyle.MOBILE_CAPTURE);
        }

        
        private SignatureStyle(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static SignatureStyle valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allSignatureStyles.ContainsKey(apiValue))
            {
                return allSignatureStyles[apiValue];
            }
            log.Warn("Unknown API SignatureStyle {0}. The upgrade is required.", apiValue);
            return new SignatureStyle(apiValue, "UNRECOGNIZED", allSignatureStyles.Values.Count);
        }

        public static string[] GetNames()
        {
            var names = new string[allSignatureStyles.Count];
            var i = 0;
            foreach(var signatureStyle in allSignatureStyles.Values)
            {
                names[i] = signatureStyle.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator SignatureStyle(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static SignatureStyle[] Values()
        {
            return (new List<SignatureStyle>(allSignatureStyles.Values)).ToArray();
        }

        public static SignatureStyle parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(var signatureStyle in allSignatureStyles.Values)
            {
                if (String.Equals(signatureStyle.GetName(), value))
                {
                    return signatureStyle;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the SignatureStyle");
        }
	}
}