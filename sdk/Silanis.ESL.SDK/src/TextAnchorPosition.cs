using System;
using System.Collections.Generic;
using System.Reflection;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class TextAnchorPosition : EslEnumeration
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static TextAnchorPosition TOPLEFT = new TextAnchorPosition("TOPLEFT", "TOPLEFT", 0);
        public static TextAnchorPosition TOPRIGHT = new TextAnchorPosition("TOPRIGHT", "TOPRIGHT", 1);
        public static TextAnchorPosition BOTTOMLEFT = new TextAnchorPosition("BOTTOMLEFT", "BOTTOMLEFT", 2);
        public static TextAnchorPosition BOTTOMRIGHT = new TextAnchorPosition("BOTTOMRIGHT", "BOTTOMRIGHT", 3);
        private static Dictionary<string,TextAnchorPosition> allTextAnchorPositions = new Dictionary<string,TextAnchorPosition>();

        static TextAnchorPosition()
        {
            allTextAnchorPositions.Add(TOPLEFT.getApiValue(), TextAnchorPosition.TOPLEFT);
            allTextAnchorPositions.Add(TOPRIGHT.getApiValue(), TextAnchorPosition.TOPRIGHT);
            allTextAnchorPositions.Add(BOTTOMLEFT.getApiValue(), TextAnchorPosition.BOTTOMLEFT);
            allTextAnchorPositions.Add(BOTTOMRIGHT.getApiValue(), TextAnchorPosition.BOTTOMRIGHT);
        }

        private TextAnchorPosition(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static TextAnchorPosition valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allTextAnchorPositions.ContainsKey(apiValue))
            {
                return allTextAnchorPositions[apiValue];
            }
            log.Warn("Unknown API TextAnchorPosition {0}. The upgrade is required.", apiValue);
            return new TextAnchorPosition(apiValue, "UNRECOGNIZED", allTextAnchorPositions.Values.Count);
        }

        public static string[] GetNames()
        {
            var names = new string[allTextAnchorPositions.Count];
            var i = 0;
            foreach(var authenticationMethod in allTextAnchorPositions.Values)
            {
                names[i] = authenticationMethod.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator TextAnchorPosition(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static TextAnchorPosition[] Values()
        {
            return (new List<TextAnchorPosition>(allTextAnchorPositions.Values)).ToArray();
        }

        public static TextAnchorPosition parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(var textAnchorPosition in allTextAnchorPositions.Values)
            {
                if (String.Equals(textAnchorPosition.GetName(), value))
                {
                    return textAnchorPosition;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the TextAnchorPosition");
        }
    }
}

