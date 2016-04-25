using System;
using System.Collections.Generic;
using System.Reflection;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class AuthenticationMethod : EslEnumeration
	{
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static AuthenticationMethod EMAIL = new AuthenticationMethod("NONE", "EMAIL", 0);
        public static AuthenticationMethod CHALLENGE = new AuthenticationMethod("CHALLENGE", "CHALLENGE", 1);
        public static AuthenticationMethod SMS = new AuthenticationMethod("SMS", "SMS", 2);
        public static AuthenticationMethod KBA = new AuthenticationMethod("KBA", "KBA", 3);
        private static Dictionary<string,AuthenticationMethod> allAuthenticationMethods = new Dictionary<string,AuthenticationMethod>();

        static AuthenticationMethod()
        {
            allAuthenticationMethods.Add(EMAIL.getApiValue(), AuthenticationMethod.EMAIL);
            allAuthenticationMethods.Add(CHALLENGE.getApiValue(), AuthenticationMethod.CHALLENGE);
            allAuthenticationMethods.Add(SMS.getApiValue(), AuthenticationMethod.SMS);
            allAuthenticationMethods.Add(KBA.getApiValue(), AuthenticationMethod.KBA);
        }

        private AuthenticationMethod(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static AuthenticationMethod valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allAuthenticationMethods.ContainsKey(apiValue))
            {
                return allAuthenticationMethods[apiValue];
            }
            log.Warn("Unknown API AuthenticationMethod {0}. The upgrade is required.", apiValue);
            return new AuthenticationMethod(apiValue, "UNRECOGNIZED", allAuthenticationMethods.Values.Count);
        }

        public static string[] GetNames()
        {
            string[] names = new string[allAuthenticationMethods.Count];
            int i = 0;
            foreach(AuthenticationMethod authenticationMethod in allAuthenticationMethods.Values)
            {
                names[i] = authenticationMethod.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator AuthenticationMethod(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static AuthenticationMethod[] Values()
        {
            return (new List<AuthenticationMethod>(allAuthenticationMethods.Values)).ToArray();
        }

        public static AuthenticationMethod parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(AuthenticationMethod authenticationMethod in allAuthenticationMethods.Values)
            {
                if (String.Equals(authenticationMethod.GetName(), value))
                {
                    return authenticationMethod;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the AuthenticationMethod");
        }
	}
}