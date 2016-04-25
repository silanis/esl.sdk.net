using System;
using System.Collections.Generic;
using System.Reflection;
using Silanis.ESL.SDK.Internal;

namespace Silanis.ESL.SDK
{
    public class RequirementStatus : EslEnumeration
	{
        private static ILogger log = LoggerFactory.get(typeof(AuthenticationMethod));

        public static RequirementStatus INCOMPLETE = new RequirementStatus("INCOMPLETE", "INCOMPLETE", 0);
        public static RequirementStatus REJECTED = new RequirementStatus("REJECTED", "REJECTED", 1);
        public static RequirementStatus COMPLETE = new RequirementStatus("COMPLETE", "COMPLETE", 2);
        private static Dictionary<string,RequirementStatus> allRequirementStatus = new Dictionary<string,RequirementStatus>();

        static RequirementStatus()
        {
            allRequirementStatus.Add(INCOMPLETE.getApiValue(), INCOMPLETE);
            allRequirementStatus.Add(REJECTED.getApiValue(), REJECTED);
            allRequirementStatus.Add(COMPLETE.getApiValue(), COMPLETE);
        }

        
        private RequirementStatus(string apiValue, string sdkValue, int index):base(apiValue,sdkValue,index) 
        {           
        }

        internal static RequirementStatus valueOf (string apiValue)
        {

            if (!String.IsNullOrEmpty(apiValue) && allRequirementStatus.ContainsKey(apiValue))
            {
                return allRequirementStatus[apiValue];
            }
            log.Warn("Unknown API RequirementStatus {0}. The upgrade is required.", apiValue);
            return new RequirementStatus(apiValue, "UNRECOGNIZED", allRequirementStatus.Values.Count);
        }

        public static string[] GetNames()
        {
            string[] names = new string[allRequirementStatus.Count];
            int i = 0;
            foreach(RequirementStatus requirementStatus in allRequirementStatus.Values)
            {
                names[i] = requirementStatus.GetName();
                i++;
            }
            return names;
        }

        public static explicit operator RequirementStatus(Enum enumType)
        {
            return parse(enumType.ToString());
        }

        public static RequirementStatus[] Values()
        {
            return (new List<RequirementStatus>(allRequirementStatus.Values)).ToArray();
        }

        public static RequirementStatus parse(string value)
        {

            if (null == value)
            {
                throw new ArgumentNullException("value is null");
            }

            if (value.Length == 0 || value.Trim().Length==0)
            {
                throw new ArgumentException("value is either an empty string or only contains white space");
            }
            foreach(RequirementStatus requirementStatus in allRequirementStatus.Values)
            {
                if (String.Equals(requirementStatus.GetName(), value))
                {
                    return requirementStatus;
                }
            }
            throw new ArgumentException("value is a name, but not one of the named constants defined for the RequirementStatus");
        }
	}
}

