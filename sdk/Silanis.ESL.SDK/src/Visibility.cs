using System;
using Silanis.ESL.SDK.Internal;
using System.Reflection;
using System.Collections.Generic;

namespace Silanis.ESL.SDK
{
    public class Visibility : EslEnumeration
    {
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static Visibility ACCOUNT = new Visibility("ACCOUNT", "ACCOUNT", 0);
        public static Visibility SENDER = new Visibility("SENDER", "SENDER", 1);
        private static Dictionary<string,Visibility> allVisibilities = new Dictionary<string,Visibility>();

        static Visibility()
        {
            allVisibilities.Add(ACCOUNT.getApiValue(), Visibility.ACCOUNT);
            allVisibilities.Add(SENDER.getApiValue(), Visibility.SENDER);
        }

        private Visibility(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static Visibility valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allVisibilities.ContainsKey(apiValue))
            {
                return allVisibilities[apiValue];
            }
            log.Warn("Unknown API Visibility {0}. The upgrade is required.", apiValue);
            return new Visibility(apiValue, "UNRECOGNIZED", allVisibilities.Values.Count);
        }

        public static string[] GetNames()
        {
            var names = new string[allVisibilities.Count];
            var i = 0;
            foreach(var visibility in allVisibilities.Values)
            {
                names[i] = visibility.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator Visibility(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static Visibility[] Values()
        {
            return (new List<Visibility>(allVisibilities.Values)).ToArray();
        }

        public static Visibility parse(string value)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(var visibility in allVisibilities.Values)
            {
                if (String.Equals(visibility.GetName(), value))
                {
                    return visibility;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the Visibility");
        }
    }
}

