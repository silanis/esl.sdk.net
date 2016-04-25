using System;
using System.Collections.Generic;
using System.Reflection;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
	public class FieldStyle : EslEnumeration
	{
        private static ILogger log = LoggerFactory.get(typeof(FieldStyle));

        public static FieldStyle BOUND_DATE = new FieldStyle("LABEL", "BOUND_DATE", 0);
        public static FieldStyle BOUND_NAME = new FieldStyle("LABEL", "BOUND_NAME", 1);
        public static FieldStyle BOUND_TITLE = new FieldStyle("LABEL", "BOUND_TITLE", 2);
        public static FieldStyle BOUND_COMPANY = new FieldStyle("LABEL","BOUND_COMPANY", 3);
        public static FieldStyle BOUND_QRCODE = new FieldStyle("QRCODE", "BOUND_QRCODE", 4);
        public static FieldStyle UNBOUND_TEXT_FIELD = new FieldStyle("TEXTFIELD", "UNBOUND_TEXT_FIELD", 5);
        public static FieldStyle UNBOUND_CUSTOM_FIELD = new FieldStyle("CUSTOMFIELD", "UNBOUND_CUSTOM_FIELD", 6);
        public static FieldStyle UNBOUND_CHECK_BOX = new FieldStyle("CHECKBOX", "UNBOUND_CHECK_BOX", 7);
        public static FieldStyle UNBOUND_RADIO_BUTTON = new FieldStyle("RADIO", "UNBOUND_RADIO_BUTTON", 8);
        public static FieldStyle LABEL = new FieldStyle("LABEL", "LABEL", 9);
        public static FieldStyle TEXT_AREA = new FieldStyle("TEXTAREA", "TEXT_AREA", 10);
        public static FieldStyle DROP_LIST = new FieldStyle("LIST", "DROP_LIST", 11);
        public static FieldStyle SEAL = new FieldStyle("SEAL", "SEAL", 12);
        private static Dictionary<string,FieldStyle> allFieldStyles = new Dictionary<string,FieldStyle>();

        static FieldStyle()
        {
            allFieldStyles.Add(BOUND_QRCODE.getApiValue(), FieldStyle.BOUND_QRCODE);
            allFieldStyles.Add(UNBOUND_TEXT_FIELD.getApiValue(), FieldStyle.UNBOUND_TEXT_FIELD);
            allFieldStyles.Add(UNBOUND_CUSTOM_FIELD.getApiValue(), FieldStyle.UNBOUND_CUSTOM_FIELD);
            allFieldStyles.Add(UNBOUND_CHECK_BOX.getApiValue(), FieldStyle.UNBOUND_CHECK_BOX);
            allFieldStyles.Add(UNBOUND_RADIO_BUTTON.getApiValue(), FieldStyle.UNBOUND_RADIO_BUTTON);
            allFieldStyles.Add(LABEL.getApiValue(), FieldStyle.LABEL);
            allFieldStyles.Add(TEXT_AREA.getApiValue(), FieldStyle.TEXT_AREA);
            allFieldStyles.Add(DROP_LIST.getApiValue(), FieldStyle.DROP_LIST);
            allFieldStyles.Add(SEAL.getApiValue(), FieldStyle.SEAL);
        }

        private FieldStyle(string apiValue, string sdkValue, int index):base(apiValue, sdkValue, index) 
        {           
        }
      
        internal static FieldStyle valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allFieldStyles.ContainsKey(apiValue))
            {
                return allFieldStyles[apiValue];
            }
            log.Warn("Unknown API FieldStyle {0}. The upgrade is required.", apiValue);
            return new FieldStyle(apiValue, "UNRECOGNIZED", allFieldStyles.Values.Count);
        }

        public static string[] GetNames()
        {
            string[] names = new string[allFieldStyles.Count];
            int i = 0;
            foreach(FieldStyle fieldStyle in allFieldStyles.Values)
            {
                names[i] = fieldStyle.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator FieldStyle(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static FieldStyle[] Values()
        {
            return (new List<FieldStyle>(allFieldStyles.Values)).ToArray();
        }

        public static FieldStyle parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(FieldStyle fieldStyle in allFieldStyles.Values){
                if (String.Equals(fieldStyle.GetName(), value))
                {
                    return fieldStyle;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the FieldStyle");
        }
	}
}